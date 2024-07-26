using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using Reminder.Models;

namespace Reminder.Infrastructure
{
    public class ReminderDbContext : DbContext
    {
        public ReminderDbContext(DbContextOptions<ReminderDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<CatalogStockReminder>  CatalogStockReminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CatalogStockReminder>().ToCollection("catalogstockreminders");
        }
    }
}
