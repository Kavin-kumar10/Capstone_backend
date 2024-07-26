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
                  Email = "john.doe@example.com",
                  Role = RoleEnum.User,
                  Membership = Membershipenum.Premium,
                  Gender = "Male",
                  Relation = "Single",
                  PersonName = "John Doe",
                  About = "A software developer with a passion for coding.",
                  Height = 180,
                  MotherTongue = "English",
                  Caste = "General",
                  Religion = "Christian",
                  MaritalStatus = "Single",
                  Disabilities = "None",
                  AllowLocation = true,
                  IsVerified = true,
                  ProfilePic = "https://example.com/profilepic.jpg",
              },
               new Member
               {
                   MemberId = 2,
                   Name = "Kavin",
                   Email = "kavin.doe@example.com",
                   Role = RoleEnum.User,
                   Membership = Membershipenum.Premium,
                   Gender = "Male",
                   Relation = "Single",
                   PersonName = "John Doe",
                   About = "A software developer with a passion for coding.",
                   Height = 180,
                   MotherTongue = "English",
                   Caste = "General",
                   Religion = "Christian",
                   MaritalStatus = "Single",
                   Disabilities = "None",
                   AllowLocation = true,
                   IsVerified = true,
                   ProfilePic = "https://example.com/profilepic.jpg",
                   // Add default values for relationships if applicable
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
                PersonalDetailsId = 1
            },
            new Hobby
            {
                HobbyId = 2,
                HobbyName = "Reading",
                PersonalDetailsId = 1
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

        modelBuilder.Entity<PersonalDetails>()
            .HasMany(m => m.Hobby)
            .WithOne(h => h.PersonalDetails)
            .HasForeignKey(h => h.PersonalDetailsId);

        modelBuilder.Entity<PersonalDetails>()
            .Navigation(m => m.Hobby)
            .AutoInclude();

        //Likes

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
        modelBuilder.Entity<Like>()
            .HasOne(l => l.LikedBy)
            .WithMany()
            .HasForeignKey(l => l.LikedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Like>()
            .HasOne(l => l.Liked)
            .WithMany()
            .HasForeignKey(l => l.LikedId)
            .OnDelete(DeleteBehavior.Restrict);

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

        //base.OnModelCreating(modelBuilder);
        }
    }
}
