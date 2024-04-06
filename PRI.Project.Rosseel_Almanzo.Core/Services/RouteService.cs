using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRI.Project.Rosseel_Almanzo.Core.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;

        public RouteService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public Task<ResultModel<Route>> DeleteRouteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultModel<IEnumerable<Route>>> GetAllAsync()
        {
            //get the routes
            var routes = await _routeRepository.GetAllAsync();
            //create new resultmodel
            var eventResultModel = new ResultModel<IEnumerable<Route>>();
            //check if count > 0
            if (routes.Count() > 0)
            {
                eventResultModel.Success = true;
                eventResultModel.Value = routes;
                return eventResultModel;
            }
            //if not
            eventResultModel.Errors = new List<string> { "No events found" };
            return eventResultModel;
        }

        public async Task<ResultModel<Route>> GetByIdAsync(int id)
        {
            //get the route
            var route = await _routeRepository.GetByIdAsync(id);
            //create new resultmodel
            var routeResultModel = new ResultModel<Route>();
            //check if exists
            if (route == null)
            {
                routeResultModel.Success = false;
                routeResultModel.Errors = new List<string> { "No event found" };
                return routeResultModel;
            }
            
            //if event exists
            routeResultModel.Success = true;
            routeResultModel.Value = route;
            return routeResultModel;
        }
    }
}
