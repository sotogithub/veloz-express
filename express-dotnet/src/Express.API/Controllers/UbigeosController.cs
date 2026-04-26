using Express.Application.Features.Ubigeos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Express.API.Controllers
{
    [Route("api/ubigeos")]
    public class UbigeosController : BaseApiController
    {
        public UbigeosController(ISender sender) : base(sender)
        {
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchUbigeoQuery query, CancellationToken ct)
        {  
            var result = await Sender.Send(query, ct);
            return HandleResult(result);
        }
    }
}
