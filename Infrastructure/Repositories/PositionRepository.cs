using System.Runtime.InteropServices;
using Application.Interfaces.Repositories;
using Dapper;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class PositionRepository(DataBase dataBase) : IPositionRepository
{
    private readonly DataBase data = dataBase;
    public async Task<bool> AddPosition(Position position, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "insert into positions (title, minsalary, maxsalary)values(@title, @minsalary, @maxsalary)";
        var command = new CommandDefinition(
            query,
            position,
            cancellationToken: cancellationToken
        );
        var res = await conn.ExecuteAsync(command);
        return res > 0;
    }

    public async Task<Position> GetPosition(int id, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "select * from positions where id = @id";
        var command = new CommandDefinition(
            query,
            new{id},
            cancellationToken: cancellationToken
        );
        var res = await conn.QuerySingleOrDefaultAsync<Position>(command);
        return res!;
    }

    public async Task<List<Position>> GetPositions(CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "select * from positions";
        var command = new CommandDefinition(
            query,
            cancellationToken: cancellationToken
        );
        var res = await conn.QueryAsync<Position>(command);
        return res.ToList();
    }
}
