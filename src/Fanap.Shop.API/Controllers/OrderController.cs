using Fanap.Shop.Appliction.Features.Invoices.Commands.CreateInvoice;
using Fanap.Shop.Appliction.Features.Invoices.Commands.PayInvoice;
using Fanap.Shop.Appliction.Features.Invoices.Queries.GetInvoices;
using Fanap.Shop.Appliction.Features.Orders.Queries.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fanap.Shop.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class OrderController(IMediator mediator) : ControllerBase
{
    [HttpPost("GetOrders")]
    public async Task<IActionResult> Get(GetOrdersQuery request)
    {
        var users = await mediator.Send(request);
        return Ok(users);
    }

    [HttpPost(nameof(CreateInvoice))]
    public async Task<IActionResult> CreateInvoice(CreateInvoiceCommand request)
    {
        await mediator.Send(request);
        return Ok();
    }

    [HttpPost(nameof(PayInvoice))]
    public async Task<IActionResult> PayInvoice(PayInvoiceCommand request)
    {
        await mediator.Send(request);
        return Ok();
    }

    [HttpPost(nameof(GetInvoices))]
    public async Task<IActionResult> GetInvoices(GetInvoicesQuery request)
    {
        var users = await mediator.Send(request);
        return Ok(users);
    }

}
