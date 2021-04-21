using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Msa.Dal.Interfaces
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(T entity, IEnumerable<string> fields);
        void Update(IEnumerable<T> enities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        TResult Find<TResult>(Expression<Func<T, bool>> filter);
        IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter);
    }
}
