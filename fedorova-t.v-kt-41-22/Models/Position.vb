Namespace fedorova_t.v_kt_41_22.Models
    Public Class Position
        Public Property Id As Integer
        Public Property Title As String = String.Empty
        Public Property Teachers As ICollection(Of Teacher) = New List(Of Teacher)()

    End Class
End Namespace
