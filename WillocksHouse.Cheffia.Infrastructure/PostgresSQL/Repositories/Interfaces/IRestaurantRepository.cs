using WillocksHouse.Cheffia.Domain.Entities;

namespace WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Interfaces;

public interface IRestaurantRepository
{
    Task<Restaurant?> Get(Guid id);
    Task<IEnumerable<Restaurant>> GetAll();
    Task<Restaurant?> Add(Restaurant restaurant);
    Task<Restaurant?> Update(Restaurant restaurant);
    Task Delete(Guid id);
}