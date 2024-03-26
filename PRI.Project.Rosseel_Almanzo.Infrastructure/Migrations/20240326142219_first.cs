using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Migrations
{
    public partial class first : Migration
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
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    OrganizerId = table.Column<int>(type: "int", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                name: "EventUser",
                columns: table => new
                {
                    AttendingEventsId = table.Column<int>(type: "int", nullable: false),
                    AttendingUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => new { x.AttendingEventsId, x.AttendingUsersId });
                    table.ForeignKey(
                        name: "FK_EventUser_Events_AttendingEventsId",
                        column: x => x.AttendingEventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_Users_AttendingUsersId",
                        column: x => x.AttendingUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UserId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Images_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                    { 9, "Leuven", "België", "Vlaams-Brabant", "Grote Markt 1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "Password" },
                values: new object[] { 1, 1, new DateTime(1980, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "John", "male", "DeWachter", "" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "Password" },
                values: new object[] { 2, 2, new DateTime(1985, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Jane", "female", "DeWachter", "" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "Password" },
                values: new object[] { 3, 3, new DateTime(1990, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Jack", "male", "DeVos", "" });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "DateOfBirth", "Gender", "Image", "Name", "Race", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3319), "Male", null, "Inca", "Husky", 1 },
                    { 2, new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3359), "Female", null, "Zara", "Border-collie", 1 },
                    { 3, new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3362), "Male", null, "Sleepy", "Duitse-herder", 2 },
                    { 4, new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3364), "Male", null, "Sleepy", "Duitse-herder", 3 },
                    { 5, new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3365), "Female", null, "Tunder", "Dog", 1 },
                    { 6, new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3367), "Male", null, "Zira", "Husky", 2 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AddressId", "Date", "DateCreated", "Description", "OrganizerId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2024, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3410), "Geniet van een ontspannen wandeling met je hond in het prachtige bosgebied. Neem je viervoeter mee voor een leuke tijd in de natuur.", 1, 0m, "Hondenwandeling in het bos" },
                    { 2, 5, new DateTime(2024, 4, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3442), "Kom en bewonder verschillende hondenrassen tijdens de hondenshow in Brussel. Er zijn prijzen te winnen en veel plezier te beleven!", 2, 10.50m, "Hondenshow Brussel" },
                    { 3, 6, new DateTime(2024, 4, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3444), "Geniet van een ontspannen wandeling met je hond in het prachtige bosgebied. Neem je viervoeter mee voor een leuke tijd in de natuur.", 3, 0m, "Hondenwandeling aan zee" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "EventId", "File", "RouteId", "UserId" },
                values: new object[,]
                {
                    { 4, null, null, null, 1 },
                    { 5, null, null, null, 1 },
                    { 11, null, null, null, 3 },
                    { 18, null, null, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "AddressId", "DateCreated", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 7, new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3392), "Een mooie wandeling door het bos met je hond. Geniet van de natuur en de frisse lucht.", "Boswandeling", 1 },
                    { 2, 8, new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3395), "Een ontspannen wandeling met je hond langs het strand. Laat je viervoeter lekker uitwaaien!", "Strandwandeling", 2 },
                    { 3, 9, new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3396), "Een leuke wandeling met je hond door het park. Laat je hond lekker rennen en spelen.", "Parkwandeling", 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DateCreated", "EventId", "RouteId", "UserId" },
                values: new object[,]
                {
                    { 1, "Gezellige avond!", new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3369), 1, null, 1 },
                    { 2, "Leuke wandeling!", new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3371), 2, null, 1 },
                    { 3, "Gezellige avond!", new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3373), 2, null, 2 },
                    { 4, "Gezellige avond!", new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3375), 3, null, 3 },
                    { 5, "Mooie route!", new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3377), null, 1, 1 },
                    { 6, "Leuke wandeling!", new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3379), null, 2, 2 },
                    { 7, "Mooie route!", new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3380), null, 2, 2 },
                    { 8, "Mooie route!", new DateTime(2024, 3, 26, 15, 22, 19, 702, DateTimeKind.Local).AddTicks(3382), null, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "EventUser",
                columns: new[] { "AttendingEventsId", "AttendingUsersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "EventId", "File", "RouteId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, null, 1 },
                    { 2, 1, null, null, 1 },
                    { 3, null, null, 1, 1 },
                    { 6, 2, null, null, 2 },
                    { 7, null, null, 2, 2 },
                    { 8, null, null, 2, 2 },
                    { 9, 2, null, null, 3 },
                    { 10, null, null, 2, 3 },
                    { 12, 3, null, null, 1 },
                    { 13, 2, null, null, 1 },
                    { 14, null, null, 3, 2 },
                    { 15, 1, null, null, 2 },
                    { 16, null, null, 1, 2 },
                    { 17, null, null, 3, 3 }
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
                name: "IX_EventUser_AttendingUsersId",
                table: "EventUser",
                column: "AttendingUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_EventId",
                table: "Images",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_RouteId",
                table: "Images",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

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
                name: "EventUser");

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
