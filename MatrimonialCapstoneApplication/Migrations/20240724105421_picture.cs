using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonialCapstoneApplication.Migrations
{
    public partial class picture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Members_MemberId",
                table: "Picture");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Picture",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Members_MemberId",
                table: "Picture",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Members_MemberId",
                table: "Picture");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Picture",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "MatchDate",
                value: new DateTime(2024, 7, 24, 10, 43, 14, 810, DateTimeKind.Utc).AddTicks(3881));

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "PictureId",
                keyValue: 1,
                column: "MemberId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "PictureId",
                keyValue: 2,
                column: "MemberId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Members_MemberId",
                table: "Picture",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId");
        }
    }
}
