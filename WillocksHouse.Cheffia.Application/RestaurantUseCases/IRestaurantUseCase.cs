using WillocksHouse.Cheffia.Application.Library;
using WillocksHouse.Cheffia.Application.RestaurantUseCases.RestaurantDto;

namespace WillocksHouse.Cheffia.Application.RestaurantUseCases;

public interface IRestaurantUseCase
{
    Task<IOutput> CreateRestaurant(RestaurantInputDto restaurantInput);
}