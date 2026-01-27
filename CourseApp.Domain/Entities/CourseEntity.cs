namespace CourseApp.Domain.Entities;

public class CourseEntity
{
    public Guid Id { get; set; }
    public string CourseName { get; set; } = null!;
    public string Description { get; set; } = null!;

}
