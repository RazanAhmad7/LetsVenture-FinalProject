using LetsVen.Data;
using LetsVen.Models;
using LetsVen.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LetsVen.Controllers
{
    public class DashController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public DashController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var existingUser = await _userManager.GetUserAsync(User);
            if(existingUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var adventures = await _context.Adventures.Include(a => a.GroupUser).ToListAsync();
            var adventuresDashModel = new AdventureDashModel
            {
                Adventures = adventures,
                groupUser = existingUser
                
            };
            return View(adventuresDashModel);
        }


        public async Task<IActionResult> AddAdventure()
        {
            var existingUser = await _userManager.GetUserAsync(User);
            var adventuresDashModel = new AdventureDashModel
            {
                groupUser = existingUser

            };
            return View(adventuresDashModel);
        }

        public async Task<IActionResult> EditAdventure(int adventureId)
        {
            var adventure = _context.Adventures.FirstOrDefault(a => a.Id == adventureId);
            string stringID = adventure.UserId;
            var group = _context.Users.FirstOrDefault(a => a.Id == stringID);
            var adventuresDashModel = new AdventureDashModel
            {
                Adventures = new List<Adventure>(),// Ensure this returns a list or an empty list if no data
                oneAdventure = adventure,// Ensure this is not null, or handle it appropriately
                groupUser = group, // Make sure this is not null
                UploadedImages = new List<IFormFile>() // Initialize with an empty list if needed
            };
            return View(adventuresDashModel);
        }

    }
}
