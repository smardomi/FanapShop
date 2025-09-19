using Fanap.Shop.Domain.Common;

namespace Fanap.Shop.Domain.Exceptions;

public class AmountExceedsWalletBalanceException : DomainException
{
    public override string Message => "مبلغ از موجودی کیف پول بیشتر است";
}
