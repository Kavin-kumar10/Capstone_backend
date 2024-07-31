using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonialCapstoneApplication.Migrations
{
    public partial class bugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Hobbies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "DailyLogId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 31, 16, 47, 5, 73, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2024, 7, 31, 11, 17, 5, 73, DateTimeKind.Utc).AddTicks(1979));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Hobbies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "DailyLogId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 31, 16, 39, 7, 289, DateTimeKind.Local).AddTicks(8085));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2024, 7, 31, 11, 9, 7, 289, DateTimeKind.Utc).AddTicks(8182));
        }
    }
}
