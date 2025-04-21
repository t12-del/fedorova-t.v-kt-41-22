Namespace fedorova_t.v_kt_41_22.Models
    Public Class Department
        Public Property Id As Integer
        Public Property Name As String = String.Empty
        Public Property HeadId As Integer? ' Ссылается на преподавателя
        Public Property Head As Teacher? ' Навигационное свойство
        Public Property Teachers As ICollection(Of Teacher) = New List(Of Teacher)()

    End Class
End Namespace
