using Crosscut.SharedDomain;

namespace CustomerService.Domain.Entities;

public class Customer : EntityBase
{
    public double CreditLimit { get; protected set; }

    private Customer()
    {
        
    }

    protected Customer(double creditLimit)
    {
        CreditLimit = creditLimit;
    }

    public static Customer Create(double creditLimit)
    {
        return new Customer(creditLimit);
    }
}