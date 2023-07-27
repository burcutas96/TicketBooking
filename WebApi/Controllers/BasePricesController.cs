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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasePricesController : ControllerBase
    {
        IBasePriceService _basePriceService;
        public BasePricesController(IBasePriceService basePriceService)
        {
            _basePriceService = basePriceService;
        }


        [HttpGet]
        public IActionResult Get(int id) 
        {
            var result = _basePriceService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpGet]
        public IActionResult GetAll()
        {
            TicketBookingContext context = new TicketBookingContext();
            FlightDTO flightDTO = new FlightDTO();

            var data = context.Flights
                .Include(f => f.Airline)
                .Include(f => f.DeparturePort)
                .Include(f => f.Tickets)
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


        [HttpPost]
        public IActionResult Add(BasePrice basePrice)
        {
            var result = _basePriceService.Add(basePrice);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _basePriceService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPut]
        public IActionResult Update(BasePrice basePrice)
        {
            var result = _basePriceService.Update(basePrice);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
