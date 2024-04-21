using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SniffHikesDbContext _dbContext;
        protected readonly DbSet<User> _targetTable;
        private readonly ILogger<IUserRepository> _logger;

        public UserRepository(SniffHikesDbContext dbContext, ILogger<IUserRepository> logger)
        {
            _dbContext = dbContext;
            _targetTable = _dbContext.Set<User>();
            _logger = logger;
        }

        public async Task<bool> AddAsync(User toAdd)
        {
            _targetTable.Add(toAdd);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(User toDelete)
        {
            _targetTable.Remove(toDelete);
            return await SaveChangesAsync();
        }

        public IQueryable<User> GetAll()
        {
            return _targetTable.AsQueryable();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var data = await _targetTable
                .Include(u => u.Address)
                .Include(u => u.Comments)
                .Include(u => u.Dogs)
                .Include(u => u.Routes)
                .Include(u => u.OrganizedEvents)
                .Include(u => u.AttendingEvents)
                .ToListAsync();
            return data;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _targetTable
                .Include(u => u.Address)
                .Include(u => u.Comments)
                .Include(u => u.Dogs)
                .Include(u => u.Routes)
                .Include(u => u.OrganizedEvents)
                .Include(u => u.AttendingEvents)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> UpdateAsync(User toUpdate)
        {
            _targetTable.Update(toUpdate);
            return await SaveChangesAsync();
        }

        public IQueryable<Dog> GetAllUserDogs(string id)
        {
            var user = GetByIdAsync(id);

            return user.Result.Dogs.AsQueryable();
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

        public async Task<bool> CheckIfExistsAsync(string id)
        {
            return await _targetTable.AnyAsync(t => t.Id == id);
        }
    }
}
