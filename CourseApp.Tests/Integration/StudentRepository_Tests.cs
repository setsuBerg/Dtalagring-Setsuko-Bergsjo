using CourseApp.Domain.Entities;
using CourseApp.Infrastructure.Data;
using CourseApp.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Tests.Integration;

[Collection(SqliteInMemoryCollection.Name)]
public sealed class StudentRepository_Tests(SqliteInMemoryFixture fixture)
{
    [Fact]
    public async Task CreateAsync_Should_Save_Student() 
    {
        await using var context = fixture.CreatedDbContext();
        await ClearStudentsAsync(context);

        var repository = new StudentRepository(context);

        var student = new StudentEntity
        {
            FirstName = "John",
            LastName = "Hansson",
            Email = "john@domain.com"
        };

        await repository.CreateAsync(student, CancellationToken.None);


        var all = await repository.GetAllAsync(CancellationToken.None);


        Assert.Single(all);
        Assert.Equal("John", all[0].FirstName);
        Assert.Equal("Hansson", all[0].LastName);
        Assert.Equal("john@domain.com", all[0].Email);
    }

    [Fact]
    public async Task CreateAsync_Should_Throw_When_Email_Duplicate()
    {
        await using var context = fixture.CreatedDbContext();
        await ClearStudentsAsync(context);

        var repository = new StudentRepository(context);

        var student1 = new StudentEntity
        {
            FirstName = "John",
            LastName = "Mori",
            Email = "john.mori@domain.com"
        };

        await repository.CreateAsync(student1, CancellationToken.None);


        var student2 = new StudentEntity
        {
            FirstName = "Ken",
            LastName = "Hansson",
            Email = "john.mori@domain.com"
        };

        await Assert.ThrowsAsync<DbUpdateException>(() =>
            repository.CreateAsync(student2, CancellationToken.None));
    }


    private static async Task ClearStudentsAsync(CourseAppDbContext context)
    {
        await context.Database.ExecuteSqlRawAsync("DELETE FROM Students; ");
    }

}

