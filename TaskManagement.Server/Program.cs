using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Interfaces;
using TaskManagement.Infrastructure.Context;
using TaskManagement.Infrastructure.Repositories;
using Test.Application.ExceptionHandler;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IEmployeeTaskRepository, EmployeeTaskRepository>();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();