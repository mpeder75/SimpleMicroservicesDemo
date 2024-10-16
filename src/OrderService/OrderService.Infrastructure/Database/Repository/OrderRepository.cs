using OrderService.Application.Command;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Database.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _db;

    public OrderRepository(OrderContext db)
    {
        _db = db;
    }

    void IOrderRepository.Add(Order order)
    {
        _db.SaveChanges();
    }
}