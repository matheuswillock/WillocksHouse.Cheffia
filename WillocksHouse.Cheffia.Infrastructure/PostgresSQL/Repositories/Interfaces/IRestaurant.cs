using WillocksHouse.Cheffia.Domain.Entities;

public interface IRestaurantRepository
{
    Task<Restaurant?> Get(Guid id);
    Task<IEnumerable<Restaurant>> GetAll();
    Task<Restaurant?> Add(Restaurant restaurant);
    Task<Restaurant?> Update(Restaurant restaurant);
    Task Delete(Guid id);
}