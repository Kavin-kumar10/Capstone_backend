using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonialCapstoneApplication.Migrations
{
    public partial class duplicatememberremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberName",
                table: "Members");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2024, 7, 26, 4, 6, 30, 406, DateTimeKind.Utc).AddTicks(4488));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemberName",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2024, 7, 25, 7, 14, 20, 41, DateTimeKind.Utc).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "MemberName",
                value: "John");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "MemberName",
                value: "John");
        }
    }
}
