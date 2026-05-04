using Express.Application.Common.Interfaces;
using Express.Application.Common.Models;
using Express.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Express.Application.Features.Ubigeos.Queries;


public record GetUbigeosQuery()
    : IRequest<Result<IReadOnlyList<UbigeoDto>>>;

public class GetUbigeosQueryHandler(IApplicationDbContext db)
    : IRequestHandler<GetUbigeosQuery, Result<IReadOnlyList<UbigeoDto>>>
{
    public async Task<Result<IReadOnlyList<UbigeoDto>>> Handle(GetUbigeosQuery req, CancellationToken ct)
    {
        var query = db.Ubigeos
            .AsNoTracking()
            .AsQueryable();

        var results = await query
            .OrderBy(u => u.Department)
            .ThenBy(u => u.Province)
            .ThenBy(u => u.District)
            .Select(u => new UbigeoDto(
                u.Id,
                u.Code,
                u.Department,
                u.Province,
                u.District))
            .ToListAsync(ct);

        return Result<IReadOnlyList<UbigeoDto>>.Success(results);
    }
}