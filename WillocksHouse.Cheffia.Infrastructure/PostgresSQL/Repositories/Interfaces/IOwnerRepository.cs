using WillocksHouse.Cheffia.Domain.Entities;

namespace WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Interfaces;

public interface IOwnerRepository
{
    Task<Owner?> GetOwner(Guid id);
    Task<IEnumerable<Owner>> GetAllOwners();
    Task AddOwner(Owner owner);
    Task UpdateOwner(Owner owner);
    Task DeleteOwner(Guid id);
    Task<Owner?> GetOwnerByEmail(string email);
}