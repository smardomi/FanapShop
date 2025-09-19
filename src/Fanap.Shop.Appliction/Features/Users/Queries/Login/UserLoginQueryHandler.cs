using Fanap.Shop.Appliction.Exceptions;
using Fanap.Shop.Appliction.Features.Account.Queries.Login;
using Fanap.Shop.Appliction.Services;
using Fanap.Shop.Domain.Services;
using MediatR;


namespace Fanap.Shop.Appliction.Features.Users.Queries.Login;

public class UserLoginQueryHandler(IUserRepository userRepository,JwtService jwtService) : IRequestHandler<UserLoginQuery, string>
{
    public async Task<string> Handle(UserLoginQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Username,cancellationToken);

        if (user == null || !user.CheckPassword(request.Password))
            throw new UsernameOrPasswordInInvalidException();

        return jwtService.GenerateToken(user);
    }
}
