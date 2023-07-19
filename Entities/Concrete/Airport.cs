using Entities.Concrete.Common;

namespace Entities.Concrete;
public class Airport : BaseEntity
{
    public string Code { get; set; }
    public string Explanation { get; set; }
    public string ExplanationOnly { get; set; }
    public string CodeOnly { get; set; }
    public ICollection<Flight> Flights { get; set; }
}