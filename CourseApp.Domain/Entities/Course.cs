namespace CourseApp.Domain.Entities;

public class Course
{
    public Guid Id { get; set; }
    public string CourseName { get; set; } = null!;
    public string Description { get; set; } = null!;

}
