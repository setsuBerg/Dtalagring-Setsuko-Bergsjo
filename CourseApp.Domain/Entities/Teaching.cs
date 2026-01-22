namespace CourseApp.Domain.Entities;

public class Teaching
{
    public Guid Id { get; set; }
    public Guid TeacherId { get; set; }
    public Guid CourseEventId { get; set; }
}
