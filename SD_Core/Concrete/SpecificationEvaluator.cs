using Data.Entities;
using Microsoft.EntityFrameworkCore;
using SD_Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Core.Concrete
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            // Apply filter criteria
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            // Apply eager loading
            foreach (var include in specification.Includes)
            {
                query = query.Include(include);
            }

            // Apply sorting
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }
            else if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            return query;
        }
    }
}
















  /*  public class SpecificationEvaluator<T> //where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, BaseSpecification<T> specification)
        {
            var query = inputQuery;

            // modify the IQueryable using the specification's criteria expression
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }
  */
// Includes all expression-based includes
/*  query = specification.Includes.Aggregate(query,
                          (current, include) => current.Include(include));

  // Include any string-based include statements
  query = specification.IncludeStrings.Aggregate(query,
                          (current, include) => current.Include(include));*/

// Apply ordering if expressions are set
/*  if (specification.OrderBy != null)
  {
      query = query.OrderBy(specification.OrderBy);
  }
  else if (specification.OrderByDescending != null)
  {
      query = query.OrderByDescending(specification.OrderByDescending);
  }*/

// Apply paging if enabled
/*  if (specification.isPagingEnabled)
  {
      query = query.Skip(specification.Skip)
                   .Take(specification.Take);
  }*/
/* return query;
}
}
}*/
