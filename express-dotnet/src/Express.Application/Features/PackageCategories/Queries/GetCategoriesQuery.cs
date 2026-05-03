using Express.Application.Common.Interfaces;
using Express.Application.Common.Models;
using Express.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Express.Application.Features.PackageCategories.Queries;


//PackageCategoryDto
public record GetCategoriesQuery : IRequest<Result<IReadOnlyList<PackageCategoryDto>>>;

public class GetCategoriesQueryHandler(IApplicationDbContext db)
    : IRequestHandler<GetCategoriesQuery, Result<IReadOnlyList<PackageCategoryDto>>>
{
    public async Task<Result<IReadOnlyList<PackageCategoryDto>>> Handle(GetCategoriesQuery req, CancellationToken ct)
    {
        var categories = await db.PackageCategories
            .Where(c => c.IsActive)
            .OrderBy(c => c.Name)
            .Select(c => new PackageCategoryDto(c.Id, c.Name, c.Description, c.IsActive))
            .ToListAsync(ct);

        return Result<IReadOnlyList<PackageCategoryDto>>.Success(categories);
    }
}
