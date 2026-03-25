
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PresenceHub.Application.InterfaceService;
using PresenceHub.Application.Mapper;
//using PresenceHub.Application.Mapping;
using PresenceHub.Application.Service;
using PresenceHub.Domain.InterfaceRepo;
using PresenceHub.Infrastructure.DB_Context;
using PresenceHub.Infrastructure.Repositories;
using System.Reflection;
using System.Text;


namespace PresenceHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //cors
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()  // For development, allows all origins
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            //loger
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            //Add JWT services
            var key = builder.Configuration["Jwt:Key"];

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,

                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(key)
                    )
                };
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(HubMapping).Assembly);
            });
            builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            builder.Services.AddScoped<IAttendanceService, AttendanceService>();
            builder.Services.AddAutoMapper(x => x.AddProfile<AttendanceProfile>());
            //builder.Services.AddAutoMapper(x => x.AddProfile<HubMapping>());
            builder.Services.AddDbContext<HubDBcontext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IAuthRepo, AuthRepo>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();
            // Enable CORS
            app.UseCors();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
