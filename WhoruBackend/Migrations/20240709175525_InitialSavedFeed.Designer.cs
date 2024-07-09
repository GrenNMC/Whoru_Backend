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
    [Migration("20240709175525_InitialSavedFeed")]
    partial class InitialSavedFeed
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

                    b.Property<bool?>("IsSeen")
                        .HasColumnType("boolean");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<string>("Type")
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

            modelBuilder.Entity("WhoruBackend.Models.FaceRecogNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Embedding")
                        .HasColumnType("double precision");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FaceRecogNumbers");
                });

            modelBuilder.Entity("WhoruBackend.Models.Feed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("State")
                        .HasColumnType("integer");

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

                    b.Property<string>("ImageName")
                        .HasColumnType("text");

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

            modelBuilder.Entity("WhoruBackend.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Locations");
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
                            CreatedDate = new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7697),
                            RoleName = "Admin",
                            UpdatedDate = new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7701)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7702),
                            RoleName = "User",
                            UpdatedDate = new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7703)
                        });
                });

            modelBuilder.Entity("WhoruBackend.Models.SavedFeed", b =>
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

                    b.ToTable("SavedFeeds");
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

                    b.HasIndex("UserId");

                    b.ToTable("Shares");
                });

            modelBuilder.Entity("WhoruBackend.Models.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("WhoruBackend.Models.SuggestionUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("SuggestUser")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "SuggestUser");

                    b.HasIndex("SuggestUser");

                    b.ToTable("SuggestionUsers");
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
                            CreatedDate = new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7748),
                            Email = "nmc0401@gmail.com",
                            IsDisabled = false,
                            Password = "AQAQJwAA4P2RLZcv7/YpanVgYlMgwODBNALFhe+D/q3nT6r17uLqqPWq3TtsO7BURBW0j1QG",
                            Phone = "0769395658",
                            RoleId = 1,
                            UpdatedDate = new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7748),
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            ActiveCode = "412222",
                            CreatedDate = new DateTime(2024, 7, 9, 17, 55, 24, 699, DateTimeKind.Utc).AddTicks(4023),
                            Email = "20110455@gmail.com",
                            IsDisabled = false,
                            Password = "AQAQJwAABLHlPbEfPrL/bv5LQhablzlM0mQS00bNfCXLUFSzTcruGauN2c+muWUlVNPDdTKh",
                            Phone = "0769395658",
                            RoleId = 1,
                            UpdatedDate = new DateTime(2024, 7, 9, 17, 55, 24, 699, DateTimeKind.Utc).AddTicks(4026),
                            UserName = "admin_2"
                        });
                });

            modelBuilder.Entity("WhoruBackend.Models.UserChat", b =>
                {
                    b.Property<int>("IdUser1")
                        .HasColumnType("integer");

                    b.Property<int>("IdUser2")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("isWait")
                        .HasColumnType("boolean");

                    b.HasKey("IdUser1", "IdUser2");

                    b.HasIndex("IdUser2");

                    b.ToTable("UserChats");
                });

            modelBuilder.Entity("WhoruBackend.Models.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<string>("AvtName")
                        .HasColumnType("text");

                    b.Property<string>("Backround")
                        .HasColumnType("text");

                    b.Property<string>("BackroundName")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("StudyAt")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("WorkingAt")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserInfos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Avatar = "https://firebasestorage.googleapis.com/v0/b/whoru-2f115.appspot.com/o/Avatars%2Fdefault-avatar.jpg?alt=media&token=7721df77-f806-41c7-bcfe-2aae9acc98c7",
                            AvtName = "default-avatar",
                            Backround = "https://firebasestorage.googleapis.com/v0/b/whoru-2f115.appspot.com/o/Backgrounds%2Fdefault-background.jpg?alt=media&token=e99f5f3d-9b05-4594-a233-f839204e56e6",
                            BackroundName = "default-backround",
                            Description = "Lonely",
                            FullName = "Nguyen Minh Cuong",
                            StudyAt = "HCMUTE",
                            UserId = 1,
                            WorkingAt = "HCMUTE"
                        },
                        new
                        {
                            Id = 2,
                            Avatar = "https://firebasestorage.googleapis.com/v0/b/whoru-2f115.appspot.com/o/Avatars%2Fdefault-avatar.jpg?alt=media&token=7721df77-f806-41c7-bcfe-2aae9acc98c7",
                            AvtName = "default-avatar",
                            Backround = "https://firebasestorage.googleapis.com/v0/b/whoru-2f115.appspot.com/o/Backgrounds%2Fdefault-background.jpg?alt=media&token=e99f5f3d-9b05-4594-a233-f839204e56e6",
                            BackroundName = "default-backround",
                            Description = "Naive",
                            FullName = "Nguyen Minh Nhut",
                            StudyAt = "HCMUTE",
                            UserId = 2,
                            WorkingAt = "HCMUTE"
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

            modelBuilder.Entity("WhoruBackend.Models.FaceRecogNumber", b =>
                {
                    b.HasOne("WhoruBackend.Models.UserInfo", "UserInfo")
                        .WithMany("Embeddings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

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

            modelBuilder.Entity("WhoruBackend.Models.Location", b =>
                {
                    b.HasOne("WhoruBackend.Models.UserInfo", "UserInfo")
                        .WithOne("Location")
                        .HasForeignKey("WhoruBackend.Models.Location", "UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

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

            modelBuilder.Entity("WhoruBackend.Models.SavedFeed", b =>
                {
                    b.HasOne("WhoruBackend.Models.Feed", "Feed")
                        .WithMany("SavedFeed")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("WhoruBackend.Models.UserInfo", "UserInfo")
                        .WithMany("SavedFeed")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Feed");

                    b.Navigation("UserInfo");
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
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Feed");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("WhoruBackend.Models.Story", b =>
                {
                    b.HasOne("WhoruBackend.Models.UserInfo", "User")
                        .WithMany("Stories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
                });

            modelBuilder.Entity("WhoruBackend.Models.SuggestionUser", b =>
                {
                    b.HasOne("WhoruBackend.Models.UserInfo", "SuggestUserInfo")
                        .WithMany("isSuggestionUsers")
                        .HasForeignKey("SuggestUser")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("WhoruBackend.Models.UserInfo", "UserInfo")
                        .WithMany("SuggestionUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("SuggestUserInfo");

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

            modelBuilder.Entity("WhoruBackend.Models.UserChat", b =>
                {
                    b.HasOne("WhoruBackend.Models.UserInfo", "UserInfo1")
                        .WithMany("UserChat1")
                        .HasForeignKey("IdUser1")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("WhoruBackend.Models.UserInfo", "UserInfo2")
                        .WithMany("UserChat2")
                        .HasForeignKey("IdUser2")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("UserInfo1");

                    b.Navigation("UserInfo2");
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

                    b.Navigation("SavedFeed");

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

                    b.Navigation("Embeddings");

                    b.Navigation("Feeds");

                    b.Navigation("Follower");

                    b.Navigation("Following");

                    b.Navigation("Likes");

                    b.Navigation("Location");

                    b.Navigation("ReceiveChats");

                    b.Navigation("ReceiveNotifications");

                    b.Navigation("SavedFeed");

                    b.Navigation("SendChats");

                    b.Navigation("SendNotifications");

                    b.Navigation("Shares");

                    b.Navigation("Stories");

                    b.Navigation("SuggestionUsers");

                    b.Navigation("UserChat1");

                    b.Navigation("UserChat2");

                    b.Navigation("isSuggestionUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
