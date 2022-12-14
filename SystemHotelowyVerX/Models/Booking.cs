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
        public int Id { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public string GuestId { get; set; }
        [Required]
        public double Time { get; set; }
        [Required]
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

        private List<ApplicationUser> getGuestUsers()
        {
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