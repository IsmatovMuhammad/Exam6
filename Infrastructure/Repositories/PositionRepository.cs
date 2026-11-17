using System.Runtime.InteropServices;
using Application.Interfaces.Repositories;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PositionRepository(DataBase dataBase) : IPositionRepository
{
    private readonly DataBase data = dataBase;
    public async Task<bool> AddPosition(Position position, CancellationToken cancellationToken)
    {
        data.Positions.Add(position);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Position> GetPosition(int id, CancellationToken cancellationToken)
    {
        var position = await data.Positions.FirstOrDefaultAsync(x => x.Id == id);
        return position??new();
    }

    public async Task<List<Position>> GetPositions(CancellationToken cancellationToken)
    {
        return await data.Positions.ToListAsync();
    }
}
