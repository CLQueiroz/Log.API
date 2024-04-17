using Log.API;
using Log.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = (builder.Configuration.GetConnectionString("prod"));

builder.Services.AddDbContext<LogDB>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoints

app.MapPost("/SaveLog", async (LogModelView value, LogDB context) =>
{
    LogModelView newLog = new()
    {
        Description = value.Description,
        User_ID = value.User_ID,
        Company_ID = value.Company_ID,
        DTREPLIC = DateTime.Now,
    };

    context.Logs.Add(newLog);
    context.SaveChangesAsync().Wait();
});

app.Run();