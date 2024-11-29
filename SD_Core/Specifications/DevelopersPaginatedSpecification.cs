using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Core.Specifications
{
    public class DevelopersPaginatedSpecification : BaseSpecification<Developer>
    {
        public DevelopersPaginatedSpecification(int x,int y)
        {
            ApplyPaging(x,y);

        }
    }
}
