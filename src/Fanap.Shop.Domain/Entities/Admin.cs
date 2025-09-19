
namespace Fanap.Shop.Domain.Entities;

public abstract class Admin : User
{
    protected Admin(string firstName, string lastName, string email, string password) : base(firstName, lastName, email, password)
    {
    }

    protected Admin() { }
}
