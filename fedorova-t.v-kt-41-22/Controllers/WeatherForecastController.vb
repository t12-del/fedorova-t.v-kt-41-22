Imports Microsoft.AspNetCore.Mvc

Namespace fedorova_t.v_kt_41_22.Controllers
    <ApiController>
    <Route("[controller]")>
    Public Class WeatherForecastController
        Inherits ControllerBase
        Private Shared ReadOnly Summaries As String() = {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"}

        Private ReadOnly _logger As Microsoft.Extensions.Logging.ILogger(Of WeatherForecastController)

        Public Sub New(logger As Microsoft.Extensions.Logging.ILogger(Of WeatherForecastController))
            _logger = logger
        End Sub

        <HttpGet(Name:="GetWeatherForecast")>
        Public Function [Get]() As IEnumerable(Of WeatherForecast)
            _logger.LogError("Method was called")
            Return Enumerable.Range(1, 5).[Select](Function(index) New WeatherForecast With {
    .[Date] = Date.Now.AddDays(index),
    .TemperatureC = Random.Shared.Next(-20, 55),
    .Summary = Summaries(Random.Shared.Next(Summaries.Length))
            }).ToArray()
        End Function

        <HttpPost(Name:="AddNewSummary")>

        Public Function AddNewSummary(newSummary As String) As String()
            _logger.LogError("New method was called")

            Dim list = Summaries.ToList()
            list.Add(newSummary)
            Return list.ToArray()
        End Function
    End Class
End Namespace
