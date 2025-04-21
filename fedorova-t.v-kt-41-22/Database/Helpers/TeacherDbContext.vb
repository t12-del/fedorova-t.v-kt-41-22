Imports fedorova_t.v_kt_41_22.Database.Configurations
Imports fedorova_t.v_kt_41_22.Models

Imports Microsoft.EntityFrameworkCore

Namespace fedorova_t.v_kt_41_22.Database
    Public Class TeacherDbContext
        Inherits DbContext
        Public Property Departments As DbSet(Of Department)
        Public Property Teachers As DbSet(Of Teacher)
        Public Property AcademicDegrees As DbSet(Of AcademicDegree)
        Public Property Positions As DbSet(Of Position)
        Public Property Disciplines As DbSet(Of Discipline)
        Public Property Loads As DbSet(Of Load)

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            modelBuilder.ApplyConfiguration(New DepartmentConfiguration())
            modelBuilder.ApplyConfiguration(New TeacherConfiguration())
            modelBuilder.ApplyConfiguration(New AcademicDegreeConfiguration())
            modelBuilder.ApplyConfiguration(New PositionConfiguration())
            modelBuilder.ApplyConfiguration(New DisciplineConfiguration())
            modelBuilder.ApplyConfiguration(New LoadConfiguration())

            MyBase.OnModelCreating(modelBuilder)
        End Sub

        Public Sub New(options As DbContextOptions(Of TeacherDbContext))
            MyBase.New(options)
        End Sub
    End Class
End Namespace
