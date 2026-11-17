using Application.Interfaces.Repositories;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DepartmentRepository(DataBase dataBase) : IDepartmentRepository
{
    private readonly DataBase data = dataBase;
    public async Task<bool> AddDepartment(Department department, CancellationToken cancellationToken)
    {
        data.Departments.Add(department);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteDepartment(int id, CancellationToken cancellationToken)
    {
        var department = await data.Departments.FirstOrDefaultAsync(x => x.id == id);
        if(department != null)
        {
            data.Departments.Remove(department);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Department> GetDepartment(int id, CancellationToken cancellationToken)
    {
        var department = await data.Departments.FirstOrDefaultAsync(x => x.id == id);
        return department??new();
    }

    public async Task<List<Department>> GetDepartments(CancellationToken cancellationToken)
    {
        return await data.Departments.ToListAsync();
    }

    public async Task<bool> UpdateDepartment(Department department, CancellationToken cancellationToken)
    {
        var dep = await data.Departments.FirstOrDefaultAsync(x => x.id == department.id);
        if(dep != null)
        {
            dep.Name = department.Name;
            dep.Description = department.Description;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

}
