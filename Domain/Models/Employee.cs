using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(20)]
    [Phone]
    public string Phone { get; set; } = null!;
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public bool IsActive { get; set; }
    
    public int DepartmentId { get; set; }
    public int PositionId { get; set; }

    public Department? Department { get; set; }
    public Position? Position { get; set; }
}
