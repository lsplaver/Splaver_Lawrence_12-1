using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{
    public class TripViewModel
    {
        public Trip Trip { get; set; }
        public IEnumerable<Trip> Trips { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
        public int[] SelectedActivities { get; set; }

        public int PageNumber { get; set; }
    }
}
