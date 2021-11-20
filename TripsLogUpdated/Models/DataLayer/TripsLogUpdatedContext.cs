using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models
{
    public class TripsLogUpdatedContext : DbContext
    {
        public TripsLogUpdatedContext(DbContextOptions<TripsLogUpdatedContext> options) : base(options) { }

        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripActivity> TripActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TripActivity>().HasKey(ta => new { ta.TripId, ta.ActivityId });

            modelBuilder.Entity<TripActivity>().HasOne(ta => ta.Trip).WithMany(t => t.TripActivities).HasForeignKey(ta => ta.TripId);
            modelBuilder.Entity<TripActivity>().HasOne(ta => ta.Activity).WithMany(a => a.TripActivities).HasForeignKey(ta => ta.ActivityId);

            modelBuilder.ApplyConfiguration(new AccommodationConfig());
            modelBuilder.ApplyConfiguration(new ActivityConfig());
            modelBuilder.ApplyConfiguration(new DestinationConfig());
            modelBuilder.ApplyConfiguration(new TripConfig());
            modelBuilder.ApplyConfiguration(new TripActivityConfig());
        }
    }
}
