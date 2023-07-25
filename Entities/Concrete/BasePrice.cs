using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BasePrice : BaseEntity
    {
        public int id { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
    }
}
