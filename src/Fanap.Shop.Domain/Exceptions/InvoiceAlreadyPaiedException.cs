
using Fanap.Shop.Domain.Common;

namespace Fanap.Shop.Domain.Exceptions;

public class InvoiceAlreadyPaidException : DomainException
{
    public override string Message => "فاکتور قبلا پرداخت شده است";
}
