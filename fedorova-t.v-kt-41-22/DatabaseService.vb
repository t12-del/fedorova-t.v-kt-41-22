Imports fedorova_t.v_kt_41_22.Database
Imports fedorova_t.v_kt_41_22.Models

Public Class DatabaseService
    Private ReadOnly _context As TeacherDbContext

    Public Sub New(context As TeacherDbContext)
        _context = context
    End Sub

    Public Async Function AddTeacherAsync() As Task
        Dim degree = New AcademicDegree()
        Dim position = New Position()
        Dim department = New Department()

        _context.AcademicDegrees.Add(degree)
        _context.Positions.Add(position)
        _context.Departments.Add(department)
        Await _context.SaveChangesAsync()

        Dim teacher = New Teacher With {
    .AcademicDegreeId = degree.Id,
    .PositionId = position.Id,
    .DepartmentId = department.Id
}

        _context.Teachers.Add(teacher)
        Await _context.SaveChangesAsync()
    End Function
End Class
