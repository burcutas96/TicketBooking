using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class TicketBookingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(@"Server=ticket-booking.cl7uvv8utzfs.eu-north-1.rds.amazonaws.com;Port=5432;Database=FlightTicketBooking;User Id=postgres;Password=ticketbooking123;");
        }


        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<FlightType> FlightTypes { get; set; }

    }
}
