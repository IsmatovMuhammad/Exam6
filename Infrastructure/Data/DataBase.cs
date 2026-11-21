using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using Domain.Models;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure.Data;

public class DataBase(DbContextOptions<DataBase> options) : DbContext(options)
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<Position> Positions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new LeaveRequestConfiguration());
        modelBuilder.ApplyConfiguration(new PositionConfiguration());
    }

}
