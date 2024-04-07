using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services
{
    public interface IDogService
    {
        Task<ResultModel<Dog>> GetByIdAsync(int id);
        Task<ResultModel<User>> AddDogAsync(DogCreateRequestModel dogCreateRequestModel);
        Task<ResultModel<Dog>> DeleteDogAsync(int dogId);
    }
}
