using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Command;

namespace OrderService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IOrderCommand, OrderCommand>();
        return services;
    }
}