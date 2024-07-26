using Catalog.Infrastructure.IntegrationEvents;
using MassTransit;
using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;
using Reminder.Infrastructure;
using Reminder.Publishing;

namespace Reminder.Subsciptions.CatalogRemindMessageSubscribe
{
    public class CatalogItemStockAvailableEventConsumer(
        IPublishEndpoint publisher,
        ReminderDbContext dbContext) : IConsumer<CatalogItemStockAvailableEvent>
    {
        private readonly ReminderDbContext _dbContext = dbContext;
        private readonly IPublishEndpoint _publisher = publisher;
        public async Task Consume(ConsumeContext<CatalogItemStockAvailableEvent> context)
        {
            var remiders = await _dbContext.CatalogStockReminders
                                          .Where(x => context.Message.Slugs.Contains(x.Slug))
                                          .Select(x => new BatchNotifyItem
                                          {
                                              Channel = x.NotifyChannel,
                                              Message = x.Message,
                                              UserId = x.User
                                          })
                                          .ToListAsync();

            await _publisher.Publish(new BatchNotifyMessage
            {
                Notifies = [.. remiders]
            });
        }
    }
}

