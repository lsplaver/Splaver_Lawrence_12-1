using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> entity)
        {
            entity.HasOne(t => t.Destination)
                .WithMany(d => d.Trips)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(t => t.Accommodation)
                .WithMany(a => a.Trips)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasData(
                new Trip { TripId = 1, DestinationId = 1, AccommodationId = 1, StartDate = DateTime.Parse("7/2/2020"), EndDate = DateTime.Parse("7/9/2020") },
                new Trip { TripId = 2, DestinationId = 2, AccommodationId = 2, StartDate = DateTime.Parse("10/25/2020"), EndDate = DateTime.Parse("11/1/2020") },
                new Trip { TripId = 3, DestinationId = 3, AccommodationId = 3, StartDate = DateTime.Parse("2/15/2021"), EndDate = DateTime.Parse("2/21/2021") }
                );
        }
    }
}
