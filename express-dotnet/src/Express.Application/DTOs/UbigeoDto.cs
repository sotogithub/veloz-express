namespace Express.Application.DTOs;

public record UbigeoDto(
    int Id,
    string Code,
    string Department,
    string Province,
    string District);