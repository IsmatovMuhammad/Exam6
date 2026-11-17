using System.Diagnostics.CodeAnalysis;
using Application.Interfaces.Repositories;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Infrastructure.Repositories;

public class LeaveRequestRepository(DataBase dataBase) : ILeaveRequestRepository
{
    private readonly DataBase data = dataBase;
    public async Task<bool> AddLeaveRequest(LeaveRequest leaveRequest, CancellationToken cancellationToken)
    {
        data.LeaveRequests.Add(leaveRequest);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteLeaveRequest(int id, CancellationToken cancellationToken)
    {
        var leave = await data.LeaveRequests.FirstOrDefaultAsync(x => x.Id == id);
        if(leave != null)
        {
            data.LeaveRequests.Remove(leave);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<LeaveRequest> GetRequest(int id, CancellationToken cancellationToken)
    {
        var leave = await data.LeaveRequests.FirstOrDefaultAsync(x => x.Id == id);
        return leave??new();
    }

    public async Task<List<LeaveRequest>> GetRequests(CancellationToken cancellationToken)
    {
        return await data.LeaveRequests.ToListAsync();
    }

    public async Task<bool> UpdateLeaveRequest(LeaveRequest leaveRequest, CancellationToken cancellationToken)
    {
        var leave = await data.LeaveRequests.FirstOrDefaultAsync(x => x.Id == leaveRequest.Id);
        if(leave != null)
        {
            leave.EmployeeId = leaveRequest.EmployeeId;
            leave.LeaveType = leaveRequest.LeaveType;
            leave.StartDate = leaveRequest.StartDate;
            leave.EndDate = leaveRequest.EndDate;
            leave.Status = leaveRequest.Status;
            leave.Reason = leaveRequest.Reason;
            leave.CreatedAt = leaveRequest.CreatedAt;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

}
