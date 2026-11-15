using Domain.Enum;

namespace Application.DTOs.LeaveRequests;

public class UpdateLeaveRequestDto
{
    public int EmployeeId { get; set; }
    public LeaveType LeaveType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public StatusType Status { get; set; }
    public string Reason { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
