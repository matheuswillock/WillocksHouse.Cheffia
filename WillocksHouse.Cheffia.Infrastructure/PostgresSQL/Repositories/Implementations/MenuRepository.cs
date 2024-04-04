using Microsoft.EntityFrameworkCore;
using WillocksHouse.Cheffia.Domain.Entities;
using WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Interfaces;

namespace WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Implementations;

public class MenuRepository : IMenuRepository
{
    private readonly CheffiaDbContext _context;

    public MenuRepository(CheffiaDbContext context)
    {
        _context = context;
    }

    public async Task<Menu?> Get(Guid id)
    {
        return await _context.Menus.FindAsync(id);
    }

    public async Task<IEnumerable<Menu>> GetAll()
    {
        return await _context.Menus.ToListAsync();
    }

    public async Task<Menu?> Add(Menu menu)
    {
        _context.Menus.Add(menu);
        await _context.SaveChangesAsync();
        return await _context.Menus.FirstOrDefaultAsync(x => x.Id == menu.Id);
    }

    public async Task<Menu?> Update(Menu menu)
    {
        _context.Menus.Update(menu);
        await _context.SaveChangesAsync();
        return await _context.Menus.FirstOrDefaultAsync(x => x.Id == menu.Id);
    }

    public async Task Delete(Guid id)
    {
        var menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);

        if (menu == null) return;

        _context.Menus.Remove(menu);
        await _context.SaveChangesAsync();
    }
}