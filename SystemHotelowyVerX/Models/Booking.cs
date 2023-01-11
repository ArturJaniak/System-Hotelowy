using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SystemHotelowyVer3.Models;

namespace SystemHotelowyVer3.Models
{
    public class Booking
    {
        //Kod ma klasę o nazwie ApplicationDbContext, która jest kontekstem bazy danych dla tej aplikacji.
        //DBContext w skrócie odpowiada za połączenie do bazy oraz za wymianę danych i odwzorowanie ich na obiekty w C#. W projekcie może być wiele takich kontekstów do jednej lub wielu baz.
        //Ma dwie właściwości: Pokoje i Użytkownicy.
        //Kod ma również metodę o nazwie Goście, która zwraca listę gości, którzy są aktualnie zalogowani w tej aplikacji, a także ich role (Gość lub GuestManager).
        //Kod jest prostym przykładem tworzenia klasy modelu korzystającej z Entity Framework.
        //Kod ma 3 właściwości: Id, RoomId i GuestId.
        public int Id { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        //Właściwość RoomId jest wymagana, ponieważ odpowiada jednostce w bazie danych.
        public string GuestId { get; set; }
        [Required]
        //Właściwość GuestId jest również wymagana, ponieważ odpowiada jednostce w bazie danych.
        public double Time { get; set; }
        [Required]
        //Właściwość Time jest wymagana, ponieważ jest używana do celów sprawdzania poprawności z typem DateTime.
        public DateTime CheckIn { get; set; }
        [NotMapped]
        public virtual DateTime CheckOut => CheckIn.AddHours(Time);
        public DateTime Date { get; set; }
        public virtual Room Room => new ApplicationDbContext().Rooms.Find(RoomId);
        public virtual ApplicationUser Guest => new ApplicationDbContext().Users.Find(GuestId);
        [NotMapped]
        public virtual string[] RoomTypes => new string[] { "Apartament", "Podwójny pokój", "Pojedyńczy pokój" };
        //public virtual int[] RoomTypes => new int[] { 7, 8, 9 };
        [NotMapped]
        //public List<ApplicationUser> Guests => new ApplicationDbContext().Users.ToList().Where(x => x.Roles.ToList().Where(y => y.RoleId == "Guest").ToList());
        public virtual List<ApplicationUser> Guests => getGuestUsers();
        //public virtual List<Room> Rooms => getRooms();
        //Właściwość Rooms to IList<Room>, która zawiera wszystkie pokoje w hotelu, podczas gdy właściwość Users to IList<ApplicationUser>, która zawiera wszystkich użytkowników w tej aplikacji.

        //Zwraca listę użytkowników z rolą Guest
        private List<ApplicationUser> getGuestUsers()
        {
            //Stworzenie instatcji klasy ApplicationDbContext
            ApplicationDbContext db = new ApplicationDbContext();
            List<ApplicationUser> users = db.Users.ToList();
            List<ApplicationUser> newUsers = new List<ApplicationUser>();

            var role = db.Roles.Where(m => m.Name == "Guest").FirstOrDefault();

            foreach (var item in users)
            {
                if (item.Roles.FirstOrDefault().RoleId == role.Id)
                {
                    newUsers.Add(item);
                }
            }
            return newUsers;

        }
        //private List<Room> getRooms()
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    List<Room> rooms = db.Rooms.ToList();
        //    List<Room> newRoom = new List<Room>();

        //    var type = db.Rooms.Where(m => m.RoomType == "Apartament").FirstOrDefault();

        //    foreach (var item in rooms)
        //    {
        //        if (item.RoomTypes.FirstOrDefault().TypeId == type.Id)
        //        {
        //            newRoom.Add(item);
        //        }
        //    }
        //    return newRoom;

        //}
    }
}