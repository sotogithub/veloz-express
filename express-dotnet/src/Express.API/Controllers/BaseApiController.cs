using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Express.API.Controllers;

[ApiController]
public abstract class BaseApiController : ControllerBase
{
    private ISender? _mediator;
    protected ISender Sender => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected int UserId =>
        int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var id)
            ? id
            : throw new UnauthorizedAccessException();

}
