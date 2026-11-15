using System.ComponentModel;
using System.Net.Http.Headers;
using Application.Interfaces.Repositories;
using Application.Response;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.VisualBasic;

namespace Infrastructure.Repositories;

public class EmployeeRepository(DataBase dataBase) : IEmployeeRepositry
{
    private readonly DataBase data = dataBase;
    public async Task<bool> AddEmployee(Employee employee, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = @"insert into employees(firstname, lastname, email, phone, hiredate, salary, isactive, departmentid, positionid)values
        (@firstname, @lastname, @email, @phone, @hiredate, @salary, @isactive, @departmentid, @positionid)";
        var command = new CommandDefinition(
            query,
            employee,
            cancellationToken: cancellationToken
        );
        var res = await conn.ExecuteAsync(command);
        return res > 0;
    }

    public async Task<bool> DeleteEmployee(int id, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "delete from employees where id = @id";
        var command = new CommandDefinition(
            query,
            new{id},
            cancellationToken: cancellationToken);
        var res = await conn.ExecuteAsync(command);
        return res > 0;
    }

    public async Task<bool> EmployeePatch(int id, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "update employees set isactive = false where id = @id";
        var command = new CommandDefinition(
            query,
            new{id},
            cancellationToken: cancellationToken);
        var res = await conn.ExecuteAsync(command);
        return res > 0;
    }


    public async Task<Employee> GetEmployee(int id, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "select * from employees where id = @id";
        var command = new CommandDefinition(
            query,
            new{id},
            cancellationToken: cancellationToken
        );
        var res = await conn.QuerySingleOrDefaultAsync<Employee>(command);
        return res!;
    }

    public async Task<List<Employee>> GetEmployees(CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "select * from employees where id = @id";
        var command = new CommandDefinition(
            query,
            cancellationToken: cancellationToken
        );
        var res = await conn.QueryAsync<Employee>(command);
        return res.ToList();
    }

    public async Task<bool> UpdateEmloyee(Employee employee, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = @"update employees set firstname = @firstname, lastname = @lastname, email = @email, 
        phone = @phone, hiredate = @hiredate, isactive = @isactive, departmentid = @departmentid,
        positionid = @positionid where id = @id";
        var command = new CommandDefinition(
            query,
            employee,
            cancellationToken: cancellationToken
        );
        var res = await conn.ExecuteAsync(command);
        return res > 0;
    }

}
