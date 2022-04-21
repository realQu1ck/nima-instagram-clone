using Microsoft.EntityFrameworkCore;
using Nima.Instagram.Server.API.Core.Data.Database;
using System.Linq.Expressions;

namespace Nima.Instagram.Server.API.Core.Services.UnitOFWork.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected InstagramDB context;
        internal DbSet<T> table;
        public readonly ILogger logger;

        public GenericRepository(InstagramDB _context, ILogger logger)
        {
            this.context = _context;
            this.logger = logger;
            this.table = context.Set<T>();
        }

        public async Task<bool> AddAsync(T model)
        {
            try
            {
                await table.AddAsync(model);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in Add Process {ex}", typeof(T));
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await table.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in All Process {ex}", typeof(T));
                return null;
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await table.AnyAsync(expression);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in Any Process {ex}", typeof(T));
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var item = await this.GetByIdAsync(id);
                if (item != null)
                {
                    table.Remove(item);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in Delete Process {ex}", typeof(T));
                return false;
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                var item = await table.FindAsync(id);
                if (item != null)
                    return item;

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in GetById Process {ex}", typeof(T));
                return null;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var item = await table.Where(expression).ToListAsync();
                if (item != null)
                    return item;

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in Select Process {ex}", typeof(T));
                return null;
            }
        }

        public virtual Task<bool> UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Where(Expression<Func<T, bool>> expression)
        {
            try
            {
                var item = await table.Where(expression).FirstOrDefaultAsync();
                if (item != null)
                    return item;

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in Where Process {ex}", typeof(T));
                return null;
            }
        }
    }
}
