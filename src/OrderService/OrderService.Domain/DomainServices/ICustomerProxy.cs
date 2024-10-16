namespace OrderService.Domain.DomainServices;

public interface ICustomerProxy
{
    Task<double> GetCustomerCreditLimit(int customerId);
}