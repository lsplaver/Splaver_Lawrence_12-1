using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
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
                    int destinationId = (int)TempData.Peek(nameof(Trip.DestinationId));
                    int? accommodationId = (int?)TempData.Peek(nameof(Trip.AccommodationId));
                    DateTime startDate = (DateTime)TempData.Peek(nameof(Trip.StartDate));
                    DateTime endDate = (DateTime)TempData.Peek(nameof(Trip.EndDate));
                    vm.Trip = new Trip { DestinationId = destinationId, AccommodationId = accommodationId, StartDate = startDate, EndDate = endDate };
                    return View("Add2", vm);
                case "page1":
                default:
                    TempData.Clear();
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
                    //int[] tempActivities;
                    //if (vm.SelectedActivities != null)
                    //{
                    //    tempActivities = new int[vm.SelectedActivities.Count()];
                    //    for (int x = 0; x < tempActivities.Count(); x++)
                    //    {
                    //        tempActivities[x] = vm.SelectedActivities.ElementAt(x);
                    //    }
                    //    vm = new TripAddViewModel();

                    //    vm.Trip.TripActivities = new List<TripActivity>();
                    //    foreach (int activityId in tempActivities)
                    //    {
                    //        vm.Trip.TripActivities.Add(new TripActivity { ActivityId = activityId });
                    //    }
                    //}
                    int destinationId = (int)TempData.Peek(nameof(Trip.DestinationId));
                    int? accommodationId = (int?)TempData.Peek(nameof(Trip.AccommodationId));
                    DateTime startDate = (DateTime)TempData.Peek(nameof(Trip.StartDate));
                    DateTime endDate = (DateTime)TempData.Peek(nameof(Trip.EndDate));
                    vm.Trip = new Trip { DestinationId = destinationId, AccommodationId = accommodationId, StartDate = startDate, EndDate = endDate };

                    if (vm.SelectedActivities != null)
                    {
                        foreach (int activityId in vm.SelectedActivities)
                        {

                            if (vm.Trip.TripActivities == null)
                            {
                                vm.Trip.TripActivities = new List<TripActivity>();
                            }

                            vm.Trip.TripActivities.Add(new TripActivity { ActivityId = activityId });

                        }
                    }


                    //int? temp = vm.Trip.DestinationId;
                    //int intTemp = (int)TempData[nameof(Trip.DestinationId)];
                    vm.Trip.DestinationId =  (int)TempData[nameof(Trip.DestinationId)];
                    vm.Trip.AccommodationId = (int?)TempData[nameof(Trip.AccommodationId)];
                    vm.Trip.StartDate = (DateTime)TempData[nameof(Trip.StartDate)];
                    vm.Trip.EndDate = (DateTime)TempData[nameof(Trip.EndDate)];
                    string destinationName = null;
                    vm.Destinations = new List<Destination>();
                    destinationName = vm.Destinations.Where(d => d.DestinationId == vm.Trip.DestinationId).ToString();
                    data.Trips.Insert(vm.Trip);
                    data.Trips.Save();
                    TempData["message"] = $"Trip to {destinationName} between {vm.Trip.StartDate} and {vm.Trip.EndDate} has been added.";
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

            ViewBag.ActivityCount = data.Activities.List(new QueryOptions<Activity>
            {
                OrderBy = a => a.ActivityId
            }).Count();

            ViewBag.Operation = operation;
        }
    }
}
