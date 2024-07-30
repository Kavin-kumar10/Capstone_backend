using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonialCapstoneApplication.Migrations
{
    public partial class likesupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Members_LikedById",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_LikedById",
                table: "Likes");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "PersonalDetails");

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

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikedById",
                table: "Likes",
                column: "LikedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Members_LikedById",
                table: "Likes",
                column: "LikedById",
                principalTable: "Members",
                principalColumn: "MemberId");
        }
    }
}
