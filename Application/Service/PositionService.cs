using System.Net;
using Application.DTOs.Positions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Response;
using Domain.Models;

namespace Application.Service;

public class PositionService(
    IPositionRepository positionRepository) : IPositionServices
{
    private IPositionRepository repository = positionRepository;
    public async Task<ApiResponse<bool>> AddPosition(CreatePositionDto position, CancellationToken cancellationToken)
    {
        Position po = new()
        {
            Title = position.Title,
            MinSalary = position.MinSalary,
            MaxSalary = position.MaxSalary
        };
        var res = await repository.AddPosition(po, cancellationToken);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Position added !", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Position not added !");
    }

    public async Task<ApiResponse<ResponsePositionDto>> GetPosition(int id, CancellationToken cancellationToken)
    {
        var con = await repository.GetPosition(id, cancellationToken);
        if(con == null)
        {
            return new ApiResponse<ResponsePositionDto>(HttpStatusCode.NotFound, "Not found !");
        }
        var po = new ResponsePositionDto
        {
            Id = id,
            Title = con.Title,
            MinSalary = con.MinSalary,
            MaxSalary = con.MaxSalary
        };
        return new ApiResponse<ResponsePositionDto>(HttpStatusCode.OK, "Position by id ", po);
    }

    public async Task<ApiResponse<List<ResponsePositionDto>>> GetPositions(CancellationToken cancellationToken)
    {
        var con = await repository.GetPositions(cancellationToken);
        var po = con.Select(s => new ResponsePositionDto
        {
            Id = s.Id,
            Title = s.Title,
            MinSalary = s.MinSalary,
            MaxSalary = s.MaxSalary
        }).ToList();
        return new ApiResponse<List<ResponsePositionDto>>(HttpStatusCode.OK, "List of position ", po);
    }

}
