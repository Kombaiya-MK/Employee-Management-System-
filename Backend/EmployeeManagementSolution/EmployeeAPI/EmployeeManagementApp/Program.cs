using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Models;
using EmployeeManagementApp.Models.Context;
using EmployeeManagementApp.Models.DTO;
using EmployeeManagementApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("empConn"));
}
    );
builder.Services.AddScoped<IRepo<Employee,string> , EmployeeRepository>();
builder.Services.AddScoped<IRepo<User, string>, UserRepository>();
builder.Services.AddScoped<IManageEmployee,ManageEmployeeService>();
builder.Services.AddScoped<IGenerateToken,GenerateTokenService>();
builder.Services.AddScoped<IGenerateUserID,GenerateUserIDService>();
builder.Services.AddScoped<IUpdateEmployee,UpdateEmployeeService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
