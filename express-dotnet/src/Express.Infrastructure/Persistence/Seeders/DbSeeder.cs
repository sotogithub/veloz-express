using Express.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Express.Infrastructure.Persistence.Seeders;

public static class DbSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<AppDbContext>>();

        try
        {
            await db.Database.MigrateAsync();

            await SeedItemsAsync(db);
            await SeedPackageCategoriesAsync(db);
            await SeedRatesAsync(db);
            await SeedUbigeosAsync(db);
            await SeedCoverageZonesAsync(db);
            await SeedUsersAsync(db);
            await SeedDriverProfilesAsync(db);
            await SeedAddressesAsync(db);
            logger.LogInformation("Seeding completado correctamente.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error durante el seeding de la base de datos.");
            throw;
        }
    }

    // ── Item ─────────────────────────────────────────────────
    private static async Task SeedItemsAsync(AppDbContext db)
    {
        if (await db.Items.AnyAsync()) return;

        db.Items.AddRange(
            new Item
            {
                Name = "Estado de Asignación",
                Description = "Indica el estado actual del proceso de asignación de un paquete a un courier.",
                ItemDetails = new List<ItemDetail>
                {
                    new ItemDetail { Name = "Activa" },
                    new ItemDetail { Name = "Completada" },
                    new ItemDetail { Name = "Reasignada" },
                    new ItemDetail { Name = "Cancelada" }
                }
            },
            new Item
            {
                Name = "Estado de Incidencia",
                Description = "Estado actual de una incidencia en el envío.",
                ItemDetails = new List<ItemDetail>
                {
                    new ItemDetail { Name = "Abierta" },
                    new ItemDetail { Name = "En Revisión" },
                    new ItemDetail { Name = "Resuelta" },
                    new ItemDetail { Name = "Cerrada" }
                }
            },
            new Item
            {
                Name = "Estado de Pago",
                Description = "Estado actual del pago de un envío o servicio.",
                ItemDetails = new List<ItemDetail>
                {
                    new ItemDetail { Name = "Pendiente" },
                    new ItemDetail { Name = "Aprobado" },
                    new ItemDetail { Name = "Rechazado" },
                    new ItemDetail { Name = "Reembolsado" }
                }
            },
            new Item
            {
                Name = "Estado de Paquete",
                Description = "Estado actual del paquete durante el proceso de envío.",
                ItemDetails = new List<ItemDetail>
                {
                    new ItemDetail { Name = "Pendiente" },
                    new ItemDetail { Name = "Confirmado" },
                    new ItemDetail { Name = "Asignado" },
                    new ItemDetail { Name = "Recogido" },
                    new ItemDetail { Name = "En Almacen" },
                    new ItemDetail { Name = "En Camino" },
                    new ItemDetail { Name = "Entregado" },
                    new ItemDetail { Name = "Cancelado" },
                    new ItemDetail { Name = "Devuelto" }
                }
            },
            new Item
            {
                Name = "Método de Pago",
                Description = "Estado actual del paquete durante el proceso de envío.",
                ItemDetails = new List<ItemDetail>
                {
                    new ItemDetail { Name = "Tarjeta" },
                    new ItemDetail { Name = "Transferencia" },
                    new ItemDetail { Name = "Efectivo" },
                    new ItemDetail { Name = "Yape" },
                    new ItemDetail { Name = "Plin" },
                    new ItemDetail { Name = "PayPal" }
                }
            },
            new Item
            {
                Name = "Rol de nombre",
                Description = "Define el tipo de rol asignado a un usuario en el sistema.",
                ItemDetails = new List<ItemDetail>
                {
                    new ItemDetail { Name = "Admin" },
                    new ItemDetail { Name = "Cliente" },
                    new ItemDetail { Name = "Motorizado" }
                }
            },
            new Item
            {
                Name = "Tipo de Incidencia",
                Description = "Clasificación de la incidencia reportada en el envío.",
                ItemDetails = new List<ItemDetail>
                {
                    new ItemDetail { Name = "Paquete Dañado" },
                    new ItemDetail { Name = "Paquete Perdido" },
                    new ItemDetail { Name = "Demora" },
                    new ItemDetail { Name = "Dirección Incorrecta" },
                    new ItemDetail { Name = "Otro" }
                }
            },
            new Item
            {
                Name = "Tipo de Token",
                Description = "Tipo de token utilizado para autenticación o autorización.",
                ItemDetails = new List<ItemDetail>
                {
                    new ItemDetail { Name = "Verificar Email" },
                    new ItemDetail { Name = "Recuperar Password" }
                }
            },
            new Item
            {
                Name = "Tipo de Vehículo",
                Description = "Clasificación del vehículo utilizado para entregas.",
                ItemDetails = new List<ItemDetail>
                {
                    new ItemDetail { Name = "Moto" },
                    new ItemDetail { Name = "Bicicleta" },
                    new ItemDetail { Name = "Auto" },
                    new ItemDetail { Name = "Furgoneta" }
                }
            }
        );

        await db.SaveChangesAsync();
    }

    // ── Categorias de paquete ─────────────────────────────────────────────────
    private static async Task SeedPackageCategoriesAsync(AppDbContext db)
    {
        if (await db.PackageCategories.AnyAsync()) return;

        db.PackageCategories.AddRange(
            new PackageCategory { Name = "Documentos", Description = "Sobres, cartas y documentos ligeros." },
            new PackageCategory { Name = "Pequeño", Description = "Paquetes de hasta 5 kg." },
            new PackageCategory { Name = "Mediano", Description = "Paquetes de hasta 15 kg." },
            new PackageCategory { Name = "Grande", Description = "Paquetes de hasta 30 kg." },
            new PackageCategory { Name = "Extra Grande", Description = "Paquetes de más de 30 kg." }
        );

        await db.SaveChangesAsync();
    }

    // ── Tarifas ───────────────────────────────────────────────────────────────
    private static async Task SeedRatesAsync(AppDbContext db)
    {
        if (await db.Rates.AnyAsync()) return;

        // Categorias ya fueron agregadas en este mismo SaveChanges batch —
        // necesitamos leerlas desde el ChangeTracker local.
        var categories = db.PackageCategories.Local.ToList();

        var config = new[]
        {
            // (nombre,         precioBase, precioPorKm, precioPorKg, pesoMax)
            ("Documentos",   5.00m,  0.50m, 0.00m,  0.5m),
            ("Pequeño",      8.00m,  0.80m, 0.50m,  5m),
            ("Mediano",     12.00m,  1.20m, 0.80m,  15m),
            ("Grande",      18.00m,  1.80m, 1.20m,  30m),
            ("Extra Grande",25.00m,  2.50m, 1.80m,  null as decimal?),
        };
        foreach (var (name, basePrice, pricePerKm, pricePerKg, maxWeight) in config)
        {
            var category = categories.FirstOrDefault(c => c.Name == name);
            if (category is not null)
                db.Rates.Add(new Rate { PackageCategoryId = category.Id, BasePrice = basePrice, PricePerKm = pricePerKm, PricePerKg = pricePerKg, MaxWeightKg = maxWeight });
        }
        await db.SaveChangesAsync(); // ← clave

    }

    // ── Ubigeos (distritos reales del Perú) ───────────────────────────────────
    private static async Task SeedUbigeosAsync(AppDbContext db)
    {
        if (await db.Ubigeos.AnyAsync()) return;

        // Formato: (codigo, departamento, provincia, distrito)
        var ubigeos = new[]
        {
            // Lima - Lima
            ("150101", "Lima", "Lima", "Lima"),
            ("150102", "Lima", "Lima", "Ancón"),
            ("150104", "Lima", "Lima", "Breña"),
            ("150105", "Lima", "Lima", "Carabayllo"),
            ("150106", "Lima", "Lima", "Chaclacayo"),
            ("150107", "Lima", "Lima", "Chorrillos"),
            ("150111", "Lima", "Lima", "La Molina"),
            ("150113", "Lima", "Lima", "Lince"),
            ("150114", "Lima", "Lima", "Los Olivos"),
            ("150115", "Lima", "Lima", "Lurigancho"),
            ("150116", "Lima", "Lima", "Lurín"),
            ("150117", "Lima", "Lima", "Magdalena del Mar"),
            ("150118", "Lima", "Lima", "Miraflores"),
            ("150120", "Lima", "Lima", "Pueblo Libre"),
            ("150121", "Lima", "Lima", "Puente Piedra"),
            ("150122", "Lima", "Lima", "Punta Hermosa"),
            ("150125", "Lima", "Lima", "San Borja"),
            ("150126", "Lima", "Lima", "San Isidro"),
            ("150127", "Lima", "Lima", "San Juan de Lurigancho"),
            ("150128", "Lima", "Lima", "San Juan de Miraflores"),
            ("150129", "Lima", "Lima", "San Luis"),
            ("150130", "Lima", "Lima", "San Martín de Porres"),
            ("150131", "Lima", "Lima", "San Miguel"),
            ("150132", "Lima", "Lima", "Santa Anita"),
            ("150133", "Lima", "Lima", "Santiago de Surco"),
            ("150134", "Lima", "Lima", "Surquillo"),
            ("150135", "Lima", "Lima", "Villa El Salvador"),
            ("150136", "Lima", "Lima", "Villa María del Triunfo"),
            // Callao
            ("070101", "Callao", "Callao", "Callao"),
            ("070102", "Callao", "Callao", "Bellavista"),
            ("070103", "Callao", "Callao", "Carmen de La Legua Reynoso"),
            ("070104", "Callao", "Callao", "La Perla"),
            ("070105", "Callao", "Callao", "La Punta"),
            ("070106", "Callao", "Callao", "Mi Perú"),
            ("070107", "Callao", "Callao", "Ventanilla"),
            // Arequipa
            ("040101", "Arequipa", "Arequipa", "Arequipa"),
            ("040102", "Arequipa", "Arequipa", "Alto Selva Alegre"),
            ("040103", "Arequipa", "Arequipa", "Cayma"),
            ("040104", "Arequipa", "Arequipa", "Cerro Colorado"),
            ("040109", "Arequipa", "Arequipa", "Jacobo Hunter"),
            ("040111", "Arequipa", "Arequipa", "Mariano Melgar"),
            ("040112", "Arequipa", "Arequipa", "Miraflores"),
            ("040113", "Arequipa", "Arequipa", "Paucarpata"),
            ("040115", "Arequipa", "Arequipa", "Sachaca"),
            ("040116", "Arequipa", "Arequipa", "San Juan de Tarucani"),
            ("040120", "Arequipa", "Arequipa", "Yanahuara"),
            // Trujillo
            ("130101", "La Libertad", "Trujillo", "Trujillo"),
            ("130102", "La Libertad", "Trujillo", "El Porvenir"),
            ("130104", "La Libertad", "Trujillo", "Florencia de Mora"),
            ("130106", "La Libertad", "Trujillo", "La Esperanza"),
            ("130107", "La Libertad", "Trujillo", "Laredo"),
            ("130108", "La Libertad", "Trujillo", "Moche"),
            ("130111", "La Libertad", "Trujillo", "Víctor Larco Herrera"),
            // Piura
            ("200101", "Piura", "Piura", "Piura"),
            ("200104", "Piura", "Piura", "Catacaos"),
            ("200110", "Piura", "Piura", "La Arena"),
            ("200114", "Piura", "Piura", "Piura"),
            ("200121", "Piura", "Piura", "Veintiseis de Octubre"),
            // Cusco
            ("080101", "Cusco", "Cusco", "Cusco"),
            ("080102", "Cusco", "Cusco", "Ccorca"),
            ("080103", "Cusco", "Cusco", "Poroy"),
            ("080104", "Cusco", "Cusco", "San Jerónimo"),
            ("080105", "Cusco", "Cusco", "San Sebastián"),
            ("080106", "Cusco", "Cusco", "Santiago"),
            ("080107", "Cusco", "Cusco", "Saylla"),
            ("080108", "Cusco", "Cusco", "Wanchaq"),
        };

        foreach (var (code, department, province, district) in ubigeos)
        {
            db.Ubigeos.Add(new Ubigeo
            {
                Code = code,
                Department = department,
                Province = province,
                District = district
            });
        }
        await db.SaveChangesAsync(); // ← clave

    }

    // ── Zonas de cobertura ────────────────────────────────────────────────────
    private static async Task SeedCoverageZonesAsync(AppDbContext db)
    {
        if (await db.CoverageZones.AnyAsync()) return;

        var ubigeos = db.Ubigeos.Local.ToList();

        // Estimated times by department (hours)
        byte EstimatedTime(string department) => department switch
        {
            "Lima" => 2,
            "Callao" => 3,
            "Arequipa" => 48,
            "La Libertad" => 24,
            "Piura" => 36,
            "Cusco" => 72,
            _ => 48
        };

        foreach (var ubigeo in ubigeos)
        {
            db.CoverageZones.Add(
                new CoverageZone
                {
                    UbigeoId = ubigeo.Id,
                    EstimatedTimeHours = EstimatedTime(ubigeo.Department)
                }
            );
        }
        await db.SaveChangesAsync(); // ← clave
    }

    // ── Usuarios ──────────────────────────────────────────────────────────────
    private static async Task SeedUsersAsync(AppDbContext db)
    {
        if (await db.Users.AnyAsync()) return;

        var roles = await db.Roles.ToListAsync();
        int RoleId(string name) => roles.First(r => r.Name == name).Id;

        string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);

        // 1 Admin
        var admin = new User { RoleId = RoleId("admin"), FirstName = "Carlos", LastName = "Mendoza", Email = "admin@courier.pe", PasswordHash = Hash("Admin123!"), Phone = "999000001", IsEmailVerified = true };

        // 2 Couriers
        var courier1 = new User { RoleId = RoleId("courier"), FirstName = "Jorge", LastName = "Quispe", Email = "moto1@courier.pe", PasswordHash = Hash("Moto123!"), Phone = "999000002", IsEmailVerified = true };
        var courier2 = new User { RoleId = RoleId("courier"), FirstName = "Luis", LastName = "Huanca", Email = "moto2@courier.pe", PasswordHash = Hash("Moto123!"), Phone = "999000003", IsEmailVerified = true };

        // 3 Customers
        var customer1 = new User { RoleId = RoleId("customer"), FirstName = "Ana", LastName = "Torres", Email = "ana@example.com", PasswordHash = Hash("Customer123!"), Phone = "999000004", IsEmailVerified = true };
        var customer2 = new User { RoleId = RoleId("customer"), FirstName = "Pedro", LastName = "Salinas", Email = "pedro@example.com", PasswordHash = Hash("Customer123!"), Phone = "999000005", IsEmailVerified = true };
        var customer3 = new User { RoleId = RoleId("customer"), FirstName = "María", LastName = "Flores", Email = "maria@example.com", PasswordHash = Hash("Customer123!"), Phone = "999000006", IsEmailVerified = true };

        db.Users.AddRange(admin, courier1, courier2, customer1, customer2, customer3);
        await db.SaveChangesAsync(); // ← clave

    }

    // ── Perfiles de motorizado ────────────────────────────────────────────────
    private static async Task SeedDriverProfilesAsync(AppDbContext db)
    {
        if (await db.DriverProfiles.AnyAsync()) return;

        var couriers = await db.Users
            .Where(u => u.Role.Name == "courier")
            .Take(2)
            .ToListAsync();

        var vehicleTypes = await db.ItemDetails
            .Where(c => c.Item.Name == "Tipo de Vehículo")
            .Take(2)
            .ToListAsync();

        if (couriers.Count < 2 || vehicleTypes.Count < 2) return;

        DriverProfile CreateProfile(User user, int vehicleTypeId, string license, string driverLicense)
            => new()
            {
                UserId = user.Id,
                VehicleTypeId = vehicleTypeId,
                LicensePlate = license,
                DriverLicenseNumber = driverLicense,
                TotalDeliveries = 0,
                AverageRating = 0
            };

        var profile1 = CreateProfile(couriers[0], vehicleTypes[0].Id, "ABC-123", "LIC-00001");
        var profile2 = CreateProfile(couriers[1], vehicleTypes[1].Id, null, "LIC-00002");

        ApplyRating(profile1, 5, 5);
        ApplyRating(profile2, 4, 3);

        db.DriverProfiles.AddRange(profile1, profile2);
        await db.SaveChangesAsync();
    }

    private static void ApplyRating(DriverProfile profile, int rating, int deliveries)
    {
        for (int i = 0; i < deliveries; i++)
        {
            profile.TotalDeliveries++;

            profile.AverageRating =
                ((profile.AverageRating * (profile.TotalDeliveries - 1)) + rating)
                / profile.TotalDeliveries;
        }
    }


    // ── Direcciones ───────────────────────────────────────────────────────────
    private static async Task SeedAddressesAsync(AppDbContext db)
    {
        if (await db.Addresses.AnyAsync()) return;

        var customers = await db.Users
            .Include(u => u.Role)
            .Where(u => u.Role.Name == "customer")
            .ToListAsync();

        var ubigeos = await db.Ubigeos.ToListAsync();

        int UbigeoId(string district)
            => ubigeos.FirstOrDefault(u => u.District == district)?.Id
               ?? ubigeos.First().Id;

        if (customers.Count < 3) return;

        // Customer 1 — Ana Torres
        var address1 = new Address { UserId = customers[0].Id, UbigeoId = UbigeoId("Miraflores"), AddressLine = "Av. Larco 1234", Alias = "Casa", Reference = "Frente al parque", Latitude = -12.1211m, Longitude = -77.0296m };
        var address2 = new Address { UserId = customers[0].Id, UbigeoId = UbigeoId("San Isidro"), AddressLine = "Calle Las Flores 456", Alias = "Trabajo", Reference = "Piso 3, oficina 301", Latitude = -12.0967m, Longitude = -77.0359m };

        var address3 = new Address { UserId = customers[1].Id, UbigeoId = UbigeoId("Surquillo"), AddressLine = "Jr. Los Pinos 789", Alias = "Casa", Reference = "Ref: farmacia inkafarma", Latitude = -12.1120m, Longitude = -77.0079m };
        var address4 = new Address { UserId = customers[1].Id, UbigeoId = UbigeoId("La Molina"), AddressLine = "Av. La Molina 321", Alias = "Trabajo", Reference = "Edificio azul, 2do piso", Latitude = -12.0844m, Longitude = -76.9437m };

        var address5 = new Address { UserId = customers[2].Id, UbigeoId = UbigeoId("San Borja"), AddressLine = "Av. San Luis 654", Alias = "Casa", Reference = "Condominio Los Jardines", Latitude = -12.1034m, Longitude = -76.9939m };
        var address6 = new Address { UserId = customers[2].Id, UbigeoId = UbigeoId("Santiago de Surco"), AddressLine = "Calle Monte Rosa 987", Alias = "Trabajo", Reference = "Torre B, piso 8", Latitude = -12.1295m, Longitude = -76.9992m };

        db.Addresses.AddRange(address1, address2, address3, address4, address5, address6);
        await db.SaveChangesAsync();

    }

}

