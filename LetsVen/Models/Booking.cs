using System.ComponentModel.DataAnnotations.Schema;

namespace LetsVen.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        public int AdventureId { get; set; }

        [ForeignKey("AdventureId")]
        public Adventure Adventure { get; set; }
    }
}
