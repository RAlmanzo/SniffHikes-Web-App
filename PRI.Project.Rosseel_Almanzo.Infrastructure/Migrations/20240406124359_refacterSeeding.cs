using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Migrations
{
    public partial class refacterSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5821));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5823));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5825));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5827));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5831));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5833));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5816));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 6, 14, 43, 58, 716, DateTimeKind.Local).AddTicks(5877));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6039));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6040));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6047));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6028));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6079));

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "EventId", "File", "RouteId" },
                values: new object[,]
                {
                    { 1, 1, null, null },
                    { 2, 1, null, null },
                    { 4, null, null, null },
                    { 5, null, null, null },
                    { 11, null, null, null },
                    { 13, 2, null, null },
                    { 15, 1, null, null },
                    { 18, null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 5, 2, 37, 4, 760, DateTimeKind.Local).AddTicks(6061));
        }
    }
}
