using Fanap.Shop.Appliction.Dtos;
using Fanap.Shop.Appliction.Extensions;
using Fanap.Shop.Appliction.Infra;
using Fanap.Shop.Domain.Entities;
using Fanap.Shop.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Fanap.Shop.Appliction.Features.Customers.Queries.GetCustomers;

public class GetCustomersQueryHandler(ICustomerRepository customerRepository, IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetCustomersQuery, List<UserDto>>
{
    public async Task<List<UserDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var user = httpContextAccessor.HttpContext?.User
              ?? throw new UnauthorizedAccessException();

        var role = user.GetRole();
        var userId = user.GetUserId();

        List<Customer> users = role switch
        {
            nameof(Admin) => await customerRepository.GetAllAsync(),
            nameof(Customer) when userId.HasValue =>
                await customerRepository.GetByIdAsync(userId.Value, cancellationToken) is { } customer
                    ? new List<Customer> { customer }
                    : new List<Customer>(),
            _ => throw new UnauthorizedAccessException()
        };

        return users.Select(u => u.ToDto()).ToList();
    }
}
