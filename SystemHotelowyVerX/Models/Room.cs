using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemHotelowyVer3.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        [Required]
        public string RoomType { get; set; }
        public bool Isactive { get; set; }
        public DateTime Date { get; set; }

        [NotMapped]
        public virtual string[] RoomTypes => new string[] { "Apartament", "Podwójny pokój", "Pojedyńczy pokój" };
        //public virtual int[] RoomTypes => new int[] { 7, 8, 9 };

        //[NotMapped]
        //public virtual List<Room> Rooms => new ApplicationDbContext().Rooms.ToList();
        //public virtual List<Booking> Bookings => 
        // new ApplicationDbContext().Booking.ToList().Where(x => x.RoomId == Id).ToList();

    }
}