using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using SportsEvents.Web.Models;
using SportsEvents.Web.Repository;

namespace SportsEvents.Web.Infrastructure
{
    public class EFRpository<T> : IRepository<T> where T : class
    {
        private SportsEventsDbContext _dbContext;

        public EFRpository(SportsEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected SportsEventsDbContext DbContextSingelton => _dbContext ?? (_dbContext = new SportsEventsDbContext());
        protected SportsEventsDbContext DbContext => new SportsEventsDbContext();

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            if (typeof(T) == typeof(Event))
            {
                return DbContext.Set<T>().Include("Pictures").Where(predicate);
            }
            return DbContext.Set<T>().Where(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().CountAsync(predicate);
        }

        public async Task<long> CountAsync()
        {
            return await DbContext.Set<T>().LongCountAsync();
        }

        public async Task<List<T>> AllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();

        }

        public async Task<T> GetAsync(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> AddAsync(T entity)
        {
            DbContextSingelton.Set<T>().Add(entity);
            return await DbContextSingelton.SaveChangesAsync();
        }

        public async Task<T> GetAsync<TK>(TK id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> Update(T entity)
        {
            DbEntityEntry entry = DbContextSingelton.Entry(entity);
            DbContextSingelton.Set<T>().Attach(entity);

            entry.State = EntityState.Modified;


            return await DbContextSingelton.SaveChangesAsync();
        }

        public int Count(Func<T, bool> pradicate)
        {
            return DbContext.Set<T>().Count();
        }
    }
}
