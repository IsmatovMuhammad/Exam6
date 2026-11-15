namespace Application.DTOs.Departments;

public class ResponseDepartmenDto
{
    public int id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
