using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;
using MatrimonialCapstoneApplication.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialCapstoneApplication.Context
{
    public class MatrimonialContext : DbContext
    {
        public MatrimonialContext(DbContextOptions<MatrimonialContext> options): base(options) { 
        
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Verification> Verifications { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<Locate> Locations { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<DailyLog> DailyLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    MemberId = 1,
                    Name = "John Doe",
                    Email = "johndoe.prof@gmail.com",
                    Role = RoleEnum.User,
                    Membership = Membershipenum.Free,
                    Gender = "Male",
                    Age = 30,
                    Relation = "Brother",
                    PersonName = "Kavin Kumar M",
                    About = "I am a software developer who loves coding and hiking.",
                    Height = 180,
                    MotherTongue = "English",
                    Caste = "General",
                    Religion = "Christian",
                    MaritalStatus = "Single",
                    Native = "Theni",
                    Disabilities = "None",
                    AllowLocation = true,
                    IsVerified = true,
                    ProfilePic = "https://kavincapstone.blob.core.windows.net/kavinimages/a4151274-cd05-4500-aea5-e1d07d753252.jpg",
                },
                new Member
                {
                    MemberId = 2,
                    Name = "Jane Smith",
                    Email = "janesmith@example.com",
                    Role = RoleEnum.User,
                    Membership = Membershipenum.Premium,
                    Gender = "Female",
                    Age = 28,
                    Relation = "Sister",
                    PersonName = "Marry jasmine",
                    About = "I enjoy reading, traveling, and learning new languages.",
                    Height = 165,
                    MotherTongue = "Spanish",
                    Caste = "OBC",
                    Religion = "Hindu",
                    MaritalStatus = "Single",
                    Native = "Chennai",
                    Disabilities = "None",
                    AllowLocation = true,
                    IsVerified = true,
                    ProfilePic = "https://example.com/janesmith.jpg",
                }

        );

            modelBuilder.Entity<DailyLog>().HasData(
                new DailyLog
                {
                    Date = DateTime.Now,
                    MemberId = 2,
                    CreditsCount = 5,
                    DailyLogId = 1,
                }       
            );

        modelBuilder.Entity<PersonalDetails>().HasData(
            new PersonalDetails
            {
                PersonalDetailsId = 1,
                FamilyType = "Nuclear",
                FamilyValue = "Traditional",
                FamilyStatus = "Upper",
                ProfessionName = "Software Engineer",
                Education = "Bachelor's in Computer Science",
                AnnualIncome = "60000",
            }
        );

        modelBuilder.Entity<Locate>().HasData(
            new Locate
            {
                LocateId = 1,
                PersonalDetailsId = 1,
                Lat = 72.000,
                Long = 83.222
            }
        );
           
        // Seeding Pictures
        modelBuilder.Entity<Picture>().HasData(
            new Picture
            {
                PictureId = 1,
                PictureUrl = "https://example.com/picture1.jpg",
                PersonalDetailsId = 1
            },
            new Picture
            {
                PictureId = 2,
                PictureUrl = "https://example.com/picture2.jpg",
                PersonalDetailsId = 1
            }
        );

        // Seeding Hobbies
        modelBuilder.Entity<Hobby>().HasData(
            new Hobby
            {
                HobbyId = 1,
                HobbyName = "Coding",
                MemberId = 1
            },
            new Hobby
            {
                HobbyId = 2,
                HobbyName = "Reading",
                MemberId = 2
            }
        );

        // Seeding Matches
        modelBuilder.Entity<Match>().HasData(
            new Match
            {
                MatchId = 1,
                FromProfileId = 1,
                ToProfileId = 2,
                Status = "Pending",
                Message = "Hi, I would like to connect.",
                MatchDate = DateTime.UtcNow
            }
        );

        // Seeding Reports
        modelBuilder.Entity<Report>().HasData(
            new Report
            {
                ReportId = 1,
                ReportedById = 1,
                ReportedAccountId = 2,
                AdminHandledId = null,
                ReportMessage = "Inappropriate behavior."
            }
        );


        //Location

        modelBuilder.Entity<PersonalDetails>()
            .HasOne(p => p.Location)
            .WithOne(l => l.PersonalDetails);

        modelBuilder.Entity<PersonalDetails>()
            .Navigation(p => p.Location)
            .AutoInclude();

        //Pictures

        modelBuilder.Entity<PersonalDetails>()
            .HasMany(m => m.Pictures)
            .WithOne(p => p.PersonalDetails)
            .HasForeignKey(p => p.PersonalDetailsId);

        modelBuilder.Entity<PersonalDetails>()
            .Navigation(m => m.Pictures)
            .AutoInclude();

        //Hobby

        modelBuilder.Entity<Member>()
            .HasMany(m => m.Hobby)
            .WithOne(h => h.Member)
            .HasForeignKey(h => h.HobbyId);

        modelBuilder.Entity<Member>()
            .Navigation(m => m.Hobby)
            .AutoInclude();



            //DailyLog

            modelBuilder.Entity<Member>()
                .HasOne(m => m.DailyLog)
                .WithOne(d => d.Member)
                .HasForeignKey<DailyLog>(d => d.MemberId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Member>()
                .Navigation(m=>m.DailyLog)
                .AutoInclude();

            //Like

            modelBuilder.Entity<Like>()
                .HasOne(l => l.LikedBy)
                .WithMany(m => m.LikesGiven)
                .HasForeignKey(l => l.LikedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Liked)
                .WithMany(m => m.LikesReceived)
                .HasForeignKey(l => l.LikedId)
                .OnDelete(DeleteBehavior.NoAction);

            // Optionally, you can use AutoInclude
            modelBuilder.Entity<Member>()
                .Navigation(m => m.LikesGiven)
                .AutoInclude();

            modelBuilder.Entity<Member>()
                .Navigation(m => m.LikesReceived)
                .AutoInclude();
            //modelBuilder.Entity<Member>()
            //    .HasMany(m => m.Likes)
            //    .WithOne(l => l.LikedBy)
            //    .HasForeignKey(l=>l.LikedById);


            //modelBuilder.Entity<Member>()
            //    .HasMany(m => m.Likes)
            //    .WithOne(l => l.Liked)
            //    .HasForeignKey(l => l.LikedId);

            //modelBuilder.Entity<Member>()
            //    .Navigation(m => m.Likes)
            //    .AutoInclude();

            //Match

            //modelBuilder.Entity<Member>()
            //    .HasMany(m => m.Matches)
            //    .WithOne(m=>m.FromProfile)
            //    .HasForeignKey(m=>m.FromProfileId);


            //modelBuilder.Entity<Member>()
            //    .HasMany(m => m.Matches)
            //    .WithOne(m => m.ToProfile)
            //    .HasForeignKey(m => m.ToProfileId);


            //modelBuilder.Entity<Member>()
            //    .Navigation(m => m.Matches)
            //    .AutoInclude();

            modelBuilder.Entity<Match>()
                .HasOne(m => m.FromProfile)
                .WithMany()
                .HasForeignKey(m => m.FromProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.ToProfile)
                .WithMany()
                .HasForeignKey(m => m.ToProfileId)
                .OnDelete(DeleteBehavior.Restrict);

        // Configuring relationships for Like
        //modelBuilder.Entity<Like>()
        //    .HasOne(l => l.LikedBy)
        //    .WithMany()
        //    .HasForeignKey(l => l.LikedById)
        //    .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<Like>()
        //    .HasOne(l => l.Liked)
        //    .WithMany()
        //    .HasForeignKey(l => l.LikedId)
        //    .OnDelete(DeleteBehavior.Restrict);

        // Configuring relationships for Report

        modelBuilder.Entity<Report>()
            .HasOne(r => r.ReportedBy)
            .WithMany()
            .HasForeignKey(r => r.ReportedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Report>()
            .HasOne(r => r.ReportedAccount)
            .WithMany()
            .HasForeignKey(r => r.ReportedAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Report>()
            .HasOne(r => r.AdminHandled)
            .WithMany()
            .HasForeignKey(r => r.AdminHandledId)
            .OnDelete(DeleteBehavior.SetNull);

            // Configuring relationships for Picture
            //modelBuilder.Entity<Picture>()
            //    .HasOne(p => p.Member)
            //    .WithMany(m => m.Pictures)
            //    .HasForeignKey(p => p.MemberId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Picture>()
            //    .Navigation(p => p.Member)
            //    .AutoInclude();
            //modelBuilder.Entity<Hobby>()
            //    .HasOne(p => p.Member)
            //    .WithMany(m => m.Hobby)
            //    .HasForeignKey(p => p.MemberId)
            //    .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
