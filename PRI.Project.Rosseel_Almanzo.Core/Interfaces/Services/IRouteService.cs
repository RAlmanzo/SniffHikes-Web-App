using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services
{
    public interface IRouteService
    {
        Task<ResultModel<IEnumerable<Route>>> GetAllAsync();
        Task<ResultModel<Route>> GetByIdAsync(int id);
        Task<ResultModel<Route>> CreateRouteAsync(RouteCreateRequestModel routeCreateRequestModel);
        Task<ResultModel<Route>> UpdateRouteAsync(RouteUpdateRequestModel routeUpdateRequestModel);
        Task<ResultModel<Route>> DeleteRouteAsync(int id);
        Task<bool> CheckIfExistsAsync(int id);
        Task<ResultModel<Route>> AddImage(int id, string imagePath);
        Task<ResultModel<Route>> DeleteImage(int id, int imageId);
    }
}
