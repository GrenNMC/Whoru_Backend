using Microsoft.AspNetCore.Identity;
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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserInfo>() 
                .HasOne(s => s.User)
                .WithOne(s => s.UserInfo)
                .HasForeignKey<UserInfo>(s => s.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Set indexes
            modelBuilder.Entity<User>()
                .HasIndex(s => s.UserName);

            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
            //SeedUserInfos(modelBuilder);
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
                InfoId = 1,
                RoleId = 1,
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
                InfoId = 2,
                RoleId = 1,
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
            modelBuilder.Entity<UserInfo>().HasData(userInfo);
        }

    }
}
