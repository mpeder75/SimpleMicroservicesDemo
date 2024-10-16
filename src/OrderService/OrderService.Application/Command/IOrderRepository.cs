using OrderService.Domain.Entities;

namespace OrderService.Application.Command;

public interface IOrderRepository
{
    void Add(Order order);
}