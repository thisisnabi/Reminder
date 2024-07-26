using Catalog.Infrastructure.IntegrationEvents;

namespace Reminder.Publishing;

public class BatchNotifyMessage
{
    public ICollection<BatchNotifyItem> Notifies { get; set; }
}

public class BatchNotifyItem
{
    public string Message { get; set; }
    public Guid UserId { get; set; }
    public NotifyChannel Channel { get; set; }
}
