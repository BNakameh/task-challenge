using coding_challenge.Entities.Dtos;
using coding_challenge.OperationResult;
using coding_challenge.Repositories;

namespace coding_challenge.Services;

public class MockTaskService : IMockTaskService
{
    #region Properties And Constructor

    private readonly IMockTaskRepository _mockTaskRepository;

    public MockTaskService(IMockTaskRepository mockTaskRepository)
    {
        _mockTaskRepository = mockTaskRepository;
    }
    #endregion

    public Result<IEnumerable<TaskDto>> GetAll()
    {
        var result = _mockTaskRepository.GetAll();
        return Result.Success(result);
    }

    public Result<TaskDto> GetById(int id)
    {
        if (!_mockTaskRepository.IsExist(id))
        {
            return Result.Failure<TaskDto>(new Error("404", "this record not found", ErrorType.NotFound));
        }

        var result = _mockTaskRepository.GetById(id);
        return Result.Success(result!);
    }
}
