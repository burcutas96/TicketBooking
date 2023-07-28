using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            var data = context.Flights
                .Select(x => new FlightDTO
                {
                    Id = x.Id, 
                    FlightNo = x.Airline.Code + x.Id,
                    AirlineCode = x.Airline.Code,
                    Airline = x.Airline.Name, 
                    DepTime = x.DepartureTime.ToString("HH:mm:ss"),
                    ArrTime = x.ArriveTime.ToString("HH:mm:ss"),
                    DepPort = x.DeparturePort.Code,
                    ArrPort = x.ArrivePort.Code,
                    FlightDate = x.ArriveTime.ToString("dd.MM.yyyy"),
                    PassengerPrices = x.Tickets.Select(t => new PassengerPrice()
                    {
                        PriceWithoutTax = t.Price,
                        Currency = t.Currency,
                        Surcharge = t.Surcharge,
                        TotalTax = t.Price * t.TaxRatio,
                        Type = t.PassengerType.ToString(),
                        Price = (t.Price * t.TaxRatio) + t.Price
                    }).ToList()
                }).ToList();

            return Ok(data);
        }
    }
}
