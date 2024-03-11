
using Microsoft.EntityFrameworkCore;
using SITechnicalTest_API.Data;

namespace SITechnicalTest_API.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _dbContext;
        internal DbSet<T> _dbSet { get; set; }
        protected readonly ILogger _logger;

        public GenericRepository(ApplicationDbContext context, ILogger logger )
        {
            _dbContext = context;
            _logger = logger; 
            this._dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByID(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual  async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }
    }
}
