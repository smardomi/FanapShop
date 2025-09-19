using Fanap.Shop.Appliction.Exceptions;
using Fanap.Shop.Appliction.Infra;
using Fanap.Shop.Domain.Entities;
using Fanap.Shop.Domain.Services;
using MediatR;

namespace Fanap.Shop.Appliction.Features.Invoices.Commands.CreateInvoice;

public class CreateInvoiceCommandHandler(IOrderRepository orderRepository, IInvoiceRepository invoiceRepository, IDbContext dbContext) : IRequestHandler<CreateInvoiceCommand>
{
    public async Task Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(request.OrderId, cancellationToken);

        if (order == null) throw new OrderNotFoundException();

        var invoice = new Invoice(order.Id, order.TotalAmount, request.DueDate);
        await invoiceRepository.CreateAsync(invoice, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
