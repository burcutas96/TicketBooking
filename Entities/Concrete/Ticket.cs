using Core.Entities;

namespace Entities.Concrete
{
    public class Ticket : BaseEntity
    {
        public int FlightId { get; set; }
        public float Price { get; set; }
        public float Surcharge { get; set; }
        public float TaxRatio { get; set; }
        public string Currency { get; set; }
        public PassengerType PassengerType { get; set; }


        public Flight Flight { get; set; }
    }

    public enum PassengerType
    {
        ADULT,
        CHILD,
        BABY
    }
}
