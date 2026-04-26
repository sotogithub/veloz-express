namespace Express.Application.DTOs;

public record AddressDto(
    int Id,
    string? Alias,
    string Address,
    string? Reference,
    string District,
    string Province,
    string Department,
    decimal? Latitude,
    decimal? Longitude);
