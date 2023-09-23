using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using WhoruBackend.Data;
using WhoruBackend.Repositorys;
using WhoruBackend.Repositorys.Implement;
using WhoruBackend.Services;
using WhoruBackend.Services.Implement;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Register Serilog
//Log.Logger = new LoggerConfiguration().WriteTo.File("log/logs.txt", rollingInterval: RollingInterval.Day).MinimumLevel.Debug().CreateLogger();
//builder.Host.UseSerilog();
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.AddSerilog(logger);
builder.Host.UseSerilog();
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
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,
            RequireSignedTokens = true
        };
    });

// Add services to the container.
services.AddDbContext<ApplicationDbContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));
services.AddControllers();

// Register Service
services.AddScoped<IUserService, UserService>();
services.AddScoped<ILogService, LogService>();

// Register Repository
services.AddScoped<IUserRepository, UserRepositoty>();
services.AddScoped<IlogRepository, LogRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
