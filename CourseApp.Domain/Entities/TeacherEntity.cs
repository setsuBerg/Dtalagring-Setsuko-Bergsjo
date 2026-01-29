namespace CourseApp.Domain.Entities;

public class TeacherEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;
    public string Expertise { get; set; } = null!;
    public virtual ICollection<TeachingEntity> Teachings { get; set; } = [];
}
