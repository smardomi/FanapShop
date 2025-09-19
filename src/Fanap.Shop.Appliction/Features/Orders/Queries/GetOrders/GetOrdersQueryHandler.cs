using Fanap.Shop.Appliction.Dtos;
using Fanap.Shop.Appliction.Extensions;
using Fanap.Shop.Appliction.Infra;
using Fanap.Shop.Domain.Entities;
using Fanap.Shop.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Fanap.Shop.Appliction.Features.Orders.Queries.GetOrders;

public class GetOrdersQueryHandler(IOrderRepository orderRepository, IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetOrdersQuery, List<OrderDto>>
{
    public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var user = httpContextAccessor.HttpContext?.User
              ?? throw new UnauthorizedAccessException();

        var role = user.GetRole();
        var userId = user.GetUserId();

        List<Order> ordersList;

        if (role == nameof(Admin))
        {
            ordersList = await orderRepository.GetAllAsync(cancellationToken);
        }
        else if (role == nameof(Customer) && userId.HasValue)
        {
            ordersList = await orderRepository.GetAllByCustomerIdAsync(userId.Value, cancellationToken)
                          ?? new List<Order>();
        }
        else
        {
            throw new UnauthorizedAccessException();
        }

        return ordersList
            .OrderByDescending(o => o.OrderDate)
            .Select(o => o.ToDto())
            .ToList();
    }
}
