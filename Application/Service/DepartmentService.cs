using System.Diagnostics.CodeAnalysis;
using System.Net;
using Application.DTOs.Departments;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Response;
using Domain.Models;

namespace Application.Service;

public class DepartmentService(
    IDepartmentRepository departmentRepository) : IDepartmetServices
{
    private readonly IDepartmentRepository repository = departmentRepository;
    public async Task<ApiResponse<bool>> AddDepartment(CreateDepartmentDto department, CancellationToken cancellationToken)
    {
        Department dp = new()
        {
            Name = department.Name,
            Description = department.Description,
            CreatedAt = department.CreatedAt
        };
        var res = await repository.AddDepartment(dp, cancellationToken);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Department added !", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Department not added !");
    }
    public async Task<ApiResponse<bool>> DeleteDepartment(int id, CancellationToken cancellationToken)
    {
        var res = await repository.DeleteDepartment(id, cancellationToken);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Department deleted !", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Department not deleted !");
    }

    public async Task<ApiResponse<ResponseDepartmenDto>> GetDepartment(int id, CancellationToken cancellationToken)
    {
        var dp = await repository.GetDepartment(id, cancellationToken);
        if(dp == null)
        {
            return new ApiResponse<ResponseDepartmenDto>(HttpStatusCode.NotFound, "Not found !");
        }
        var department = new ResponseDepartmenDto
        {
            id = dp.id,
            Name = dp.Name,
            Description = dp.Description,
            CreatedAt = dp.CreatedAt
        };
        return new ApiResponse<ResponseDepartmenDto>(HttpStatusCode.OK, "Department by id", department);
    }

    public async Task<ApiResponse<List<ResponseDepartmenDto>>> GetDepartments(CancellationToken cancellationToken)
    {
        var dp = await repository.GetDepartments(cancellationToken);
        var department = dp.Select(s => new ResponseDepartmenDto
        {
            id = s.id,
            Name = s.Name,
            Description = s.Description,
            CreatedAt = s.CreatedAt
        }).ToList();
        return new ApiResponse<List<ResponseDepartmenDto>>(HttpStatusCode.OK, "List of Department", department);
    }

    public async Task<ApiResponse<bool>> UpdateDepartment(int id, UpdateDepartmentDto department, CancellationToken cancellationToken)
    {
        Department dp = new()
        {
            id = id,
            Name = department.Name,
            Description = department.Description,
            CreatedAt = department.CreatedAt
        };
        var res = await repository.UpdateDepartment(dp, cancellationToken);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Department updated !", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Department not updated !");
    }
}
