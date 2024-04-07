using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Migrations
{
    public partial class seedData : Migration
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
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
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    OrganizerId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Events_Users_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Users",
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
                    UserId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Routes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventsUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsUser", x => new { x.UserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventsUser_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventsUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                table: "Users",
                columns: new[] { "Id", "AddressId", "DateOfBirth", "Email", "FirstName", "Gender", "Image", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1980, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "John", "male", null, "DeWachter", "" },
                    { 2, 2, new DateTime(1985, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Jane", "female", null, "DeWachter", "" },
                    { 3, 3, new DateTime(1990, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Jack", "male", null, "DeVos", "" },
                    { 4, 10, new DateTime(1995, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Jill", "female", null, "Vogels", "" },
                    { 5, 11, new DateTime(2000, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Jim", "male", null, "Schoonaert", "" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "DateOfBirth", "Gender", "Image", "Name", "Race", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(1916), "Male", null, "Inca", "Husky", 1 },
                    { 2, new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(1963), "Female", null, "Zara", "Border-collie", 1 },
                    { 3, new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(1966), "Male", null, "Sleepy", "Duitse-herder", 2 },
                    { 4, new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(1969), "Male", null, "Sleepy", "Duitse-herder", 3 },
                    { 5, new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(1971), "Female", null, "Tunder", "Dog", 1 },
                    { 6, new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(1974), "Male", null, "Zira", "Husky", 2 },
                    { 7, new DateTime(2019, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", null, "Bella", "Labrador Retriever", 4 },
                    { 8, new DateTime(2018, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", null, "Rocky", "German Shepherd", 4 },
                    { 9, new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", null, "Luna", "Golden Retriever", 5 },
                    { 10, new DateTime(2017, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", null, "Max", "Poodle", 5 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AddressId", "Date", "DateCreated", "Description", "OrganizerId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2024, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2060), "Geniet van een ontspannen wandeling met je hond in het prachtige bosgebied. Neem je viervoeter mee voor een leuke tijd in de natuur.", 1, 0m, "Hondenwandeling in het bos" },
                    { 2, 5, new DateTime(2024, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2066), "Kom en bewonder verschillende hondenrassen tijdens de hondenshow in Brussel. Er zijn prijzen te winnen en veel plezier te beleven!", 2, 10.50m, "Hondenshow Brussel" },
                    { 3, 6, new DateTime(2024, 4, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2068), "Geniet van een ontspannen wandeling met je hond in het prachtige bosgebied. Neem je viervoeter mee voor een leuke tijd in de natuur.", 3, 0m, "Hondenwandeling aan zee" },
                    { 4, 12, new DateTime(2024, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2071), "Kom en bewonder verschillende hondenrassen tijdens de hondenshow in Brussel. Er zijn prijzen te winnen en veel plezier te beleven!", 4, 10.50m, "Hondenshow West-Vlaanderen" },
                    { 5, 13, new DateTime(2024, 4, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2074), "Geniet van een ontspannen wandeling met je hond in het prachtige bosgebied. Neem je viervoeter mee voor een leuke tijd in de natuur.", 4, 0m, "Hondenwandeling Heuvelland" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "AddressId", "DateCreated", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 7, new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2030), "Een mooie wandeling door het bos met je hond. Geniet van de natuur en de frisse lucht.", "Boswandeling", 1 },
                    { 2, 8, new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2033), "Een ontspannen wandeling met je hond langs het strand. Laat je viervoeter lekker uitwaaien!", "Strandwandeling", 2 },
                    { 3, 9, new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2036), "Een leuke wandeling met je hond door het park. Laat je hond lekker rennen en spelen.", "Parkwandeling", 3 },
                    { 4, 14, new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2038), "Een ontspannen wandeling met je hond langs het strand. Laat je viervoeter lekker uitwaaien!", "Strandwandeling", 4 },
                    { 5, 15, new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2040), "Een leuke wandeling met je hond door het park. Laat je hond lekker rennen en spelen.", "Parkwandeling", 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DateCreated", "EventId", "RouteId", "UserId" },
                values: new object[,]
                {
                    { 1, "Gezellige avond!", new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(1992), 1, null, 1 },
                    { 2, "Leuke wandeling!", new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(1996), 2, null, 1 },
                    { 3, "Gezellige avond!", new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(1998), 2, null, 2 },
                    { 4, "Gezellige avond!", new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2001), 3, null, 3 },
                    { 5, "Mooie route!", new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2003), null, 1, 1 },
                    { 6, "Leuke wandeling!", new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2005), null, 2, 2 },
                    { 7, "Mooie route!", new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2008), null, 2, 2 },
                    { 8, "Mooie route!", new DateTime(2024, 4, 7, 21, 13, 38, 24, DateTimeKind.Local).AddTicks(2010), null, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "EventsUser",
                columns: new[] { "EventId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 4 },
                    { 5, 5 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "EventsUser");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
