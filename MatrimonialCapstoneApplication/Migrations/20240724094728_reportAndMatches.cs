using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonialCapstoneApplication.Migrations
{
    public partial class reportAndMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "MatchId", "FromProfileId", "MatchDate", "MemberId", "Message", "Status", "ToProfileId" },
                values: new object[] { 1, 1, new DateTime(2024, 7, 24, 9, 47, 27, 866, DateTimeKind.Utc).AddTicks(7407), null, "Hi, I would like to connect.", "Pending", 2 });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "AdminHandledId", "MemberId", "ReportMessage", "ReportedAccountId", "ReportedById" },
                values: new object[] { 1, null, null, "Inappropriate behavior.", 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Match",
                keyColumn: "MatchId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: 1);
        }
    }
}
