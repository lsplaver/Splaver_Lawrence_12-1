using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{
    internal class TripsLogUpdatedUnitOfWork : ITripsLogUpdatedUnitOfWork
    {
        private TripsLogUpdatedContext context { get; set; }
        public TripsLogUpdatedUnitOfWork(TripsLogUpdatedContext ctx) => context = ctx;

        private Repository<Accommodation> accommodationData;
        private Repository<Activity> activityData;
        private Repository<Destination> destinationData;
        private Repository<Trip> tripData;
        private Repository<TripActivity> tripActivityData;

        public Repository<Accommodation> Accommodations
        {
            get
            {
                if (accommodationData == null) accommodationData = new Repository<Accommodation>(context);

                return accommodationData;
            }
        }

        public Repository<Activity> Activities
        {
            get
            {
                if (activityData == null) activityData = new Repository<Activity>(context);

                return activityData;
            }
        }

        public Repository<Destination> Destinations
        {
            get
            {
                if (destinationData == null) destinationData = new Repository<Destination>(context);

                return destinationData;
            }
        }

        public Repository<Trip> Trips
        {
            get
            {
                if (tripData == null) tripData = new Repository<Trip>(context);

                return tripData;
            }
        }

        public Repository<TripActivity> TripActivities
        {
            get
            {
                if (tripActivityData == null) tripActivityData = new Repository<TripActivity>(context);

                return tripActivityData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}