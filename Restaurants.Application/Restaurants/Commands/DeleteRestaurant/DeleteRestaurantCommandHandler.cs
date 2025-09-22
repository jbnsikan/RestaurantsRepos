using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger, IRestaurantsRepository restaurantsRepository)
        : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Delete restaurant with id : {request.Id}");
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"Restaurant with {request.Id} doesn't exist");
            await restaurantsRepository.Delete(restaurant);
        }
    }
}
