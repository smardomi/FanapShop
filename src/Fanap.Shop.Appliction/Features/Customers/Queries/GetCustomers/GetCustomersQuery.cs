using Fanap.Shop.Appliction.Dtos;
using Fanap.Shop.Domain.Entities;
using MediatR;

namespace Fanap.Shop.Appliction.Features.Customers.Queries.GetCustomers;

public record GetCustomersQuery : IRequest<List<UserDto>>;
