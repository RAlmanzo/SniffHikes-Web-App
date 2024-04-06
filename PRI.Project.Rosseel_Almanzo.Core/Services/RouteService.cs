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
        private readonly IAddressRepository _addressRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ICommentRepository _commentRepository;

        public RouteService(IRouteRepository routeRepository, IUserRepository userRepository, IAddressRepository addressRepository, IImageRepository imageRepository, ICommentRepository commentRepository)
        {
            _routeRepository = routeRepository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _imageRepository = imageRepository;
            _commentRepository = commentRepository;
        }

        public async Task<ResultModel<Route>> DeleteRouteAsync(int id)
        {
            //get the route
            var route = await _routeRepository.GetByIdAsync(id);
            //check if route exists
            if (route == null)
            {
                return new ResultModel<Route>
                {
                    Success = false,
                    Errors = new List<string> { "Route does not exist!" }
                };
            }

            //get route address
            var routeAddress = await _addressRepository.GetByIdAsync(route.AddressId);
            //get route comments
            var routeComments = _routeRepository.GetAllRouteComments(route.Id);
            //get route images
            var routeImages = _routeRepository.GetAllRouteImages(route.Id);
            //check if deleteAsync returns true
            if (await _routeRepository.DeleteAsync(route))
            {
                if (await _addressRepository.DeleteAsync(routeAddress))
                {
                    foreach (var image in routeImages)
                    {
                        await _imageRepository.DeleteAsync(image);
                    }
                    foreach (var comment in routeComments)
                    {
                        await _commentRepository.DeleteAsync(comment);
                    }
                    return new ResultModel<Route> { Success = true, };
                }             
            }

            //if not
            return new ResultModel<Route>
            {
                Success = false,
                Errors = new List<string> { "Some error occured!" }
            };
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
            eventResultModel.Errors = new List<string> { "No routes found" };
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
                routeResultModel.Errors = new List<string> { "No route found" };
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

            //call the routesrepo addAsync method
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
                Errors = new List<string> { "Route not created!" }
            };
        }

        public async Task<ResultModel<Route>> UpdateRouteAsync(RouteUpdateRequestModel routeUpdateRequestModel)
        {
            //check if organizerid exists
            if (_userRepository.GetAll().Any(g => g.Id == routeUpdateRequestModel.OrganizerId) == false)
            {
                return new ResultModel<Route>
                {
                    Success = false,
                    Errors = new List<string> { "Orginazer does not exist!" }
                };
            }

            //get the route
            var route = await _routeRepository.GetByIdAsync(routeUpdateRequestModel.Id);

            //update event
            route.Id = routeUpdateRequestModel.Id;
            route.Title = routeUpdateRequestModel.Title;
            route.Description = routeUpdateRequestModel.Description;
            route.Address.Street = routeUpdateRequestModel.Street;
            route.Address.City = routeUpdateRequestModel.City;
            route.Address.State = routeUpdateRequestModel.State;
            route.Address.Country = routeUpdateRequestModel.Country;
            route.UserId = routeUpdateRequestModel.OrganizerId;

            if (await _routeRepository.UpdateAsync(route))
            {
                return new ResultModel<Route>
                {
                    Success = true,
                    Value = route,
                };
            }
            return new ResultModel<Route>
            {
                Success = false,
                Errors = new List<string> { "Route update failed!" }
            };
        }

        public async Task<bool> CheckIfExistsAsync(int id)
        {
            return await _routeRepository.CheckIfExistsAsync(id);
        }

        public async Task<ResultModel<Route>> AddImageAsync(int id, string imagePath)
        {
            //check if route exists
            if (_routeRepository.GetAll().Any(g => g.Id == id) == false)
            {
                return new ResultModel<Route>
                {
                    Success = false,
                    Errors = new List<string> { "Route does not exist!" }
                };
            }

            //check if image is present
            var result = false;
            if (!string.IsNullOrWhiteSpace(imagePath))
            {
                var image = new Image { File = imagePath , RouteId = id};
                result = await _imageRepository.AddAsync(image);
            }

            if (result)
            {
                var updatedRoute = await GetByIdAsync(id);
                return new ResultModel<Route>
                {
                    Success = true,
                    Value = updatedRoute.Value,
                };
            }
            return new ResultModel<Route>
            {
                Success = false,
                Errors = new List<string> { "Route not created!" }
            };
        }
    }
}
