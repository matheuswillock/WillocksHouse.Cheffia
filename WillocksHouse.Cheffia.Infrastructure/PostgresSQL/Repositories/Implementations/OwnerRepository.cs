using Microsoft.EntityFrameworkCore;
using WillocksHouse.Cheffia.Domain.Entities;
using WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Interfaces;

namespace WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Implementations;

public class OwnerRepository : IOwnerRepository
{
    private readonly CheffiaDbContext _context;

    public OwnerRepository(CheffiaDbContext context)
    {
        _context = context;
    }

    public async Task<Owner?> GetOwner(Guid id)
    {
        return await _context.Owners.FindAsync(id);
    }

    public async Task<IEnumerable<Owner>> GetAllOwners()
    {
        return await _context.Owners.ToListAsync();
    }

    public async Task AddOwner(Owner owner)
    {
        _context.Owners.Add(owner);
        await _context.SaveChangesAsync();
    }

    public async Task<Owner?> GetOwnerByEmail(string email)
    {
        return await _context.Owners.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task UpdateOwner(Owner owner)
    {
        _context.Entry(owner).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOwner(Guid id)
    {
        var owner = await _context.Owners.FindAsync(id);
        if (owner != null)
        {
            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();
        }
    }
}