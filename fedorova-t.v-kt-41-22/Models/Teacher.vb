Namespace fedorova_t.v_kt_41_22.Models
    Public Class Teacher
        Public Property Id As Integer
        Public Property FirstName As String = String.Empty
        Public Property LastName As String = String.Empty

        Public Property AcademicDegreeId As Integer?
        Public Property AcademicDegree As AcademicDegree?

        Public Property PositionId As Integer?
        Public Property Position As Position?

        Public Property DepartmentId As Integer?
        Public Property Department As Department?

        Public Property ManagedDepartment As Department? ' Кафедра, которой заведует преподаватель

        Public Property Loads As ICollection(Of Load) = New List(Of Load)()

    End Class
End Namespace
