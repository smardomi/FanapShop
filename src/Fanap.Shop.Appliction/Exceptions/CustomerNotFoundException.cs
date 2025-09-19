namespace Fanap.Shop.Appliction.Exceptions;

public class CustomerNotFoundException : ApplicationException
{
    public override string Message => "مشتری یافت نشد";
}

public class InsufficientWalletBalanceException : ApplicationException
{
    public override string Message => "مقدار پول موجود در کیف پول برای انجام این عملیات کافی نیست";
}
