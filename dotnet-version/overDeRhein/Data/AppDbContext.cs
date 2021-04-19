using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using overDeRhein.Data.Models;

namespace overDeRhein.Data
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _AppSettings { get; set; }
        public AppDbContext(IConfiguration appSettings)
        {
            _AppSettings = appSettings;
        }

        public DbSet<CableChecklists> CableChecklists { get; set; }
        public DbSet<CoverPages> CoverPages { get; set; }
        public DbSet<CoverPageStatus> CoverPageStatus { get; set; }
        public DbSet<LiftingTests> LiftingTests { get; set; }
        public DbSet<Signatures> Signatures { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserType> UserType { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_AppSettings.GetValue<string>("SqlConectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserType>().HasData(new UserType {
                UserTypeID = 1,
                Type = "Directie"
            });
            modelBuilder.Entity<UserType>().HasData(new UserType {
                UserTypeID = 2,
                Type = "Veiligheid en milieu"
            });
            modelBuilder.Entity<UserType>().HasData(new UserType {
                UserTypeID = 3,
                Type = "Materieel"
            });
            modelBuilder.Entity<UserType>().HasData(new UserType {
                UserTypeID = 4,
                Type = "Projectbureau"
            });
            modelBuilder.Entity<UserType>().HasData(new UserType {
                UserTypeID = 5,
                Type = "admin"
            });

            modelBuilder.Entity<Users>().HasData(new Users {
                UserID = 1,
                UserTypeID = 5,
                UserName = "admin",
                Password = "c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec"
            });
            modelBuilder.Entity<Users>().HasData(new Users {
                UserID = 2,
                UserTypeID = 1,
                UserName = "user",
                Password = "c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec"
            });
        }
    }
}