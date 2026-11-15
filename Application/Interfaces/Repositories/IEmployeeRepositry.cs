using Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IEmployeeRepositry
{
    Task<bool> AddEmployee(Employee employee, CancellationToken cancellationToken);
    Task<bool> UpdateEmloyee(Employee employee, CancellationToken cancellationToken);
    Task<bool> DeleteEmployee(int id, CancellationToken cancellationToken);
    Task<Employee> GetEmployee(int id, CancellationToken cancellationToken);
    Task<List<Employee>> GetEmployees(CancellationToken cancellationToken);
    Task<bool> EmployeePatch(int id, CancellationToken cancellationToken);
}
