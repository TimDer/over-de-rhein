using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace overDeRhein.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverPageStatus",
                columns: table => new
                {
                    CoverPageStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverPageStatus", x => x.CoverPageStatusID);
                });

            migrationBuilder.CreateTable(
                name: "CoverPageType",
                columns: table => new
                {
                    CoverPageTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverPageType", x => x.CoverPageTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    SignaturesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Signature = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.SignaturesID);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_UserType_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "UserType",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoverPages",
                columns: table => new
                {
                    CoverPagesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TCVTNumber = table.Column<int>(type: "int", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Executor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Specialist = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CrainSetup = table.Column<string>(type: "nvarchar(52)", maxLength: 52, nullable: true),
                    ExecutionTowerHookHeight = table.Column<int>(type: "int", nullable: false),
                    BoomType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    TelescopicBoomParts = table.Column<double>(type: "float", nullable: false),
                    ConstructionBoomMeters = table.Column<double>(type: "float", nullable: false),
                    JibBoomMeters = table.Column<double>(type: "float", nullable: false),
                    FlyJibParts = table.Column<int>(type: "int", nullable: false),
                    BoomLength = table.Column<double>(type: "float", nullable: false),
                    Topable = table.Column<byte>(type: "tinyint", nullable: false),
                    Trolley = table.Column<byte>(type: "tinyint", nullable: false),
                    AdjustableBoom = table.Column<byte>(type: "tinyint", nullable: false),
                    StampsType = table.Column<int>(type: "int", nullable: false),
                    Shortcomings = table.Column<byte>(type: "tinyint", nullable: false),
                    SignOutBefore = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Elucidation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WorkInstruction = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CableSupplier = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OperatingHours = table.Column<int>(type: "int", nullable: false),
                    DiscardReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CoverPageStatusID = table.Column<int>(type: "int", nullable: false),
                    SignatureID = table.Column<int>(type: "int", nullable: false),
                    SignaturesID = table.Column<int>(type: "int", nullable: true),
                    CoverPageTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverPages", x => x.CoverPagesID);
                    table.ForeignKey(
                        name: "FK_CoverPages_CoverPageStatus_CoverPageStatusID",
                        column: x => x.CoverPageStatusID,
                        principalTable: "CoverPageStatus",
                        principalColumn: "CoverPageStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoverPages_CoverPageType_CoverPageTypeID",
                        column: x => x.CoverPageTypeID,
                        principalTable: "CoverPageType",
                        principalColumn: "CoverPageTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoverPages_Signatures_SignaturesID",
                        column: x => x.SignaturesID,
                        principalTable: "Signatures",
                        principalColumn: "SignaturesID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoverPages_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CableChecklists",
                columns: table => new
                {
                    CableChecklistsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CableDamage_6D = table.Column<int>(type: "int", nullable: false),
                    CableDamage_30D = table.Column<int>(type: "int", nullable: false),
                    OutsideCableDamage = table.Column<int>(type: "int", nullable: false),
                    Rust = table.Column<int>(type: "int", nullable: false),
                    ReducedCableDiameter = table.Column<int>(type: "int", nullable: false),
                    MeasuringPoints = table.Column<int>(type: "int", nullable: false),
                    TotalDamage = table.Column<int>(type: "int", nullable: false),
                    DamageRustType = table.Column<int>(type: "int", nullable: false),
                    CoverPagesID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UsersUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CableChecklists", x => x.CableChecklistsID);
                    table.ForeignKey(
                        name: "FK_CableChecklists_CoverPages_CoverPagesID",
                        column: x => x.CoverPagesID,
                        principalTable: "CoverPages",
                        principalColumn: "CoverPagesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CableChecklists_Users_UsersUserID",
                        column: x => x.UsersUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LiftingTests",
                columns: table => new
                {
                    LiftingTestsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDrawn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MainBoomLength = table.Column<int>(type: "int", nullable: false),
                    MechSectionBoomLength = table.Column<int>(type: "int", nullable: false),
                    AuxiliaryBoomLength = table.Column<double>(type: "float", nullable: false),
                    JibBoomLength = table.Column<int>(type: "int", nullable: false),
                    HoistingCablePartsAmount = table.Column<int>(type: "int", nullable: false),
                    SwingAngle = table.Column<int>(type: "int", nullable: false),
                    OwnMassBallast = table.Column<int>(type: "int", nullable: false),
                    PermissibleOperatingLoad = table.Column<double>(type: "float", nullable: false),
                    LbmInEffect = table.Column<double>(type: "float", nullable: false),
                    TestLoad = table.Column<double>(type: "float", nullable: false),
                    Agreed = table.Column<byte>(type: "tinyint", nullable: false),
                    CoverPagesID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UsersUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftingTests", x => x.LiftingTestsID);
                    table.ForeignKey(
                        name: "FK_LiftingTests_CoverPages_CoverPagesID",
                        column: x => x.CoverPagesID,
                        principalTable: "CoverPages",
                        principalColumn: "CoverPagesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiftingTests_Users_UsersUserID",
                        column: x => x.UsersUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CoverPageStatus",
                columns: new[] { "CoverPageStatusID", "StatusType" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Gesloten" }
                });

            migrationBuilder.InsertData(
                table: "CoverPageType",
                columns: new[] { "CoverPageTypeID", "Type" },
                values: new object[,]
                {
                    { 1, "Hijs-testen" },
                    { 2, "Kabel-check-lijst" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "UserTypeID", "Type" },
                values: new object[,]
                {
                    { 1, "Directie" },
                    { 2, "Veiligheid en milieu" },
                    { 3, "Materieel" },
                    { 4, "Projectbureau" },
                    { 5, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Password", "UserName", "UserTypeID" },
                values: new object[] { 2, "c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec", "user", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Password", "UserName", "UserTypeID" },
                values: new object[] { 1, "c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec", "admin", 5 });

            migrationBuilder.InsertData(
                table: "CoverPages",
                columns: new[] { "CoverPagesID", "AdjustableBoom", "BoomLength", "BoomType", "CableSupplier", "ConstructionBoomMeters", "CoverPageStatusID", "CoverPageTypeID", "CrainSetup", "DiscardReason", "Elucidation", "ExecutionTowerHookHeight", "Executor", "FlyJibParts", "InspectionDate", "JibBoomMeters", "Observations", "OperatingHours", "Shortcomings", "SignOutBefore", "SignatureID", "SignaturesID", "Specialist", "StampsType", "TCVTNumber", "TelescopicBoomParts", "Topable", "Trolley", "UserID", "WorkInstruction" },
                values: new object[] { 1, (byte)1, 6.0, "hfdsf", "Hello world", 6.0, 1, 1, "owreuityert", "Broken", "hjg", 4378, "ksgfskdajf", 5, new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0, "hello it is me", 5, (byte)0, new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "dkshjfgfh", 5, 234, 6.0, (byte)1, (byte)1, 2, "dskgf" });

            migrationBuilder.InsertData(
                table: "CoverPages",
                columns: new[] { "CoverPagesID", "AdjustableBoom", "BoomLength", "BoomType", "CableSupplier", "ConstructionBoomMeters", "CoverPageStatusID", "CoverPageTypeID", "CrainSetup", "DiscardReason", "Elucidation", "ExecutionTowerHookHeight", "Executor", "FlyJibParts", "InspectionDate", "JibBoomMeters", "Observations", "OperatingHours", "Shortcomings", "SignOutBefore", "SignatureID", "SignaturesID", "Specialist", "StampsType", "TCVTNumber", "TelescopicBoomParts", "Topable", "Trolley", "UserID", "WorkInstruction" },
                values: new object[] { 2, (byte)1, 7.0, "hfdsf", "Hello world", 7.0, 1, 1, "zsngfye", "Broken", "hre78v", 657, "dsjbvjkdb", 6, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0, "hello it is not me", 6, (byte)0, new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "ouirehjbgf", 6, 234, 7.0, (byte)1, (byte)1, 2, "dskghkgf" });

            migrationBuilder.InsertData(
                table: "CableChecklists",
                columns: new[] { "CableChecklistsID", "CableDamage_30D", "CableDamage_6D", "CoverPagesID", "DamageRustType", "MeasuringPoints", "OutsideCableDamage", "ReducedCableDiameter", "Rust", "TotalDamage", "UserID", "UsersUserID" },
                values: new object[] { 1, 3, 3, 2, 435, 8475, 44, 34, 54, 45, 2, null });

            migrationBuilder.InsertData(
                table: "LiftingTests",
                columns: new[] { "LiftingTestsID", "Agreed", "AuxiliaryBoomLength", "CoverPagesID", "DateDrawn", "HoistingCablePartsAmount", "JibBoomLength", "LbmInEffect", "MainBoomLength", "MechSectionBoomLength", "OwnMassBallast", "PermissibleOperatingLoad", "SwingAngle", "TestLoad", "UserID", "UsersUserID" },
                values: new object[] { 1, (byte)1, 5.0, 1, new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 4.0, 6, 6, 44, 34.0, 3, 44.0, 2, null });

            migrationBuilder.CreateIndex(
                name: "IX_CableChecklists_CoverPagesID",
                table: "CableChecklists",
                column: "CoverPagesID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CableChecklists_UsersUserID",
                table: "CableChecklists",
                column: "UsersUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CoverPages_CoverPageStatusID",
                table: "CoverPages",
                column: "CoverPageStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_CoverPages_CoverPageTypeID",
                table: "CoverPages",
                column: "CoverPageTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CoverPages_SignaturesID",
                table: "CoverPages",
                column: "SignaturesID");

            migrationBuilder.CreateIndex(
                name: "IX_CoverPages_UserID",
                table: "CoverPages",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_LiftingTests_CoverPagesID",
                table: "LiftingTests",
                column: "CoverPagesID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LiftingTests_UsersUserID",
                table: "LiftingTests",
                column: "UsersUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeID",
                table: "Users",
                column: "UserTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CableChecklists");

            migrationBuilder.DropTable(
                name: "LiftingTests");

            migrationBuilder.DropTable(
                name: "CoverPages");

            migrationBuilder.DropTable(
                name: "CoverPageStatus");

            migrationBuilder.DropTable(
                name: "CoverPageType");

            migrationBuilder.DropTable(
                name: "Signatures");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}
