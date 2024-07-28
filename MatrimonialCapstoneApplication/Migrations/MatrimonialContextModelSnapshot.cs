﻿// <auto-generated />
using System;
using MatrimonialCapstoneApplication.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MatrimonialCapstoneApplication.Migrations
{
    [DbContext(typeof(MatrimonialContext))]
    partial class MatrimonialContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MatrimonialCapstoneApplication.Modals.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<bool?>("AllowLocation")
                        .HasColumnType("bit");

                    b.Property<string>("Caste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Disabilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<bool?>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Membership")
                        .HasColumnType("int");

                    b.Property<string>("MotherTongue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Native")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("MemberId");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            About = "I am a software developer who loves coding and hiking.",
                            Age = 30,
                            AllowLocation = true,
                            Caste = "General",
                            Disabilities = "None",
                            Email = "johndoe.prof@gmail.com",
                            Gender = "Male",
                            Height = 180,
                            IsVerified = true,
                            MaritalStatus = "Single",
                            Membership = 0,
                            MotherTongue = "English",
                            Name = "John Doe",
                            Native = "Theni",
                            PersonName = "Kavin Kumar M",
                            ProfilePic = "https://kavincapstone.blob.core.windows.net/kavinimages/a4151274-cd05-4500-aea5-e1d07d753252.jpg",
                            Relation = "Brother",
                            Religion = "Christian",
                            Role = 0
                        },
                        new
                        {
                            MemberId = 2,
                            About = "I enjoy reading, traveling, and learning new languages.",
                            Age = 28,
                            AllowLocation = true,
                            Caste = "OBC",
                            Disabilities = "None",
                            Email = "janesmith@example.com",
                            Gender = "Female",
                            Height = 165,
                            IsVerified = true,
                            MaritalStatus = "Single",
                            Membership = 1,
                            MotherTongue = "Spanish",
                            Name = "Jane Smith",
                            Native = "Chennai",
                            PersonName = "Marry jasmine",
                            ProfilePic = "https://example.com/janesmith.jpg",
                            Relation = "Sister",
                            Religion = "Hindu",
                            Role = 0
                        });
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Modals.User", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.DailyLog", b =>
                {
                    b.Property<int>("DailyLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DailyLogId"), 1L, 1);

                    b.Property<int>("CreditsCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.HasKey("DailyLogId");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("DailyLogs");

                    b.HasData(
                        new
                        {
                            DailyLogId = 1,
                            CreditsCount = 5,
                            Date = new DateTime(2024, 7, 28, 11, 2, 21, 936, DateTimeKind.Local).AddTicks(2504),
                            MemberId = 2
                        });
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.Hobby", b =>
                {
                    b.Property<int>("HobbyId")
                        .HasColumnType("int");

                    b.Property<string>("HobbyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.HasKey("HobbyId");

                    b.ToTable("Hobbies");

                    b.HasData(
                        new
                        {
                            HobbyId = 1,
                            HobbyName = "Coding",
                            MemberId = 1
                        },
                        new
                        {
                            HobbyId = 2,
                            HobbyName = "Reading",
                            MemberId = 2
                        });
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.Like", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LikeId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("LikedById")
                        .HasColumnType("int");

                    b.Property<int>("LikedId")
                        .HasColumnType("int");

                    b.HasKey("LikeId");

                    b.HasIndex("LikedById");

                    b.HasIndex("LikedId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.Locate", b =>
                {
                    b.Property<int>("LocateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocateId"), 1L, 1);

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Long")
                        .HasColumnType("float");

                    b.Property<int>("PersonalDetailsId")
                        .HasColumnType("int");

                    b.HasKey("LocateId");

                    b.HasIndex("PersonalDetailsId")
                        .IsUnique();

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocateId = 1,
                            Lat = 72.0,
                            Long = 83.221999999999994,
                            PersonalDetailsId = 1
                        });
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatchId"), 1L, 1);

                    b.Property<int>("FromProfileId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ToProfileId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("FromProfileId");

                    b.HasIndex("MemberId");

                    b.HasIndex("ToProfileId");

                    b.ToTable("Match");

                    b.HasData(
                        new
                        {
                            MatchId = 1,
                            FromProfileId = 1,
                            MatchDate = new DateTime(2024, 7, 28, 5, 32, 21, 936, DateTimeKind.Utc).AddTicks(2592),
                            Message = "Hi, I would like to connect.",
                            Status = "Pending",
                            ToProfileId = 2
                        });
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.PersonalDetails", b =>
                {
                    b.Property<int>("PersonalDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonalDetailsId"), 1L, 1);

                    b.Property<string>("AnnualIncome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("ProfessionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonalDetailsId");

                    b.ToTable("PersonalDetails");

                    b.HasData(
                        new
                        {
                            PersonalDetailsId = 1,
                            AnnualIncome = "60000",
                            Education = "Bachelor's in Computer Science",
                            FamilyStatus = "Upper",
                            FamilyType = "Nuclear",
                            FamilyValue = "Traditional",
                            MemberId = 0,
                            ProfessionName = "Software Engineer"
                        });
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PictureId"), 1L, 1);

                    b.Property<int>("PersonalDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PictureId");

                    b.HasIndex("PersonalDetailsId");

                    b.ToTable("Pictures");

                    b.HasData(
                        new
                        {
                            PictureId = 1,
                            PersonalDetailsId = 1,
                            PictureUrl = "https://example.com/picture1.jpg"
                        },
                        new
                        {
                            PictureId = 2,
                            PersonalDetailsId = 1,
                            PictureUrl = "https://example.com/picture2.jpg"
                        });
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.Report", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportId"), 1L, 1);

                    b.Property<int?>("AdminHandledId")
                        .HasColumnType("int");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("ReportMessage")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ReportedAccountId")
                        .HasColumnType("int");

                    b.Property<int>("ReportedById")
                        .HasColumnType("int");

                    b.HasKey("ReportId");

                    b.HasIndex("AdminHandledId");

                    b.HasIndex("MemberId");

                    b.HasIndex("ReportedAccountId");

                    b.HasIndex("ReportedById");

                    b.ToTable("Reports");

                    b.HasData(
                        new
                        {
                            ReportId = 1,
                            ReportMessage = "Inappropriate behavior.",
                            ReportedAccountId = 2,
                            ReportedById = 1
                        });
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.Verification", b =>
                {
                    b.Property<int>("VerificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VerificationId"), 1L, 1);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScheduledTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("VerificationId");

                    b.ToTable("Verifications");
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Modals.User", b =>
                {
                    b.HasOne("MatrimonialCapstoneApplication.Modals.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.DailyLog", b =>
                {
                    b.HasOne("MatrimonialCapstoneApplication.Modals.Member", "Member")
                        .WithOne("DailyLog")
                        .HasForeignKey("MatrimonialCapstoneApplication.Models.DailyLog", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.Hobby", b =>
                {
                    b.HasOne("MatrimonialCapstoneApplication.Modals.Member", "Member")
                        .WithMany("Hobby")
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.Like", b =>
                {
                    b.HasOne("MatrimonialCapstoneApplication.Modals.Member", "LikedBy")
                        .WithMany("LikesGiven")
                        .HasForeignKey("LikedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MatrimonialCapstoneApplication.Modals.Member", "Liked")
                        .WithMany("LikesReceived")
                        .HasForeignKey("LikedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Liked");

                    b.Navigation("LikedBy");
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.Locate", b =>
                {
                    b.HasOne("MatrimonialCapstoneApplication.Models.PersonalDetails", "PersonalDetails")
                        .WithOne("Location")
                        .HasForeignKey("MatrimonialCapstoneApplication.Models.Locate", "PersonalDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalDetails");
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.Match", b =>
                {
                    b.HasOne("MatrimonialCapstoneApplication.Modals.Member", "FromProfile")
                        .WithMany()
                        .HasForeignKey("FromProfileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MatrimonialCapstoneApplication.Modals.Member", null)
                        .WithMany("Matches")
                        .HasForeignKey("MemberId");

                    b.HasOne("MatrimonialCapstoneApplication.Modals.Member", "ToProfile")
                        .WithMany()
                        .HasForeignKey("ToProfileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromProfile");

                    b.Navigation("ToProfile");
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.Picture", b =>
                {
                    b.HasOne("MatrimonialCapstoneApplication.Models.PersonalDetails", "PersonalDetails")
                        .WithMany("Pictures")
                        .HasForeignKey("PersonalDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalDetails");
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.Report", b =>
                {
                    b.HasOne("MatrimonialCapstoneApplication.Modals.Member", "AdminHandled")
                        .WithMany()
                        .HasForeignKey("AdminHandledId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("MatrimonialCapstoneApplication.Modals.Member", null)
                        .WithMany("Reports")
                        .HasForeignKey("MemberId");

                    b.HasOne("MatrimonialCapstoneApplication.Modals.Member", "ReportedAccount")
                        .WithMany()
                        .HasForeignKey("ReportedAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MatrimonialCapstoneApplication.Modals.Member", "ReportedBy")
                        .WithMany()
                        .HasForeignKey("ReportedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AdminHandled");

                    b.Navigation("ReportedAccount");

                    b.Navigation("ReportedBy");
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Modals.Member", b =>
                {
                    b.Navigation("DailyLog");

                    b.Navigation("Hobby");

                    b.Navigation("LikesGiven");

                    b.Navigation("LikesReceived");

                    b.Navigation("Matches");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("MatrimonialCapstoneApplication.Models.PersonalDetails", b =>
                {
                    b.Navigation("Location");

                    b.Navigation("Pictures");
                });
#pragma warning restore 612, 618
        }
    }
}
