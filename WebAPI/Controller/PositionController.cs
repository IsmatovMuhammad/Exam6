using Application.DTOs.Positions;
using Application.Interfaces.Services;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class PositionController(
    IPositionServices positionServices) : ControllerBase
{
    private readonly IPositionServices services = positionServices;

    [HttpGet]
    public async Task<ApiResponse<List<ResponsePositionDto>>> GetPositions(CancellationToken cancellationToken)
    {
        return await services.GetPositions(cancellationToken);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<ResponsePositionDto>> GetPosition(int id, CancellationToken cancellationToken)
    {
        return await services.GetPosition(id, cancellationToken);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddPosition(CreatePositionDto position, CancellationToken cancellationToken)
    {
        return await services.AddPosition(position, cancellationToken);
    }
}
