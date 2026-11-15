using Application.Interfaces.Repositories;
using Dapper;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class DepartmentRepository(DataBase dataBase) : IDepartmentRepository
{
    private readonly DataBase data = dataBase;
    public async Task<bool> AddDepartment(Department department, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "insert into departments(name, description, createdat)values(@name, @description, @createdat)";
        var command = new CommandDefinition(
            query,
            department,
            cancellationToken: cancellationToken);
        var res = await conn.ExecuteAsync(command);
        return res > 0;
    }

    public async Task<bool> DeleteDepartment(int id, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "delete from departments where id = @id";
        var command = new CommandDefinition(
            query,
            new{id},
            cancellationToken: cancellationToken
        );
        var res = await conn.ExecuteAsync(command);
        return res > 0;
    }

    public async Task<Department> GetDepartment(int id, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "select * from departments where id = @id";
        var command = new CommandDefinition(
            query,
            new{id},
            cancellationToken: cancellationToken);
        var res = await conn.QuerySingleOrDefaultAsync<Department>(command);
        return res!;
    }

    public async Task<List<Department>> GetDepartments(CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "select * from departments";
        var command = new CommandDefinition(
            query,
            cancellationToken: cancellationToken);
        var res = await conn.QueryAsync<Department>(command);
        return res.ToList();
    }

    public async Task<bool> UpdateDepartment(Department department, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "update departments set name = @name, description = @description, createdat = @createdat where id = @id";
        var command = new CommandDefinition(
            query,
            department,
            cancellationToken: cancellationToken);
        var res = await conn.ExecuteAsync(command);
        return res > 0;
    }

}
