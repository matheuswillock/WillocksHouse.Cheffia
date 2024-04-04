using Microsoft.Extensions.Logging;
using WillocksHouse.Cheffia.Application.Library;
using WillocksHouse.Cheffia.Application.MenuUseCases.MenuDto;
using WillocksHouse.Cheffia.Application.OwnerUseCases;
using WillocksHouse.Cheffia.Application.RestaurantUseCases.RestaurantDto;
using WillocksHouse.Cheffia.Domain.Entities;
using WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Interfaces;

namespace WillocksHouse.Cheffia.Application.RestaurantUseCases;

public class RestaurantUseCase : IRestaurantUseCase
{
    private readonly IOutput _output;
    private readonly ILogger<RestaurantUseCase> _logger;
    private readonly IOwnerRepository _ownerRepository;
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMenuRepository _menuRepository;
    
    public RestaurantUseCase(IOutput output, ILogger<RestaurantUseCase> logger, 
        IOwnerRepository ownerRepository, IRestaurantRepository restaurantRepository, IMenuRepository menuRepository)
    {
        _output = output;
        _logger = logger;
        _ownerRepository = ownerRepository;
        _restaurantRepository = restaurantRepository;
        _menuRepository = menuRepository;
    }
    
    public async Task<IOutput> CreateRestaurant(RestaurantInputDto restaurantInput)
    {
        try
        {
            var getOwnerByEmail = await _ownerRepository.GetOwnerByEmail(restaurantInput.OwnerEmail);
            
            if (getOwnerByEmail == null)
            {
                _logger.LogError("RestaurantUseCase::CreateRestaurant - An Error occurred while creating the restaurant - error: Owner not found");
                _output.AddErrorMessage("An Error occurred while creating the restaurant - error: Owner not found");
                return _output;
            }
            
            var menuCreate = await _menuRepository.Add(new Menu());
            
            if (menuCreate == null)
            {
                _logger.LogError("RestaurantUseCase::CreateRestaurant - An Error occurred while creating the restaurant - error: Menu not created");
                _output.AddErrorMessage("An Error occurred while creating the restaurant - error: Menu not created");
                return _output;
            }
            
            Restaurant restaurant = new(getOwnerByEmail.Id, restaurantInput.RestaurantName, menuCreate.Id);
            
            var restaurantCreate = await _restaurantRepository.Add(restaurant);
            
            if (restaurantCreate == null)
            {
                _logger.LogError("RestaurantUseCase::CreateRestaurant - An Error occurred while creating the restaurant");
                _output.AddErrorMessage("An Error occurred while creating the restaurant");
                return _output;
            }
            
            MenuOutputDto menuOutputDto = new(menuCreate.Dishes);
            
            RestaurantOutputDto restaurantOutput = new(restaurantCreate.Name, getOwnerByEmail.Email, menuOutputDto);
            
            _output.AddResult(restaurantOutput);
            
            return _output;
        }
        catch (Exception e)
        {
            _logger.LogError($"RestaurantUseCase::CreateRestaurant - An Error occurred while creating the restaurant - error: {e}", e.Message);
            _output.AddErrorMessage($"RestaurantUseCase::CreateRestaurant - An Error occurred while creating the restaurant - error: {e.Message}");
            return _output;
        }
    }
}