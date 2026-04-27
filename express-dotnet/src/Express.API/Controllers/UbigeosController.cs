using Express.Application.Features.Ubigeos.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Express.API.Controllers
{
    [Route("api/ubigeos")]
    public class UbigeosController : BaseApiController
    {
       
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchUbigeoQuery query, CancellationToken ct)
        {  
            var result = await Sender.Send(query, ct);
            return result.IsSuccess ? Ok(result.Value) : Problem(detail: result.Error, statusCode: result.StatusCode);
        }
    }
}
