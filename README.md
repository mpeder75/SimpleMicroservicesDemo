# SimpleMicroservicesDemo
Simple Microservices Demo. A very simple system with a Customer and a Order service. When a new order is created, the OrderService ask the Customer fore the creditmax. A new order is only accepted is it is below credit max.



## Agenda

1. Create OrderService and CustomerServices using a Onion template (KbrOnionTemplate-Core-8.bat)
2. Implement CustomerService using a MSSSQL database with seeded data
3. Implement OrderService using a MSSSQL database with seeded data. And using a domain service to check creditmax. The domain service uses a CustomerProxy (HttpClient) to talk to the CustomerService.



### Chaper 1: Create OrderService and CustomerServices using a Onion template

Branch: CH-01

CustomerService:

```powershell
KbrOnionTemplate-Core-8.bat
Enter application name: CustomerService
```

cd..

OrderService

```powershell
KbrOnionTemplate-Core-8.bat
Enter application name: OrderService
```



Create a empty solution to include both services.

The solution looks like this:

![](Images\CH-01-Folders-01.jpg)



### Chapter 2: Implement CustomerService using a MSSSQL database with seeded data

Branch: CH-02

Crosscut projekt created

I de enkelte projekter implementeres: DependencyInjection som udfylder IoC med klasser fra dette projekt.

Domain - Customer oprettet.

Infrastructure:

- CustomerContext oprettet
- DependencyInjection udfyldt
- DB connection string: CustomerDbConnection som er i API projektet appsettings.json filen



Query oprettes: 

```csharp
namespace CustomerService.Application.Query;

public interface ICustomerQuery
{
    CustomerDto
        GetCustomer(int id);
}
```



Interface implementeres i infrastructure og oprettes i DependencyInjection.



API Endpoint oprettes i program.cs:

```csharp
app.MapGet("/Customer/{id}", (int id, ICustomerQuery query) =>
{
var result = query.GetCustomer(id);
    return result;
});
```





Det sikres at databasen er oprettet - og hvis ikke så opret den:

```csharp
    public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
```

Seed af data:

```csharp
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
```



i Program.cs:

```csharp
var app = builder.Build();
SeedDatabase.UpdateDatabase(app.Services);
```

