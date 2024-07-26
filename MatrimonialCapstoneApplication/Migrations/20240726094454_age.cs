using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonialCapstoneApplication.Migrations
{
    public partial class age : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2024, 7, 26, 9, 44, 53, 434, DateTimeKind.Utc).AddTicks(5135));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Members");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2024, 7, 26, 4, 6, 30, 406, DateTimeKind.Utc).AddTicks(4488));
        }
    }
}
