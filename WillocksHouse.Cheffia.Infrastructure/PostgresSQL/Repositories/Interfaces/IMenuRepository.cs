using WillocksHouse.Cheffia.Domain.Entities;

namespace WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Interfaces;

public interface IMenuRepository
{
    Task<Menu?> Get(Guid id);
    Task<IEnumerable<Menu>> GetAll();
    Task<Menu?> Add(Menu menu);
    Task<Menu?> Update(Menu menu);
    Task Delete(Guid id);
}