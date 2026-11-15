using System.ComponentModel;
using Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IDepartmentRepository
{
    Task<bool> AddDepartment(Department department, CancellationToken cancellationToken);
    Task<bool> UpdateDepartment(Department department, CancellationToken cancellationToken);
    Task<bool> DeleteDepartment(int id, CancellationToken cancellationToken);
    Task<Department> GetDepartment(int id, CancellationToken cancellationToken);
    Task<List<Department>> GetDepartments(CancellationToken cancellationToken);
}
