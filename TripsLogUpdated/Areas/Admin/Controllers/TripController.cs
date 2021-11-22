using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsLogUpdated.Models;

namespace TripsLogUpdated.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TripController : Controller
    {
        private TripsLogUpdatedUnitOfWork data { get; set; }
        public TripController(TripsLogUpdatedContext ctx) => data = new TripsLogUpdatedUnitOfWork(ctx);

        [HttpGet]
        public ViewResult Index()
        {
            this.LoadViewBag("Delete");
            return View();
        }

        [HttpPost]
        public IActionResult Add(TripManageViewModel vm)
        {
            if (((vm.Accommodation.AccommodationEmail != null) || (vm.Accommodation.AccommodationPhone != null)) && vm.Accommodation.AccommodationName == null)
            {
                ModelState.AddModelError("Accommodation.AccommodationName", "You need to have an accommodation name to add either an accommodation phone or an accommodation email.");
            }
            if (ModelState.IsValid)
            {
                if (vm.Accommodation.AccommodationName != null)
                {
                    data.Accommodations.Insert(vm.Accommodation);
                    data.Accommodations.Save();
                    TempData["messageAccommodation"] = $"{vm.Accommodation.AccommodationName} has been added to the Accommodations table";
                }
                if (vm.Activity.ActivityName != null)
                {
                    data.Activities.Insert(vm.Activity);
                    data.Activities.Save();
                    TempData["messageActivity"] = $"{vm.Activity.ActivityName} has been added to the Activities table";
                }
                if (vm.Destination.DestinationName != null)
                {
                    data.Destinations.Insert(vm.Destination);
                    data.Destinations.Save();
                    TempData["messageDestination"] = $"{vm.Destination.DestinationName} has been added to the Accommodations table";
                }
            }
            else
                return RedirectToAction("Index", "Trip");
            return RedirectToAction("Index", "Trip");
        }

        public RedirectToActionResult Delete(TripManageViewModel vm)//Trip trip)
        {
            if (vm.Accommodation.AccommodationId > 0)
            {
                //Accommodation accommodation = new Accommodation();
                //accommodation = GetAccommodation(id);
                
                data.Accommodations.Delete(vm.Accommodation);
                data.Accommodations.Save();
                TempData["accomodationDeleted"] = $"{vm.Accommodation.AccommodationName} has been deleted.";
            }
            if (vm.Activity.ActivityId > 0)
            {
                //Accommodation accommodation = new Accommodation();
                //accommodation = GetAccommodation(id);

                data.Activities.Delete(vm.Activity);
                data.Activities.Save();
                TempData["activityDeleted"] = $"{vm.Activity.ActivityName} has been deleted.";
            }
            if (vm.Destination.DestinationId > 0)
            {
                //Accommodation accommodation = new Accommodation();
                //accommodation = GetAccommodation(id);

                data.Destinations.Delete(vm.Destination);
                data.Destinations.Save();
                TempData["destinationDeleted"] = $"{vm.Destination.DestinationName} has been deleted.";
            }
            return RedirectToAction("Index", "Trip");
        }

        //private Accommodation GetAccommodation(int id)
        //{
        //    var accommodationOptions = new QueryOptions<Trip>
        //    {
        //        Where = t => t.TripId == id
        //    };

        //    return data.Accommodations.Get(accommodationOptions);
        //}


        private void LoadViewBag(string operation)
        {
            ViewBag.DeleteDestinationId = data.Destinations.List(new QueryOptions<Destination>
            {
                OrderBy = d => d.DestinationId
            });

            ViewBag.DeleteAccommodationId = data.Accommodations.List(new QueryOptions<Accommodation>
            {
                OrderBy = a => a.AccommodationId
            });

            ViewBag.DeleteActivityId = data.Activities.List(new QueryOptions<Activity>
            {
                OrderBy = a => a.ActivityId
            });

            ViewBag.Operation = operation;
        }
    }
}
