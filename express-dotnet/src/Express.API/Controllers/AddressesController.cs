using Express.Application.Features.addresses.Commands;
using Express.Application.Features.addresses.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Express.API.Controllers;

[Route("api/addresses")]
public class AddressesController : BaseApiController
{
    // GET api/addresses
    [HttpGet]
    public async Task<IActionResult> GetAddresses(CancellationToken ct)
    {
        var result = await Sender.Send(new GetAddressesQuery(1), ct);

        return result.IsSuccess
            ? Ok(result.Value)
            : Problem(detail: result.Error, statusCode: result.StatusCode);
    }

    // POST api/direcciones
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAddressCommand req, CancellationToken ct)
    {
        var result = await Sender.Send(new CreateAddressCommand(
            1, req.UbigeoId, req.Address,
            req.Alias, req.Reference, req.Latitude, req.Longitude, req.IsPrimary), ct);

        return result.IsSuccess
           ? StatusCode(result.StatusCode, result.Value)
           : Problem(detail: result.Error, statusCode: result.StatusCode);
    }

    // DELETE api/addresses/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var result = await Sender.Send(new DeleteAddressCommand(id, 1), ct);
        return result.IsSuccess ? NoContent() : Problem(detail: result.Error, statusCode: result.StatusCode);
    }

}


