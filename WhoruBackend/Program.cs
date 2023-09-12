using Microsoft.EntityFrameworkCore;
using Serilog;
using WhoruBackend.Data;
using WhoruBackend.Repositorys;
using WhoruBackend.Repositorys.Implement;
using WhoruBackend.Services;
using WhoruBackend.Services.Implement;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Register Serilog
Log.Logger = new LoggerConfiguration().WriteTo.File("log/logs.txt", rollingInterval: RollingInterval.Day).CreateLogger();
builder.Host.UseSerilog();

// Add services to the container.
//services.AddDbContext<ApplicationDbContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));
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
