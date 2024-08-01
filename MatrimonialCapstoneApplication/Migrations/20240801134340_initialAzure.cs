using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonialCapstoneApplication.Migrations
{
    public partial class initialAzure : Migration
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
                    Age = table.Column<int>(type: "int", nullable: true),
                    Relation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Native = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    MotherTongue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowLocation = table.Column<bool>(type: "bit", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: true),
                    ProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDetails",
                columns: table => new
                {
                    PersonalDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    FamilyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualIncome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDetails", x => x.PersonalDetailsId);
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
                name: "DailyLogs",
                columns: table => new
                {
                    DailyLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditsCount = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyLogs", x => x.DailyLogId);
                    table.ForeignKey(
                        name: "FK_DailyLogs_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    HobbyId = table.Column<int>(type: "int", nullable: false),
                    HobbyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.HobbyId);
                    table.ForeignKey(
                        name: "FK_Hobbies_Members_HobbyId",
                        column: x => x.HobbyId,
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
                        name: "FK_Likes_Members_LikedId",
                        column: x => x.LikedId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Long = table.Column<double>(type: "float", nullable: false),
                    PersonalDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocateId);
                    table.ForeignKey(
                        name: "FK_Locations_PersonalDetails_PersonalDetailsId",
                        column: x => x.PersonalDetailsId,
                        principalTable: "PersonalDetails",
                        principalColumn: "PersonalDetailsId");
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_Pictures_PersonalDetails_PersonalDetailsId",
                        column: x => x.PersonalDetailsId,
                        principalTable: "PersonalDetails",
                        principalColumn: "PersonalDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "About", "Age", "AllowLocation", "Caste", "Disabilities", "Email", "Gender", "Height", "IsVerified", "MaritalStatus", "Membership", "MotherTongue", "Name", "Native", "PersonName", "ProfilePic", "Relation", "Religion", "Role" },
                values: new object[] { 1, "I am a software developer who loves coding and hiking.", 30, true, "General", "None", "johndoe.prof@gmail.com", "Male", 180, true, "Single", 0, "English", "John Doe", "Theni", "Kavin Kumar M", "https://kavincapstone.blob.core.windows.net/kavinimages/a4151274-cd05-4500-aea5-e1d07d753252.jpg", "Brother", "Christian", 0 });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "About", "Age", "AllowLocation", "Caste", "Disabilities", "Email", "Gender", "Height", "IsVerified", "MaritalStatus", "Membership", "MotherTongue", "Name", "Native", "PersonName", "ProfilePic", "Relation", "Religion", "Role" },
                values: new object[] { 2, "I enjoy reading, traveling, and learning new languages.", 28, true, "OBC", "None", "janesmith@example.com", "Female", 165, true, "Single", 1, "Spanish", "Jane Smith", "Chennai", "Marry jasmine", "https://example.com/janesmith.jpg", "Sister", "Hindu", 0 });

            migrationBuilder.InsertData(
                table: "PersonalDetails",
                columns: new[] { "PersonalDetailsId", "AnnualIncome", "Education", "FamilyStatus", "FamilyType", "FamilyValue", "MemberId", "Mobile", "ProfessionName" },
                values: new object[] { 1, "60000", "Bachelor's in Computer Science", "Upper", "Nuclear", "Traditional", 0, null, "Software Engineer" });

            migrationBuilder.InsertData(
                table: "DailyLogs",
                columns: new[] { "DailyLogId", "CreditsCount", "Date", "MemberId" },
                values: new object[] { 1, 5, new DateTime(2024, 8, 1, 19, 13, 40, 706, DateTimeKind.Local).AddTicks(970), 2 });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "HobbyId", "HobbyName", "MemberId" },
                values: new object[,]
                {
                    { 1, "Coding", 1 },
                    { 2, "Reading", 2 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocateId", "Lat", "Long", "PersonalDetailsId" },
                values: new object[] { 1, 72.0, 83.221999999999994, 1 });

            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "MatchId", "FromProfileId", "MatchDate", "MemberId", "Message", "Status", "ToProfileId" },
                values: new object[] { 1, 1, new DateTime(2024, 8, 1, 13, 43, 40, 706, DateTimeKind.Utc).AddTicks(1064), null, "Hi, I would like to connect.", "Pending", 2 });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "PictureId", "PersonalDetailsId", "PictureUrl" },
                values: new object[,]
                {
                    { 1, 1, "https://example.com/picture1.jpg" },
                    { 2, 1, "https://example.com/picture2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "AdminHandledId", "MemberId", "ReportMessage", "ReportedAccountId", "ReportedById" },
                values: new object[] { 1, null, null, "Inappropriate behavior.", 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DailyLogs_MemberId",
                table: "DailyLogs",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikedId",
                table: "Likes",
                column: "LikedId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_PersonalDetailsId",
                table: "Locations",
                column: "PersonalDetailsId",
                unique: true,
                filter: "[PersonalDetailsId] IS NOT NULL");

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
                name: "IX_Pictures_PersonalDetailsId",
                table: "Pictures",
                column: "PersonalDetailsId");

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
                name: "DailyLogs");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Verifications");

            migrationBuilder.DropTable(
                name: "PersonalDetails");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
