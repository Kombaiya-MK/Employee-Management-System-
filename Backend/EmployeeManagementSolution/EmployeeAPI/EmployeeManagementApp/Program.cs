using EmployeeManagementApp.Interfaces;
using EmployeeManagementApp.Mapper;
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
builder.Services.AddScoped<IRepo<Employee,String> , EmployeeRepository>();
builder.Services.AddScoped<IManageEmployee<Employee,EmployeeDTO>,ManageEmployeeService>();
builder.Services.AddScoped<IMapper<Employee, EmployeeDTO>, Mapper>();
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
