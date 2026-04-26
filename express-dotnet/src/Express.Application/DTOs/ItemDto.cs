namespace Express.Application.DTOs;

public record ItemDto(
    int Id,
    string Name,
    string? Description,
    ICollection<ItemDetailDto> ItemDetails);
