namespace Express.Application.Common.Interfaces;


/// <summary>
/// Sends real-time push events to connected SignalR clients.
/// Implemented in Infrastructure; injected into Application command handlers.
/// </summary>
public interface IRealtimeNotificationService
{
    /// <summary>
    /// Pushes a notification payload to a specific user's SignalR group.
    /// </summary>
    Task SendToUserAsync(int userId, RealtimeNotificationPayload payload, CancellationToken ct = default);
}

/// <summary>
/// Lightweight payload sent over the wire via SignalR.
/// Mirrors NotificacionDto so the Angular client can update its state directly.
/// </summary>
public record RealtimeNotificationPayload(
    int Id,
    string Titulo,
    string Mensaje,
    string Tipo,
    bool Leida,
    int? PaqueteId,
    DateTime CreadoEn);

