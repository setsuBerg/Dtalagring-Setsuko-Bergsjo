namespace CourseApp.Application.Dtos;

public record StudentUpdateDto(string FirstName, string LastName, string Email, string PhoneNumber, DateOnly? DateOfBirth);
