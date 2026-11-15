using Application.DTOs.Departments;
using Application.Interfaces.Services;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class DepartmentController(
    IDepartmetServices services) : ControllerBase
{
    private readonly IDepartmetServices _services = services;
    
    [HttpGet]
    public async Task<ApiResponse<List<ResponseDepartmenDto>>> GetDepartments(CancellationToken cancellationToken)
    {
        return await _services.GetDepartments(cancellationToken);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddDepartment(CreateDepartmentDto department, CancellationToken cancellationToken)
    {
        return await _services.AddDepartment(department, cancellationToken);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateDepartment(int id, UpdateDepartmentDto department, CancellationToken cancellationToken)
    {
        return await _services.UpdateDepartment(id, department, cancellationToken);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteDepartment(int id, CancellationToken cancellationToken)
    {
        return await _services.DeleteDepartment(id, cancellationToken);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<ResponseDepartmenDto>> GetDepartment(int id, CancellationToken cancellationToken)
    {
        return await _services.GetDepartment(id, cancellationToken);
    }
}
