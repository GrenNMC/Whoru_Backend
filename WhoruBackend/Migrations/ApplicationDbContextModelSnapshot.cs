﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WhoruBackend.Data;

#nullable disable

namespace WhoruBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WhoruBackend.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5455),
                            RoleName = "Admin",
                            UpdatedDate = new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5459)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5461),
                            RoleName = "User",
                            UpdatedDate = new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5462)
                        });
                });

            modelBuilder.Entity("WhoruBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("InfoId")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserName");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5542),
                            Email = "nmc0401@gmail.com",
                            InfoId = 1,
                            Password = "AQAQJwAAjvc2lWChvVWj5cOkLSsiL8QmaRibrroW0wepE6GITxLvrY199b1HPgXjv/KmDdgs",
                            RoleId = 1,
                            UpdatedDate = new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5543),
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 9, 10, 19, 10, 6, 346, DateTimeKind.Utc).AddTicks(7989),
                            Email = "20110455@gmail.com",
                            InfoId = 2,
                            Password = "AQAQJwAAwtC5HnB0ixu9cm1cF4vMVlsvp4h4cQJ2nyHENOVVXcfgRFY2L2AijTCIXhbY1fZt",
                            RoleId = 1,
                            UpdatedDate = new DateTime(2023, 9, 10, 19, 10, 6, 346, DateTimeKind.Utc).AddTicks(7993),
                            UserName = "admin_2"
                        });
                });

            modelBuilder.Entity("WhoruBackend.Models.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("WhoruBackend.Models.UserInfo", b =>
                {
                    b.HasOne("WhoruBackend.Models.User", "User")
                        .WithOne("UserInfo")
                        .HasForeignKey("WhoruBackend.Models.UserInfo", "UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
                });

            modelBuilder.Entity("WhoruBackend.Models.User", b =>
                {
                    b.Navigation("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
