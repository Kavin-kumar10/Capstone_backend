using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonialCapstoneApplication.Migrations
{
    public partial class hobbybugupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HobbyName",
                table: "Hobbies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HobbyName",
                table: "Hobbies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "DailyLogId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 30, 20, 16, 38, 310, DateTimeKind.Local).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2024, 7, 30, 14, 46, 38, 310, DateTimeKind.Utc).AddTicks(3191));
        }
    }
}
