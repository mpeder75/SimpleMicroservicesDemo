using OrderService.Application.Command.CommandDto;
using OrderService.Domain.Entities;

namespace OrderService.Application.Command;

public class OrderCommand : IOrderCommand
{
    private readonly IOrderRepository _repository;
    private readonly IServiceProvider _ioc;

    public OrderCommand(IOrderRepository repository, IServiceProvider ioc)
    {
        _repository = repository;
        _ioc = ioc;
    }

    void IOrderCommand.CreateOrder(CreateOrderCommandDto command)
    {
        var order = Order.Create(command.CustomerId, command.OrderAmount, _ioc);
        _repository.Add(order);
    }


}