using System;
using System.Linq;
using System.Linq.Expressions;
using SportsEvents.Web.Models;

namespace SportsEvents.Web.Infrastructure
{
    public interface IRepository<T>
    {
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        int Count(Expression<Func<T, bool>> predicate);
        long Count();

    }
}