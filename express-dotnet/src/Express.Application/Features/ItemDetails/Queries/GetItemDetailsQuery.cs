using Express.Application.Common.Interfaces;
using Express.Application.Common.Models;
using Express.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Express.Application.Features.ItemDetails.Queries;

// ── Listar todos los items detalle ─────────────────────────────────────────────────────────
public record GetItemDetailsQuery(string filterText, int itemId) : IRequest<Result<ItemDto>>;

public class GetItemDetailsQueryHandler(IApplicationDbContext db) : IRequestHandler<GetItemDetailsQuery, Result<ItemDto>>
{
    public async Task<Result<ItemDto>> Handle(GetItemDetailsQuery request, CancellationToken cancellationToken)
    {
        var query = db.ItemDetails
           .Where(c => c.ItemId == request.itemId && !c.IsDeleted);

        // 🔍 aplicar filtro si hay texto
        if (!string.IsNullOrWhiteSpace(request.filterText))
        {
            var text = request.filterText.ToLower();

            query = query.Where(c =>
                c.Name.ToLower().Contains(text) ||
                c.Code!.ToLower().Contains(text) ||
                (c.Description != null && c.Description.ToLower().Contains(text))
            );
        }

        var result = await query
            .GroupBy(c => new { c.Item.Id, c.Item.Name, c.Item.Description })
            .Select(g => new ItemDto(
                g.Key.Id,
                g.Key.Name,
                g.Key.Description,
                g.Select(c => new ItemDetailDto(
                    c.Id,
                    c.ItemId,
                    c.Name,
                    c.Code,
                    c.Description
                )).ToList()
            ))
            .FirstOrDefaultAsync(cancellationToken);

        return Result<ItemDto>.Success(result!);
    }
}
