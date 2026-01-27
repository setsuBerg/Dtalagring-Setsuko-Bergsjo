namespace CourseApp.Domain.Entities;

public class CourseRegistrationEntity
{
    public Guid Id { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string Status { get; set; } = null!;
    public Guid StudentId { get; set; }
    public Guid CourseEventId { get; set; }
}
