using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Migrations
{
    public partial class updateOrginazerClaims2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "289e9cce-fd43-45a3-9d30-9f337f08369b", "AQAAAAEAACcQAAAAEEgPOjbdeyJB3I9FfjUoMfYXE4BdieV6rrIim/k7fhoKm+z6w1i+1gixThg/h8Jyvw==", "7a2a1bbf-10ec-4328-a026-2f3a0f04d22b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c2659b8-e0cd-48c6-b71d-d091f88729a8", "AQAAAAEAACcQAAAAEHvQOP3xTyRV5z2hn0Mz+Jo/K/bHlhDTD8eot6Q2Fuo3G6Bd5iuQdxpvnC3whzSyUA==", "ca69420b-a94e-4350-b431-435be918bb13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1c636ef-b41d-46be-ab9d-a45d7bc84329", "AQAAAAEAACcQAAAAEDQDvvYNVQqvZRYAONoKOxtAhqi+SQG6oSEJScll1q2cByDnmDK97ZB8yfvPLHk4+A==", "7328b4ec-5a72-4484-8497-8f5f9da10452" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dff869e8-29c8-4b81-9cd0-23030475f169", "AQAAAAEAACcQAAAAEKoKlrtISl7GnCq7lpKfgC2B9mre8yYEwlQE78yk4OSc4EnYaL2A1bDGwWmA3FIvXg==", "b5758003-fd23-4465-9cd9-526f5dbc5c7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cea41d55-b817-4a41-b709-c1eda938d4b0", "AQAAAAEAACcQAAAAEL3j+UopyTGwn4T+cqHey7nzq8QkoeLW/u6w74B+XTvvTUylEXB36Y9fmSF4kAzS4w==", "219bdab9-abcc-41b3-ab0c-85047d6dda57" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5954));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5956));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5925));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5927));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 762, DateTimeKind.Local).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 762, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 762, DateTimeKind.Local).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 762, DateTimeKind.Local).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 762, DateTimeKind.Local).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5974));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5976));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 16, 59, 31, 757, DateTimeKind.Local).AddTicks(5977));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
