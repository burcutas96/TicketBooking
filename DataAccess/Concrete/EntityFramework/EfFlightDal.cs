using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFlightDal : EfEntityRepositoryBase<Flight, TicketBookingContext>, IFlightDal
    {
        public List<FlightDTO> GetFlightDTOs()
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
                }.ToList();
            
            return data;
        }
    }
}