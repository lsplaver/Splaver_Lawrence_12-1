using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{
    public class AccommodationConfig : IEntityTypeConfiguration<Accommodation>
    {
        public void Configure(EntityTypeBuilder<Accommodation> entity)
        {
            entity.HasData(
                new Accommodation { AccommodationId = 1, AccommodationName = "Camping", AccommodationPhone = null, AccommodationEmail = null},
                new Accommodation { AccommodationId = 2, AccommodationName = "Staybridge Suites", AccommodationPhone = "(555)-123-9876", AccommodationEmail = "contact@staybridgesyutes.com"},
                new Accommodation { AccommodationId = 3, AccommodationName = "The Lodge at Whitefish Lake", AccommodationPhone = null, AccommodationEmail = "thelodge@whitefish.com" }
                );
        }
    }
}
