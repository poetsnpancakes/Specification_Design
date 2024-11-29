using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SD_Core.Specifications
{
    /* public class BaseSpecifcation<T> : ISpecification<T>
     {
         public BaseSpecifcation()
         {
         }
         public BaseSpecifcation(Expression<Func<T, bool>> criteria)
         {
             Criteria = criteria;
         }
         public Expression<Func<T, bool>> Criteria { get; }
         public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
         public Expression<Func<T, object>> OrderBy { get; private set; }
         public Expression<Func<T, object>> OrderByDescending { get; private set; }
         public void AddInclude(Expression<Func<T, object>> includeExpression)
         {
             Includes.Add(includeExpression);
         }
         public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
         {
             OrderBy = orderByExpression;
         }
         public void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
         {
             OrderByDescending = orderByDescExpression;
         }
     }*/
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public BaseSpecification()
        {

        }
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public Expression<Func<T, object>> GroupBy { get; private set; }

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; } = false;

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        /* protected virtual void ApplyPaging(int skip, int take)
         {
             Skip = skip;
             Take = take;
             IsPagingEnabled = true;
         }*/
        protected virtual void ApplyPaging(int pageNumber, int pageSize )
        {
            // Ensure that the page number and page size are positive values
            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }

            if (pageSize <= 0 || pageSize > 100) // Optionally cap page size for performance
            {
                pageSize = 10;
            }

            // Calculate the number of items to skip and take
            Skip = (pageNumber - 1) * pageSize;
            Take = pageSize;
            IsPagingEnabled = true;
        }


        protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected virtual void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }

    }
}
