using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SniffHikesDbContext _dbContext;
        private readonly DbSet<T> _targetTable;
        private readonly ILogger<BaseRepository<T>> _logger;

        public BaseRepository(SniffHikesDbContext context, ILogger<BaseRepository<T>> logger)
        {
            _dbContext = context;
            _targetTable = _dbContext.Set<T>();
            _logger = logger;
        }

        public async Task<bool> AddAsync(T toAdd)
        {
            _targetTable.Add(toAdd);
            return await SaveChangesAsync();
        }

        public Task<bool> DeleteAsync(T toDelete)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T toUpdate)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbUpdateException)
            {
                _logger.LogError(dbUpdateException.Message);
                return false;
            }
        }
    }
}
