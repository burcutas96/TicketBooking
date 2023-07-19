using Entities.Concrete.Common;
using Entities.Concrete.Enums;

namespace Entities.Concrete;
public class Passenger : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public PassengerType Type { get; set; }
}
