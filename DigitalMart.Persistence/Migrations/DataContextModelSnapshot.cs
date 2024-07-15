﻿// <auto-generated />
using System;
using DigitalMart.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DigitalMart.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DigitalMart.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("http_method")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("permissions", (string)null);
                });

            modelBuilder.Entity("DigitalMart.Domain.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("created_by")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("system");

                    b.Property<DateTimeOffset?>("created_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("image_local_path")
                        .HasColumnType("text");

                    b.Property<string>("image_url")
                        .HasColumnType("text");

                    b.Property<bool?>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("modified_by")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("system");

                    b.Property<DateTimeOffset?>("modified_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("DigitalMart.Domain.Entities.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("DigitalMart.Domain.Entities.RolePermission", b =>
                {
                    b.Property<int>("role_id")
                        .HasColumnType("integer");

                    b.Property<int>("permission_id")
                        .HasColumnType("integer");

                    b.HasKey("role_id", "permission_id");

                    b.HasIndex("permission_id");

                    b.ToTable("role_permissions", (string)null);
                });

            modelBuilder.Entity("DigitalMart.Domain.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("created_by")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("system");

                    b.Property<DateTimeOffset?>("created_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("modified_by")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("system");

                    b.Property<DateTimeOffset?>("modified_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("password_hash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("password_reset_expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("password_reset_token")
                        .HasColumnType("text");

                    b.Property<string>("password_salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("refresh_token")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("refresh_token_created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("refresh_token_expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("role_id")
                        .HasColumnType("integer");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("verify_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("verify_token")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("role_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("DigitalMart.Domain.Entities.RolePermission", b =>
                {
                    b.HasOne("DigitalMart.Domain.Entities.Permission", "permission")
                        .WithMany("role_permissions")
                        .HasForeignKey("permission_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalMart.Domain.Entities.Role", "role")
                        .WithMany("role_permissions")
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("permission");

                    b.Navigation("role");
                });

            modelBuilder.Entity("DigitalMart.Domain.Entities.User", b =>
                {
                    b.HasOne("DigitalMart.Domain.Entities.Role", "role")
                        .WithMany()
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");
                });

            modelBuilder.Entity("DigitalMart.Domain.Entities.Permission", b =>
                {
                    b.Navigation("role_permissions");
                });

            modelBuilder.Entity("DigitalMart.Domain.Entities.Role", b =>
                {
                    b.Navigation("role_permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
