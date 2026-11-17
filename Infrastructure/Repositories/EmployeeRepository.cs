using System.ComponentModel;
using System.Data.Common;
using System.Net.Http.Headers;
using Application.Interfaces.Repositories;
using Application.Response;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Infrastructure.Repositories;

public class EmployeeRepository(DataBase dataBase) : IEmployeeRepositry
{
    private readonly DataBase data = dataBase;
    public async Task<bool> AddEmployee(Employee employee, CancellationToken cancellationToken)
    {
        data.Employees.Add(employee);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteEmployee(int id, CancellationToken cancellationToken)
    {
        var employee = await data.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if(employee != null)
        {
            data.Employees.Remove(employee);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> EmployeePatch(int id, CancellationToken cancellationToken)
    {
        var empl = await data.Employees.FirstOrDefaultAsync(x => x.Id == id);
        return empl == null;
    }


    public async Task<Employee> GetEmployee(int id, CancellationToken cancellationToken)
    {
        var empl = await data.Employees.FirstOrDefaultAsync(x => x.Id == id);
        return empl??new();
    }

    public async Task<List<Employee>> GetEmployees(CancellationToken cancellationToken)
    {
        return await data.Employees.ToListAsync();
    }

    public async Task<bool> UpdateEmloyee(Employee employee, CancellationToken cancellationToken)
    {
        var empl = await data.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
        if(empl != null)
        {
            empl.FirstName = employee.FirstName;
            empl.LastName = employee.LastName;
            empl.Email = employee.Email;
            empl.Phone = employee.Phone;
            empl.HireDate = employee.HireDate;
            empl.Salary = employee.Salary;
            empl.IsActive = employee.IsActive;
            empl.DepartmentId = employee.DepartmentId;
            empl.PositionId = employee.PositionId;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

}
