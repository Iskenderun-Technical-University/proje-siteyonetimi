using ResidenceManagement.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Contracts.Repositories.Commons
{
    public interface IRepositoryBase<T> where T : EntityBase
    {

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params string[] includeStrings);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate =null, string includeString = null, params string[] includeStrings);

        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       bool disableTracking = true,
                                       string includeString = null, params string[] includeStrings);
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<int> ids);

        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);


        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}