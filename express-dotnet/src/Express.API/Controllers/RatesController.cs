using Express.Application.Features.Rates.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Express.API.Controllers;


[Route("api/rates")]
[ApiController]
public class RatesController : BaseApiController
{

    [HttpGet("categories/{id:int}")]
    public async Task<IActionResult> GetRates(int id, CancellationToken ct)
    {
        var result = await Sender.Send(new GetRatesByCategoryQuery(id), ct);
        return result.IsSuccess
            ? Ok(result.Value)
            : Problem(detail: result.Error, statusCode: result.StatusCode);
    }
}