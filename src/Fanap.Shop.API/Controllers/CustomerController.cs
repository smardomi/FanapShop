using Fanap.Shop.Appliction.Features.Customers.Commands.AddFund;
using Fanap.Shop.Appliction.Features.Customers.Queries.GetCustomers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fanap.Shop.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class CustomerController(IMediator mediator) : ControllerBase
{
    [HttpPost("GetCustomerInfo")]
    public async Task<IActionResult> Get(GetCustomersQuery request)
    {
        var users = await mediator.Send(request);
        return Ok(users);
    }

    [HttpPost(nameof(AddFund))]
    public async Task<IActionResult> AddFund(AddFundsCommand request)
    {
        await mediator.Send(request);
        return Ok();
    }
}
