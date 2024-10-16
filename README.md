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
