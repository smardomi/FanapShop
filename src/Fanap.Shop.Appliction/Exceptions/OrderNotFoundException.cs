namespace Fanap.Shop.Appliction.Exceptions;

public class OrderNotFoundException : ApplicationException
{
    public override string Message => "سفارشی یافت نشد";
}

public class UsernameOrPasswordInInvalidException : ApplicationException
{
    public override string Message => "نام کاربری یا رمز عبور اشتباه است";
}
