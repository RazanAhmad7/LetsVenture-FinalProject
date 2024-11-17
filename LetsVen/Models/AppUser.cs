
using Microsoft.AspNetCore.Identity;

namespace LetsVen.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
   
        public DateTime JoiningDate { get; set; }

        // not shared properites
        public string? Bio { get; set; }
        public string? ShortDescription { get; set; }
        public string? ProfilePicUrl { get; set; }


        public List<Adventure> ?Adventures { get; set; }

        public List<Booking> ?Bookings { get; set; }


    }
}
