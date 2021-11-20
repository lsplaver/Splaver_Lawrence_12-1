using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{
    public class TripActivityConfig : IEntityTypeConfiguration<TripActivity>
    {
        public void Configure(EntityTypeBuilder<TripActivity> entity)
        {
            entity.HasData(
                new TripActivity { TripId = 1, ActivityId = 1 },
                new TripActivity { TripId = 1, ActivityId = 2 },
                new TripActivity { TripId = 2, ActivityId = 3 },
                new TripActivity { TripId = 2, ActivityId = 4 },
                new TripActivity { TripId = 3, ActivityId = 5 },
                new TripActivity { TripId = 3, ActivityId = 6 },
                new TripActivity { TripId = 3, ActivityId = 7 }
                );
        }
    }
}
