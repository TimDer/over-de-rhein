﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using overDeRhein.Data;

namespace overDeRhein.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("overDeRhein.Data.Models.CableChecklists", b =>
                {
                    b.Property<int>("CableChecklistsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CableDamage_30D")
                        .HasColumnType("int");

                    b.Property<int>("CableDamage_6D")
                        .HasColumnType("int");

                    b.Property<int?>("CoverPagesID")
                        .HasColumnType("int");

                    b.Property<int>("DamageRustType")
                        .HasColumnType("int");

                    b.Property<int>("MeasuringPoints")
                        .HasColumnType("int");

                    b.Property<int>("OutsideCableDamage")
                        .HasColumnType("int");

                    b.Property<int>("ReducedCableDiameter")
                        .HasColumnType("int");

                    b.Property<int>("Rust")
                        .HasColumnType("int");

                    b.Property<int>("TotalDamage")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("UsersUserID")
                        .HasColumnType("int");

                    b.HasKey("CableChecklistsID");

                    b.HasIndex("CoverPagesID")
                        .IsUnique()
                        .HasFilter("[CoverPagesID] IS NOT NULL");

                    b.HasIndex("UsersUserID");

                    b.ToTable("CableChecklists");

                    b.HasData(
                        new
                        {
                            CableChecklistsID = 1,
                            CableDamage_30D = 3,
                            CableDamage_6D = 3,
                            CoverPagesID = 2,
                            DamageRustType = 435,
                            MeasuringPoints = 8475,
                            OutsideCableDamage = 44,
                            ReducedCableDiameter = 34,
                            Rust = 54,
                            TotalDamage = 45,
                            UserID = 2
                        });
                });

            modelBuilder.Entity("overDeRhein.Data.Models.CoverPageStatus", b =>
                {
                    b.Property<int>("CoverPageStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CoverPageStatusID");

                    b.ToTable("CoverPageStatus");

                    b.HasData(
                        new
                        {
                            CoverPageStatusID = 1,
                            StatusType = "Open"
                        },
                        new
                        {
                            CoverPageStatusID = 2,
                            StatusType = "Gesloten"
                        });
                });

            modelBuilder.Entity("overDeRhein.Data.Models.CoverPageType", b =>
                {
                    b.Property<int>("CoverPageTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CoverPageTypeID");

                    b.ToTable("CoverPageType");

                    b.HasData(
                        new
                        {
                            CoverPageTypeID = 1,
                            Type = "Hijs-testen"
                        },
                        new
                        {
                            CoverPageTypeID = 2,
                            Type = "Kabel-check-lijst"
                        });
                });

            modelBuilder.Entity("overDeRhein.Data.Models.CoverPages", b =>
                {
                    b.Property<int>("CoverPagesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("AdjustableBoom")
                        .HasColumnType("tinyint");

                    b.Property<double>("BoomLength")
                        .HasColumnType("float");

                    b.Property<string>("BoomType")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("CableSupplier")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double>("ConstructionBoomMeters")
                        .HasColumnType("float");

                    b.Property<int>("CoverPageStatusID")
                        .HasColumnType("int");

                    b.Property<int>("CoverPageTypeID")
                        .HasColumnType("int");

                    b.Property<string>("CrainSetup")
                        .HasMaxLength(52)
                        .HasColumnType("nvarchar(52)");

                    b.Property<string>("DiscardReason")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Elucidation")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("ExecutionTowerHookHeight")
                        .HasColumnType("int");

                    b.Property<string>("Executor")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FlyJibParts")
                        .HasColumnType("int");

                    b.Property<DateTime>("InspectionDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("JibBoomMeters")
                        .HasColumnType("float");

                    b.Property<string>("Observations")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("OperatingHours")
                        .HasColumnType("int");

                    b.Property<byte>("Shortcomings")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("SignOutBefore")
                        .HasColumnType("datetime2");

                    b.Property<string>("Specialist")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StampsType")
                        .HasColumnType("int");

                    b.Property<int>("TCVTNumber")
                        .HasColumnType("int");

                    b.Property<double>("TelescopicBoomParts")
                        .HasColumnType("float");

                    b.Property<byte>("Topable")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Trolley")
                        .HasColumnType("tinyint");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("WorkInstruction")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("CoverPagesID");

                    b.HasIndex("CoverPageStatusID");

                    b.HasIndex("CoverPageTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("CoverPages");

                    b.HasData(
                        new
                        {
                            CoverPagesID = 1,
                            AdjustableBoom = (byte)1,
                            BoomLength = 6.0,
                            BoomType = "hfdsf",
                            CableSupplier = "Hello world",
                            ConstructionBoomMeters = 6.0,
                            CoverPageStatusID = 1,
                            CoverPageTypeID = 1,
                            CrainSetup = "owreuityert",
                            DiscardReason = "Broken",
                            Elucidation = "hjg",
                            ExecutionTowerHookHeight = 4378,
                            Executor = "ksgfskdajf",
                            FlyJibParts = 5,
                            InspectionDate = new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JibBoomMeters = 6.0,
                            Observations = "hello it is me",
                            OperatingHours = 5,
                            Shortcomings = (byte)0,
                            SignOutBefore = new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Specialist = "dkshjfgfh",
                            StampsType = 1,
                            TCVTNumber = 234,
                            TelescopicBoomParts = 6.0,
                            Topable = (byte)1,
                            Trolley = (byte)1,
                            UserID = 2,
                            WorkInstruction = "dskgf"
                        },
                        new
                        {
                            CoverPagesID = 2,
                            AdjustableBoom = (byte)1,
                            BoomLength = 7.0,
                            BoomType = "hfdsf",
                            CableSupplier = "Hello world",
                            ConstructionBoomMeters = 7.0,
                            CoverPageStatusID = 1,
                            CoverPageTypeID = 2,
                            CrainSetup = "zsngfye",
                            DiscardReason = "Broken",
                            Elucidation = "hre78v",
                            ExecutionTowerHookHeight = 657,
                            Executor = "dsjbvjkdb",
                            FlyJibParts = 6,
                            InspectionDate = new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JibBoomMeters = 7.0,
                            Observations = "hello it is not me",
                            OperatingHours = 6,
                            Shortcomings = (byte)0,
                            SignOutBefore = new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Specialist = "ouirehjbgf",
                            StampsType = 2,
                            TCVTNumber = 234,
                            TelescopicBoomParts = 7.0,
                            Topable = (byte)1,
                            Trolley = (byte)1,
                            UserID = 2,
                            WorkInstruction = "dskghkgf"
                        });
                });

            modelBuilder.Entity("overDeRhein.Data.Models.LiftingTests", b =>
                {
                    b.Property<int>("LiftingTestsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Agreed")
                        .HasColumnType("tinyint");

                    b.Property<double>("AuxiliaryBoomLength")
                        .HasColumnType("float");

                    b.Property<int?>("CoverPagesID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDrawn")
                        .HasColumnType("datetime2");

                    b.Property<int>("HoistingCablePartsAmount")
                        .HasColumnType("int");

                    b.Property<int>("JibBoomLength")
                        .HasColumnType("int");

                    b.Property<double>("LbmInEffect")
                        .HasColumnType("float");

                    b.Property<int>("MainBoomLength")
                        .HasColumnType("int");

                    b.Property<int>("MechSectionBoomLength")
                        .HasColumnType("int");

                    b.Property<int>("OwnMassBallast")
                        .HasColumnType("int");

                    b.Property<double>("PermissibleOperatingLoad")
                        .HasColumnType("float");

                    b.Property<int>("SwingAngle")
                        .HasColumnType("int");

                    b.Property<double>("TestLoad")
                        .HasColumnType("float");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("UsersUserID")
                        .HasColumnType("int");

                    b.HasKey("LiftingTestsID");

                    b.HasIndex("CoverPagesID")
                        .IsUnique()
                        .HasFilter("[CoverPagesID] IS NOT NULL");

                    b.HasIndex("UsersUserID");

                    b.ToTable("LiftingTests");

                    b.HasData(
                        new
                        {
                            LiftingTestsID = 1,
                            Agreed = (byte)1,
                            AuxiliaryBoomLength = 5.0,
                            CoverPagesID = 1,
                            DateDrawn = new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HoistingCablePartsAmount = 3,
                            JibBoomLength = 4,
                            LbmInEffect = 4.0,
                            MainBoomLength = 6,
                            MechSectionBoomLength = 6,
                            OwnMassBallast = 44,
                            PermissibleOperatingLoad = 34.0,
                            SwingAngle = 3,
                            TestLoad = 44.0,
                            UserID = 2
                        });
                });

            modelBuilder.Entity("overDeRhein.Data.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Role")
                        .HasColumnType("tinyint");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserTypeID");

                    b.ToTable("UserType");

                    b.HasData(
                        new
                        {
                            UserTypeID = 1,
                            Role = (byte)0,
                            Type = "Directie"
                        },
                        new
                        {
                            UserTypeID = 2,
                            Role = (byte)0,
                            Type = "Veiligheid en milieu"
                        },
                        new
                        {
                            UserTypeID = 3,
                            Role = (byte)0,
                            Type = "Materieel"
                        },
                        new
                        {
                            UserTypeID = 4,
                            Role = (byte)0,
                            Type = "Projectbureau"
                        },
                        new
                        {
                            UserTypeID = 5,
                            Role = (byte)1,
                            Type = "admin"
                        });
                });

            modelBuilder.Entity("overDeRhein.Data.Models.Users", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("UserName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("UserTypeID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("UserTypeID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Password = "c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec",
                            UserName = "admin",
                            UserTypeID = 5
                        },
                        new
                        {
                            UserID = 2,
                            Password = "c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec",
                            UserName = "user",
                            UserTypeID = 1
                        });
                });

            modelBuilder.Entity("overDeRhein.Data.Models.CableChecklists", b =>
                {
                    b.HasOne("overDeRhein.Data.Models.CoverPages", "CoverPage")
                        .WithOne("CableChecklists")
                        .HasForeignKey("overDeRhein.Data.Models.CableChecklists", "CoverPagesID");

                    b.HasOne("overDeRhein.Data.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersUserID");

                    b.Navigation("CoverPage");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("overDeRhein.Data.Models.CoverPages", b =>
                {
                    b.HasOne("overDeRhein.Data.Models.CoverPageStatus", "CoverPageStatus")
                        .WithMany("CoverPages")
                        .HasForeignKey("CoverPageStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("overDeRhein.Data.Models.CoverPageType", "CoverPageType")
                        .WithMany("CoverPages")
                        .HasForeignKey("CoverPageTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("overDeRhein.Data.Models.Users", "User")
                        .WithMany("CoverPages")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoverPageStatus");

                    b.Navigation("CoverPageType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("overDeRhein.Data.Models.LiftingTests", b =>
                {
                    b.HasOne("overDeRhein.Data.Models.CoverPages", "CoverPage")
                        .WithOne("LiftingTests")
                        .HasForeignKey("overDeRhein.Data.Models.LiftingTests", "CoverPagesID");

                    b.HasOne("overDeRhein.Data.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersUserID");

                    b.Navigation("CoverPage");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("overDeRhein.Data.Models.Users", b =>
                {
                    b.HasOne("overDeRhein.Data.Models.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeID");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("overDeRhein.Data.Models.CoverPageStatus", b =>
                {
                    b.Navigation("CoverPages");
                });

            modelBuilder.Entity("overDeRhein.Data.Models.CoverPageType", b =>
                {
                    b.Navigation("CoverPages");
                });

            modelBuilder.Entity("overDeRhein.Data.Models.CoverPages", b =>
                {
                    b.Navigation("CableChecklists");

                    b.Navigation("LiftingTests");
                });

            modelBuilder.Entity("overDeRhein.Data.Models.UserType", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("overDeRhein.Data.Models.Users", b =>
                {
                    b.Navigation("CoverPages");
                });
#pragma warning restore 612, 618
        }
    }
}
