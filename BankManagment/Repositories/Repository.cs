using DomainEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
