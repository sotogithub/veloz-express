using Express.Application.Common.Interfaces;
using Express.Application.Common.Models;
using Express.Application.DTOs;
using Express.Domain.Entities;
using MediatR;

namespace Express.Application.Features.addresses.Commands;

public record CreateAddressCommand(
    int UserId, int UbigeoId, string Address,
    string? Alias, string? Reference,
    decimal? Latitude, decimal? Longitude,
    bool IsPrimary) : IRequest<Result<AddressDto>>;

public class CreateAddressCommandHandler(IApplicationDbContext db)
    : IRequestHandler<CreateAddressCommand, Result<AddressDto>>
{
    public async Task<Result<AddressDto>> Handle(CreateAddressCommand req, CancellationToken ct)
    {
        var ubigeo = await db.Ubigeos.FindAsync([req.UbigeoId], ct);
        if (ubigeo is null) return Result<AddressDto>.NotFound("Ubigeo not found.");

        if (req.IsPrimary)
        {
            var previous = await db.Addresses
                .Where(d => d.UserId == req.UserId && d.IsPrimary)
                .ToListAsync(ct);

            previous.ForEach(d => d.RemovePrimary());
        }

        var address = Address.Create(
            req.UserId, req.UbigeoId, req.Address,
            req.Alias, req.Reference, req.Latitude, req.Longitude
        );

        if (req.IsPrimary) address.SetPrimary();

        db.Addresses.Add(address);
        await db.SaveChangesAsync(ct);

        return Result<AddressDto>.Success(new AddressDto(
            address.Id,
            address.Alias,
            address.AddressText,
            address.Reference,
            ubigeo.District,
            ubigeo.Province,
            ubigeo.Department,
            address.Latitude,
            address.Longitude
        ), 201);
    }
}
