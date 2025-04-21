Namespace fedorova_t.v_kt_41_22
    Public Class WeatherForecast
        Public Property [Date] As Date

        Public Property TemperatureC As Integer

        Public ReadOnly Property TemperatureF As Integer
            Get
                Return 32 + CInt(TemperatureC / 0.5556)
            End Get
        End Property

        Public Property Summary As String?
    End Class
End Namespace
