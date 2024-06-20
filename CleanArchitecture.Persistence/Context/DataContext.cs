using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurasi nama tabel
            modelBuilder.Entity<User>()
                .ToTable("users");

            modelBuilder.Entity<User>()
                .Property(e => e.created_date)
                .HasDefaultValueSql("CURRENT_TIMESTAMP"); 

            modelBuilder.Entity<User>()
                .Property(e => e.created_by)
                .HasDefaultValue("system"); 

            modelBuilder.Entity<User>()
                .Property(e => e.modified_date)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                .Property(e => e.modified_by)
                .HasDefaultValue("system");


            base.OnModelCreating(modelBuilder);

        }


    }
}
