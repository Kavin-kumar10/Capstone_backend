using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonialCapstoneApplication.Migrations
{
    public partial class pic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2024, 7, 24, 10, 55, 46, 119, DateTimeKind.Utc).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "PictureId",
                keyValue: 1,
                column: "MemberId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "PictureId",
                keyValue: 2,
                column: "MemberId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2024, 7, 24, 10, 54, 21, 94, DateTimeKind.Utc).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "PictureId",
                keyValue: 1,
                column: "MemberId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "PictureId",
                keyValue: 2,
                column: "MemberId",
                value: 0);
        }
    }
}
