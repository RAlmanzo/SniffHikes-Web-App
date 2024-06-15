using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Migrations
{
    public partial class addImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 22, "profile-image", "FB_IMG_1676153444794.jpg", "1" },
                    { 23, "profile-image", "AInca&me_153848.jpeg", "2" },
                    { 24, "profile-image", "received_3074607475886000.jpeg", "3" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Image", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18032c48-62a6-40bc-bf80-a81a74c951f7", "FB_IMG_1676153444794.jpg", "AQAAAAEAACcQAAAAECS7AUcRmJzq/DuHmwq9eMBmTPe2RkjVrLwlodJxvk46qZc7w0Jd8oBWLoNXU8YKGg==", "99ef2440-3680-4aa8-a0b4-98a75e9d9bf4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Image", "PasswordHash", "SecurityStamp" },
                values: new object[] { "064861f8-1d34-4536-b815-09747e8d8f0a", "AInca&me_153848.jpeg", "AQAAAAEAACcQAAAAEExbmaaji21xEOihayQGa7b/ixDIFioBYSY3mGDZ4xByW3ThCQuRjDGHtBLgg3STmw==", "eb9dbf6a-cc0a-462d-88c2-0ad62ffa541a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "Image", "PasswordHash", "SecurityStamp" },
                values: new object[] { "255aa8a8-0b9d-4834-b177-2f0d1621f8ce", "received_3074607475886000.jpeg", "AQAAAAEAACcQAAAAEDiXYQLNVlgcr0tymnUdmUHasPtF35MIMfsv3ft6MlzxfpnU4Vfk+Z5hpilwHU0GfA==", "6f623afd-5ae1-49b2-b9e4-dd192c503204" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3aa2ab82-34ad-4d94-8532-c84f0854e1a6", "AQAAAAEAACcQAAAAEO5wKG54pZh4UW6ke1obdNS2msi9dB2dARcgwqttVA1UMP1Z7wYpZ91gpKZU3qVw+Q==", "0163b857-ad41-4e6e-8e7f-6ee701481182" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22efeb95-a6bf-4197-b918-7b37d20a5c7f", "AQAAAAEAACcQAAAAECy3t5TPXpRTofdBIyfAQbvWWqT0NHAIK2lTMhzrMJ1KjhIGJjcH0BqbIAPbEKMM5A==", "d54e6f83-0b93-42e5-bc7d-c1b524998d7a" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3821));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3828));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Image" },
                values: new object[] { new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3764), "inca2.jpg" });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "Image" },
                values: new object[] { new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3803), "FB_IMG_1676153391880.jpg" });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "Image", "Name", "Race" },
                values: new object[] { new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3806), "IMG_20201118_121810.jpg", "Zira", "Husky" });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateOfBirth", "Image", "UserId" },
                values: new object[] { new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3808), "received_455341335122662.jpeg", "2" });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateOfBirth", "Gender", "Image", "Name", "Race", "UserId" },
                values: new object[] { new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3810), "Male", "IMG_20210613_142801.jpg", "Sleepy", "Duitse-herder", "3" });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateOfBirth", "Image", "Name", "Race" },
                values: new object[] { new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "IMG_20210619_162819.jpg", "Luna", "Golden Retriever" });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateOfBirth", "Image", "Name", "Race", "UserId" },
                values: new object[] { new DateTime(2017, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "received_421419258529965.jpeg", "Max", "Poodle", "5" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 6, 15, 18, 32, 9, 634, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 6, 15, 18, 32, 9, 634, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 6, 15, 18, 32, 9, 634, DateTimeKind.Local).AddTicks(3039));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 6, 15, 18, 32, 9, 634, DateTimeKind.Local).AddTicks(3041));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 6, 15, 18, 32, 9, 634, DateTimeKind.Local).AddTicks(3043));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "File",
                value: "AHiken.jpeg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "File",
                value: "IMG_20210516_165116.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { 1, "IMG_20210516_171528.jpg", null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "File",
                value: "Schermafbeelding 2024-06-15 173812.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { 3, "FB_IMG_1676153401593.jpg", null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { 3, "IMG_20210613_150444.jpg", null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EventId", "File" },
                values: new object[] { 4, "Schermafbeelding 2024-06-15 175152.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { 5, "IMG_20210620_161504.jpg", null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { null, "IMG_20210620_154507.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { null, "IMG_20210620_154515.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "File", "RouteId" },
                values: new object[] { "Schermafbeelding 2024-06-15 180613.png", 2 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { null, "Schermafbeelding 2024-06-15 180627.png", 2 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "File", "RouteId" },
                values: new object[] { "Schermafbeelding 2024-06-15 180646.png", 2 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17,
                column: "File",
                value: "Schermafbeelding 2024-06-15 180856.png");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "EventId", "File", "RouteId" },
                values: new object[,]
                {
                    { 4, 2, "Schermafbeelding 2024-06-15 173550.png", null },
                    { 5, 2, "Schermafbeelding 2023-11-03 203719.png", null },
                    { 11, null, "IMG_20210620_152407.jpg", 1 },
                    { 18, null, "Schermafbeelding 2024-06-15 180954.png", 3 },
                    { 19, null, "Schermafbeelding 2024-06-15 181114.png", 4 },
                    { 20, null, "Schermafbeelding 2024-06-15 181021.png", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Title" },
                values: new object[] { new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3874), "HellegatBos wandeling" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Title" },
                values: new object[] { new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3876), "Strandwandeling DePanne" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "Title" },
                values: new object[] { new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3878), "Parkwandeling Brussel" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "Title" },
                values: new object[] { new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3879), "Strandwandeling Oostende" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "Title" },
                values: new object[] { new DateTime(2024, 6, 15, 18, 32, 9, 629, DateTimeKind.Local).AddTicks(3881), "Parkwandeling Brugge" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 24);

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
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Image", "PasswordHash", "SecurityStamp" },
                values: new object[] { "518c2080-2525-4369-b89e-cf368256174d", null, "AQAAAAEAACcQAAAAEGdvE8wdTuT7HLYUCOMLjFInWb9p5djtByhE5dBVpzE7phYQgGPuEhCMuhQfNCFk4w==", "cab5e653-9a68-4a15-8157-448c2cc8358a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Image", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83e1cf39-02ee-4654-acf1-ee80f405a8c8", null, "AQAAAAEAACcQAAAAEP3NPHTP2YpjOHJFv7OxWJC/I1/R0F1XXvX0xBbYeLGRiZ6KohysDjoprXLc46hRwQ==", "dac8b120-7dc1-4150-9748-777f44181d11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "Image", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78421e5e-8589-493b-99c4-f8eed8252e90", null, "AQAAAAEAACcQAAAAELdBpyq2CA3xd1AyTFDWgGNgeYdyNGId4/X+dANAlEaWyazlO0EDM6gB1ljuQ+MIzw==", "84259b99-1eba-4f11-b157-83d901e7409d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6819dbf-efa6-4cb3-a2b7-f4cc045993c7", "AQAAAAEAACcQAAAAEFhez/D3lmcte/mlOp1RllZ/qW79/dI188vxWTklUOnMaMJWt6a9NBMOyuLaxYSsVQ==", "dcdb9990-ef46-431f-82ac-aea7f9b19289" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b652848-d412-4087-86b5-af8ea7cf5a7b", "AQAAAAEAACcQAAAAEOxvhUX/PwIE1H7CJLbdZHm+sXsZjpDKocY2EzXE+OlLccLGDrqXi5O5Jx6c10iJtw==", "9e23e212-dec3-4e91-8045-b762e71b1ccc" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4619));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Image" },
                values: new object[] { new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4560), null });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "Image" },
                values: new object[] { new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4599), null });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "Image", "Name", "Race" },
                values: new object[] { new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4601), null, "Sleepy", "Duitse-herder" });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateOfBirth", "Image", "UserId" },
                values: new object[] { new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4604), null, "3" });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateOfBirth", "Gender", "Image", "Name", "Race", "UserId" },
                values: new object[] { new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4606), "Female", null, "Tunder", "Dog", "1" });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateOfBirth", "Image", "Name", "Race" },
                values: new object[] { new DateTime(2019, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bella", "Labrador Retriever" });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateOfBirth", "Image", "Name", "Race", "UserId" },
                values: new object[] { new DateTime(2018, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rocky", "German Shepherd", "4" });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "DateOfBirth", "Gender", "Image", "Name", "Race", "UserId" },
                values: new object[,]
                {
                    { 6, new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4607), "Male", null, "Zira", "Husky", "2" },
                    { 9, new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", null, "Luna", "Golden Retriever", "5" },
                    { 10, new DateTime(2017, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", null, "Max", "Poodle", "5" }
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 5, 5, 20, 32, 58, 307, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 5, 5, 20, 32, 58, 307, DateTimeKind.Local).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 5, 5, 20, 32, 58, 307, DateTimeKind.Local).AddTicks(2847));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 5, 5, 20, 32, 58, 307, DateTimeKind.Local).AddTicks(2849));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 5, 5, 20, 32, 58, 307, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "File",
                value: null);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "File",
                value: null);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { null, null, 1 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "File",
                value: null);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { null, null, 2 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { null, null, 2 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EventId", "File" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { null, null, 2 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { 3, null, null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { 2, null, null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "File", "RouteId" },
                values: new object[] { null, 3 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EventId", "File", "RouteId" },
                values: new object[] { 1, null, null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "File", "RouteId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17,
                column: "File",
                value: null);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Title" },
                values: new object[] { new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4644), "Boswandeling" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Title" },
                values: new object[] { new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4646), "Strandwandeling" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "Title" },
                values: new object[] { new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4648), "Parkwandeling" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "Title" },
                values: new object[] { new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4650), "Strandwandeling" });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "Title" },
                values: new object[] { new DateTime(2024, 5, 5, 20, 32, 58, 302, DateTimeKind.Local).AddTicks(4651), "Parkwandeling" });
        }
    }
}
