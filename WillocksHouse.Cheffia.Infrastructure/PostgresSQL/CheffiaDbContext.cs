using Microsoft.EntityFrameworkCore;
using WillocksHouse.Cheffia.Domain.Entities;

namespace WillocksHouse.Cheffia.Infrastructure.PostgresSQL;

public class CheffiaDbContext : DbContext
{
    public CheffiaDbContext(DbContextOptions<CheffiaDbContext> options) : base(options)
    {
    }

    public CheffiaDbContext() : base(new DbContextOptionsBuilder<CheffiaDbContext>()
        .UseNpgsql("Host=localhost;Database=cheffia_db_postgres;Username=my_user;Password=my_pw;Port=5432")
        .Options)
    {
    }

    public DbSet<Owner> Owners { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Menu> Menus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>().HasKey(x => x.Id);
        modelBuilder.Entity<Restaurant>().HasKey(x => x.Id);
        modelBuilder.Entity<Dish>().HasKey(x => x.Id);
        modelBuilder.Entity<Menu>().HasKey(x => x.Id);
    }
}