using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SystemHotelowyVer3.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SystemHotelowyVer3.Models
{
    // Możesz dodać dane profilu dla użytkownika, dodając więcej właściwości do klasy ApplicationUser. Odwiedź stronę https://go.microsoft.com/fwlink/?LinkID=317594, aby dowiedzieć się więcej.
    public class ApplicationUser : IdentityUser
    {
        //Zadeklarowanie zmiennej o nazwie userIdentity.
        //Wywołanie metody CreateIdentityAsync w menedżerze UserManager<ApplicationUser>, który zwraca wystąpienie ClaimsIdentity.
        //Kod jest metodą, która wygeneruje obiekt ClaimsIdentity z menedżera UserManager<ApplicationUser>.
        //Kod generuje tożsamość dla bieżącego użytkownika, do której można uzyskać dostęp, wywołując: var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            //Utworzenie elementu AuthenticationType, który należy przekazać do elementu zdefiniowanego w CookieAuthenticationOptions.AuthenticationType i przypisuje go do nowej zmiennej o nazwie userIdentity.
            //Następnym krokiem jest utworzenie nowej instancji DefaultAuthenticationTypes z ApplicationCookie jako typem i przypisanie jej do innej nowej zmiennej o nazwie AuthenticationType.
            //Następnie ten nowo utworzony obiekt AuthenticationType jest przypisywany do nowo utworzonego obiektu userIdentity przy użyciu menedżera oczekiwania.CreateIdentityAsync(this, AuthenticationType).
            // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Dodaj tutaj niestandardowe oświadczenia użytkownika
            return userIdentity;
        }

        [Required(ErrorMessage = "Imię jest wymagane.")]
        [Display(Name = "Imię")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        [Display(Name = "Nazwisko")]
        [StringLength(20)]
        public string Surname { get; set; }
        //public string Names { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }

        //[NotMapped]
        //public virtual List<Guest> Guests => new ApplicationDbContext().Guests.ToList();

        //Zwrócenie wszystkich Bookings z GuestId równe ID
        public virtual List<Booking> Bookings => new ApplicationDbContext().Booking.ToList().Where(x => x.GuestId == Id).ToList();
    }

    //stworzenie klasy ApplicationDbContext
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        //Kod tworzy instancję obiektu typu ApplicationDbContext przez wywołanie konstruktora podstawowego bez argumentów.
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Kod konfiguruje trzy właściwości DbSet: Goście, Pokoje i Rezerwacje.
        //Są to wszystkie obiekty Entity Framework reprezentujące tabele w naszym schemacie bazy danych do przechowywania danych odpowiednio o gościach przebywających w hotelach i zarezerwowanych dla nich pokojach.
        //Każda właściwość ma własną metodę ustawiającą, która pozwala nam dodawać lub usuwać elementy z tych kolekcji za pomocą odpowiednio zapytań LINQ lub instrukcji SQL.


        //public System.Data.Entity.DbSet<SystemHotelowyVer2.Models.Guest> Guests { get; set; }

        public System.Data.Entity.DbSet<SystemHotelowyVer3.Models.Room> Rooms { get; set; }

        public System.Data.Entity.DbSet<SystemHotelowyVer3.Models.Booking> Booking { get; set; }
    }
}