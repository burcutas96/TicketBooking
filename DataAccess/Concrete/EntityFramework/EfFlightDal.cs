using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFlightDal : EfEntityRepositoryBase<Flight, TicketBookingContext>, IFlightDal
    {
        public List<FlightDTO> GetFlightDTOs(Expression<Func<FlightDTO, bool>> filter = null)
        {
            using (TicketBookingContext context = new TicketBookingContext())
            {
                var data = from flight in context.Flights
                           join airline in context.Airlines
                           on flight.AirlineId equals airline.Id

                           join flightType in context.FlightTypes
                           on flight.FlightTypeId equals flightType.Id

                           select new FlightDTO
                           {
                               Id = flight.Id,
                               FlightNo = airline.Code + flight.Id,
                               FlightType = flightType.Name,
                               AirlineCode = airline.Code,
                               Airline = airline.Name,
                               DepTime = flight.DepartureTime.ToString(@"hh\:mm\:ss"),
                               ArrTime = flight.ArriveTime.ToString(@"hh\:mm\:ss"),
                               DepPort = flight.DeparturePort.Code,
                               ArrPort = flight.ArrivePort.Code,
                               FlightDate = flight.FlightDate.ToString("dd.MM.yyyy"),
                               PassengerPrices = flight.Tickets.Select(t => new PassengerPrice()
                               {
                                   BasePrice = t.BasePrice,
                                   Currency = t.Currency,
                                   Surcharge = t.Surcharge,
                                   TotalTax = t.TaxAmount,
                                   Type = t.PassengerType.ToString(),
                                   SalesPrice = t.Surcharge + t.TaxAmount + t.BasePrice
                               }).ToList()
                           };

                return data.Where(filter).ToList();
            }
        }
    }
}