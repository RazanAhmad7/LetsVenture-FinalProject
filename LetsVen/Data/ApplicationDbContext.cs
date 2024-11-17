
using LetsVen.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LetsVen.Data
{
    public class ApplicationDbContext :  IdentityDbContext<AppUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {      
        }

        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<AdventureImages> Images { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
