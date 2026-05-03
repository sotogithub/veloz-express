using Express.Application.Common.Interfaces;
using Express.Application.Common.Models;
using Express.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Express.Application.Features.Rates.Queries;

public record GetRatesByCategoryQuery(int CategoryId)
    : IRequest<Result<IReadOnlyList<RateDto>>>;

public class GetRatesByCategoryQueryHandler(IApplicationDbContext db)
    : IRequestHandler<GetRatesByCategoryQuery, Result<IReadOnlyList<RateDto>>>
{
    public async Task<Result<IReadOnlyList<RateDto>>> Handle(GetRatesByCategoryQuery req, CancellationToken ct)
    {
        var rates = await db.Rates
            .Include(t => t.Category)
            .Where(t => t.PackageCategoryId == req.CategoryId && t.IsActive)
            .Select(t => new RateDto(
                t.Id,
                t.PackageCategoryId,
                t.Category.Name,
                t.BasePrice,
                t.PricePerKm,
                t.PricePerKg))
            .ToListAsync(ct);

        return Result<IReadOnlyList<RateDto>>.Success(rates);
    }
}
