using System.Net;
using Application.DTOs.Employees;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Response;
using Domain.Models;

namespace Application.Service;

public class EmployeeService(
    IEmployeeRepositry employeeRepositry) : IEmployeeServices
{
    private IEmployeeRepositry repositry = employeeRepositry;

    public async Task<ApiResponse<bool>> AddEmployee(CreateEmployeeDto employee, CancellationToken cancellationToken)
    {
        Employee em = new()
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Phone = employee.Phone,
            HireDate = employee.HireDate,
            Salary = employee.Salary,
            IsActive = employee.IsActive,
            DepartmentId = employee.DepartmentId,
            PositionId = employee.PositionId
        };
        var res = await repositry.AddEmployee(em, cancellationToken);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Employee added ! ", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Employee not added !");
    }
    public async Task<ApiResponse<bool>> UpdateEmployee(int id, UpdateEmployeeDto employee, CancellationToken cancellationToken)
    {
        Employee em = new()
        {
            Id = id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Phone = employee.Phone,
            HireDate = employee.HireDate,
            Salary = employee.Salary,
            IsActive = employee.IsActive,
            DepartmentId = employee.DepartmentId,
            PositionId = employee.PositionId
        };
        var res = await repositry.UpdateEmloyee(em, cancellationToken);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Employee updated ! ", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Employee not updated !");
    }
    public async Task<ApiResponse<bool>> DeleteEmployee(int id, CancellationToken cancellationToken)
    {
        var res = await repositry.DeleteEmployee(id, cancellationToken);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Employee deleted !", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Employee not deleted !");
    }
    public async Task<ApiResponse<ResponseEmployeeDto>> GetEmployee(int id, CancellationToken cancellationToken)
    {
        var con = await repositry.GetEmployee(id, cancellationToken);
        if(con == null)
        {
            return new ApiResponse<ResponseEmployeeDto>(HttpStatusCode.NotFound, "Not found !");
        }
        var em = new ResponseEmployeeDto
        {
            Id = con.Id,
            FirstName = con.FirstName,
            LastName = con.LastName,
            Email = con.Email,
            Phone = con.Phone,
            HireDate = con.HireDate,
            Salary = con.Salary,
            IsActive = con.IsActive,
            DepartmentId = con.DepartmentId,
            PositionId = con.PositionId
        };
        return new ApiResponse<ResponseEmployeeDto>(HttpStatusCode.OK, "Employee by id", em);
    }
    public async Task<ApiResponse<List<ResponseEmployeeDto>>> GetEmployees(CancellationToken cancellationToken)
    {
        var con = await repositry.GetEmployees(cancellationToken);
        var em = con.Select(s => new ResponseEmployeeDto
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,
            Phone = s.Phone,
            HireDate = s.HireDate,
            Salary = s.Salary,
            IsActive = s.IsActive,
            DepartmentId = s.DepartmentId,
            PositionId = s.PositionId
        }).ToList();
        return new ApiResponse<List<ResponseEmployeeDto>>(HttpStatusCode.OK, "List of Employee", em);
    }
    public async Task<ApiResponse<bool>> EmployeePatch(int id, CancellationToken cancellationToken)
    {
        var res = await repositry.EmployeePatch(id, cancellationToken);
        if(res == null)
        {
            return new ApiResponse<bool>(HttpStatusCode.NotFound, "Not found !");
        }
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Employee patch ! ", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Employee not patch !");
    }
}
