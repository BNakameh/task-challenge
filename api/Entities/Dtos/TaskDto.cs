namespace coding_challenge.Entities.Dtos;

public record TaskDto(int id, string Title, string Description, bool IsCompleted, DateTime CreatedAt, DateTime? DueDate)
{
    public TaskDto(Entities.Models.Task task)
        : this(task.Id, task.Title, task.Description, task.IsCompleted, task.CreatedAt, task.DueDate)
    {
    }
}