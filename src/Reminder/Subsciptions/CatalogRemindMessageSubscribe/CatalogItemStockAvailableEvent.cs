
namespace Catalog.Infrastructure.IntegrationEvents
{
    public class CatalogItemStockAvailableEvent
    {
        public ICollection<string> Slugs { get; set; }
    }
}
