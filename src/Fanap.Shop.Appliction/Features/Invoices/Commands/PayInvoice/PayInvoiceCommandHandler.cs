using Fanap.Shop.Appliction.Exceptions;
using Fanap.Shop.Appliction.Infra;
using Fanap.Shop.Domain.Services;
using MediatR;

namespace Fanap.Shop.Appliction.Features.Invoices.Commands.PayInvoice;

public class PayInvoiceCommandHandler(IInvoiceRepository invoiceRepository, ICustomerRepository customerRepository, IDbContext dbContext) : IRequestHandler<PayInvoiceCommand>
{
    public async Task Handle(PayInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await invoiceRepository.GetByIdAsync(request.InvoiceId, cancellationToken);
        if (invoice == null) throw new InvoiceNotFoundException();

        var customer = await customerRepository.GetByIdAsync(request.CustomerId, cancellationToken);
        if (customer == null) throw new CustomerNotFoundException();

        customer.DeductFunds(invoice.Amount);
        invoice.MarkAsPaid();

        customerRepository.Update(customer);
        invoiceRepository.Update(invoice);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
