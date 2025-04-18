using coding_challenge.Entities.Dtos;
using coding_challenge.OperationResult;

namespace coding_challenge.Services;

public interface IMockTaskService
{
    Result<IEnumerable<TaskDto>> GetAll();
    Result<TaskDto> GetById(int id);
}
