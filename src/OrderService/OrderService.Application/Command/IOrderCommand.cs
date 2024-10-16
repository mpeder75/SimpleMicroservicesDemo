using OrderService.Application.Command.CommandDto;
using OrderService.Domain.Entities;

namespace OrderService.Application.Command;

public interface IOrderCommand
{
    void CreateOrder(CreateOrderCommandDto command);
}