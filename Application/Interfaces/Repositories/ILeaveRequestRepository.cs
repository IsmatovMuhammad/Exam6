using Domain.Models;

namespace Application.Interfaces.Repositories;

public interface ILeaveRequestRepository
{
    Task<bool> AddLeaveRequest(LeaveRequest leaveRequest, CancellationToken cancellationToken);
    Task<bool> UpdateLeaveRequest(LeaveRequest leaveRequest, CancellationToken cancellationToken);
    Task<bool> DeleteLeaveRequest(int id, CancellationToken cancellationToken);
    Task<LeaveRequest> GetRequest(int id, CancellationToken cancellationToken);
    Task<List<LeaveRequest>> GetRequests(CancellationToken cancellationToken);
}
