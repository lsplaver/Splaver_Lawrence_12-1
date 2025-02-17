﻿using Microsoft.AspNetCore.Mvc;
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
        private TripsLogUpdatedUnitOfWork data { get; set; }

        public HomeController(TripsLogUpdatedContext context) => data = new TripsLogUpdatedUnitOfWork(context);

        [HttpGet]
        public ViewResult Index()
        {
            var tripOptions = new QueryOptions<Trip>
            {
                Includes = "Accommodation, Destination, TripActivities.Activity"
            };

            tripOptions.OrderBy = t => t.StartDate;
            var vm = new TripViewModel
            {
                Trips = data.Trips.List(tripOptions)
            };
            return View(vm);
        }

        public RedirectToActionResult Delete(int id)
        {
            Trip trip = new Trip();
            trip = GetTrip(id);
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
