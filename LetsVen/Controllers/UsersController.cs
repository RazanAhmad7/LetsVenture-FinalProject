using LetsVen.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LetsVen.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GroupProfile(string id)
        {
            var oneGroup = _context.Users
                .Include(a => a.Adventures)
                .FirstOrDefault(a => a.Id == id);
            return View(oneGroup);
        }
    }
}
