using APIAss04.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<NorthWindContext>(options =>
{
    // pass the Connection String
    // using the builder.Configuration.GetConnectionString()
    // this will read the "ConnectionString" section of appsettings.json

    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));
});
// Add services to the container.

builder.Services.AddMemoryCache();


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
