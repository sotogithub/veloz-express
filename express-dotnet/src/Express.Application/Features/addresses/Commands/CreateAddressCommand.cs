using Express.Application.Common.Interfaces;
using Express.Application.Common.Models;
using Express.Application.DTOs;
using Express.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Express.Application.Features.addresses.Commands;

public record CreateAddressCommand(
    int UserId, int UbigeoId, string Address,
    string? Alias, string? Reference,
    decimal? Latitude, decimal? Longitude,
    bool IsPrimary) : IRequest<Result<AddressDto>>;

public class CreateAddressCommandHandler(IApplicationDbContext db)
    : IRequestHandler<CreateAddressCommand, Result<AddressDto>>
{
    public async Task<Result<AddressDto>> Handle(CreateAddressCommand req, CancellationToken ct)
    {
        var ubigeo = await db.Ubigeos.FindAsync([req.UbigeoId], ct);
        if (ubigeo is null) return Result<AddressDto>.NotFound("Ubigeo not found.");

        if (req.IsPrimary)
        {
            var previousAddresses = await db.Addresses
                .Where(d => d.UserId == req.UserId && d.IsPrimary)
                .ToListAsync(ct);

            foreach (var previous in previousAddresses)
            {
                previous.IsPrimary = false;
            }

        }

        var address = new Address
        {
            UserId = req.UserId,
            IsPrimary = req.IsPrimary,
            UbigeoId = req.UbigeoId,
            AddressLine = req.Address,
            Alias = req.Alias,
            Reference = req.Reference,
            Latitude = req.Latitude,
            Longitude = req.Longitude,
        };

        

        db.Addresses.Add(address);
        await db.SaveChangesAsync(ct);

        return Result<AddressDto>.Success(new AddressDto(
            address.Id,
            address.Alias,
            address.AddressLine,
            address.Reference,
            ubigeo.District,
            ubigeo.Province,
            ubigeo.Department,
            address.Latitude,
            address.Longitude
        ), 201);
    }
}

//// ── Request models ────────────────────────────────────────────────────────────
//public record CreateAddressRequest(
//    int UbigeoId, string Address,
//    string? Alias, string? Reference,
//    decimal? Latitude, decimal? Longitude,
//    bool IsPrimary);

//VALIDACIONES
public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        
        RuleFor(x => x.UbigeoId)
            .GreaterThan(0)
            .WithMessage("El UbigeoId debe ser mayor a 0.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("La dirección es requerida.")
            .MaximumLength(250).WithMessage("La dirección no puede exceder 250 caracteres.");

        //RuleFor(x => x.Alias)
        //    .MaximumLength(100).WithMessage("El alias no puede exceder 100 caracteres.")
        //    .When(x => !string.IsNullOrWhiteSpace(x.Alias));

        //RuleFor(x => x.Reference)
        //    .MaximumLength(250).WithMessage("La referencia no puede exceder 250 caracteres.")
        //    .When(x => !string.IsNullOrWhiteSpace(x.Reference));

        //RuleFor(x => x.Latitude)
        //    .InclusiveBetween(-90, 90)
        //    .WithMessage("La latitud debe estar entre -90 y 90.")
        //    .When(x => x.Latitude.HasValue);

        //RuleFor(x => x.Longitude)
        //    .InclusiveBetween(-180, 180)
        //    .WithMessage("La longitud debe estar entre -180 y 180.")
        //    .When(x => x.Longitude.HasValue);

        //// Validación opcional: si uno viene, el otro también
        //RuleFor(x => x)
        //    .Must(x => x.Latitude.HasValue == x.Longitude.HasValue)
        //    .WithMessage("Latitud y longitud deben enviarse juntos o ninguno.");
    }
}

