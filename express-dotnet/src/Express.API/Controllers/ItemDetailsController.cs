using Express.Application.Features.ItemDetails.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Express.API.Controllers;

[Route("api/item-details")]
public class ItemDetailsController : BaseApiController
{
    
    [HttpGet("{itemId:int}")]
    public async Task<IActionResult> GetItemDetails(int itemId, [FromQuery] string? filterText)
    {
        var result = await Sender.Send(new GetItemDetailsQuery(filterText!, itemId));
        return result.IsSuccess ? Ok(result.Value) : Problem(detail: result.Error, statusCode: result.StatusCode);
    }
}
