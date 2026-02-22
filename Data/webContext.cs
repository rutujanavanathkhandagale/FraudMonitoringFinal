using FraudMonitoringSystem.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace FraudMonitoringSystem.Data
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options) { }

        // ✅ DbSets for all entities
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<KYCProfile> KYCProfile { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasColumnType("decimal(18,2)");  

        }

    }
}
