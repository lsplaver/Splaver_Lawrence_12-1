using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{
    public class TripAddViewModel
    {
        public Trip Trip { get; set; }
        public IEnumerable<Trip> Trips { get; set; }
        public IEnumerable<TripActivity> TripActivities { get; set; }
        public IEnumerable<Accommodation> Accommodations { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
        public IEnumerable<Destination> Destinations { get; set; }
        public int PageNumber { get; set; }
        public int[] SelectedActivities { get; set; }

    }
}
