using DigitalMart.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalMart.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurasi nama tabel
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Role>().ToTable("roles");
            modelBuilder.Entity<Permission>().ToTable("permissions");
            modelBuilder.Entity<RolePermission>().ToTable("role_permissions");
            modelBuilder.Entity<Product>().ToTable("products");

            modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new { rp.role_id, rp.permission_id });

            modelBuilder.Entity<Role>()
            .HasMany(r => r.role_permissions)
            .WithOne(rp => rp.role)
            .HasForeignKey(rp => rp.role_id);

            modelBuilder.Entity<Permission>()
                .HasMany(p => p.role_permissions)
                .WithOne(rp => rp.permission)
                .HasForeignKey(rp => rp.permission_id);

            // Daftar entitas yang ingin dikonfigurasi
            var entities = new[] { typeof(User), typeof(Product)};
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
