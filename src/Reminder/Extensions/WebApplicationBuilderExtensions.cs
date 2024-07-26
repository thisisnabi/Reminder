using MassTransit;
using Microsoft.EntityFrameworkCore;
using Reminder.Infrastructure;
using System.Reflection;

namespace Reminder.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void BrokerConfigure(this IHostApplicationBuilder builder)
        {
            builder.Services.AddMassTransit(configure =>
            {
                var brokerConfig = builder.Configuration.GetSection(BrokerOptions.SectionName)
                                                        .Get<BrokerOptions>();
                if (brokerConfig is null)
                {
                    throw new ArgumentNullException(nameof(BrokerOptions));
                }

                configure.AddConsumers(Assembly.GetExecutingAssembly());
                configure.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(brokerConfig.Host, hostConfigure =>
                    {
                        hostConfigure.Username(brokerConfig.Username);
                        hostConfigure.Password(brokerConfig.Password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });
        }

        public static void DbContextConfigure(this IHostApplicationBuilder builder)
        {
          
            var settings = builder.Configuration.Get<ReminderOptions>();

            builder.Services.AddDbContext<ReminderDbContext>(options =>
            {
                if (settings is null)
                {
                    // TODO: create custom excetion
                    throw new Exception("Invalid settings!");
                }
                options.UseMongoDB(settings.MongoDbSettings.Host,
                                   settings.MongoDbSettings.DatabaseName);
            });
        }
    }
}
