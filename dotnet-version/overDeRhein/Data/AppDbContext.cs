using System;
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
        public DbSet<CoverPageType> CoverPageType { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserType> UserType { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_AppSettings.GetValue<string>("SqlConectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // UserType table
            modelBuilder.Entity<UserType>().HasData(new UserType {
                UserTypeID = 1,
                Type = "Directie",
                Role = 0
            });
            modelBuilder.Entity<UserType>().HasData(new UserType {
                UserTypeID = 2,
                Type = "Veiligheid en milieu",
                Role = 0
            });
            modelBuilder.Entity<UserType>().HasData(new UserType {
                UserTypeID = 3,
                Type = "Materieel",
                Role = 0
            });
            modelBuilder.Entity<UserType>().HasData(new UserType {
                UserTypeID = 4,
                Type = "Projectbureau",
                Role = 0
            });
            modelBuilder.Entity<UserType>().HasData(new UserType {
                UserTypeID = 5,
                Type = "admin",
                Role = 1
            });

            // Users table
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

            // CoverPageStatus table
            modelBuilder.Entity<CoverPageStatus>().HasData(new CoverPageStatus
            {
                CoverPageStatusID = 1,
                StatusType = "Open"
            });
            modelBuilder.Entity<CoverPageStatus>().HasData(new CoverPageStatus
            {
                CoverPageStatusID = 2,
                StatusType = "Gesloten"
            });

            // CoverPageType table
            modelBuilder.Entity<CoverPageType>().HasData(new CoverPageType
            {
                CoverPageTypeID = 1,
                Type = "Hijs-testen"
            });
            modelBuilder.Entity<CoverPageType>().HasData(new CoverPageType
            {
                CoverPageTypeID = 2,
                Type = "Kabel-check-lijst"
            });

            // CoverPages table
            modelBuilder.Entity<CoverPages>().HasData(new CoverPages
            {
                CoverPagesID = 1,
                UserID = 2,
                CoverPageStatusID = 1,
                CoverPageTypeID = 1,
                TCVTNumber = 234,
                InspectionDate = new DateTime(2021, 2, 15),
                Executor = "ksgfskdajf",
                Specialist = "dkshjfgfh",
                CrainSetup = "owreuityert",
                ExecutionTowerHookHeight = 4378,
                BoomType = "hfdsf",
                TelescopicBoomParts = 6,
                ConstructionBoomMeters = 6,
                JibBoomMeters = 6,
                FlyJibParts = 5,
                BoomLength = 6,
                Topable = 1,
                Trolley = 1,
                AdjustableBoom = 1,
                StampsType = 1,
                Shortcomings = 0,
                SignOutBefore = new DateTime(2021, 3, 3),
                Elucidation = "hjg",
                WorkInstruction = "dskgf",
                CableSupplier = "Hello world",
                Observations = "hello it is me",
                OperatingHours = 5,
                DiscardReason = "Broken"
            });
            modelBuilder.Entity<CoverPages>().HasData(new CoverPages
            {
                CoverPagesID = 2,
                UserID = 2,
                CoverPageStatusID = 1,
                CoverPageTypeID = 2,
                TCVTNumber = 234,
                InspectionDate = new DateTime(2020, 2, 15),
                Executor = "dsjbvjkdb",
                Specialist = "ouirehjbgf",
                CrainSetup = "zsngfye",
                ExecutionTowerHookHeight = 657,
                BoomType = "hfdsf",
                TelescopicBoomParts = 7,
                ConstructionBoomMeters = 7,
                JibBoomMeters = 7,
                FlyJibParts = 6,
                BoomLength = 7,
                Topable = 1,
                Trolley = 1,
                AdjustableBoom = 1,
                StampsType = 2,
                Shortcomings = 0,
                SignOutBefore = new DateTime(2021, 3, 3),
                Elucidation = "hre78v",
                WorkInstruction = "dskghkgf",
                CableSupplier = "Hello world",
                Observations = "hello it is not me",
                OperatingHours = 6,
                DiscardReason = "Broken"
            });

            // LiftingTests table
            modelBuilder.Entity<LiftingTests>().HasData(new LiftingTests
            {
                LiftingTestsID = 1,
                CoverPagesID = 1,
                UserID = 2,
                DateDrawn = new DateTime(2021, 2, 15),
                MainBoomLength = 6,
                MechSectionBoomLength = 6,
                AuxiliaryBoomLength = 5,
                JibBoomLength = 4,
                HoistingCablePartsAmount = 3,
                SwingAngle = 3,
                OwnMassBallast = 44,
                PermissibleOperatingLoad = 34,
                LbmInEffect = 4,
                TestLoad = 44,
                Agreed = 1
            });

            // CableChecklists table
            modelBuilder.Entity<CableChecklists>().HasData(new CableChecklists
            {
                CableChecklistsID = 1,
                CoverPagesID = 2,
                UserID = 2,
                CableDamage_6D = 3,
                CableDamage_30D = 3,
                OutsideCableDamage = 44,
                Rust = 54,
                ReducedCableDiameter = 34,
                MeasuringPoints = 8475,
                TotalDamage = 45,
                DamageRustType = 435
            });
        }
    }
}