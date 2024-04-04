using Microsoft.EntityFrameworkCore;
using WillocksHouse.Cheffia.Domain.Entities;
using WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Interfaces;

namespace WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Implementations;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly CheffiaDbContext _context;

    public RestaurantRepository(CheffiaDbContext context)
    {
        _context = context;
    }

    public async Task<Restaurant?> Get(Guid id)
    {
        return await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Restaurant>> GetAll()
    {
        return await _context.Restaurants.ToListAsync();
    }

    public async Task<Restaurant?> Add(Restaurant restaurant)
    {
        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();
        return await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == restaurant.Id);
    }

    public async Task<Restaurant?> Update(Restaurant restaurant)
    {
        _context.Restaurants.Update(restaurant);
        await _context.SaveChangesAsync();
        return await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == restaurant.Id);
    }

    public async Task Delete(Guid id)
    {
        var restaurant = await _context.Restaurants.FirstOrDefaultAsync(x=> x.Id == id);

        if (restaurant == null) return;

        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();
    }
}