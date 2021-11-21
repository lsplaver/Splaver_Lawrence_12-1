using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsLogUpdated.Models;

namespace TripsLogUpdated.Controllers
{
    public class TripController : Controller
    {
        private TripsLogUpdatedUnitOfWork data { get; set; }

        public TripController(TripsLogUpdatedContext ctx) => data = new TripsLogUpdatedUnitOfWork(ctx);

        [HttpGet]
        public ViewResult Add(string id)
        {
            TripAddViewModel vm = new TripAddViewModel();
            switch (id?.ToLower())
            {
                case "page2":
                    this.LoadViewBag("Add");
                    vm.PageNumber = 2;
                    return View("Add2", vm);
                case "page1":
                default:
                    this.LoadViewBag("Add");
                    vm.PageNumber = 1;
                    return View("Add1", vm);
            }
        }

        [HttpPost]
        public IActionResult Add(TripAddViewModel vm)
        {
            switch (vm.PageNumber)
            {
                case 1:
                    if (!ModelState.IsValid)
                    {
                        return View("Add1", vm);
                    }

                    TempData[nameof(Trip.DestinationId)] = vm.Trip.DestinationId;
                    TempData[nameof(Trip.AccommodationId)] = vm.Trip.AccommodationId;
                    TempData[nameof(Trip.StartDate)] = vm.Trip.StartDate;
                    TempData[nameof(Trip.EndDate)] = vm.Trip.EndDate;
                    //TripViewModel trip = new TripViewModel();
                    //vm.Trip.Destination.DestinationName = vm.Destination.DestinationName.FirstOrDefault(vm.Destination.DestinationId == vm.Trip.DestinationId);
                    //TempData[nameof(Trip.Destination.DestinationName)] = vm.Trip.Destination.DestinationName.Where(d => d.;
                    return RedirectToAction("Add", new { id = "Page2" });
                case 2:
                    vm.Trip.DestinationId = (int)TempData[nameof(Trip.DestinationId)];
                    vm.Trip.AccommodationId = (int)TempData[nameof(Trip.AccommodationId)];
                    vm.Trip.StartDate = (DateTime)TempData[nameof(Trip.StartDate)];
                    vm.Trip.EndDate = (DateTime)TempData[nameof(Trip.EndDate)];

                    data.Trips.Insert(vm.Trip);
                    data.Trips.Save();
                    TempData["message"] = $"Trip to {vm.Trip.Destination.DestinationName} between {vm.Trip.StartDate} and {vm.Trip.EndDate} has been added.";
                    return RedirectToAction("Index", "Home");
                default:
                    return RedirectToAction("Index", "Home");

            }    
        }

        public IActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }

        private void LoadViewBag(string operation)
        {
            ViewBag.Destination = data.Destinations.List(new QueryOptions<Destination>
            {
                OrderBy = d => d.DestinationId
            });

            ViewBag.Accommodation = data.Accommodations.List(new QueryOptions<Accommodation>
            {
                OrderBy = a => a.AccommodationId
            });

            ViewBag.Activity = data.Activities.List(new QueryOptions<Activity>
            {
                OrderBy = a => a.ActivityId
            });

            ViewBag.Operation = operation;
        }
    }
}
