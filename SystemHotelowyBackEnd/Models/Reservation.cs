using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemHotelowyBackEnd.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public int Phone { get; set; }
        public int Country { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int RoomType { get; set; }
        public int RoomNo { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        [NotMapped]
        public string CheckIn => CheckInDate.ToString("dd/MM/yyyy");
        [NotMapped]
        public string CheckOut => CheckOutDate.ToString("dd/MM/yyyy");
    }
}