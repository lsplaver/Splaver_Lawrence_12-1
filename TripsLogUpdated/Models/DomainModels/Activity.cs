﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
