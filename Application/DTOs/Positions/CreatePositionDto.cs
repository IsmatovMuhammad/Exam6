namespace Application.DTOs.Positions;

public class CreatePositionDto
{
    public string Title { get; set; } = null!;
    public decimal MinSalary { get; set; }
    public decimal MaxSalary { get; set; }
}
