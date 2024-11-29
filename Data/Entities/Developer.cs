using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Developer : BaseEntity
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }
        public int EstimatedIncome { get; set; }
        public Address Address { get; set; }
    }
}
