using Domain.Enum;

namespace Application.DTOs.LeaveRequests;

public class ResponseLeaveRequestDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public LeaveType LeaveType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public StatusType Status { get; set; }
    public string Reason { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
