using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().CountAsync(predicate);
        }

        public Task<long> CountAsync()
        {
            return DbContext.Set<Event>().LongCountAsync();
        }
    }
}
