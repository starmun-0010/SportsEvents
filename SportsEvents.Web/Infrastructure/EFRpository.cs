using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        protected SportsEventsDbContext DbContext => _dbContext ?? (_dbContext = new SportsEventsDbContext());

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            if (typeof(T) == typeof(Event))
            {
                return DbContext.Set<T>().Include("Sport").Include("EventType").Include("Organizer").Include("Pictures").Where(predicate);
            }
            return DbContext.Set<T>().Where(predicate);
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Count(predicate);
        }

        public long Count()
        {
            return DbContext.Set<Event>().LongCount();
        }
    }
}
