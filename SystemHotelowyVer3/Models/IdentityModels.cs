using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SystemHotelowyVer3.Models;

namespace SystemHotelowyVer3.Models
{
    // Możesz dodać dane profilu dla użytkownika, dodając więcej właściwości do klasy ApplicationUser. Odwiedź stronę https://go.microsoft.com/fwlink/?LinkID=317594, aby dowiedzieć się więcej.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Dodaj tutaj niestandardowe oświadczenia użytkownika
            return userIdentity;
        }

        public string Names { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }

        //[NotMapped]
        //public virtual List<Guest> Guests => new ApplicationDbContext().Guests.ToList();

        public virtual List<Booking> Bookings =>
            new ApplicationDbContext().Booking.ToList().Where(x => x.GuestId == Id).ToList();
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // public System.Data.Entity.DbSet<SystemHotelowyVer2.Models.Guest> Guests { get; set; }

        public System.Data.Entity.DbSet<SystemHotelowyVer3.Models.Room> Rooms { get; set; }

        public System.Data.Entity.DbSet<SystemHotelowyVer3.Models.Booking> Booking { get; set; }
    }
}