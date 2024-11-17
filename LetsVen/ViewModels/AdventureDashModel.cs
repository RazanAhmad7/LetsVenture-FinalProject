using LetsVen.Models;

namespace LetsVen.ViewModels
{
    public class AdventureDashModel
    {
        public List<Adventure> Adventures { get; set; }
        public Adventure oneAdventure { get; set; }
        public AppUser groupUser { get; set; }
        public List<IFormFile> UploadedImages { get; set; }  // Make sure this is a List<IFormFile>

    }
}
