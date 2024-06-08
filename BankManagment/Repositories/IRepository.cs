using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        IQueryable<T> GetAll();
        // IEnumerable<T> GetAll2();

        T GetById(int id);

        IQueryable<T> Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
    }
}
