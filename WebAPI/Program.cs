using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Service;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Components.Infrastructure;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DataBase>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmetServices, DepartmentService>();

builder.Services.AddScoped<IEmployeeRepositry, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeServices, EmployeeService>();

builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IPositionServices, PositionService>();

builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
builder.Services.AddScoped<ILeaveRequestServices, LeaveRequestService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseMiddleware<RequestLoggingMiddleware>();

app.Run();