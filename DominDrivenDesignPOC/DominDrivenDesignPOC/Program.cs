using DDD.Infrastucture.Registrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddEmployeeManagementServices();
// Use the application services
//var employeeAppService = builder.Services.BuildServiceProvider().GetRequiredService<IEmployeeAppService>();

//// Perform actions using the application services
//employeeAppService.HireEmployee("John", "Doe", 1);
//employeeAppService.UpdateSalary(1, 60000);

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
