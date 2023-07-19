using Entities.Concrete.Common;

namespace Entities.Concrete;
public class Flight : BaseEntity
{
    public int DeparturePortId { get; set; }
    public int ArrivePortId { get; set; }
    public string AirlineCode { get; set; } 
    public string Airline { get; set; }
    public DateTime DepartureDate { get; set; }//15:30
    public DateTime ArriveDate { get; set; }//16:30

    public Airport DeparturePort { get; set; }//ankaradan
    public Airport ArrivePort { get; set; }//kastamonu
}
