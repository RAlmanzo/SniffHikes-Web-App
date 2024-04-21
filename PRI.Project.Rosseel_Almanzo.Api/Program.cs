using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PRI.Project.Rosseel_Almanzo.Api.Services;
using PRI.Project.Rosseel_Almanzo.Api.Services.Interfaces;
using PRI.Project.Rosseel_Almanzo.Core.Entities;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Repositories;
using PRI.Project.Rosseel_Almanzo.Core.Interfaces.Services;
using PRI.Project.Rosseel_Almanzo.Core.Services;
using PRI.Project.Rosseel_Almanzo.Infrastructure.Data;
using PRI.Project.Rosseel_Almanzo.Infrastructure.Repositories;
using System.Security.Claims;
using System.Text;

namespace PRI.Project.Rosseel_Almanzo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<SniffHikesDbContext>
                (options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("SniffHikestDb")));
            //register identity
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                //TODO moet nog aangepast worden na testing!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
            }).AddEntityFrameworkStores<SniffHikesDbContext>()
            .AddDefaultTokenProviders();

            //configure jwt bearer token
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidAudience = builder.Configuration["JWTConfiguration:Audience"],
                ValidIssuer = builder.Configuration["JWTConfiguration:Issuer"],
                IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfiguration:SecretKey"]))
            });

            //Add authorisation policies          
            builder.Services.AddAuthorization(options =>
            {
                //admin claim
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Admin");
                });
                //userclaim
                options.AddPolicy("User", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "User");
                });
                //options.AddPolicy("User", policy =>
                //{
                //    //policy.RequireClaim(ClaimTypes.Role, "User");
                //    policy.RequireAssertion(contex =>
                //    {
                //        if (contex.User.HasClaim(ClaimTypes.Role, "Admin") || contex.User.HasClaim(ClaimTypes.Role, "User"))
                //        {
                //            return true;
                //        }
                //        return false;
                //    });
                //});
                //options.AddPolicy("AdultOnly", policy =>
                //{
                //    policy.RequireAssertion(context =>
                //    {
                //        //check if claims are present
                //        if (context.User.Claims.Count() != 0)
                //        {
                //            //get de dateofbirth
                //            var claimValue = context.User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.DateOfBirth)).Value;
                //            // parse the date
                //            var dateOfBirth = DateTime.Parse(claimValue);
                //            //calculate age
                //            if (DateTime.Now.Year - dateOfBirth.Year >= 18)
                //            {
                //                return true;
                //            }
                //            return false;
                //        }
                //        return false;
                //    });
                //});
            });

            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<IEventUserRepository, EventUserRepository>();
            builder.Services.AddScoped<IImageRepository, ImageRepository>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<IRouteRepository, RouteRepository>();
            builder.Services.AddScoped<IRouteService, RouteService>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IDogRepository, DogRepository>();
            builder.Services.AddScoped<IDogService, DogService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
