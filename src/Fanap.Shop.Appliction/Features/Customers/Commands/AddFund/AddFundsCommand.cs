using MediatR;

namespace Fanap.Shop.Appliction.Features.Customers.Commands.AddFund;

public record AddFundsCommand(Guid CustomerId, decimal Amount) : IRequest;
