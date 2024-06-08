using DomainEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _dbSet;
        private readonly BankManagementSystemContext context;

        public Repository()
        {
            this.context = new BankManagementSystemContext();
            this._dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _dbSet.Add(entity);
            context.SaveChanges();
        }

        public bool Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            context.Update(entity);
            context.SaveChanges();
            return true;
        }

        public bool Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            _dbSet.Remove(entity);
            context.SaveChanges();
            return true;
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var item in includes)
            {
                query = query.Include(item);   
            }
            return query;
        }
    }
}
