using LetsVen.Data;
using LetsVen.Models;
using LetsVen.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;
using System.Diagnostics;

namespace LetsVen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            DateTime currentDate = DateTime.Now;
            DateTime nextWeekDate = currentDate.AddDays(7);
            var upcomingAdventures = await _context.Adventures
                .Include(a => a.Images)
                .Where(a => a.StartDate >= currentDate && a.StartDate <= nextWeekDate)
            .ToListAsync();

            // _context.Roles: Retrieves the role with the name "group" to get its Id.
            var groupRole = await _context.Roles
                .Where(r => r.Name=="group")
                .Select(r => r.Id)
                .FirstOrDefaultAsync();
            // _context.UserRoles: Used to check if a user is assigned the "group" role by matching UserId and RoleId.
            // _context.Users: Filters users based on the UserId that matches the role's Id in the UserRoles table.
            var groups = await _context.Users
                .Where(u => _context.UserRoles.Any(ur=> ur.UserId == u.Id && ur.RoleId == groupRole))
                .ToListAsync();

            var AdventuresAndGroups = new upComingAdvGroupsModel
            {
                UpComingAdventures = upcomingAdventures,
                Groups = groups
            };
            return View(AdventuresAndGroups);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AboutUs() 
        {
            return View();
        }
    }
}
