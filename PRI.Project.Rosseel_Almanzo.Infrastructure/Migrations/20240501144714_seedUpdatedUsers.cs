using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Migrations
{
    public partial class seedUpdatedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClaimType",
                value: "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8,
                column: "ClaimType",
                value: "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Orginazer" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "20/09/1990 0:00:00" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "orginazer@pri.be" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "3", "3" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "25/11/1995 0:00:00" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "jill@pri.be" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "4", "4" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "30/01/2000 0:00:00" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "jim@pri.be" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "5", "5" });

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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b3d257ae-753e-4e21-9474-b706c7809d59", "orginazer@pri.be", "ORGINAZER@PRI.BE", "ORGINAZER@PRI.BE", "AQAAAAEAACcQAAAAEG/mHmWXW+9f2EQBzdNOIek/ZzWdP2FzOhDa4tLAieHFyUez7SwUG698jqzi8UA/mA==", "163fdbcf-4117-409d-9413-d1069112e935", "orginazer@pri.be" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClaimType",
                value: "UserId");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8,
                column: "ClaimType",
                value: "UserId");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "20/09/1990 0:00:00" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "jack@pri.be" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "UserId", "3" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", "4" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "25/11/1995 0:00:00" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "jill@pri.be" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "UserId", "4" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", "5" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "30/01/2000 0:00:00" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "jim@pri.be" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "UserId", "5" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Orginazer", "3" });

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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b1c636ef-b41d-46be-ab9d-a45d7bc84329", "jack@pri.be", "JACK@PRI.BE", "JACK@PRI.BE", "AQAAAAEAACcQAAAAEDQDvvYNVQqvZRYAONoKOxtAhqi+SQG6oSEJScll1q2cByDnmDK97ZB8yfvPLHk4+A==", "7328b4ec-5a72-4484-8497-8f5f9da10452", "jack@pri.be" });

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
    }
}
