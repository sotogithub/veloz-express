namespace Express.Application.DTOs;

public record RateDto(
    int Id,
    int PackageCategoryId,
    string CategoryName,
    decimal BasePrice,
    decimal PricePerKm,
    decimal PricePerKg
    //decimal? MaxWeightKg
    );

