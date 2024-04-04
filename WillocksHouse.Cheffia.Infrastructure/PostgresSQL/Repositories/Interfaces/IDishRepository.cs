using WillocksHouse.Cheffia.Domain.Entities;

namespace WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Interfaces;

public interface IDishRepository
{
    Task<Dish?> Get(Guid id);
    Task<IEnumerable<Dish>> GetAll();
    Task<Dish?> Add(Dish dish);
    Task<Dish?> Update(Dish dish);
    Task Delete(Guid id);
}