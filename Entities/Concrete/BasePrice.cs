using Core.Entities;

namespace Entities.Concrete
{
    public class BasePrice : BaseEntity
    {
        public int id { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
    }
}
