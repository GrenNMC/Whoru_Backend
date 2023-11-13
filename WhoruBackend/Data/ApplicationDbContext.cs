using Microsoft.EntityFrameworkCore;
using WhoruBackend.Models;
using WhoruBackend.Utilities.SecurePassword;

namespace WhoruBackend.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<FeedImage> FeedImages { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Follow>()
                .HasKey(f => new { f.IdFollowing, f.IdFollower });
            modelBuilder.Entity<Notification>()
                .HasKey(f => new { f.UserReceive, f.UserSend });

            modelBuilder.Entity<User>()
                .HasOne(s => s.Role)
                .WithMany(s => s.Users)
                .HasForeignKey(s => s.RoleId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<UserInfo>() 
                .HasOne(s => s.User)
                .WithOne(s => s.UserInfo)
                .HasForeignKey<UserInfo>(s => s.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Feed>()
                .HasOne(s => s.UserInfo)
                .WithMany(s => s.Feeds)
                .HasForeignKey(s => s.UserInfoId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<FeedImage>()
                .HasOne(s => s.Feed)
                .WithMany(s => s.Images)
                .HasForeignKey(s => s.FeedId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Share>()
                .HasOne(s => s.Feed)
                .WithMany(s => s.Shares)
                .HasForeignKey(s => s.FeedId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Share>()
                .HasOne(s => s.UserInfo)
                .WithMany(s => s.Shares)
                .HasForeignKey(s => s.FeedId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Like>()
               .HasOne(s => s.Feed)
               .WithMany(s => s.Likes)
               .HasForeignKey(s => s.FeedId)
               .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Like>()
                .HasOne(s => s.UserInfo)
                .WithMany(s => s.Likes)
                .HasForeignKey(s => s.FeedId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Comment>()
                .HasOne(s => s.Feed)
                .WithMany(s => s.Comments)
                .HasForeignKey(s => s.FeedId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Comment>()
                .HasOne(s => s.UserInfo)
                .WithMany(s => s.Comments)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Follow>()
                .HasOne(s => s.Following)
                .WithMany(s => s.Following)
                .HasForeignKey(s => s.IdFollowing)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Follow>()
                .HasOne(s => s.Follower)
                .WithMany(s => s.Follower)
                .HasForeignKey(s => s.IdFollower)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Notification>()
                .HasOne(s => s.Sender)
                .WithMany(s => s.SendNotifications)
                .HasForeignKey(s => s.UserSend)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Notification>()
                .HasOne(s => s.Receiver)
                .WithMany(s => s.ReceiveNotifications)
                .HasForeignKey(s => s.UserReceive)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Chat>()
                .HasOne(s => s.Sender)
                .WithMany(s => s.SendChats)
                .HasForeignKey(s => s.UserSend)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Chat>()
                .HasOne(s => s.Receiver)
                .WithMany(s => s.ReceiveChats)
                .HasForeignKey(s => s.UserReceive)
                .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<UserInfo>()
            //    .HasMany(ui => ui.Follower)
            //    .WithOne()
            //    .HasForeignKey(ui => ui.UserId)
            //    .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<UserInfo>()
            //    .HasMany(ui => ui.Following)
            //    .WithOne()
            //    .HasForeignKey(ui => ui.UserId)
            //    .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<Notification>()
            //    .HasOne(s => s.Sender)
            //    .WithMany(s => s.Notifications)
            //    .HasForeignKey(s => s.UserSend)
            //    .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<Notification>()
            //    .HasOne(s => s.Receiver)
            //    .WithMany(s => s.Notifications)
            //    .HasForeignKey(s => s.UserReceive)
            //    .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<Chat>()
            //    .HasOne(s => s.Sender)
            //    .WithMany(s => s.Chats)
            //    .HasForeignKey(s => s.UserSend)
            //    .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<Chat>()
            //    .HasOne(s => s.Receiver)
            //    .WithMany(s => s.Chats)
            //    .HasForeignKey(s => s.UserReceive)
            //    .OnDelete(DeleteBehavior.SetNull);

            // Set indexes
            modelBuilder.Entity<User>()
                .HasIndex(s => s.UserName);

            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
            SeedUserInfos(modelBuilder);
        }

        // Seed data
        private void SeedRoles(ModelBuilder modelBuilder)
        {
            Role newAdminRole = new()
            {
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Id = 1,
                RoleName = "Admin"
            };
            Role newUserRole = new()
            {
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Id = 2,
                RoleName = "User"
            };
            modelBuilder.Entity<Role>().HasData(newAdminRole);
            modelBuilder.Entity<Role>().HasData(newUserRole);
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            User newUser = new()
            {
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Id = 1,
                UserName = "Admin",
                Email = "nmc0401@gmail.com",
                RoleId = 1,
                Phone = "0769395658",
                IsDisabled = false,
                ActiveCode = "412002"
            };
            newUser.Password = new PasswordHasher().HashToString("123456@A");
            modelBuilder.Entity<User>().HasData(newUser);

            User newUser2 = new User
            {
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Id = 2,
                UserName = "admin_2",
                Email = "20110455@gmail.com",
                RoleId = 1,
                Phone = "0769395658",
                IsDisabled = false,
                ActiveCode = "412222"
            };
            newUser2.Password = new PasswordHasher().HashToString("123456@A");
            modelBuilder.Entity<User>().HasData(newUser2);
        }
        private void SeedUserInfos(ModelBuilder modelBuilder)
        {
            UserInfo userInfo = new()
            {
                Id = 1,
                FullName = "Nguyen Minh Cuong",
                Avatar = "Link hinh anh :>",
                UserId = 1
            };
            modelBuilder.Entity<UserInfo>().HasData(userInfo);

            UserInfo userInfo2 = new()
            {
                Id = 2,
                FullName = "Nguyen Minh Nhut",
                Avatar = "Link hinh anh :>",
                UserId = 2
            };
            modelBuilder.Entity<UserInfo>().HasData(userInfo2);
        }

    }
}
