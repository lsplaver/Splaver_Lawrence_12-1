using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{
    public interface ITripsLogUpdatedUnitOfWork
    {
        public Repository<Accommodation> Accommodations { get; }
        public Repository<Activity> Activities { get; }
        public Repository<Destination> Destinations { get; }
        public Repository<Trip> Trips { get; }
        public Repository<TripActivity> TripActivities { get; }

        public void Save();
    }
}