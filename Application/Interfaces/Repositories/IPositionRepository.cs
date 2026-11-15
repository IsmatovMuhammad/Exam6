using Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IPositionRepository
{
    Task<bool> AddPosition(Position position, CancellationToken cancellationToken);
    Task<Position> GetPosition(int id, CancellationToken cancellationToken);
    Task<List<Position>> GetPositions(CancellationToken cancellationToken);
}
