using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using OrderService.Domain.DomainServices;

namespace OrderService.Infrastructure.ExternalServices;

public class CustomerProxy : ICustomerProxy
{
    private readonly HttpClient _client;
    private readonly ILogger<CustomerProxy> _logger;

    public CustomerProxy(HttpClient client, ILogger<CustomerProxy> logger)
    {
        _client = client;
        _logger = logger;
    }

    async Task<double> ICustomerProxy.GetCustomerCreditLimit(int customerId)
    {
        var requestUri = $"/AddressHandler/{customerId}";
        var response = await _client.GetFromJsonAsync<double>(requestUri);

        return response;
    }
}