using CourseApp.Application.Contracts;
using CourseApp.Domain.Entities;
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

// get student by ID
app.MapGet("/students/{id.guid}", async (Guid id, IStudentRepository repo, CancellationToken ct) =>
{
    var student = await repo.GetByIdAsync(id, ct);
    return student is null ? Results.NotFound() : Results.Ok(student);
});

// create a new student
app.MapPost("/students", async (StudentEntity student, IStudentRepository repo, CancellationToken ct) =>
{
    await repo.CreateAsync(student, ct);
    var createdStudent = await repo.GetByEmailAsync(student.Email, ct);
    if (createdStudent == null)
        return Results.BadRequest("Student could not be created.");

    return Results.Created($"/students/{createdStudent.Id}", createdStudent);
});

// Endpoint to delete a student by ID
app.MapDelete("/students/{id:guid}", async (Guid id, IStudentRepository repo, CancellationToken ct) =>
{
    try
    {
        await repo.DeleteAsync(id, ct);
        return Results.NoContent();
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound();
    }

});

app.Run();
