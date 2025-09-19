using Fanap.Shop.Appliction.Dtos;
using MediatR;

namespace Fanap.Shop.Appliction.Features.Orders.Queries.GetOrders;

public record GetOrdersQuery : IRequest<List<OrderDto>>;

