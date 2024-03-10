using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<ResultModel<IEnumerable<User>>> GetAllAsync();
        Task<ResultModel<User>> GetByIdAsync(Guid id);
        //Task<ResultModel<User>> CreateRecordAsync(EventCreateRequestModel eventCreateRequestModel);
        //Task<ResultModel<User>> UpdateRecordAsync(EventUpdateRequestModel eventUpdateRequestModel);
        Task<ResultModel<User>> DeleteRecordAsync(int id);
    }
}
