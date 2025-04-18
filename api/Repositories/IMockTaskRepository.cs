using coding_challenge.Entities.Dtos;

namespace coding_challenge.Repositories;

public interface IMockTaskRepository
{
    IEnumerable<TaskDto> GetAll();
    TaskDto? GetById(int id);
    Entities.Models.Task Create(string title, string description, DateTime? dueDate);
    Entities.Models.Task Update(int id, string title, string description, bool isCompleted, DateTime? dueDate);
    bool Delete(int id);

    bool IsExist(int id);
}
