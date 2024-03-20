using Microsoft.Extensions.DependencyInjection;
using WillocksHouse.Cheffia.Application.Library;
using WillocksHouse.Cheffia.Application.OwnerUseCases;

namespace WillocksHouse.Cheffia.Application.DependencyInjection.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IOwnerUseCase, OwnerUseCase>();
        services.AddScoped<IOutput, Output>();
        return services;
    }
}