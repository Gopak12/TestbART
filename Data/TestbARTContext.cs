using Microsoft.EntityFrameworkCore;
using TestbART.Model;

namespace TestbART.Data
{
    public class TestbARTContext : DbContext
    {
        public TestbARTContext(DbContextOptions<TestbARTContext> options)
            : base(options)
        {
        }

        public DbSet<TestbART.Model.Contact> Contacts { get; set; } 

        public DbSet<TestbART.Model.Account>? Accounts { get; set; }

        public DbSet<TestbART.Model.Incident>? Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestbART.Model.Contact>()
                .HasKey(c => c.Email)
                .IsClustered();

            modelBuilder.Entity<TestbART.Model.Contact>()
                .HasOne(c => c.Account)
                .WithMany(c => c.Contacts);

            modelBuilder.Entity<TestbART.Model.Account>()
                .HasOne(c => c.Incident)
                .WithMany(c => c.Accounts);
        }
    }
}
