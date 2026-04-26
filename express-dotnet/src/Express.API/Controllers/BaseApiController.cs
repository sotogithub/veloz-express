using Express.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Express.API.Controllers;

[ApiController]
public abstract class BaseApiController : ControllerBase
{
    protected readonly ISender Sender;

    protected BaseApiController(ISender sender)
    {
        Sender = sender;
    }

    protected int UserId =>
        int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var id)
            ? id
            : throw new UnauthorizedAccessException();

    protected IActionResult HandleResult<T>(Result<T> result)
    {
        return result.IsSuccess
            ? StatusCode(result.StatusCode, result.Value)
            : Problem(detail: result.Error, statusCode: result.StatusCode);
    }

    protected IActionResult HandleResult(Result result)
    {
        return result.IsSuccess
            ? StatusCode(result.StatusCode)
            : Problem(detail: result.Error, statusCode: result.StatusCode);
    }
}
