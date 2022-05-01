using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResidenceManagement.Domain.Entities.Auths;
using ResidenceManagement.Domain.Entities.Managements;
using System.Collections.Generic;

namespace ResidenceManagement.Infrastructure.Persistence
{
    public class SiteContext : IdentityDbContext<User,Role,int>
    {
        public SiteContext(DbContextOptions<SiteContext> options) : base(options)
        {

        }
        public DbSet<Residence> Residences { get; set; }
        public DbSet<ResidenceType> ResidenceTypes { get; set; }
        public DbSet<UserResidence> UserResidences { get; set; }
        public DbSet<Dues> Dueses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ResidenceDues> ResidenceDues { get; set; }
        public DbSet<ResidenceInvoice> ResidenceInvoices { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            SeedUsers(builder);
            SeedRoles(builder);
            SeedResidenceType(builder);
            SeedUserRole(builder);
            SeedResidentType(builder);


        }

        private void SeedUsers(ModelBuilder builder)
        {
            var admin = new User()
            {
                Id=1,
                FirstName = "Rıza Can",
                LastName = "Tire",
                Email ="admin@admin.com"
                
            };

            var user1 = new User()
            {
                Id = 2,
                FirstName = "Ahmet",
                LastName = "Tire",
                Email = "ahmet@admin.com"

            };

            var user2 = new User()
            {
                Id = 3,
                FirstName = "Demiralp",
                LastName = "Tire",
                Email = "d@d.com"

            };

            var user3 = new User()
            {
                Id = 4,
                FirstName = "Yasemin",
                LastName = "Tire",
                Email = "y@y.com"

            };

            var user4 = new User()
            {
                Id = 5,
                FirstName = "Hasibe",
                LastName = "Tire",
                Email = "h@h.com"

            };


            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin123");
            user1.PasswordHash = passwordHasher.HashPassword(user1, "Abcd123");
            user2.PasswordHash = passwordHasher.HashPassword(user2, "Abcd123");
            user3.PasswordHash = passwordHasher.HashPassword(user3, "Abcd123");
            user4.PasswordHash = passwordHasher.HashPassword(user4, "Abcd123");





            builder.Entity<User>().HasData(admin);
            builder.Entity<User>().HasData(user1);
            builder.Entity<User>().HasData(user2);
            builder.Entity<User>().HasData(user3);
            builder.Entity<User>().HasData(user4);


        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role() { Id = 1, Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new Role() { Id = 2, Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }

                );
        }

        private void SeedResidenceType(ModelBuilder builder)
        {
            builder.Entity<ResidenceType>().HasData(
                new ResidenceType() { Id = 1, Type = "1+0"},
                new ResidenceType() { Id = 2, Type = "1+1" },
                new ResidenceType() { Id = 3, Type = "2+1" },
                new ResidenceType() { Id = 4, Type = "3+1" },
                new ResidenceType() { Id = 5, Type = "4+1" },
                new ResidenceType() { Id = 6, Type = "5+1" }
                );
        }
        private void SeedUserRole(ModelBuilder builder)
        {
            builder.Entity<UserRole>().HasData(
                new UserRole() { UserId = 1, RoleId = 1 },
                new UserRole() { UserId = 2, RoleId = 2 },
                new UserRole() { UserId = 3, RoleId = 2 },
                new UserRole() { UserId = 4, RoleId = 2 },
                new UserRole() { UserId = 5, RoleId = 2 }

                );
        }

        private void SeedResidentType(ModelBuilder builder)
        {
            builder.Entity<ResidentType>().HasData(
                new ResidentType() {Id=1, Type = "Owner" },
                new ResidentType() {Id=2,  Type = "Tenant" }

                );
        }


    }
}
