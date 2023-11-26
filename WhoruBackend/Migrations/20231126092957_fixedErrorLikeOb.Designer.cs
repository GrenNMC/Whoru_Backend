﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WhoruBackend.Data;

#nullable disable

namespace WhoruBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231126092957_fixedErrorLikeOb")]
    partial class fixedErrorLikeOb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WhoruBackend.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<int?>("UserReceive")
                        .HasColumnType("integer");

                    b.Property<int?>("UserSend")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserReceive");

                    b.HasIndex("UserSend");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("WhoruBackend.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FeedId")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FeedId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WhoruBackend.Models.Feed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserInfoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("Feeds");
                });

            modelBuilder.Entity("WhoruBackend.Models.FeedImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("FeedId")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FeedId");

                    b.ToTable("FeedImages");
                });

            modelBuilder.Entity("WhoruBackend.Models.Follow", b =>
                {
                    b.Property<int>("IdFollowing")
                        .HasColumnType("integer");

                    b.Property<int>("IdFollower")
                        .HasColumnType("integer");

                    b.HasKey("IdFollowing", "IdFollower");

                    b.HasIndex("IdFollower");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("WhoruBackend.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FeedId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FeedId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("WhoruBackend.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<int?>("UserReceive")
                        .HasColumnType("integer");

                    b.Property<int?>("UserSend")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserReceive");

                    b.HasIndex("UserSend");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("WhoruBackend.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 11, 26, 9, 29, 57, 468, DateTimeKind.Utc).AddTicks(3640),
                            RoleName = "Admin",
                            UpdatedDate = new DateTime(2023, 11, 26, 9, 29, 57, 468, DateTimeKind.Utc).AddTicks(3645)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 11, 26, 9, 29, 57, 468, DateTimeKind.Utc).AddTicks(3647),
                            RoleName = "User",
                            UpdatedDate = new DateTime(2023, 11, 26, 9, 29, 57, 468, DateTimeKind.Utc).AddTicks(3648)
                        });
                });

            modelBuilder.Entity("WhoruBackend.Models.Share", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FeedId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FeedId");

                    b.ToTable("Shares");
                });

            modelBuilder.Entity("WhoruBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ActiveCode")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool?>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActiveCode = "412002",
                            CreatedDate = new DateTime(2023, 11, 26, 9, 29, 57, 468, DateTimeKind.Utc).AddTicks(3716),
                            Email = "nmc0401@gmail.com",
                            IsDisabled = false,
                            Password = "AQAQJwAAlCzp0R87s9pBOL99LFaBMbbj90a691hOIq5tyjXksE2eAzYE+X7lDFrJrb3/U/4Y",
                            Phone = "0769395658",
                            RoleId = 1,
                            UpdatedDate = new DateTime(2023, 11, 26, 9, 29, 57, 468, DateTimeKind.Utc).AddTicks(3717),
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            ActiveCode = "412222",
                            CreatedDate = new DateTime(2023, 11, 26, 9, 29, 57, 479, DateTimeKind.Utc).AddTicks(134),
                            Email = "20110455@gmail.com",
                            IsDisabled = false,
                            Password = "AQAQJwAATAakuIQ9+PFab7+aPUDK8NcHgzBGp1TfRD7B4aSxV4+qxr1+S+f7XDTE/8mh2XLN",
                            Phone = "0769395658",
                            RoleId = 1,
                            UpdatedDate = new DateTime(2023, 11, 26, 9, 29, 57, 479, DateTimeKind.Utc).AddTicks(137),
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

                    b.Property<string>("Backround")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserInfos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Avatar = "Link hinh anh :>",
                            FullName = "Nguyen Minh Cuong",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Avatar = "Link hinh anh :>",
                            FullName = "Nguyen Minh Nhut",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("WhoruBackend.Models.Chat", b =>
                {
                    b.HasOne("WhoruBackend.Models.UserInfo", "Receiver")
                        .WithMany("ReceiveChats")
                        .HasForeignKey("UserReceive")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WhoruBackend.Models.UserInfo", "Sender")
                        .WithMany("SendChats")
                        .HasForeignKey("UserSend")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("WhoruBackend.Models.Comment", b =>
                {
                    b.HasOne("WhoruBackend.Models.Feed", "Feed")
                        .WithMany("Comments")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("WhoruBackend.Models.UserInfo", "UserInfo")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Feed");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("WhoruBackend.Models.Feed", b =>
                {
                    b.HasOne("WhoruBackend.Models.UserInfo", "UserInfo")
                        .WithMany("Feeds")
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("WhoruBackend.Models.FeedImage", b =>
                {
                    b.HasOne("WhoruBackend.Models.Feed", "Feed")
                        .WithMany("Images")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Feed");
                });

            modelBuilder.Entity("WhoruBackend.Models.Follow", b =>
                {
                    b.HasOne("WhoruBackend.Models.UserInfo", "Follower")
                        .WithMany("Follower")
                        .HasForeignKey("IdFollower")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("WhoruBackend.Models.UserInfo", "Following")
                        .WithMany("Following")
                        .HasForeignKey("IdFollowing")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Following");
                });

            modelBuilder.Entity("WhoruBackend.Models.Like", b =>
                {
                    b.HasOne("WhoruBackend.Models.Feed", "Feed")
                        .WithMany("Likes")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("WhoruBackend.Models.UserInfo", "UserInfo")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Feed");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("WhoruBackend.Models.Notification", b =>
                {
                    b.HasOne("WhoruBackend.Models.UserInfo", "Receiver")
                        .WithMany("ReceiveNotifications")
                        .HasForeignKey("UserReceive")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WhoruBackend.Models.UserInfo", "Sender")
                        .WithMany("SendNotifications")
                        .HasForeignKey("UserSend")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("WhoruBackend.Models.Share", b =>
                {
                    b.HasOne("WhoruBackend.Models.Feed", "Feed")
                        .WithMany("Shares")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("WhoruBackend.Models.UserInfo", "UserInfo")
                        .WithMany("Shares")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Feed");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("WhoruBackend.Models.User", b =>
                {
                    b.HasOne("WhoruBackend.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WhoruBackend.Models.UserInfo", b =>
                {
                    b.HasOne("WhoruBackend.Models.User", "User")
                        .WithOne("UserInfo")
                        .HasForeignKey("WhoruBackend.Models.UserInfo", "UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
                });

            modelBuilder.Entity("WhoruBackend.Models.Feed", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Images");

                    b.Navigation("Likes");

                    b.Navigation("Shares");
                });

            modelBuilder.Entity("WhoruBackend.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WhoruBackend.Models.User", b =>
                {
                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("WhoruBackend.Models.UserInfo", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Feeds");

                    b.Navigation("Follower");

                    b.Navigation("Following");

                    b.Navigation("Likes");

                    b.Navigation("ReceiveChats");

                    b.Navigation("ReceiveNotifications");

                    b.Navigation("SendChats");

                    b.Navigation("SendNotifications");

                    b.Navigation("Shares");
                });
#pragma warning restore 612, 618
        }
    }
}
