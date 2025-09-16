using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger) : IRestaurantsService
    {
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            logger.LogInformation("Appel du service");
            var restaurants = await restaurantsRepository.GetAllAsync();
            var restaurantsDto = restaurants.Select(RestaurantDto.FromEntity);
            return restaurantsDto!;
        }

        public async Task<RestaurantDto?> GetRestaurantById(int id)
        {
            logger.LogInformation("Appel du service");
            var restaurant = await restaurantsRepository.GetByIdAsync(id);
            var restaurantDto = RestaurantDto.FromEntity(restaurant);
            return restaurantDto;
        }
    }
}
