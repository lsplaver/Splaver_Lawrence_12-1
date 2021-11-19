using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TripsLogUpdated.Models.Validation;

namespace TripsLogUpdated.Models
{
    public class Accommodation
    {
        public int AccommodationId { get; set; }
        public string AccommodationName { get; set; }
        [StringLength(14, MinimumLength = 14, ErrorMessage = ("Phone number must be 14 characters long."))]
        [CustomPhoneFormat(ErrorMessage = "Phone number must be in the (123)-456-7890 format.")]
        public string AccommodationPhone { get; set; }
        [CustomEmailFormat(ErrorMessage = "Email must be in the format of 'name@example.com")]
        public string AccommodationEmail { get; set; }

    }
}
