using Application.DTOs.Employees;
using Application.Interfaces.Services;
using Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class EmployeeController(
    IEmployeeServices employeeServices) : ControllerBase
{
    private readonly IEmployeeServices services = employeeServices;

    [HttpGet]
    public async Task<ApiResponse<List<ResponseEmployeeDto>>> GetEmployees(CancellationToken cancellationToken)
    {
        return await services.GetEmployees(cancellationToken);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddEmployee(CreateEmployeeDto employee, CancellationToken cancellationToken)
    {
        return await services.AddEmployee(employee, cancellationToken);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateEmployee(int id, UpdateEmployeeDto employee, CancellationToken cancellationToken)
    {
        return await services.UpdateEmployee(id, employee, cancellationToken);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteEmployee(int id, CancellationToken cancellationToken)
    {
        return await services.DeleteEmployee(id, cancellationToken);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<ResponseEmployeeDto>> GetEmployee(int id, CancellationToken cancellationToken)
    {
        return await services.GetEmployee(id, cancellationToken);
    }

    [HttpPatch("{id:int}")]
    public async Task<ApiResponse<bool>> EmployeePatch(int id, CancellationToken cancellationToken)
    {
        return await services.EmployeePatch(id, cancellationToken);
    }
}
