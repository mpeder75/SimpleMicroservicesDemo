using Crosscut.SharedDomain;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Domain.DomainServices;

namespace OrderService.Domain.Entities;

public class Order : EntityBase
{
    private Order()
    {
    }

    protected Order(int customerId, double orderAmount, ICustomerProxy customerService)
    {
        CustomerId = customerId;
        OrderAmount = orderAmount;
        if (!IsWithinCreditLimit(customerService)) throw new Exception("Order amount exceeds customer credit limit");
    }

    public int CustomerId { get; protected set; }
    public double OrderAmount { get; protected set; }

    public static Order Create(int customerId, double orderAmount, IServiceProvider serviceProvider)
    {
        var customerService = serviceProvider.GetRequiredService<ICustomerProxy>();


        return new Order(customerId, orderAmount, customerService);
    }

    protected bool IsWithinCreditLimit(ICustomerProxy customerService)
    {
        var creditLimit = customerService.GetCustomerCreditLimit(CustomerId).Result;
        return OrderAmount <= creditLimit;
    }
}