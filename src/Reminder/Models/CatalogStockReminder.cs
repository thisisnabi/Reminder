using Catalog.Infrastructure.IntegrationEvents;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace Reminder.Models;

[Collection("catalogstockreminders")]
public class CatalogStockReminder
{
    public ObjectId Id { get; set; }
    public required string Message { get; set; }
    public Guid User { get; set; }
    public required string Slug { get; set; }
    public required NotifyChannel NotifyChannel { get; set; }
}
