using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Core.Specifications
{
    public class DeveloperByIncomeSpecification : BaseSpecification<Developer>
    {
       public DeveloperByIncomeSpecification(int minIncome)
             :base(Developer => Developer.EstimatedIncome > minIncome)
        {
            // ApplyOrderByDescending(x => x.EstimatedIncome>y);
           // Criteria = Developer => Developer.EstimatedIncome > y;
        }
    }
}
