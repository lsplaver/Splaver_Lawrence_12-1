using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{
    public class TripViewModel
    {
        public IEnumerable<Trip> Trips { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
    }
}
