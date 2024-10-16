using CustomerService.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.Infrastructure.Database;

public class SeedDatabase
{
    public static void UpdateDatabase(IServiceProvider ioc)
    {
        using (var serviceScope = ioc.CreateScope())
        {
            var db = serviceScope.ServiceProvider.GetRequiredService<CustomerContext>();
            if (!db.Customers.Any())
            {
                db.Customers.Add(Customer.Create(1000));
                db.SaveChanges();
            }
        }
    }
}