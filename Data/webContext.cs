using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace FraudMonitoringSystem.Data
{
    public class WebContext : DbContext//track
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options) { }//connetion string and provide database and it will configure to program.cs

      
        public DbSet<Registration> Registrations { get; set; }//support ececution actinary item 
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<KYCProfile> KYCProfile { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Role>()
.Property(r => r.RoleId)
.ValueGeneratedOnAdd();
            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);
        

    }

    }
}
