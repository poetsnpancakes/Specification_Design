using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Address : BaseEntity
    {
       
        public string City { get; set; }
        public string Street { get; set; }
    }
}
