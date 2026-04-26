using Express.API.Hubs;
using Express.API.Middlewares;
using Express.API.Services;
using Express.Application.Common.Interfaces;
using Express.Application.Extensions;
using Express.Infrastructure.Extensions;
using Express.Infrastructure.Persistence.Seeders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// ── Application + Infrastructure ──────────────────────────────────────────────
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// ── SignalR ────────────────────────────────────────────────────────────────────
builder.Services.AddSignalR();
builder.Services.AddScoped<IRealtimeNotificationService, SignalRNotificationService>();


// ── Controllers + OpenAPI ──────────────────────────────────────────────────────
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// ── JWT Authentication ─────────────────────────────────────────────────────────
var jwtSecret = builder.Configuration["Jwt:Secret"]
    ?? throw new InvalidOperationException("Jwt:Secret no configurado.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? "courier-api",
            ValidAudience = builder.Configuration["Jwt:Audience"] ?? "courier-client",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
            ClockSkew = TimeSpan.Zero
        };

        // Allow SignalR to read JWT from query string (WebSocket transport)
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
                    context.Token = accessToken;
                return Task.CompletedTask;
            }
        };
    });

// ── CORS ───────────────────────────────────────────────────────────────────────
// SignalR requires AllowCredentials + explicit origin (not AllowAnyOrigin)
var allowedOrigins = builder.Configuration
    .GetSection("AllowedOrigins")
    .Get<string[]>()
    ?? ["http://localhost:4200", "http://localhost:4000"];

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// ── ProblemDetails ─────────────────────────────────────────────────────────────
builder.Services.AddProblemDetails();


var app = builder.Build();

// ── Seeding ────────────────────────────────────────────────────────────────────
await DbSeeder.SeedAsync(app.Services);

// ── Middleware pipeline ────────────────────────────────────────────────────────
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Courier API";
        options.Theme = ScalarTheme.Moon;
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

// ── SignalR Hub ────────────────────────────────────────────────────────────────
app.MapHub<NotificationHub>("/hubs/notifications");

app.Run();
