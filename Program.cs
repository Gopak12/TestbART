using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestbART.Data;
using TestbART.Profiles;
using TestbART.Services;
using TestbART.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TestbARTContext>(options =>
    options.UseInMemoryDatabase("InMemory"));

builder.Services.AddTransient<IIncidentService, IncidentService>();
// Add services to the container.

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new IncidentProfile());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
