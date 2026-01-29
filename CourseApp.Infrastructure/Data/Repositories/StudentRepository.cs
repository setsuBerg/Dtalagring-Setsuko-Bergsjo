using CourseApp.Application.Contracts;
using CourseApp.Domain.Entities;

namespace CourseApp.Infrastructure.Data.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly CourseAppDbContext _context;
    public StudentRepository(CourseAppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(StudentEntity student, CancellationToken cancellationToken)
    {
        //Mappning CreateStudentDTO to StudentEntity, inte använd automappar, automappar är lätt
        var entity = new StudentEntity
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            PhoneNumber = student.PhoneNumber,
        };

        //Save to database
        _context.Students.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        
    }

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<StudentEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<StudentEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<StudentEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(StudentEntity student, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
