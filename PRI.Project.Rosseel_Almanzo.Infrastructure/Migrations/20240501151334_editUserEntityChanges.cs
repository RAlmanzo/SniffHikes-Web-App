using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Migrations
{
    public partial class editUserEntityChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c20800f-d254-4c31-a98d-d016ebca9273", "AQAAAAEAACcQAAAAEJnPdA0rOqFQRMSCSWpUKjd3at54Ie3enY+/Ly5jiiOowQItmZpOnGqtJCBQThvSLQ==", "0f884dca-de03-40e0-83e4-044081fddf82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dffb7822-315a-4d92-a12f-b8c1b84158db", "AQAAAAEAACcQAAAAEM44OyEGoEbSSIE4A8NqIdGH+5SWsXiUvFzTvCImPGpGrGYAxg+NQGahzfqwZgh19Q==", "4cd706f2-6396-4037-8a38-7dc96a6652a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68158105-3057-415c-87e8-926e7a47bd2a", "AQAAAAEAACcQAAAAEELY3KY/8s1tGPwVA1QPLb84PsYtMamvbjvrTDoO10w3rfLj/Q0NqkrnhkNq/0fv4A==", "37c057f8-927e-49e3-ac90-8ae0e57d60ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5dfc5533-263a-4e45-a134-5c40cb2a921f", "AQAAAAEAACcQAAAAEHOkGPNxqRp13cPSKuiJR59gBbStB9B1Crj12vR0Dy635DAZxSr87u7CwfxWDlBwqg==", "f797d54f-54b2-49f4-a144-7db588e4c3c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8735b09a-998a-4806-ad1b-916542fc8fb4", "AQAAAAEAACcQAAAAEHfMfOIn4adJlsYhpgLzIiydidKImB7DDD7ZptGnKFU/nmXgG8/fVz5/1sIwgbXcRw==", "97155df2-a1f1-440f-b2dd-b5ffd8299e8b" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(606));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(607));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(611));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(612));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(614));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(616));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(501));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 474, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 474, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 474, DateTimeKind.Local).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 474, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 474, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(631));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(633));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 17, 13, 33, 470, DateTimeKind.Local).AddTicks(638));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3713c6fb-114b-45d9-bfcf-3596375d4dcf", "AQAAAAEAACcQAAAAEEoigyC1W8V0sJjRInPh44IvdEn5CXoSoqC1+mgODgLYT9nezxjsPYkXKFQuvYWiQA==", "2535c2b1-642a-4090-8816-39dae3d2dc74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "048ab424-1de1-4538-903a-5b461f4f6a01", "AQAAAAEAACcQAAAAEKxhAadvOLVTb4107F2ThbYa/QeCsIDDbfHfTnRVmwDeaL1u0d4To4wLbBgFs8fF/A==", "a8d456ec-6717-455d-b7e2-cb56f3917756" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3d257ae-753e-4e21-9474-b706c7809d59", "AQAAAAEAACcQAAAAEG/mHmWXW+9f2EQBzdNOIek/ZzWdP2FzOhDa4tLAieHFyUez7SwUG698jqzi8UA/mA==", "163fdbcf-4117-409d-9413-d1069112e935" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efaa2575-7fff-423c-b3e3-786eca9d85fa", "AQAAAAEAACcQAAAAEFQ8HP+fPWXG8e1VjQGeecH8hEsTen26itWZwDWNedibN7LqlonLim6ihwph0eMzUw==", "737aab3a-1e61-4301-91d3-919635d0cf3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e5ade05-4d50-4574-98a8-b7273e40eac8", "AQAAAAEAACcQAAAAENAshGyLpA+BxDx9BZc6H8TG/lc66FMhRH8/o5CfA7KfpFHR0aqk6NJ8h4nTjwA1XQ==", "e662c76a-16c6-40f4-a905-4f365f3a2c32" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7236));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7238));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7242));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7244));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7212));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7215));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7217));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7219));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 350, DateTimeKind.Local).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 350, DateTimeKind.Local).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 350, DateTimeKind.Local).AddTicks(5532));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 350, DateTimeKind.Local).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 350, DateTimeKind.Local).AddTicks(5536));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 5, 1, 16, 47, 14, 345, DateTimeKind.Local).AddTicks(7266));
        }
    }
}
