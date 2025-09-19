using MediatR;

namespace Fanap.Shop.Appliction.Features.Account.Queries.Login;

public record UserLoginQuery(string Username,string Password) : IRequest<string>;

