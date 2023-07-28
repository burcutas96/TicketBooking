using Core.Entities;

namespace Entities.Concrete
{
    public class Airport : BaseEntity
    {
        public string Code { get; set; }
        public string Explanation { get; set; }

        public List<Flight> DepartureFlights { get; set; }
        public List<Flight> ArriveFlights { get; set; }
    }
}
