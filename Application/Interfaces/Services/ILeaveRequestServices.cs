using Application.DTOs.LeaveRequests;
using Application.Response;
using Domain.Models;

namespace Application.Interfaces.Services;

public interface ILeaveRequestServices
{
    Task<ApiResponse<bool>> AddLeaveRequest(CreateLeaveRequestDto leaveRequest, CancellationToken cancellationToken);
    Task<ApiResponse<bool>> UpdateLeaveRequest(int id, UpdateLeaveRequestDto leaveRequest, CancellationToken cancellationToken);
    Task<ApiResponse<bool>> DeleteLeaveRequest(int id, CancellationToken cancellationToken);
    Task<ApiResponse<ResponseLeaveRequestDto>> GetRequest(int id, CancellationToken cancellationToken);
    Task<ApiResponse<List<ResponseLeaveRequestDto>>> GetRequests(CancellationToken cancellationToken);
}
