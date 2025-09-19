using Fanap.Shop.Appliction.Exceptions;
using Fanap.Shop.Appliction.Infra;
using Fanap.Shop.Domain.Services;
using MediatR;

namespace Fanap.Shop.Appliction.Features.Customers.Commands.AddFund;

public class AddFundsCommandHandler(IDbContext dbContext, ICustomerRepository customerRepository) : IRequestHandler<AddFundsCommand>
{
    public async Task Handle(AddFundsCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(request.CustomerId, cancellationToken);

        if (customer == null)
        {
            throw new CustomerNotFoundException();
        }

        customer.AddFunds(request.Amount);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
