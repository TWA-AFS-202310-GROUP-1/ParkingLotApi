using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ParkingLotApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ArgumentExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
builder.Services.AddSingleton(mongoClient);
builder.Services.AddScoped<IParkinglotRepository>(provider => new ParkinglotRepository(mongoClient));
builder.Services.AddScoped<ParkringlotService>();

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

public partial class  Program 
{
    /*public static IConfiguration Configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory()) 
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
*/
}