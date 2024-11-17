
using System.ComponentModel.DataAnnotations.Schema;

namespace LetsVen.Models
{
    public class Adventure
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public int MaxNumOfPeople { get; set; }
        public string FoodAvailability { get; set; }
        public string DifficultyLevel { get; set; }
        public double TempretrueDegree { get; set; }
        public string MainImagePath { get; set; }


        // Relationships ::


        // with AdventureImage model
        public List<AdventureImages> ?Images { get; set; }

        // with AppUser (Group) model
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser GroupUser { get; set; }





    }
}
