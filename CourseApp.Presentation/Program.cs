using CourseApp.Application.Contracts;
using CourseApp.Application.Dtos;
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

    var result = students.Select(s => new StudentResponseDto(s.Id, s.FirstName, s.LastName, s.Email));

    return Results.Ok(result);
});

// get student by ID
app.MapGet("/students/{id:guid}", async (Guid id, IStudentRepository repo, CancellationToken ct) =>
{
    var student = await repo.GetByIdAsync(id, ct);

    if (student is null)
        return Results.NotFound();

    var response = new StudentResponseDto(student.Id, student.FirstName, student.LastName, student.Email);

    return Results.Ok(response);
});

// create a new student
app.MapPost("/students", async (StudentCreateDto dto, IStudentRepository repo, CancellationToken ct) =>
{
    var student = new StudentEntity
    {
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Email = dto.Email,
        PhoneNumber = dto.PhoneNumber,
        DateOfBirth = dto.DateOfBirth
    };

    await repo.CreateAsync(student, ct);

    var createdStudent = await repo.GetByEmailAsync(student.Email, ct);

    if (createdStudent == null)
        return Results.BadRequest("Student could not be created.");

    var response = new StudentResponseDto(createdStudent.Id, createdStudent.FirstName, createdStudent.LastName, createdStudent.Email);
    return Results.Created($"/students/{response.Id}", response);
});

// Endpoint to update a student
app.MapPut("/students/{id:guid}", async (
    Guid id,
    StudentUpdateDto dto,
    IStudentRepository repo,
    CancellationToken ct) =>
{
    var entity = await repo.GetByIdAsync(id, ct);
    if (entity is null)
        return Results.NotFound();

        entity.FirstName = dto.FirstName;
        entity.LastName = dto.LastName;
        entity.Email = dto.Email;
        entity.PhoneNumber = dto.PhoneNumber;
        entity.DateOfBirth = dto.DateOfBirth;

        var response = new StudentResponseDto(entity.Id, entity.FirstName, entity.LastName, entity.Email);

        return Results.Ok(response);
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
