namespace CourseApp.Domain.Entities;

public class CourseEvent
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MaxSeats { get; set; }
    public int CourseId { get; set; }
    public int CityId { get; set; }

}
