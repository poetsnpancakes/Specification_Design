using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SD_Core.Specifications
{
    public class AndSpecification<T> : BaseSpecification<T>
    {
        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
            : base(CombineCriteria(left.Criteria, right.Criteria))
        {
            // Combine Includes from both specifications
            Includes.AddRange(left.Includes);
            Includes.AddRange(right.Includes);

            // Use OrderBy or OrderByDescending from the left specification if set,
            // otherwise, fall back to the right specification
          //  OrderBy = left.OrderBy ?? right.OrderBy;
           // OrderByDescending = left.OrderByDescending ?? right.OrderByDescending;
        }

        private static Expression<Func<T, bool>> CombineCriteria(
            Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            // Create a parameter to represent the entity type (T)
            var param = Expression.Parameter(typeof(T));

            // Combine the two expressions using an AND condition
            var body = Expression.AndAlso(
                Expression.Invoke(left, param),
                Expression.Invoke(right, param)
            );

            // Return the combined lambda expression
            return Expression.Lambda<Func<T, bool>>(body, param);
        }
    }

}
