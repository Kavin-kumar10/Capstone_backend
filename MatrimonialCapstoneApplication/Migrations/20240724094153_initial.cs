using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonialCapstoneApplication.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Membership = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    MotherTongue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowLocation = table.Column<bool>(type: "bit", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: true),
                    ProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualIncome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Members_MemberId1",
                        column: x => x.MemberId1,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "Verifications",
                columns: table => new
                {
                    VerificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ScheduledTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verifications", x => x.VerificationId);
                });

            migrationBuilder.CreateTable(
                name: "Hobby",
                columns: table => new
                {
                    HobbyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HobbyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobby", x => x.HobbyId);
                    table.ForeignKey(
                        name: "FK_Hobby_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    LikeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikedById = table.Column<int>(type: "int", nullable: false),
                    LikedId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.LikeId);
                    table.ForeignKey(
                        name: "FK_Likes_Members_LikedById",
                        column: x => x.LikedById,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Members_LikedId",
                        column: x => x.LikedId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromProfileId = table.Column<int>(type: "int", nullable: false),
                    ToProfileId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Match_Members_FromProfileId",
                        column: x => x.FromProfileId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                    table.ForeignKey(
                        name: "FK_Match_Members_ToProfileId",
                        column: x => x.ToProfileId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_Picture_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportedById = table.Column<int>(type: "int", nullable: false),
                    ReportedAccountId = table.Column<int>(type: "int", nullable: false),
                    AdminHandledId = table.Column<int>(type: "int", nullable: true),
                    ReportMessage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Members_AdminHandledId",
                        column: x => x.AdminHandledId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Reports_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                    table.ForeignKey(
                        name: "FK_Reports_Members_ReportedAccountId",
                        column: x => x.ReportedAccountId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Members_ReportedById",
                        column: x => x.ReportedById,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HashedPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Users_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "About", "AllowLocation", "AnnualIncome", "Caste", "Disabilities", "Education", "Email", "FamilyStatus", "FamilyType", "FamilyValue", "Gender", "Height", "IsVerified", "Location", "MaritalStatus", "MemberId1", "MemberName", "Membership", "MotherTongue", "Name", "PersonName", "ProfessionName", "ProfilePic", "Relation", "Religion", "Role" },
                values: new object[] { 1, "A software developer with a passion for coding.", true, "60000", "General", "None", "Bachelor's in Computer Science", "john.doe@example.com", "Upper", "Nuclear", "Traditional", "Male", 180, true, "New York", "Single", null, "John", 1, "English", "John Doe", "John Doe", "Software Engineer", "https://example.com/profilepic.jpg", "Single", "Christian", 1 });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "About", "AllowLocation", "AnnualIncome", "Caste", "Disabilities", "Education", "Email", "FamilyStatus", "FamilyType", "FamilyValue", "Gender", "Height", "IsVerified", "Location", "MaritalStatus", "MemberId1", "MemberName", "Membership", "MotherTongue", "Name", "PersonName", "ProfessionName", "ProfilePic", "Relation", "Religion", "Role" },
                values: new object[] { 2, "A software developer with a passion for coding.", true, "60000", "General", "None", "Bachelor's in Computer Science", "kavin.doe@example.com", "Upper", "Nuclear", "Traditional", "Male", 180, true, "New York", "Single", null, "John", 1, "English", "Kavin", "John Doe", "Software Engineer", "https://example.com/profilepic.jpg", "Single", "Christian", 1 });

            migrationBuilder.InsertData(
                table: "Hobby",
                columns: new[] { "HobbyId", "HobbyName", "MemberId" },
                values: new object[,]
                {
                    { 1, "Coding", 1 },
                    { 2, "Reading", 1 }
                });

            migrationBuilder.InsertData(
                table: "Picture",
                columns: new[] { "PictureId", "MemberId", "PictureUrl" },
                values: new object[,]
                {
                    { 1, 1, "https://example.com/picture1.jpg" },
                    { 2, 1, "https://example.com/picture2.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hobby_MemberId",
                table: "Hobby",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikedById",
                table: "Likes",
                column: "LikedById");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikedId",
                table: "Likes",
                column: "LikedId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_FromProfileId",
                table: "Match",
                column: "FromProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_MemberId",
                table: "Match",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_ToProfileId",
                table: "Match",
                column: "ToProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberId1",
                table: "Members",
                column: "MemberId1");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_MemberId",
                table: "Picture",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_AdminHandledId",
                table: "Reports",
                column: "AdminHandledId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_MemberId",
                table: "Reports",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportedAccountId",
                table: "Reports",
                column: "ReportedAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportedById",
                table: "Reports",
                column: "ReportedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hobby");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Verifications");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
