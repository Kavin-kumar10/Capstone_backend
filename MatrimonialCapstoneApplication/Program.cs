using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using MatrimonialCapstoneApplication.Models;
using MatrimonialCapstoneApplication.Repositories;
using MatrimonialCapstoneApplication.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace MatrimonialCapstoneApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            #region Bearer
            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
            //Debug.WriteLine(builder.Configuration["TokenKey:JWT"]);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"]))
                    };

                });

            #endregion

            builder.Services.AddDbContext<MatrimonialContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultString")));
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IActivateServices, ActivateServices>();

            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserServices, UserServices>();

            builder.Services.AddScoped<IRepository<int, Picture>, PictureRepository>();
            builder.Services.AddScoped<IServices<int, Picture>, PictureServices>();
            builder.Services.AddScoped<IPictureServices, PictureServices>();

            builder.Services.AddScoped<IRepository<int, Member>, MemberRepository>();
            builder.Services.AddScoped<IMemberRepository, MemberRepository>();
            builder.Services.AddScoped<IServices<int,Member>, MemberServices>();


            builder.Services.AddScoped<IRepository<int, Match>, MatchRepository>();
            builder.Services.AddScoped<IMatchesRepository,MatchRepository>();
            builder.Services.AddScoped<IServices<int, Match>, MatchServices>();
            builder.Services.AddScoped<IMatchesServices, MatchServices>();  

            builder.Services.AddScoped<IRepository<int, Like>, LikeRepository>();
            builder.Services.AddScoped<IServices<int, Like>, LikeServices>();
            builder.Services.AddScoped<ILikeServices, LikeServices>();
            builder.Services.AddScoped<ILikeRepository, LikeRepository>();

            builder.Services.AddScoped<IRepository<int, Locate>, LocateRepository>();
            builder.Services.AddScoped<IServices<int, Locate>, LocateService>();

            builder.Services.AddScoped<IRepository<int, Verification>, VerificationRepository>();
            builder.Services.AddScoped<IServices<int, Verification>, VerificationServices>();

            builder.Services.AddScoped<IRepository<int, Report>, ReportRepository>();
            builder.Services.AddScoped<IServices<int, Report>, ReportServices>();

            builder.Services.AddScoped<IRepository<int, PersonalDetails>, PersonalDetailsRepository>();
            builder.Services.AddScoped<IServices<int, PersonalDetails>, PersonalDetailsServices>();
            builder.Services.AddScoped<IPersonalDetailServices,PersonalDetailsServices>();

            builder.Services.AddScoped<IRepository<int, DailyLog>,DailyLogsRepository>();
            builder.Services.AddScoped<IDailyLogServices,DailyLogServices>();

            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
            {
                build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("corspolicy");


            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
