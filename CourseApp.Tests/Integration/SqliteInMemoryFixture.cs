using CourseApp.Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Tests.Integration;

public sealed class SqliteInMemoryFixture : IDisposable
{
    private readonly SqliteConnection _connection;

    public SqliteInMemoryFixture()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
    }

    public CourseAppDbContext CreatedDbContext()
    {
        var options = new DbContextOptionsBuilder<CourseAppDbContext>()
            .UseSqlite(_connection)
            .Options;


        var context = new CourseAppDbContext(options);
        context.Database.EnsureCreated();
        return context;
    }

    public void Dispose() => _connection.Dispose();

}

[CollectionDefinition(Name)]
public sealed class SqliteInMemoryCollection : ICollectionFixture<SqliteInMemoryFixture>
{
    public const string Name = "SqliteInMemory";
}