namespace CourseApp.Domain.Entities;

public class StudentEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    
}
