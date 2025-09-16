using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; } = default!;
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public List<DishDto> Dishes { get; set; } = [];

        public static RestaurantDto? FromEntity(Restaurant? r)
        {
            if (r == null) return null;
            return new RestaurantDto()
            {
                Id = r.Id,
                Name = r.Name,
                Category = r.Category,
                Description = r.Description,
                City = r.Address?.City,
                HasDelivery = r.HasDelivery,
                PostalCode = r.Address?.PostalCode,
                Street = r.Address?.Street,
                Dishes = [.. r.Dishes.Select(DishDto.FromEntity)]
            };
        }
    }
}
