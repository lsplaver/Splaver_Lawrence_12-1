using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
