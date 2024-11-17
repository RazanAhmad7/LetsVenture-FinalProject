using LetsVen.Data;
using LetsVen.Models;
using LetsVen.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LetsVen.Controllers
{
    public class AdventuresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public AdventuresController(ApplicationDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Adventures
        public async Task<IActionResult> Index()
        {
            var myAdventures= _context.Adventures.Include(a => a.GroupUser);
            return View(await myAdventures.ToListAsync());
        }

        // GET: Adventures/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var oneAdventure = await _context.Adventures
                .Include(a => a.GroupUser)
                .Include(a => a.Images)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (oneAdventure == null)
            {
                return NotFound();
            }
            var DetailsAdventures = new DetailsAdventuresModel
            {
                adventure = oneAdventure,
                adventures = await _context.Adventures
                .Where(a => a.Id != oneAdventure.Id)
                .Take(4).ToListAsync()
            };
            return View(DetailsAdventures);
        }

        // GET: Adventures/Create
        public async Task<IActionResult> Create()
        {
            var existingUser = await _userManager.GetUserAsync(User);
            var model = new AdventureDashModel
            {
                groupUser = existingUser,
                oneAdventure = new Adventure(),
                
            };

            return View(model);
        }


        // POST: Adventures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
  
        public async Task<IActionResult> Create(AdventureDashModel model)
        {
                var existingUser = await _userManager.GetUserAsync(User);

                // Create a new Adventure entity and map properties from the ViewModel
                var adventure = new Adventure
                {
                    UserId = existingUser.Id,
                    GroupUser = existingUser,
                    Title = model.oneAdventure.Title,
                    Description = model.oneAdventure.Description,
                    StartDate = model.oneAdventure.StartDate,
                    EndDate = model.oneAdventure.EndDate,
                    StartTime = model.oneAdventure.StartTime,
                    EndTime = model.oneAdventure.EndTime,
                    Price = model.oneAdventure.Price,
                    City = model.oneAdventure.City,
                    Location = model.oneAdventure.Location,
                    Status = model.oneAdventure.Status,
                    MaxNumOfPeople = model.oneAdventure.MaxNumOfPeople,
                    FoodAvailability = model.oneAdventure.FoodAvailability,
                    DifficultyLevel = model.oneAdventure.DifficultyLevel,
                    TempretrueDegree = model.oneAdventure.TempretrueDegree,
                    MainImagePath = "assets/petra.jpeg"
                };

                // Save the adventure to the database to generate the AdventureId
                _context.Adventures.Add(adventure);
                _context.SaveChanges();

                var imageList = new List<AdventureImages>();
                string uniqueFileName = null;
                // Process each uploaded image
                foreach (var file in model.UploadedImages)
                {
                    if (file != null)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/adventures");
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
                    // Create a new AdventureImages entry
                    var adventureImage = new AdventureImages
                    {
                        Path = "/images/adventures/" + uniqueFileName,
                        AdventureId = adventure.Id // Associate with the created Adventure
                    };

                    // Add the image entry to the list
                    imageList.Add(adventureImage);
                }

                // Save all image entries to the database
                _context.Images.AddRange(imageList);
                _context.SaveChanges();

                return RedirectToAction("Index");
          
        }


        //// GET: Adventures/Edit/5
        //public IActionResult Edit(int adventureId)
        //{
        //    var adventure = _context.Adventures.FirstOrDefault(a => a.Id == adventureId);
        //    if (adventure == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(adventure);
        //}


        // POST: Adventures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdventureDashModel updatedAdventure)
        {
                    var existingAdventure = _context.Adventures.Find(updatedAdventure.oneAdventure.Id);
                    if (existingAdventure != null)
                    {
                        existingAdventure.Title = updatedAdventure.oneAdventure.Title;
                        existingAdventure.Description = updatedAdventure.oneAdventure.Description;
                        existingAdventure.StartDate = updatedAdventure.oneAdventure.StartDate;
                        existingAdventure.EndDate = updatedAdventure.oneAdventure.EndDate;
                        existingAdventure.Price = updatedAdventure.oneAdventure.Price;
                        existingAdventure.City = updatedAdventure.oneAdventure.City;
                        existingAdventure.Location = updatedAdventure.oneAdventure.Location;
                        existingAdventure.Status = updatedAdventure.oneAdventure.Status;
                existingAdventure.FoodAvailability = updatedAdventure.oneAdventure.FoodAvailability;

                        _context.SaveChanges();
                        return RedirectToAction("Index","Dash");
                    }
                    return NotFound();
                }

          

        

        //// GET: Adventures/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var adventure = await _context.Adventures
        //   //     .Include(a => a.Group)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (adventure == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(adventure);
        //}

        //// POST: Adventures/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var adventure = await _context.Adventures.FindAsync(id);
        //    if (adventure != null)
        //    {
        //        _context.Adventures.Remove(adventure);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}



        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var adventure = await _context.Adventures.FindAsync(id);

        //        if (adventure == null)
        //        {
        //            return Json(new { success = false, message = "User not found." });
        //        }

        //        _context.Adventures.Remove(adventure);
        //        await _context.SaveChangesAsync();

        //        return Json(new { success = true, advId = id });
            
           
        //}






        private bool AdventureExists(int id)
        {
            return _context.Adventures.Any(e => e.Id == id);
        }
    }
}
