using CourseApp.Domain.Entities;

namespace CourseApp.Application.Contracts;

public interface IStudentRepository
{
    Task CreateAsync(StudentEntity student, CancellationToken cancellationToken);
    Task<StudentEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<StudentEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<IReadOnlyList<StudentEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task UpdateAsync(StudentEntity student, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
