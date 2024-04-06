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
        private readonly IUserRepository _userRepository;

        public RouteService(IRouteRepository routeRepository, IUserRepository userRepository)
        {
            _routeRepository = routeRepository;
            _userRepository = userRepository;
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

        public async Task<ResultModel<Route>> CreateRouteAsync(RouteCreateRequestModel routeCreateRequestModel)
        {
            //check if orginazerid exists
            if (_userRepository.GetAll().Any(g => g.Id == routeCreateRequestModel.OrganizerId) == false)
            {
                return new ResultModel<Route>
                {
                    Success = false,
                    Errors = new List<string> { "Orginazer does not exist!" }
                };
            }

            //fill imageslist with added image
            var imageList = new List<Image>();
            if (routeCreateRequestModel.Images.Count() > 0)
            {
                foreach (var image in routeCreateRequestModel.Images)
                {
                    var currentImage = new Image { File = image };
                    imageList.Add(currentImage);
                }
            }

            //create new route
            var newRoute = new Route
            {
                Title = routeCreateRequestModel.Title,
                Description = routeCreateRequestModel.Description,
                DateCreated = DateTime.Now,
                Address = new Address
                {
                    Street = routeCreateRequestModel.Street,
                    City = routeCreateRequestModel.City,
                    State = routeCreateRequestModel.State,
                    Country = routeCreateRequestModel.Country,
                },
                UserId = routeCreateRequestModel.OrganizerId,
                Images = imageList,
            };

            //call the eventsrepo addAsync method for the event
            var result = await _routeRepository.AddAsync(newRoute);
            if (result)
            {
                var createdRoute = await GetByIdAsync(newRoute.Id);
                return new ResultModel<Route>
                {
                    Success = true,
                    Value = createdRoute.Value,
                };
            }
            return new ResultModel<Route>
            {
                Success = false,
                Errors = new List<string> { "Event not created!" }
            };
        }
    }
}
