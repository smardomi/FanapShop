using Fanap.Shop.Domain.Entities;

namespace Fanap.Shop.Appliction.Dtos;

public record UserDto(Guid id,string FirstName, string LastName,string Email,decimal WalletBalance,List<TransactionRecordDto>? transaction = null);

public record TransactionRecordDto(DateTime Date, decimal Amount, string Discription);

public static class UserMapper
{
    public static UserDto ToDto(this User user) => user switch
    {
        Admin admin => new UserDto(
            admin.Id,
            admin.FirstName,
            admin.LastName,
            admin.Email,
            0
        ),
        Customer customer => new UserDto(
            customer.Id,
            customer.FirstName,
            customer.LastName,
            customer.Email,
            customer.WalletBalance,
            customer.Transactions.Select(t=> new TransactionRecordDto(t.Date,t.Amount,t.Description)).ToList()
        ),
        _ => throw new InvalidOperationException("نوع کاربر تعریف نشده")
    };
}

