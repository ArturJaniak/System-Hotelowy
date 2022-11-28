using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SystemHotelowyBackEnd.Models;

namespace SystemHotelowyBackEnd.Controllers
{
    public class ReservationController : Controller
    {
        ApplicationDbContext context;

        public ReservationController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Reservation
        public ActionResult Index()
        {
            return View(context.Reservation.ToList());
        }

        public ActionResult Create()
        {
            List<SelectListItem> country = new List<SelectListItem>();
            country.Add(new SelectListItem() { Text = "Kraj", Value = "" });
            country.Add(new SelectListItem() { Text = "Polska", Value = "2" });
            country.Add(new SelectListItem() { Text = "Inny", Value = "3" });
            ViewBag.country = country;
            List<SelectListItem> rooms = new List<SelectListItem>();
            rooms.Add(new SelectListItem() { Text = "Typ pokoju", Value = "" });
            rooms.Add(new SelectListItem() { Text = "Deluxe", Value = "2" });
            rooms.Add(new SelectListItem() { Text = "Superior", Value = "3" });
            rooms.Add(new SelectListItem() { Text = "Executive", Value = "4" });
            rooms.Add(new SelectListItem() { Text = "Suite", Value = "5" });
            ViewBag.rooms = rooms;
            List<SelectListItem> roomsno = new List<SelectListItem>();
            roomsno.Add(new SelectListItem() { Text = "Liczba pokoi", Value = "" });
            roomsno.Add(new SelectListItem() { Text = "1", Value = "2" });
            roomsno.Add(new SelectListItem() { Text = "2", Value = "3" });
            roomsno.Add(new SelectListItem() { Text = "3", Value = "4" });
            roomsno.Add(new SelectListItem() { Text = "4 lub więcej", Value = "5" });
            ViewBag.roomsno = roomsno;
            List<SelectListItem> adults = new List<SelectListItem>();
            adults.Add(new SelectListItem() { Text = "Dorośli", Value = "" });
            adults.Add(new SelectListItem() { Text = "1", Value = "2" });
            adults.Add(new SelectListItem() { Text = "2", Value = "3" });
            adults.Add(new SelectListItem() { Text = "3", Value = "4" });
            adults.Add(new SelectListItem() { Text = "4 lub więcej", Value = "5" });
            ViewBag.adults = adults;
            List<SelectListItem> children = new List<SelectListItem>();
            children.Add(new SelectListItem() { Text = "Dzieci", Value = "" });
            children.Add(new SelectListItem() { Text = "0", Value = "2" });
            children.Add(new SelectListItem() { Text = "1", Value = "3" });
            children.Add(new SelectListItem() { Text = "2", Value = "4" });
            children.Add(new SelectListItem() { Text = "3 lub więcej", Value = "5" });
            ViewBag.children = children;
            return View(new ReservationView());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReservationView model)
        {
            if (ModelState.IsValid)
            {
                Reservation obj = new Reservation() { Name = model.Name, Email = model.Email, Phone = model.Phone, Country = model.Country, CheckInDate = model.CheckInDate, CheckOutDate = model.CheckOutDate, RoomType = model.RoomType, RoomNo = model.RoomNo, Adults = model.Adults, Children = model.Children };
                context.Reservation.Add(obj);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
           
            return View(model);
        }
    }
}