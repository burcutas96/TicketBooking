using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class TicketBookingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(@"Server=ticket-booking.cl7uvv8utzfs.eu-north-1.rds.amazonaws.com;Port=5432;Database=flight_ticket_booking;User Id=postgres;Password=ticketbooking123;");
        }

        DbSet<BasePrice> base_prices { get; set; } 
        DbSet<PriceDetail> price_details { get; set; } 


    }
}
