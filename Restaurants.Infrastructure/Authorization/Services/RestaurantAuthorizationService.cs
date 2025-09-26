using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Interfaces;



namespace Restaurants.Infrastructure.Authorization.Services
{
    public class RestaurantAuthorizationService(ILogger<RestaurantAuthorizationService> logger, IUserContext userContext) : IRestaurantAuthorizationService
    {
        public bool Authorize(Restaurant restaurant, RessourceOperation ressourceOperation)
        {
            var user = userContext.GetCurrentUser();

            logger.LogInformation("Authorizing user {userEmail}, to {Operation} for restaurant {RestaurantName}", user!.Email, ressourceOperation, restaurant.Name);

            if (ressourceOperation == RessourceOperation.Read || ressourceOperation == RessourceOperation.Create)
            {
                logger.LogInformation("Create/read operation - successful authorization");
                return true;
            }

            if (ressourceOperation == RessourceOperation.Delete || user.IsInRole(UserRoles.Admin))
            {
                logger.LogInformation("Admin user, delete operation - successful authorization");
                return true;
            }


            if ((ressourceOperation == RessourceOperation.Delete || ressourceOperation == RessourceOperation.Create) && user.Id == restaurant.OwnerId)
            {
                logger.LogInformation("Restaurant owner, successful authorization");
                return true;
            }
            return false;
        }
    }
}
