using ParkingLotApi.Exceptions;
using ParkingLotApi.Filters;
using ParkingLotApi.Models;
using ParkingLotApi.repositories;
using ParkingLotApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<InvaliCapacityExceptionFilter>();
    options.Filters.Add<InvaliIdExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ParkingLotsService>();
builder.Services.AddSingleton<IParkingLotRepository, ParkingLotRepository>();
builder.Services.Configure<ParkingLotDatabaseSettings>(
    builder.Configuration.GetSection("ParkingLotDatabase"));


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

public partial class Program { }
