using CourseApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

//databasens namen angers här
builder.Services.AddDbContext<CourseAppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("CourseAppDatabase"),
    sql => sql.MigrationsAssembly("CourseApp.Infrastructure")
));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapOpenApi();
app.UseHttpsRedirection();

app.Run();
