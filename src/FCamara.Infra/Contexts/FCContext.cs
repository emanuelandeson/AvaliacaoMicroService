using FCamara.Domain.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace FCamara.Infra.Contexts
{
    public class FCContext : DbContext
    {
        public FCContext(DbContextOptions<FCContext> options) :
            base(options)
        { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            var options = new DbContextOptionsBuilder()
             .EnableSensitiveDataLogging()
             .Options;
        }
    }
}
