using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Command;
using OrderService.Domain.DomainServices;
using OrderService.Infrastructure.Database;
using OrderService.Infrastructure.Database.Repository;
using OrderService.Infrastructure.ExternalServices;

namespace OrderService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();

        // External services
        services.AddHttpClient<ICustomerProxy, CustomerProxy>(client =>
        {
            var uri = configuration.GetSection("ExternalServices:Customer:Uri").Value;
            Debug.Assert(string.Empty != null, "String.Empty != null");
            client.BaseAddress = new Uri(uri ?? string.Empty);
        });

        // Database
        // https://github.com/dotnet/SqlClient/issues/2239
        // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
        // Add-Migration InitialMigration -Context OrderContext -Project OrderService.DatabaseMigration
        // Update-Database -Context OrderContext -Project OrderService.DatabaseMigration
        services.AddDbContext<OrderContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString
                    ("OrderDbConnection"),
                x =>
                    x.MigrationsAssembly("OrderService.DatabaseMigration")));


        return services;
    }
}