using CustomerService.Application.Query.QueryDto;

namespace CustomerService.Application.Query;

public interface ICustomerQuery
{
    CustomerDto
        GetCustomer(int id);
}