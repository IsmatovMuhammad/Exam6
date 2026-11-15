using System.Net;
using Application.DTOs.LeaveRequests;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Response;
using Domain.Models;

namespace Application.Service;

public class LeaveRequestService(ILeaveRequestRepository leaveRequestRepository) : ILeaveRequestServices
{
    private readonly ILeaveRequestRepository repository = leaveRequestRepository;
    public async Task<ApiResponse<bool>> AddLeaveRequest(CreateLeaveRequestDto leaveRequest, CancellationToken cancellationToken)
    {
        LeaveRequest leave = new LeaveRequest()
        {
            EmployeeId = leaveRequest.EmployeeId,
            LeaveType = leaveRequest.LeaveType,
            StartDate = leaveRequest.StartDate,
            EndDate = leaveRequest.EndDate,
            Status = leaveRequest.Status,
            Reason = leaveRequest.Reason,
            CreatedAt = leaveRequest.CreatedAt
        };
        var res = await repository.AddLeaveRequest(leave, cancellationToken);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "LeaveRequest added ! ", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "leaveRequest not added !");
    }

    public async Task<ApiResponse<bool>> DeleteLeaveRequest(int id, CancellationToken cancellationToken)
    {
        var res = await repository.DeleteLeaveRequest(id, cancellationToken);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "leaveRequest deleted ! ", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "LeaveRequest not deleted ! ");
    }
    public async Task<ApiResponse<ResponseLeaveRequestDto>> GetRequest(int id, CancellationToken cancellationToken)
    {
        var res = await repository.GetRequest(id, cancellationToken);
        if(res == null)
        {
            return new ApiResponse<ResponseLeaveRequestDto>(HttpStatusCode.NotFound, "Not found !");
        }
        var le = new ResponseLeaveRequestDto
        {
            Id = res.Id,
            EmployeeId = res.EmployeeId,
            LeaveType = res.LeaveType,
            StartDate = res.StartDate,
            EndDate = res.EndDate,
            Status = res.Status,
            Reason = res.Reason,
            CreatedAt = res.CreatedAt
        };
        return new ApiResponse<ResponseLeaveRequestDto>(HttpStatusCode.OK, "List of LeaveRequest", le);
    }


    public async Task<ApiResponse<List<ResponseLeaveRequestDto>>> GetRequests(CancellationToken cancellationToken)
    {
        var res = await repository.GetRequests(cancellationToken);
        var le = res.Select(s => new ResponseLeaveRequestDto
        {
            Id = s.Id,
            EmployeeId = s.EmployeeId,
            LeaveType = s.LeaveType,
            StartDate = s.StartDate,
            Status = s.Status,
            CreatedAt = s.CreatedAt
        }).ToList();
        return new ApiResponse<List<ResponseLeaveRequestDto>>(HttpStatusCode.OK, "List of LeaveRequest", le);
    }

    public async Task<ApiResponse<bool>> UpdateLeaveRequest(int id, UpdateLeaveRequestDto leaveRequest, CancellationToken cancellationToken)
    {
        LeaveRequest leave = new LeaveRequest()
        {
            EmployeeId = leaveRequest.EmployeeId,
            LeaveType = leaveRequest.LeaveType,
            StartDate = leaveRequest.StartDate,
            EndDate = leaveRequest.EndDate,
            Status = leaveRequest.Status,
            Reason = leaveRequest.Reason,
            CreatedAt = leaveRequest.CreatedAt
        };
        var res = await repository.UpdateLeaveRequest(leave, cancellationToken);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "LeaveRequest updated ! ", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "leaveRequest not updated !");
    }

}
