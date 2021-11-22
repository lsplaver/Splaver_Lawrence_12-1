using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{ 
    public class ActivityConfig : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> entity)
        {
            entity.HasData(
                new Activity { ActivityId = 1, ActivityName = "Swimming" },
                new Activity { ActivityId = 2, ActivityName = "Hiking" },
                new Activity { ActivityId = 3, ActivityName = "Ride the subway" },
                new Activity { ActivityId = 4, ActivityName = "Go to Grand Central Station" },
                new Activity { ActivityId = 5, ActivityName = "Walk in the snow" },
                new Activity { ActivityId = 6, ActivityName = "Ice skate" },
                new Activity { ActivityId = 7, ActivityName = "Cross country skiing" }
                );
        }
    }
}
