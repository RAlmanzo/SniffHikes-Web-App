using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Migrations
{
    public partial class seedUserClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 3, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "10/05/1980 0:00:00", "1" },
                    { 4, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "15/07/1985 0:00:00", "2" },
                    { 5, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "admin@pri.be", "1" },
                    { 6, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "user@pri.be", "2" },
                    { 7, "UserId", "1", "1" },
                    { 8, "UserId", "2", "2" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "f970bab7-ff73-40f6-8efe-bc415b7ecb6d", "admin@pri.be", "ADMIN@PRI.BE", "ADMIN@PRI.BE", "AQAAAAEAACcQAAAAENsjaW23fXI/zRAIckmYJg7m0vAhlP2tMou+wyXjF9+Sm7l0TxwI3GcrlyoXVI2oIg==", "7a734246-af26-4f7f-9eda-f5ad55c79c7e", "admin@pri.be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "72f9c00a-abcc-44c3-bd71-d4975cb9f545", "user@pri.be", "USER@PRI.BE", "USER@PRI.BE", "AQAAAAEAACcQAAAAEHn4n97yfqefH+wr9rVTcGjSjXSD0RaiqFxfbCt4uKj95rt1AU6oGhGI/tJoU6qUGw==", "fcbf4378-31aa-44be-8d62-c40e89c818ab", "user@pri.be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e7959b19-8493-46a7-bb8f-57221c43a2fd", "93bbb08a-bfe1-47fa-9fc5-1dcac0e855da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ceeddee9-65c7-420f-bd97-9166f497b034", "b17f3e57-10b0-412f-bd16-83532d8a5f75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d9522450-a874-4b57-aec1-f929926d96a6", "dc060825-c355-4c99-87d6-a81c330a0ff8" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4861));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4865));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4799));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 257, DateTimeKind.Local).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 257, DateTimeKind.Local).AddTicks(4735));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 257, DateTimeKind.Local).AddTicks(4737));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 257, DateTimeKind.Local).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 257, DateTimeKind.Local).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 26, 11, 53, 41, 255, DateTimeKind.Local).AddTicks(4891));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6b132718-9123-44a4-a335-619eae4fbebc", "admin@testing.com", "ADMIN@TESTING.COM", "ADMIN@TESTING.COM", "AQAAAAEAACcQAAAAEDgVxSTuaPtHpAC/6EPdDbLNOsxazted+aet90CHTgls60eB0SCdSwc/L3MHH6FDgg==", "d241b16f-18cc-4216-a413-b69724007536", "admin@testing.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "fe5f8cb7-b2a6-4003-8fd3-1e07e46c45f7", "user@testing.com", "USER@TESTING.COM", "USER@TESTING.COM", "AQAAAAEAACcQAAAAEO1X2mgFqHdvJqB288hgmqpyWPNIk+3l8vwlKlwrPUI5a/OfkVXQWabXirpqzjv3og==", "61f98943-3901-4412-895f-6978972f9554", "user@testing.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ce8cff66-3706-47b2-b118-d705e73ba934", "2c8eaff7-4352-4a20-9007-bbf0b5b268a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "819c4ed9-aaff-4158-8be5-2eeff3ba263d", "606cfe7b-588a-46ac-a17c-ab8a477feba0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "41400c1e-54a0-41e3-8ff3-167c23cedc13", "f5db548a-9952-4471-a26f-d1980e098d8a" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6411));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6420));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6424));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6397));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6399));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 827, DateTimeKind.Local).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 827, DateTimeKind.Local).AddTicks(5596));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 827, DateTimeKind.Local).AddTicks(5598));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 827, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 827, DateTimeKind.Local).AddTicks(5602));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6440));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6442));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 21, 14, 2, 54, 825, DateTimeKind.Local).AddTicks(6447));
        }
    }
}
