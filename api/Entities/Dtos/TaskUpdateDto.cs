namespace coding_challenge.Entities.Dtos;

public record TaskUpdateDto(int id, string Title, string Description, bool IsCompleted, DateTime? DueDate);