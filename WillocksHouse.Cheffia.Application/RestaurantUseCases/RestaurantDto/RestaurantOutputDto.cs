using WillocksHouse.Cheffia.Application.MenuUseCases.MenuDto;

namespace WillocksHouse.Cheffia.Application.RestaurantUseCases.RestaurantDto;

public record RestaurantOutputDto(string RestaurantName, string OwnerEmail, MenuOutputDto Menu);