using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Migrations
{
    public partial class initIdentityRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventsUser",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsUser", x => new { x.UserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventsUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventsUser_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "State", "Street" },
                values: new object[,]
                {
                    { 1, "Anderlecht", "Belgie", "Brussel", "Rue Wayez 3" },
                    { 2, "Anderlecht", "Belgie", "Brussel", "Rue Wayez 3" },
                    { 3, "Gent", "Belgie", "Oost-Vlaanderen", "Veldstraat 15" },
                    { 4, "Brugge", "Belgie", "West-Vlaanderen", "Steenstraat 28" },
                    { 5, "Veurne", "Belgie", "West-Vlaanderen", "Ooststraat 10" },
                    { 6, "Gent", "België", "Oost-Vlaanderen", "Veldstraat 9" },
                    { 7, "Brugge", "België", "West-Vlaanderen", "Steenstraat 21" },
                    { 8, "Antwerpen", "België", "Antwerpen", "Meir 12" },
                    { 9, "Leuven", "België", "Vlaams-Brabant", "Grote Markt 1" },
                    { 10, "Mechelen", "België", "Antwerpen", "Groenplaats 21" },
                    { 11, "Brugge", "België", "West-Vlaanderen", "Oude Burg 12" },
                    { 12, "Gent", "België", "Oost-Vlaanderen", "Veldstraat 9" },
                    { 13, "Brugge", "België", "West-Vlaanderen", "Steenstraat 21" },
                    { 14, "Anderlecht", "Belgie", "Brussel", "Rue Wayez 3" },
                    { 15, "Anderlecht", "Belgie", "Brussel", "Rue Wayez 3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, 1, "6b132718-9123-44a4-a335-619eae4fbebc", new DateTime(1980, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@testing.com", true, "John", "male", null, "DeWachter", false, null, "ADMIN@TESTING.COM", "ADMIN@TESTING.COM", null, "AQAAAAEAACcQAAAAEDgVxSTuaPtHpAC/6EPdDbLNOsxazted+aet90CHTgls60eB0SCdSwc/L3MHH6FDgg==", null, false, "d241b16f-18cc-4216-a413-b69724007536", false, "admin@testing.com" },
                    { "2", 0, 2, "fe5f8cb7-b2a6-4003-8fd3-1e07e46c45f7", new DateTime(1985, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@testing.com", true, "Jane", "female", null, "DeWachter", false, null, "USER@TESTING.COM", "USER@TESTING.COM", null, "AQAAAAEAACcQAAAAEO1X2mgFqHdvJqB288hgmqpyWPNIk+3l8vwlKlwrPUI5a/OfkVXQWabXirpqzjv3og==", null, false, "61f98943-3901-4412-895f-6978972f9554", false, "user@testing.com" },
                    { "3", 0, 3, "ce8cff66-3706-47b2-b118-d705e73ba934", new DateTime(1990, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, "Jack", "male", null, "DeVos", false, null, null, null, "", null, null, false, "2c8eaff7-4352-4a20-9007-bbf0b5b268a6", false, null },
                    { "4", 0, 10, "819c4ed9-aaff-4158-8be5-2eeff3ba263d", new DateTime(1995, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, "Jill", "female", null, "Vogels", false, null, null, null, "", null, null, false, "606cfe7b-588a-46ac-a17c-ab8a477feba0", false, null },
                    { "5", 0, 11, "41400c1e-54a0-41e3-8ff3-167c23cedc13", new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, "Jim", "male", null, "Schoonaert", false, null, null, null, "", null, null, false, "f5db548a-9952-4471-a26f-d1980e098d8a", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", "1" },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", "2" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "DateOfBirth", "Gender", "Image", "Name", "Race", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6356), "Male", null, "Inca", "Husky", "1" },
                    { 2, new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6394), "Female", null, "Zara", "Border-collie", "1" },
                    { 3, new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6397), "Male", null, "Sleepy", "Duitse-herder", "2" },
                    { 4, new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6399), "Male", null, "Sleepy", "Duitse-herder", "3" },
                    { 5, new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6401), "Female", null, "Tunder", "Dog", "1" },
                    { 6, new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6403), "Male", null, "Zira", "Husky", "2" },
                    { 7, new DateTime(2019, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", null, "Bella", "Labrador Retriever", "4" },
                    { 8, new DateTime(2018, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", null, "Rocky", "German Shepherd", "4" },
                    { 9, new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", null, "Luna", "Golden Retriever", "5" },
                    { 10, new DateTime(2017, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", null, "Max", "Poodle", "5" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AddressId", "Date", "DateCreated", "Description", "OrganizerId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2024, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 14, 2, 54, 827, DateTimeKind.Local).AddTicks(5591), "Geniet van een ontspannen wandeling met je hond in het prachtige bosgebied. Neem je viervoeter mee voor een leuke tijd in de natuur.", "1", 0m, "Hondenwandeling in het bos" },
                    { 2, 5, new DateTime(2024, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 14, 2, 54, 827, DateTimeKind.Local).AddTicks(5596), "Kom en bewonder verschillende hondenrassen tijdens de hondenshow in Brussel. Er zijn prijzen te winnen en veel plezier te beleven!", "2", 10.50m, "Hondenshow Brussel" },
                    { 3, 6, new DateTime(2024, 4, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 14, 2, 54, 827, DateTimeKind.Local).AddTicks(5598), "Geniet van een ontspannen wandeling met je hond in het prachtige bosgebied. Neem je viervoeter mee voor een leuke tijd in de natuur.", "3", 0m, "Hondenwandeling aan zee" },
                    { 4, 12, new DateTime(2024, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 14, 2, 54, 827, DateTimeKind.Local).AddTicks(5600), "Kom en bewonder verschillende hondenrassen tijdens de hondenshow in Brussel. Er zijn prijzen te winnen en veel plezier te beleven!", "4", 10.50m, "Hondenshow West-Vlaanderen" },
                    { 5, 13, new DateTime(2024, 4, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 14, 2, 54, 827, DateTimeKind.Local).AddTicks(5602), "Geniet van een ontspannen wandeling met je hond in het prachtige bosgebied. Neem je viervoeter mee voor een leuke tijd in de natuur.", "5", 0m, "Hondenwandeling Heuvelland" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "AddressId", "DateCreated", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 7, new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6440), "Een mooie wandeling door het bos met je hond. Geniet van de natuur en de frisse lucht.", "Boswandeling", "1" },
                    { 2, 8, new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6442), "Een ontspannen wandeling met je hond langs het strand. Laat je viervoeter lekker uitwaaien!", "Strandwandeling", "2" },
                    { 3, 9, new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6444), "Een leuke wandeling met je hond door het park. Laat je hond lekker rennen en spelen.", "Parkwandeling", "3" },
                    { 4, 14, new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6446), "Een ontspannen wandeling met je hond langs het strand. Laat je viervoeter lekker uitwaaien!", "Strandwandeling", "4" },
                    { 5, 15, new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6447), "Een leuke wandeling met je hond door het park. Laat je hond lekker rennen en spelen.", "Parkwandeling", "5" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DateCreated", "EventId", "RouteId", "UserId" },
                values: new object[,]
                {
                    { 1, "Gezellige avond!", new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6411), 1, null, "1" },
                    { 2, "Leuke wandeling!", new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6414), 2, null, "1" },
                    { 3, "Gezellige avond!", new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6416), 2, null, "2" },
                    { 4, "Gezellige avond!", new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6418), 3, null, "3" },
                    { 5, "Mooie route!", new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6420), null, 1, "1" },
                    { 6, "Leuke wandeling!", new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6421), null, 2, "2" },
                    { 7, "Mooie route!", new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6423), null, 2, "2" },
                    { 8, "Mooie route!", new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6424), null, 3, "4" }
                });

            migrationBuilder.InsertData(
                table: "EventsUser",
                columns: new[] { "EventId", "UserId" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 3, "1" },
                    { 1, "2" },
                    { 2, "2" },
                    { 2, "3" },
                    { 3, "3" },
                    { 4, "4" },
                    { 5, "4" },
                    { 5, "5" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "EventId", "File", "RouteId" },
                values: new object[,]
                {
                    { 1, 1, null, null },
                    { 2, 1, null, null },
                    { 3, null, null, 1 },
                    { 6, 2, null, null },
                    { 7, null, null, 2 },
                    { 8, null, null, 2 },
                    { 9, 2, null, null },
                    { 10, null, null, 2 },
                    { 12, 3, null, null },
                    { 13, 2, null, null },
                    { 14, null, null, 3 },
                    { 15, 1, null, null },
                    { 16, null, null, 1 },
                    { 17, null, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EventId",
                table: "Comments",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RouteId",
                table: "Comments",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_UserId",
                table: "Dogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_AddressId",
                table: "Events",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerId",
                table: "Events",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsUser_EventId",
                table: "EventsUser",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_EventId",
                table: "Images",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_RouteId",
                table: "Images",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_AddressId",
                table: "Routes",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_UserId",
                table: "Routes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "EventsUser");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
