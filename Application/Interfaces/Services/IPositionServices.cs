using Application.DTOs.Positions;
using Application.Response;
using Domain.Models;

namespace Application.Interfaces.Services;

public interface IPositionServices
{
    Task<ApiResponse<bool>> AddPosition(CreatePositionDto position, CancellationToken cancellationToken);
    Task<ApiResponse<ResponsePositionDto>> GetPosition(int id, CancellationToken cancellationToken);
    Task<ApiResponse<List<ResponsePositionDto>>> GetPositions(CancellationToken cancellationToken);
}
