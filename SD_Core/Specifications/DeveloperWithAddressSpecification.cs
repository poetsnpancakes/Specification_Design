using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Core.Specifications
{
   public class DeveloperWithAddressSpecification : BaseSpecification<Developer>
    {
        public DeveloperWithAddressSpecification() : base()
        {
            AddInclude(x => x.Address);
        }
    }
  
}
