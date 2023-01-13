using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemHotelowyVer3.Models;

namespace SystemHotelowyVer3.Controllers
{
    // [Authorize]
    public class BookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bookings
        public async Task<ActionResult> Index()
        {
            return View(await db.Booking.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Booking.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            return View(new Booking());
        }

        // POST: Bookings/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RoomId,GuestId,Time,CheckIn")] Booking booking)
        {
            if (booking != null)
            {
                booking.Date = DateTime.Now;
                //booking.CheckIn = DateTime.Parse(booking.CheckIn);
            }
            if (ModelState.IsValid)
            {
                List<Booking> uses = db.Booking.ToList().Where(x => x.RoomId == booking.RoomId).ToList();
                foreach (var item in uses)
                {
                    if ((item.CheckIn >= booking.CheckIn && item.CheckIn <= booking.CheckOut) || item.CheckIn.AddDays(booking.Time) >= booking.CheckIn)
                    {
                        ModelState.AddModelError("", "Pokój nie jest dostępny");
                        return View(booking);
                    }
                }
                db.Booking.Add(booking);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Booking.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RoomId,GuestId,IsActive,Date")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(booking);
        }
        // POST: Bookings/Rooms
        public async Task<JsonResult> Rooms(string RoomType)
        {
            if (!string.IsNullOrEmpty(RoomType))
            {
                List<Room> rooms = await db.Rooms.ToListAsync();
                rooms = rooms.ToList().Where(x => x.RoomType.Trim().ToLower() ==
                            RoomType.Trim().ToLower()).ToList();
                return Json(new { Rooms = rooms });
            }
            return Json(new { Rooms = new List<Room>() });
        }

        // GET: Bookings/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Booking.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Booking booking = await db.Booking.FindAsync(id);
            db.Booking.Remove(booking);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}