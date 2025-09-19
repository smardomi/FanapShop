using Fanap.Shop.Appliction.Features.Account.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fanap.Shop.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(UserLoginQuery request)
    {
        var login = await mediator.Send(request);
        return Ok(login);
    }
}
