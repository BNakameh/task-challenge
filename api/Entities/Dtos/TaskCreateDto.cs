namespace coding_challenge.Entities.Dtos;

public record TaskCreateDto(string Title, string Description, DateTime? DueDate);