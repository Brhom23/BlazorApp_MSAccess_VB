Imports Microsoft.AspNetCore.Identity.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)

    Public Sub New(options As DbContextOptions(Of ApplicationDbContext))
        MyBase.New(options)
    End Sub

    Public Property Books As DbSet(Of Book)
    Public Property Categories As DbSet(Of Category)
    Public Property Students As DbSet(Of Student)
    Public Property Enrollments As DbSet(Of Enrollment)
    Public Property Courses As DbSet(Of Course)

    Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
    End Sub
    '{
    '    modelBuilder.Entity<Course>().ToTable("Course");
    '    modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
    '    modelBuilder.Entity<Student>().ToTable("Student");
    '}
End Class

