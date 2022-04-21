using System.Linq.Expressions;

namespace Nima.Instagram.Server.API.Core.Services.UnitOFWork.Generic
{
    public interface IGenericRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> AddAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<bool> DeleteAsync(Guid Id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> expression);
        Task<T> Where(Expression<Func<T, bool>> expression);
    }
}
