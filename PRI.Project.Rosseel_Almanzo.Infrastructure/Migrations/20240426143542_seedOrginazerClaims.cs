using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Migrations
{
    public partial class seedOrginazerClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "10/05/1980 0:00:00", "1" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "admin@pri.be" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "UserId", "1", "1" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", "2" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "15/07/1985 0:00:00" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "user@pri.be", "2" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 9, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", "3" },
                    { 10, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "20/09/1990 0:00:00", "3" },
                    { 11, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "jack@pri.be", "3" },
                    { 12, "UserId", "3", "3" },
                    { 13, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", "4" },
                    { 14, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "25/11/1995 0:00:00", "4" },
                    { 15, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "jill@pri.be", "4" },
                    { 16, "UserId", "4", "4" },
                    { 17, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", "5" },
                    { 18, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "30/01/2000 0:00:00", "5" },
                    { 19, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "jim@pri.be", "5" },
                    { 20, "UserId", "5", "5" },
                    { 21, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Orginazer", "3" }
                });

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
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "e409fbcb-7294-42a5-be70-1e542376af5d", "jack@pri.be", true, "JACK@PRI.BE", "JACK@PRI.BE", null, "AQAAAAEAACcQAAAAEKGIr22MsCXjABcKV4jqSsj2bnKspTa2GbvErrQ0G56zq5LqsciH2cOE9kx5fpWBVg==", "fbd70e0e-04d6-4a48-8f42-6079b65686fb", "jack@pri.be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "2b857c50-e1a6-4c10-a56b-42d9fe49d500", "jill@pri.be", true, "JILL@PRI.BE", "JILL@PRI.BE", null, "AQAAAAEAACcQAAAAEO5StNrTpcGzSmCo4sAPNVBrs1Q81pzye05IN3HD+oaqMELOyuufpJqD2eVXcOAvEw==", "016036e8-9533-459b-a43b-0d47c72c114f", "jill@pri.be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "507f80ba-8906-4504-a7df-125d725b2ab3", "jim@pri.be", true, "JIM@PRI.BE", "JIM@PRI.BE", null, "AQAAAAEAACcQAAAAELr4Rir+ZfCTmwwjcmtpRC0nhef+EoABKhjFySZ5U/EN2V/kytWEFzYOV47SPNeMSg==", "17d797ff-1089-40f2-8c2f-927997452763", "jim@pri.be" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", "2" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "10/05/1980 0:00:00" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "15/07/1985 0:00:00", "2" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "admin@pri.be", "1" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "user@pri.be" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "UserId", "1", "1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f970bab7-ff73-40f6-8efe-bc415b7ecb6d", "AQAAAAEAACcQAAAAENsjaW23fXI/zRAIckmYJg7m0vAhlP2tMou+wyXjF9+Sm7l0TxwI3GcrlyoXVI2oIg==", "7a734246-af26-4f7f-9eda-f5ad55c79c7e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72f9c00a-abcc-44c3-bd71-d4975cb9f545", "AQAAAAEAACcQAAAAEHn4n97yfqefH+wr9rVTcGjSjXSD0RaiqFxfbCt4uKj95rt1AU6oGhGI/tJoU6qUGw==", "fcbf4378-31aa-44be-8d62-c40e89c818ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "e7959b19-8493-46a7-bb8f-57221c43a2fd", "", false, null, null, "", null, "93bbb08a-bfe1-47fa-9fc5-1dcac0e855da", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ceeddee9-65c7-420f-bd97-9166f497b034", "", false, null, null, "", null, "b17f3e57-10b0-412f-bd16-83532d8a5f75", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d9522450-a874-4b57-aec1-f929926d96a6", "", false, null, null, "", null, "dc060825-c355-4c99-87d6-a81c330a0ff8", null });

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
    }
}
