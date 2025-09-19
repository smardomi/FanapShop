
using Fanap.Shop.Domain.Common.Extensions;

namespace Fanap.Shop.Domain.Entities;

public abstract class User
{
    protected User(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;  
        LastName = lastName;
        Email = email;
        SetPassword(password);
    }
    protected User() { }


    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string Email { get; protected set; }
    public string PasswordHash { get; private set; } = default!;
    public string Role { get; }

    public void SetPassword(string password)
    {
        PasswordHash = PasswordHelper.HashMd5(password);
    }

    public bool CheckPassword(string password) {
        return PasswordHash == PasswordHelper.HashMd5(password);
    }
}
