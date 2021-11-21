using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsLogUpdated.Models;

namespace TripsLogUpdated.Controllers
{
    public class HomeController : Controller
    {
        //private TripsLogUpdatedContext context { get; set; }

        private TripsLogUpdatedUnitOfWork data { get; set; }

        public HomeController(TripsLogUpdatedContext context) => data = new TripsLogUpdatedUnitOfWork(context); //=> this.context = context;

        [HttpGet]
        public ViewResult Index()
        {
            //IQueryable<Trip> query = context.Trips
            //    .Include(t => t.Accommodation)
            //    .Include(t => t.Destination)
            //    .Include(t => t.TripActivities)
            //    .OrderBy(t => t.StartDate);

            //TripViewModel vm = new TripViewModel
            //{
            //    Trips = query.ToList()
            //};

            //return View(vm);
            var tripOptions = new QueryOptions<Trip>
            {
                Includes = "Accommodation, Destination, TripActivities.Activity"
            };

            tripOptions.OrderBy = t => t.StartDate;
            //var vm = new TripViewModel();
            //vm = (TripViewModel)data.Trips.List(tripOptions);
            //vm = tripOptions;
            var vm = new TripViewModel
            {
                Trips = data.Trips.List(tripOptions)
            };
            return View(vm);
        }

        //[HttpGet]
        //public ViewResult Delete(int id)
        //{
        //    var t = this.GetTrip(id);
        //    return View(t);
        //}

        //[HttpPost]
        public RedirectToActionResult Delete(Trip trip)
        {
            data.Trips.Delete(trip);
            data.Trips.Save();
            TempData["message"] = $"{trip.Destination} between {trip.StartDate} and {trip.EndDate} has been deleted.";
            return RedirectToAction("Index", "home", new { id = 0 });
        }

        private Trip GetTrip(int id)
        {
            var tripOptions = new QueryOptions<Trip>
            {
                Includes = "Accommodation, Destination",
                Where = t => t.TripId == id
            };

            return data.Trips.Get(tripOptions);
        }
    }
}
