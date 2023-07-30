using Core.Entities;

namespace Entities.Concrete
{
    public class Flight : BaseEntity
    {
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArriveTime { get; set; }
        public DateTime FlightDate { get; set; } 
        public int AirlineId { get; set; }
        public int DeparturePortId { get; set; }
        public int ArrivePortId { get; set; }


        public List<Ticket> Tickets { get; set; }
        public Airport DeparturePort { get; set; }
        public Airport ArrivePort { get; set; }
    }
}
