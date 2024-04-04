using Microsoft.EntityFrameworkCore;
using WillocksHouse.Cheffia.Domain.Entities;
using WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Interfaces;
namespace WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Implementations;

public class DishRepository : IDishRepository
{
    private readonly CheffiaDbContext _context;

    public DishRepository(CheffiaDbContext context)
    {
        _context = context;
    }

    public async Task<Dish?> Get(Guid id)
    {
        return await _context.Dishes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Dish>> GetAll()
    {
        return await _context.Dishes.ToListAsync();
    }

    public async Task<Dish?> Add(Dish dish)
    {
        _context.Dishes.Add(dish);
        await _context.SaveChangesAsync();
        return await _context.Dishes.FirstOrDefaultAsync(x => x.Id == dish.Id);
    }

    public async Task<Dish?> Update(Dish dish)
    {
        _context.Dishes.Update(dish);
        await _context.SaveChangesAsync();
        return await _context.Dishes.FirstOrDefaultAsync(x => x.Id == dish.Id);
    }

    public async Task Delete(Guid id)
    {
        var dish = await _context.Dishes.FindAsync(id);

        if (dish == null) return;

        _context.Dishes.Remove(dish);
        await _context.SaveChangesAsync();
    }

}