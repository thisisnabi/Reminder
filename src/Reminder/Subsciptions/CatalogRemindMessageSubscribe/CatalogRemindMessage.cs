namespace Catalog.Infrastructure.IntegrationEvents;

public record CatalogRemindMessage(
    Guid UserId,
    string Slug,
    string Message,
    NotifyChannel Channel);


[Flags]
public enum NotifyChannel
{
    SMS = 1,
    Email = 2,
    MSTeams = 3,
    Telegram = 4,
    Slack = 5
}