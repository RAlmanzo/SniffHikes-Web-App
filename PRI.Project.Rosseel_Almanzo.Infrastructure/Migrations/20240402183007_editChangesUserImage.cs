using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRI.Project.Rosseel_Almanzo.Infrastructure.Migrations
{
    public partial class editChangesUserImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Users_UserId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_UserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Race",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4324));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4329));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4270));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4308));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 4, 2, 20, 30, 7, 386, DateTimeKind.Local).AddTicks(4344));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Race",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(839));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(843));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(846));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(852));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(856));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(859));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(828));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(832));

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(835));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18,
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(883));

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 3, 27, 10, 28, 30, 704, DateTimeKind.Local).AddTicks(887));

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Users_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
