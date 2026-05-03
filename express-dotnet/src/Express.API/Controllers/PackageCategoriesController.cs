using Express.Application.Features.PackageCategories.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Express.API.Controllers
{
    [Route("api/package-categories")]
    [ApiController]
    public class PackageCategoriesController : BaseApiController
    {
       
        [HttpGet]
        public async Task<IActionResult> GetCategories(CancellationToken ct)
        {
            var result = await Sender.Send(new GetCategoriesQuery(), ct);
            return result.IsSuccess
                ? Ok(result.Value)
                : Problem(detail: result.Error, statusCode: result.StatusCode);
        }
    }
}
