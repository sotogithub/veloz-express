using Express.API.Hubs;
using Express.Application.Common.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Express.API.Services;


/// <summary>
/// Pushes real-time notifications to connected SignalR clients.
/// Registered in the API project so it has access to IHubContext.
/// </summary>
public class SignalRNotificationService(IHubContext<NotificationHub> hub)
    : IRealtimeNotificationService
{
    public async Task SendToUserAsync(int userId, RealtimeNotificationPayload payload, CancellationToken ct = default)
    {
        await hub.Clients
            .Group($"user_{userId}")
            .SendAsync("ReceiveNotification", payload, ct);
    }
}
