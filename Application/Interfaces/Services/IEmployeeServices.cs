using Application.DTOs.Employees;
using Application.Response;
using Domain.Models;

namespace Application.Interfaces.Services;

public interface IEmployeeServices
{
    Task<ApiResponse<bool>> AddEmployee(CreateEmployeeDto employee, CancellationToken cancellationToken);
    Task<ApiResponse<bool>> UpdateEmployee(int id, UpdateEmployeeDto employee, CancellationToken cancellationToken);
    Task<ApiResponse<bool>> DeleteEmployee(int id, CancellationToken cancellationToken);
    Task<ApiResponse<ResponseEmployeeDto>> GetEmployee(int id, CancellationToken cancellationToken);
    Task<ApiResponse<List<ResponseEmployeeDto>>> GetEmployees(CancellationToken cancellationToken);
    Task<ApiResponse<bool>> EmployeePatch(int id, CancellationToken cancellationToken);
}