namespace CourseApp.Application.Dtos;

public record StudentCreateDto(string FirstName, string LastName, string Email, string? PhoneNumber, DateTime? DateOfBirth);
