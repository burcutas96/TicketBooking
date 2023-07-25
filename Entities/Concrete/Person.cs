using Core.Entities;

namespace Entities.Concrete
{
    public class Person : BaseEntity
    {
        public int id { get; set; }
        public string first_name { get; set; } 
        public string last_name { get; set; } 
    }
}
