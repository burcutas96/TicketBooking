namespace Entities.Concrete;

public class Ticket
{
    public int FlightId { get; set; }
    public int PassengerId { get; set; }
    public float Price { get; set; }
    public float Tax { get; set; }
    public float Surcharge { get; set; }
}
