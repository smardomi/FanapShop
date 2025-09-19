namespace Fanap.Shop.Appliction.Exceptions;

public class InvoiceNotFoundException : ApplicationException
{
    public override string Message => "فاکتوری یافت نشد";
}
