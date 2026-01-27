namespace CourseApp.Domain.Entities;

public class TeachingEntity
{
    public Guid Id { get; set; }
    public Guid TeacherId { get; set; }
    public Guid CourseEventId { get; set; }
}
