using Application.DTOs.LeaveRequests;
using Application.Interfaces.Services;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class LeaveRequestController(ILeaveRequestServices leaveRequestServices) : ControllerBase
{
    private readonly ILeaveRequestServices service = leaveRequestServices;

    [HttpGet]
    public async Task<ApiResponse<List<ResponseLeaveRequestDto>>> GetRequests(CancellationToken cancellationToken)
    {
        return await service.GetRequests(cancellationToken);
    }
    [HttpPost]
    public async Task<ApiResponse<bool>> AddLeaveRequest(CreateLeaveRequestDto leaveRequest, CancellationToken cancellationToken)
    {
        return await service.AddLeaveRequest(leaveRequest, cancellationToken);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateLeaveRequest(int id, UpdateLeaveRequestDto leaveRequest, CancellationToken cancellationToken)
    {
        return await service.UpdateLeaveRequest(id, leaveRequest, cancellationToken);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteLeaveRequest(int id, CancellationToken cancellationToken)
    {
        return await service.DeleteLeaveRequest(id, cancellationToken);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<ResponseLeaveRequestDto>> GetRequest(int id, CancellationToken cancellationToken)
    {
        return await service.GetRequest(id, cancellationToken);
    }
}
