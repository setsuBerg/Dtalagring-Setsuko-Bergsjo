using Microsoft.EntityFrameworkCore;
using CourseApp.Domain.Entities;

namespace CourseApp.Infrastructure.Data;

public sealed class CourseAppDbContext(DbContextOptions<CourseAppDbContext> options) : DbContext(options)
{
    public DbSet<StudentEntity> Students => Set<StudentEntity>();
    public DbSet<CourseEntity> Courses => Set<CourseEntity>();
    public DbSet<CourseEventEntity> courseEvents => Set<CourseEventEntity>();


    //data context del ---> registrera den i program.cs
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentEntity>(entity =>
        {
            entity.ToTable("Students");
            entity.HasKey(e => e.Id).HasName("PK_Student_Id");

            entity.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWSEQUENTIALID()");

            entity.Property(e => e.FirstName)
            .HasMaxLength(50)
            .IsRequired();

            entity.Property(e => e.LastName)
            .HasMaxLength(50)
            .IsRequired();

            entity.Property(e => e.Email)
            .HasMaxLength(256)
            .IsRequired();

            entity.Property(e => e.PhoneNumber)
            .HasMaxLength(13)
            .IsUnicode(false);


            entity.HasIndex(e => e.Email, "UQ_Students_Email").IsUnique();
            entity.ToTable(tb => tb.HasCheckConstraint("CK_Students_Email_NotEmpty", "LTRIM(RTRIM([Email])) <> ''"));

        });
    }
}
