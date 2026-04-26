using Express.Application.Features.ItemDetails.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Express.API.Controllers;

[Route("api/item-details")]
public class ItemDetailsController : BaseApiController
{
    public ItemDetailsController(ISender sender) : base(sender)
    {
    }

    [HttpGet("{itemId:int}")]
    public async Task<IActionResult> GetItemDetails(int itemId, [FromQuery] string? filterText)
    {
        var result = await Sender.Send(new GetItemDetailsQuery(filterText!, itemId));
        return HandleResult(result);
    }
}
