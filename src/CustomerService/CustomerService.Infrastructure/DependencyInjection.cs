using CustomerService.Application.Query;
using CustomerService.Infrastructure.Database;
using CustomerService.Infrastructure.Database.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerQuery, CustomerQuery>();

        // Database
        // https://github.com/dotnet/SqlClient/issues/2239
        // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
        // Add-Migration InitialMigration -Context CustomerContext -Project CustomerService.DatabaseMigration
        // Update-Database -Context CustomerContext -Project CustomerService.DatabaseMigration
        services.AddDbContext<CustomerContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString
                    ("CustomerDbConnection"),
                x =>
                    x.MigrationsAssembly("CustomerService.DatabaseMigration")));


        return services;
    }
}