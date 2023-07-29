using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        

        [HttpGet]
        public IActionResult GetAll()
        {
            TicketBookingContext context = new TicketBookingContext();

            var data = from flight in context.Flights
                       join airline in context.Airlines
                       on flight.AirlineId equals airline.Id

                       select new FlightDTO
                       {
                           Id = flight.Id,
                           FlightNo = airline.Code + flight.Id,
                           AirlineCode = airline.Code,
                           Airline = airline.Name,
                           DepTime = flight.DepartureTime.ToString("HH:mm:ss"),
                           ArrTime = flight.ArriveTime.ToString("HH:mm:ss"),
                           DepPort = flight.DeparturePort.Code,
                           ArrPort = flight.ArrivePort.Code,
                           FlightDate = flight.ArriveTime.ToString("dd.MM.yyyy"),
                           PassengerPrices = flight.Tickets.Select(t => new PassengerPrice()
                           {
                               PriceWithoutTax = t.Price,
                               Currency = t.Currency,
                               Surcharge = t.Surcharge,
                               TotalTax = t.Price * t.TaxRatio,
                               Type = t.PassengerType.ToString(),
                               Price = (t.Price * t.TaxRatio) + t.Price
                           }).ToList()
                       };


                

            return Ok(data);
        }
    }
}
