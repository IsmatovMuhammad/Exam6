using System.Diagnostics.CodeAnalysis;
using Application.Interfaces.Repositories;
using Dapper;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class LeaveRequestRepository(DataBase dataBase) : ILeaveRequestRepository
{
    private readonly DataBase data = dataBase;
    public async Task<bool> AddLeaveRequest(LeaveRequest leaveRequest, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = @"insert into leaverequests(employeeid, leavetype, startdate, enddate, status, reason, createdat)values
        (@employeeid, @leavetype, @startdate, @enddate, @status, @reason, @createdat)";
        var command = new CommandDefinition(
            query,
            leaveRequest,
            cancellationToken: cancellationToken
        );
        var res = await conn.ExecuteAsync(command);
        return res > 0;
    }

    public async Task<bool> DeleteLeaveRequest(int id, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = @"delete from leaverequests where id = @id";
        var command = new CommandDefinition(
            query,
            new{id},
            cancellationToken: cancellationToken
        );
        var res = await conn.ExecuteAsync(command);
        return res > 0;
    }

    public async Task<LeaveRequest> GetRequest(int id, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "select * from leaverequests where id = @id";
        var command = new CommandDefinition(
            query,
            new{id},
            cancellationToken: cancellationToken
        );
        var res = await conn.QuerySingleOrDefaultAsync<LeaveRequest>(command);
        return res!;
    }

    public async Task<List<LeaveRequest>> GetRequests(CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = "select * from leaverequests";
        var command = new CommandDefinition(
            query,
            cancellationToken: cancellationToken
        );
        var res = await conn.QueryAsync<LeaveRequest>(command);
        return res.ToList();
    }

    public async Task<bool> UpdateLeaveRequest(LeaveRequest leaveRequest, CancellationToken cancellationToken)
    {
        await using var conn = data.Connection();
        await conn.OpenAsync(cancellationToken);
        var query = @"update leaverequests set employeeid = @employeeid, leavetype = @leavetype, startdate = @startdate, 
        enddate = @enddate,  = @status, reason = @reason, createdat = @createdat where id = @id";
        var command = new CommandDefinition(
            query,
            leaveRequest,
            cancellationToken: cancellationToken
        );
        var res = await conn.ExecuteAsync(command);
        return res > 0;
    }

}
