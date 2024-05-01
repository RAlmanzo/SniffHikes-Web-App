using Microsoft.AspNetCore.Identity;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(string id);
        IQueryable<User> GetAll();
        Task<IEnumerable<User>> GetAllAsync();
        Task<IdentityResult> DeleteAsync(User toDelete);
        Task<IdentityResult> AddAsync(User toAdd, string password);
        Task<bool> UpdateAsync(User toUpdate);
        Task<bool> CheckIfExistsAsync(string id);
        IQueryable<Dog> GetAllUserDogs(string id);
        Task<IdentityResult> ResetPasswordAsync(User toUpdate, string currentPassword, string newPassword);
    }
}
