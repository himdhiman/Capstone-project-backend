using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Mappers;
using OnlineBank.API.Models;
using OnlineBank.API.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.Configure<MongoCollections>(builder.Configuration.GetSection("MongoCollections"));

builder.Services.AddSingleton<MongoContext>();
builder.Services.AddSingleton<IDataService, DataService>();

builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile(provider.GetService<IDataService>()));
}).CreateMapper());



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowedOrigins = "_myAllowedOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowedOrigins,
    builder =>
        {
            builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        });
});

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

app.UseCors(MyAllowedOrigins);

app.Run();
