using Core.Entities;

namespace Entities.Concrete
{
    public class Airline : BaseEntity
    {
        public string Code { get; set; }
        public string? Name { get; set; }

    }
}
