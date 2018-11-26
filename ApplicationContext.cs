using Microsoft.EntityFrameworkCore;
using MigrationBugRepro.Models;

namespace MigrationBugRepro
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Account>(b =>
            {
                b.HasKey(x => x.AccountId);
                b.Property(e => e.AccountId).HasMaxLength(36).IsRequired();

                // Multiple Owned Types
                b.OwnsOne(e => e.MainAddress, a =>
                {
                    a.Property(x => x.AddressLine1).HasMaxLength(256);
                    a.Property(x => x.City).HasMaxLength(256);
                });
                b.OwnsOne(e => e.SecondaryAddress, a =>
                {
                    a.Property(x => x.AddressLine1).HasMaxLength(256);
                    a.Property(x => x.City).HasMaxLength(256);
                });
            });
        }
    }
}
