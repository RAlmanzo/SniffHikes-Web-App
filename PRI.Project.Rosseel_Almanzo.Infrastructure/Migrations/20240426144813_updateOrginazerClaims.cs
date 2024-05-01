using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Migrations
{
    public partial class updateOrginazerClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 21,
                column: "ClaimValue",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa4a6a7d-4617-4270-a80b-cd07435b6068", "AQAAAAEAACcQAAAAEIB3nPxCuAkN9J4GxAZb6t4elu0CxwdwapzfjJ1IxKpDz+MDsY8eDxan75Qn8XqNUg==", "37f480c4-15d0-4ba0-a330-e6ccef85c89a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06971617-5465-44d3-8190-703db7c6fd64", "AQAAAAEAACcQAAAAEKCj8k3ZUxC/2tLDyGnTdnvtig4f2ZZXgrsi7uzZ8PnkwH17r4F2d3yNw9mYTdnjaw==", "c7a66e5d-d7ed-4479-bec5-a69742a0c8bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1c0b6b3-09d0-427b-be26-241e353b2f69", "AQAAAAEAACcQAAAAEEV0DTwuguPhClZCeXdfaxwBznxBt66AiXaLTItdfvtyPBCSfyd7s4NO9GE5x56KjQ==", "6c88f096-2115-4f2c-b65c-1e40e531e597" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4449988-25a1-4cc6-93ed-fce85c3711c5", "AQAAAAEAACcQAAAAENW2H6JbCBxyOijAIMa7bj4M8cqyhnrUipgU4FcclI4p0qR14UFviV0cuZIlxVybMg==", "c7bf3284-0926-493f-b58c-1238e1245f26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3665aa3-31c3-4f09-ad10-c52ad480c7dd", "AQAAAAEAACcQAAAAELPlvwKgjF8+HtObFUdZmTojRprwtHfXwUGenZlLWbkHcZAlZ7mrp22k4gA+5+uACA==", "b505909b-a1b8-4d61-a4ff-f99d818175a9" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8078));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 489, DateTimeKind.Local).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 489, DateTimeKind.Local).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 489, DateTimeKind.Local).AddTicks(6569));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 489, DateTimeKind.Local).AddTicks(6571));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 489, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 48, 12, 484, DateTimeKind.Local).AddTicks(8151));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 21,
                column: "ClaimValue",
                value: "Orginazer");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0e036ae-bd42-433e-87fb-0365acf33774", "AQAAAAEAACcQAAAAEBitPIJmoj4rEOFtfbk7diKsukTj4NmT4TDSUD/sjm7Z7CunqOIpPU048z5lqwpMsw==", "469be5bb-a8c8-4b37-b5d0-3fc70b762396" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aacc90fe-f1d5-4a71-8030-b4506372af92", "AQAAAAEAACcQAAAAEKGYBL9LTCmSjFEtqKqZNpFDD9FxMIyS9PnwzyhrFqa82o2kQPSrjuKUp0WkbFBrAg==", "f4ac7123-a46d-4b30-a7b0-cae575979cfb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e409fbcb-7294-42a5-be70-1e542376af5d", "AQAAAAEAACcQAAAAEKGIr22MsCXjABcKV4jqSsj2bnKspTa2GbvErrQ0G56zq5LqsciH2cOE9kx5fpWBVg==", "fbd70e0e-04d6-4a48-8f42-6079b65686fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b857c50-e1a6-4c10-a56b-42d9fe49d500", "AQAAAAEAACcQAAAAEO5StNrTpcGzSmCo4sAPNVBrs1Q81pzye05IN3HD+oaqMELOyuufpJqD2eVXcOAvEw==", "016036e8-9533-459b-a43b-0d47c72c114f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "507f80ba-8906-4504-a7df-125d725b2ab3", "AQAAAAEAACcQAAAAELr4Rir+ZfCTmwwjcmtpRC0nhef+EoABKhjFySZ5U/EN2V/kytWEFzYOV47SPNeMSg==", "17d797ff-1089-40f2-8c2f-927997452763" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(49));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(54));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(56));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(57));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(59));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(61));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 177, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(10));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(14));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 182, DateTimeKind.Local).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 182, DateTimeKind.Local).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 182, DateTimeKind.Local).AddTicks(8424));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 182, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 182, DateTimeKind.Local).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 35, 42, 178, DateTimeKind.Local).AddTicks(83));
        }
    }
}
