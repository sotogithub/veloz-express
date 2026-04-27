using Express.Application.Common.Interfaces;
using Express.Application.Common.Models;
using Express.Application.DTOs;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Express.Application.Features.Ubigeos.Queries;

public record SearchUbigeoQuery(string? Term)
    : IRequest<Result<IReadOnlyList<UbigeoDto>>>;

public class SearchUbigeoQueryHandler(IApplicationDbContext db)
    : IRequestHandler<SearchUbigeoQuery, Result<IReadOnlyList<UbigeoDto>>>
{
    public async Task<Result<IReadOnlyList<UbigeoDto>>> Handle(SearchUbigeoQuery req, CancellationToken ct)
    {
        var query = db.Ubigeos
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(req.Term))
        {
            var term = req.Term.ToLower().Trim();

            query = query.Where(u =>
                u.District.ToLower().Contains(term) ||
                u.Province.ToLower().Contains(term) ||
                u.Department.ToLower().Contains(term) ||
                u.Code.Contains(term));
        }

        var results = await query
            .OrderBy(u => u.Department)
            .ThenBy(u => u.Province)
            .ThenBy(u => u.District)
            .Take(50)
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


//public class SearchUbigeoQueryValidator : AbstractValidator<SearchUbigeoQuery>
//{
//    public SearchUbigeoQueryValidator()
//    {
//        RuleFor(x => x.Term)
//        .NotEmpty()
//        .WithMessage("El parámetro '{ PropertyName }' es requerido.")
//        .MinimumLength(2)
//        .WithMessage("El parámetro '{ PropertyName }' debe tener al menos 2 caracteres.");
//    }
//}