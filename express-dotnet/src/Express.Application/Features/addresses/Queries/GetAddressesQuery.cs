using Express.Application.Common.Interfaces;
using Express.Application.Common.Models;
using Express.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Express.Application.Features.addresses.Queries;

public record GetAddressesQuery(int UserId)
    : IRequest<Result<IReadOnlyList<AddressDto>>>;

public class GetAddressesQueryHandler(IApplicationDbContext db)
    : IRequestHandler<GetAddressesQuery, Result<IReadOnlyList<AddressDto>>>
{
    public async Task<Result<IReadOnlyList<AddressDto>>> Handle(GetAddressesQuery req, CancellationToken ct)
    {
        var addresses = await db.Addresses
            .Include(d => d.Ubigeo)
            .Where(d => d.UserId == req.UserId && d.IsActive)
            .OrderByDescending(d => d.IsPrimary)
            .ThenBy(d => d.Id)
            .Select(d => new AddressDto(
                d.Id,
                d.Alias,
                d.AddressLine,
                d.Reference,
                d.Ubigeo.District,
                d.Ubigeo.Province,
                d.Ubigeo.Department,
                d.Latitude,
                d.Longitude))
            .ToListAsync(ct);

        return Result<IReadOnlyList<AddressDto>>.Success(addresses);
    }
}
