using Core.Entities;

namespace Entities.Concrete
{
    public class Ticket : BaseEntity
    {
        public int FlightId { get; set; }
        public float? SalesPrice { get; set; } 
        public float Surcharge { get; set; }
        public float TaxAmount { get; set; }
        public PassengerType PassengerType { get; set; }
        public string Currency { get; set; }
        public float BasePrice { get; set; }
    }

    public enum PassengerType
    {
        ADULT,
        CHILD,
        BABY
    }
}
