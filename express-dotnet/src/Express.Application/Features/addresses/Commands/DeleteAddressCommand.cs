using Express.Application.Common.Interfaces;
using Express.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Express.Application.Features.addresses.Commands;



public record DeleteAddressCommand(int AddressId, int UserId) : IRequest<Result>;

public class DeleteAddressCommandHandler(IApplicationDbContext db)
    : IRequestHandler<DeleteAddressCommand, Result>
{
    public async Task<Result> Handle(DeleteAddressCommand req, CancellationToken ct)
    {
        var address = await db.Addresses
            .FirstOrDefaultAsync(d => d.Id == req.AddressId && d.UserId == req.UserId, ct);

        if (address is null) return Result.NotFound("Address not found.");

        address.IsActive = false;

        await db.SaveChangesAsync(ct);

        return Result.Success();
    }
}