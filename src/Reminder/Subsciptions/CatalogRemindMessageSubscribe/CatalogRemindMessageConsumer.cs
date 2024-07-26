using Catalog.Infrastructure.IntegrationEvents;
using MassTransit;
using Reminder.Infrastructure;

namespace Reminder.Subsciptions.CatalogRemindMessageSubscribe;

public class CatalogRemindMessageConsumer(ReminderDbContext dbContext) : IConsumer<CatalogRemindMessage>
{
    private readonly ReminderDbContext _dbContext = dbContext;
    public async Task Consume(ConsumeContext<CatalogRemindMessage> context)
    {
        _dbContext.CatalogStockReminders.Add(new Models.CatalogStockReminder
        {
            Message = context.Message.Message,
            NotifyChannel = context.Message.Channel,
            User = context.Message.UserId,
            Slug = context.Message.Slug
        });
        await _dbContext.SaveChangesAsync(context.CancellationToken);
    }
}
