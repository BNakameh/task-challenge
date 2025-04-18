namespace coding_challenge.Entities.Models;

public record Task(
    int Id,
    string Title,
    string Description,
    bool IsCompleted,
    DateTime CreatedAt,
    DateTime? DueDate
);