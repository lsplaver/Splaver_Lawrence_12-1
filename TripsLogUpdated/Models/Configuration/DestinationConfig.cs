using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{
    public class DestinationConfig : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> entity)
        {
            entity.HasData(
                new Destination { DestinationId = 1, DestinationName = "Olympic Peninsula" },
                new Destination { DestinationId = 2, DestinationName = "New York" },
                new Destination { DestinationId = 3, DestinationName = "Whitefish, Montana" }
                );
        }
    }
}
