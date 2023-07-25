using Core.Entities;

namespace Entities.Concrete
{
    public class PriceDetail : BaseEntity
    {
        public int id { get; set; }
        public int base_price_id { get; set; }
        public int total_tax_id { get; set; }
        public int surcharge_id { get; set; }
        public int sales_price_id { get; set; }
    }
}
