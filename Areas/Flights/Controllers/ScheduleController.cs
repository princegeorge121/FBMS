using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AirsiderFlightManagement.Areas.Flights.Controllers
{
    [Area("Flights")]
    [Authorize(Roles = "Admin")]
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext db;

        public ScheduleController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.FlightSchedules.Include(m=>m.Flight).ToList());

        }


        [HttpGet]
        public IActionResult Create()
        {
            var x = db.Flights.ToList();
            var model = new ScheduleViewModel()
            {
                Flights = x,
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ScheduleViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            db.FlightSchedules.Add(new FlightSchedule()
            {
                FlightFrom= model.FlightFrom,
                FlightTo= model.FlightTo,
                FlightDate= model.FlightDate,
                Cost= model.Cost,
                FlightId= model.Flight
            });
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var flightSchedule = await db.FlightSchedules.FindAsync(id);
            if (flightSchedule == null)
            {
                return NotFound();
            }
            return View(new FlightSchedule()
            {
                FlightFrom = flightSchedule.FlightFrom,
                FlightTo = flightSchedule.FlightTo,
                FlightDate = flightSchedule.FlightDate,
                Cost = flightSchedule.Cost,
                Flight = flightSchedule.Flight,
                FlightId = flightSchedule.FlightId
            });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(long id, ScheduleViewModel model)
        {
            var flightSchedule = await db.FlightSchedules.FindAsync(id);
            if (flightSchedule == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            flightSchedule.FlightFrom = model.FlightFrom;
            flightSchedule.FlightTo = model.FlightTo;
            flightSchedule.FlightDate = model.FlightDate;
            flightSchedule.Cost = model.Cost;
            

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    
        public async Task<IActionResult> Delete(long id)
        {
            var flightSchedule = await db.FlightSchedules.FindAsync(id);
            if (flightSchedule == null)
            {
                return NotFound();
            }
            db.FlightSchedules.Remove(flightSchedule);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
