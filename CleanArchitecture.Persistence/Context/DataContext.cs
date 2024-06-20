using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurasi nama tabel
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Role>().ToTable("roles");

            // Daftar entitas yang ingin dikonfigurasi
            var entities = new[] { typeof(User)};
            foreach (var entity in entities)
            {
                modelBuilder.Entity(entity)
                    .Property("created_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                modelBuilder.Entity(entity)
                    .Property("created_by")
                    .HasDefaultValue("system");

                modelBuilder.Entity(entity)
                    .Property("modified_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                modelBuilder.Entity(entity)
                    .Property("modified_by")
                    .HasDefaultValue("system");
            }


            base.OnModelCreating(modelBuilder);

        }


    }
}
