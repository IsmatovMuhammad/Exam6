namespace Application.DTOs.Departments;

public class CreateDepartmentDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
