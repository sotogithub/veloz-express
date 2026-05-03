namespace Express.Application.DTOs;

public record PackageCategoryDto(
   int Id,
   string Name,
   string? Description,
   bool IsActive);
