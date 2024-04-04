using Microsoft.EntityFrameworkCore;
using WillocksHouse.Cheffia.Application.DependencyInjection.Extensions;
using WillocksHouse.Cheffia.Infrastructure.DepencencyInjection.Extensions;
using WillocksHouse.Cheffia.Infrastructure.PostgresSQL;
using WillocksHouse.Cheffia.WebApi.Controllers.Validations;
using FluentValidation.AspNetCore;

namespace WillocksHouse.Cheffia.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddControllers().AddFluentValidation(fv => 
            fv.RegisterValidatorsFromAssemblyContaining<OwnerValidator>());

        builder.Services.AddDbContext<CheffiaDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddInfrastructures();
        builder.Services.AddApplication();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}