using LetsVen.Data;
using LetsVen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LetsVen.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<AppUser> userManager, ApplicationDbContext context, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            this.roleManager = roleManager;
        }
    
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(AppUser model)
        {
            // List to store error messages
            //List<string> errorMessages = new List<string>();

            // Check if the email already exists
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "This email is already associated with an existing user.");
               
                return View(model);
            }

            // Validate Name
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                ModelState.AddModelError("Name","Name is required.");
            }
            else if (model.Name.Length < 3 || model.Name.Length > 50)
            {
                ModelState.AddModelError("Name", "Name must be between 3 and 50 characters.");
            }

            // Validate Email
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                ModelState.AddModelError("Email", "Email is required.");
            }
            else if (!IsValidEmail(model.Email))
            {
                 ModelState.AddModelError("Email", "Please enter a valid email address.");
            }

            // Validate Password
            if (string.IsNullOrWhiteSpace(model.PasswordHash))
            {
                ModelState.AddModelError("PasswordHash", "Password is required.");
            }
            else if (model.PasswordHash.Length < 6)
            {
                ModelState.AddModelError("PasswordHash", "Password must be at least 6 characters long.");
            }
            else if (!HasRequiredPasswordStrength(model.PasswordHash))
            {
                ModelState.AddModelError("PasswordHash", "Password must include at least one uppercase letter, one digit, and one special character.");
            }

            // If any custom validation errors exist, return the view with errors
            if (!ModelState.IsValid)
            {
                return View();
            }

          
                AppUser user = new AppUser
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PasswordHash = model.PasswordHash,
                    JoiningDate = DateTime.Now,
                  
                };


                var result = await _userManager.CreateAsync(user, model.PasswordHash);
                if (await roleManager.RoleExistsAsync("User"))
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                //else
                //{
                //    // Add each error to the errorMessages list
                //    foreach (var error in result.Errors)
                //    {
                //        errorMessages.Add(error.Description);
                //    }
                //}
            

            // Return the model to the view to show validation errors
            return View(model);
        }

        // Helper method to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Helper method to validate password strength
        private bool HasRequiredPasswordStrength(string password)
        {
            return password.Any(char.IsUpper) // At least one uppercase letter
                && password.Any(char.IsDigit) // At least one digit
                && password.Any(c => !char.IsLetterOrDigit(c)); // At least one special character
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Email, string PasswordHash, bool rememberme = false)
        {
            
            // Validate Email
            if (string.IsNullOrWhiteSpace(Email))
            {
                ModelState.AddModelError("Email", "Email is required.");
            }
            else if (!IsValidEmail(Email))
            {
                ModelState.AddModelError("Email", "Please enter a valid email address.");
            }

            // Validate Password
            if (string.IsNullOrWhiteSpace(PasswordHash))
            {
                ModelState.AddModelError("PasswordHash", "Password is required.");
            }

            // If there are validation errors, return the view with the errors
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Find the user by email
            var user = await _userManager.FindByEmailAsync(Email);
            if (user != null)
            {
                // Check the password and attempt to sign in
                var result = await _signInManager.PasswordSignInAsync(user, PasswordHash, rememberme, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Get the user's roles
                    var roles = await _userManager.GetRolesAsync(user);

                    // Redirect based on the user's role
                    if (roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Privacy", "Home");
                    }
                    else if (roles.Contains("group"))
                    {
                        return RedirectToAction("Index", "Dash");
                    }

                }
                else if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "This account is locked out due to multiple failed login attempts.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt. Please check your credentials.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "No account found with the provided email.");
            }

            // If we reach this point, something failed; re-display the login form with error messages
            return View();
        }

        public async Task<IActionResult> Logout(string logoutId)
        {
            var currentUser = _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                await _signInManager.SignOutAsync();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Privacy", "Home");
            }
        }
       
    }
}
