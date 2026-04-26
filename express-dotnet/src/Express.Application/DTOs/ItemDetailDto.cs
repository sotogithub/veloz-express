namespace Express.Application.DTOs;

    public record ItemDetailDto(
        int Id,
        int ItemId,
        string Name,
        string? Code,
        string? Description);
