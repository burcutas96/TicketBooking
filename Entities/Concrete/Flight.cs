using Core.Entities;

namespace Entities.Concrete
{
    public class Flight : BaseEntity
    {
        public DateTime DepartureTime { get; set; }
        public DateTime ArriveTime { get; set; }
        public int AirlineId { get; set; }
        public int DeparturePortId { get; set; }
        public int ArrivePortId { get; set; }


        public List<Ticket> Tickets { get; set; }
        public Airport DeparturePort { get; set; }
        public Airport ArrivePort { get; set; }
    }
}
