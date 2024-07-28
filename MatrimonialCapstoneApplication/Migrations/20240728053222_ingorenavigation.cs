using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonialCapstoneApplication.Migrations
{
    public partial class ingorenavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "DailyLogId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 28, 11, 2, 21, 936, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2024, 7, 28, 5, 32, 21, 936, DateTimeKind.Utc).AddTicks(2592));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "DailyLogId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 28, 10, 57, 22, 575, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2024, 7, 28, 5, 27, 22, 575, DateTimeKind.Utc).AddTicks(9584));
        }
    }
}
