using CourseApp.Application.Contracts;
using CourseApp.Infrastructure.Data;
using CourseApp.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

//databasens namen angers här
builder.Services.AddDbContext<CourseAppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("CourseAppDatabase"),
    sql => sql.MigrationsAssembly("CourseApp.Infrastructure")
));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapOpenApi();
app.UseHttpsRedirection();

app.MapGet("/students", async (IStudentRepository repo, CancellationToken ct) =>
{
    var students = await repo.GetAllAsync(ct);
    return Results.Ok(students);
});

app.Run();
