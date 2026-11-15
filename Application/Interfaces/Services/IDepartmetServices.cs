using Application.DTOs.Departments;
using Application.Response;
using Domain.Models;

namespace Application.Interfaces.Services;

public interface IDepartmetServices
{
    Task<ApiResponse<bool>> AddDepartment(CreateDepartmentDto department, CancellationToken cancellationToken);
    Task<ApiResponse<bool>> UpdateDepartment(int id, UpdateDepartmentDto department, CancellationToken cancellationToken);
    Task<ApiResponse<bool>> DeleteDepartment(int id, CancellationToken cancellationToken);
    Task<ApiResponse<ResponseDepartmenDto>> GetDepartment(int id, CancellationToken cancellationToken);
    Task<ApiResponse<List<ResponseDepartmenDto>>> GetDepartments(CancellationToken cancellationToken);
}
