
namespace OrderService.Application.Command.CommandDto;

public record CreateOrderCommandDto(
    int CustomerId,
    double OrderAmount);

