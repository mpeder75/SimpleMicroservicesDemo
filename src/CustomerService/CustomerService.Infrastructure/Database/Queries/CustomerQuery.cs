using CustomerService.Application.Query;
using CustomerService.Application.Query.QueryDto;

namespace CustomerService.Infrastructure.Database.Queries;

public class CustomerQuery : ICustomerQuery
{
    private readonly CustomerContext _db;

    public CustomerQuery(CustomerContext db)
    {
        _db = db;
    }

    CustomerDto ICustomerQuery.GetCustomer(int id)
    {
        var result = _db.Customers
            .First(c => c.Id == id);

        return new CustomerDto
        {
            Id = result.Id,
            CreditLimit = result.CreditLimit
        };
    }
}