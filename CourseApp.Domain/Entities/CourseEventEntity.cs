namespace CourseApp.Domain.Entities;

public class CourseEventEntity
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MaxSeats { get; set; }
    public int CourseId { get; set; }
    public int CityId { get; set; }
    public virtual ICollection<CourseRegistrationEntity> CourseRegistrations { get; set; } = [];

    public virtual ICollection<TeachingEntity> Teachings { get; set; } = [];
}
