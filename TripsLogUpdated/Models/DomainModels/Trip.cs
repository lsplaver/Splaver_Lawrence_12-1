using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TripsLogUpdated.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        [Required(ErrorMessage = "Please enter a start date.")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Please enter an end date.")]
        public DateTime? EndDate { get; set; }
        
        [Required(ErrorMessage = "Please select a destination.")]
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }

        public int? AccommodationId { get; set; }
        public Accommodation Accommodation { get; set; }

        public ICollection<TripActivity> TripActivities { get; set; }
    }
}
