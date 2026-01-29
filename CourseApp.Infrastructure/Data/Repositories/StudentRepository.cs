using CourseApp.Application.Contracts;
using CourseApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }




    public async Task<IReadOnlyList<StudentEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.Students
            .AsNoTracking()
            .OrderBy(e => e.LastName)
            .ThenBy(e => e.FirstName)
            .ToListAsync(cancellationToken);
        return entities;
    }

    public async Task<StudentEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException(nameof(email));

        var student = await _context.Students
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.Email == email, cancellationToken);

        return student;
    }

    public async Task<StudentEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        if (id == Guid.Empty)
            throw new ArgumentNullException("Id is required.", nameof(id));

        var student = await _context.Students
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.Id == id, cancellationToken);

        return student;
    }



    public Task UpdateAsync(StudentEntity student, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
