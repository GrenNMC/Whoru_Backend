﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using System.Text.Json.Serialization;
using WhoruBackend.Data;
using WhoruBackend.Hubs;
using WhoruBackend.Repositorys;
using WhoruBackend.Repositorys.Implement;
using WhoruBackend.Services;
using WhoruBackend.Services.Implement;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add JwtAuth
var key = configuration["Jwt:Key"];
//mã hóa key
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
//Add Authentication Bearer
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //có kiểm tra Issuer (default true)
            ValidateIssuer = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            //có kiểm tra Audience (default true)
            ValidateAudience = true,
            ValidAudience = configuration["Jwt:Audience"],
            //Đảm bảo phải có thời gian hết hạn trong token

            RequireExpirationTime = true,
            ValidateLifetime = true,
            //Chỉ ra key sử dụng trong token
            IssuerSigningKey = signingKey,
            RequireSignedTokens = true
        };
    });

// Add services to the container.
services.AddDbContext<ApplicationDbContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("WhoruDbConnectionString")));

services.AddControllers().AddJsonOptions(s => s.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Register Service
services.AddScoped<IUserService, UserService>();
services.AddScoped<ILogService, LogService>();
services.AddScoped<IFeedService, FeedService>();
services.AddScoped<IUserInfoService, UserInfoService>();
services.AddScoped<IFollowService, FollowService>();
services.AddScoped<ILikeService, LikeService>();
services.AddScoped<IShareService, ShareService>();
services.AddScoped<ICommentService, CommentService>();
services.AddScoped<IChatService, ChatService>();
services.AddScoped<INotificationService, NotificationService>();
services.AddScoped<IStoryService, StoryService>();
services.AddScoped<ILocationService, LocationService>();
// Register Repository
services.AddScoped<IUserRepository, UserRepositoty>();
services.AddScoped<IlogRepository, LogRepository>();
services.AddScoped<IRoleRepository, RoleRepository>();
services.AddScoped<IFeedRepository, FeedRepository>();
services.AddScoped<IUserInfoRepository, UserInfoRepository>();
services.AddScoped<IFollowRepository, FollowRepository>();
services.AddScoped<ILikeRepository, LikeRepository>();
services.AddScoped<IShareRepository, ShareRepository>();
services.AddScoped<ICommentRepository, CommentRepository>();
services.AddScoped<IChatRepository, ChatRepository>();
services.AddScoped<INotificationRepository, NotificationRepository>();
services.AddScoped<IStoryRepository, StoryRepository>();
services.AddScoped<ILocationRepository, LocationRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddHttpContextAccessor();
services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var allowPolicy = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowPolicy,
        configure => configure.WithOrigins("https://localhost:7175")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
    );
});

services.AddSignalR(hubOptions => { 
    hubOptions.EnableDetailedErrors = true; 
    hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(10); 
    hubOptions.HandshakeTimeout = TimeSpan.FromSeconds(5); 
});
//Register Serilog
//Log.Logger = new LoggerConfiguration().WriteTo.File("Logs/logs.txt", rollingInterval: RollingInterval.Day).CreateLogger();
//builder.Host.UseSerilog();
//var logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(configuration)
//    .Enrich.FromLogContext()
//    .CreateLogger();
//builder.Logging.AddSerilog(logger);


builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.File(path: "Logs/log-.txt",
    rollingInterval: RollingInterval.Day,
    rollOnFileSizeLimit: true
    ).MinimumLevel.Information();
});



var app = builder.Build();
//app.UseCors(allowPolicy);
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseSerilogRequestLogging();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(allowPolicy);
app.MapControllers();
//app.MapHub<ChatHub>("/chatHub");
//app.MapHub<NotificationHub>("/notificationHub");
//app.MapHub<LocationHub>("/locationnHub");
app.MapHub<AppHubs>("/appHub");
app.Run();
