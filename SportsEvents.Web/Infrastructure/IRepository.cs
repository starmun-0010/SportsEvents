using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SportsEvents.Web.Models;

namespace SportsEvents.Web.Infrastructure
{
    public interface IRepository<T>
    {
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<long> CountAsync();
        Task<List<T>> AllAsync();
        Task<T> GetAsync(int id);
        Task<int> AddAsync(T entity);
        Task<T> GetAsync<TK>(TK contactDetailsId);
        Task<int> Update(T entity);
        int Count(Func<T, bool> pradicate);
    }
}