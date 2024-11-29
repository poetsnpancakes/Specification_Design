using SD_Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SD_Core.Interfaces
{
     public interface IRepository<T> where T : class
     {
         Task<T> GetByIdAsync(int id);
         Task<List<T>> GetAllAsync();

         IEnumerable<T> FindWithSpecificationPattern(BaseSpecification<T> specification = null);
     }
   /* public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindById(int id);

        IEnumerable<TEntity> Find(ISpecification<TEntity> specification = null);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        bool Contains(ISpecification<TEntity> specification = null);
        bool Contains(Expression<Func<TEntity, bool>> predicate);

        int Count(ISpecification<TEntity> specification = null);
        int Count(Expression<Func<TEntity, bool>> predicate);
    }*/
}
