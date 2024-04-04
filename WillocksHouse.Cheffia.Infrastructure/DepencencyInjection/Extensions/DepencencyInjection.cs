using Microsoft.Extensions.DependencyInjection;
using WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Implementations;
using WillocksHouse.Cheffia.Infrastructure.PostgresSQL.Repositories.Interfaces;

namespace WillocksHouse.Cheffia.Infrastructure.DepencencyInjection.Extensions;

public static class DepencencyInjection
{
    public static IServiceCollection AddInfrastructures(this IServiceCollection services)
    {
        services.AddScoped<IOwnerRepository, OwnerRepository>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IDishRepository, DishRepository>();
        
        return services;
    }
}