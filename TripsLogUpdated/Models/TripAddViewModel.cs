using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{
    public class TripAddViewModel
    {
        public Trip Trip { get; set; }
        public TripActivity TripActivity { get; set; }
        public Accommodation Accommodation { get; set; }
        public Activity Activity { get; set; }
        public Destination Destination { get; set; }
        public int PageNumber { get; set; }
    }
}
