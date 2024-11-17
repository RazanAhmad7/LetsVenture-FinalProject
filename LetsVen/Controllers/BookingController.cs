using LetsVen.Data;
using LetsVen.Models;
using LetsVen.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LetsVen.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public BookingController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task <IActionResult> Index(int id)
        {
            var adventure =  _context.Adventures.FirstOrDefault(x => x.Id == id);
            var currentUser = await _userManager.GetUserAsync(User);

            var bookingModel = new BookingModel
            {
                adventure = adventure,
                user = currentUser
            };
            return View(bookingModel);
        }

        public async Task<IActionResult> checkout(BookingModel bookingModel)
        {
            return View(bookingModel);
        }
    }
}
