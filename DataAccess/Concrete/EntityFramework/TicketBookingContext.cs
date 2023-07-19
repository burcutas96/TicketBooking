using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class TicketBookingContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public TicketBookingContext(DbContextOptions options) : base(options){}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>().Property(p=>p.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Passenger>().Property(p => p.LastName).HasMaxLength(50);
            modelBuilder.Entity<Passenger>().Property(p => p.Email).HasMaxLength(100);
            modelBuilder.Entity<Passenger>().Property(p => p.Phone).HasMaxLength(16);


            //modelBuilder.Entity<Airport>().
            //    HasMany(a => a.Flights)
            //    .WithOne(f => f.ArrivePort)
            //    .HasForeignKey(f => f.ArrivePortId);
            modelBuilder.Entity<Flight>()
                .HasOne(f=>f.ArrivePort)
                .WithMany(a=>a.Flights)
                .HasForeignKey(f=>f.ArrivePortId)
                .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Flight>()
            //    .HasOne(f => f.DeparturePort)
            //    .WithMany(a => a.Flights)
            //    .HasForeignKey(f => f.DeparturePortId)
            //    .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


        }
    }
}
