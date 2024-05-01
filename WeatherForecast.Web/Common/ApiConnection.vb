Imports System.Net.Http
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ApiConnection
    Implements IApiConnection, IDisposable
    Public Latitude As Decimal
    Public Longitude As Decimal

    Public Async Function ReturnData() As Task(Of IEnumerable(Of DayForecast)) Implements IApiConnection.ReturnData
        Dim client As New HttpClient()
        Dim callResult = Await client.GetAsync($"https://api.open-meteo.com/v1/forecast?latitude={Latitude}&longitude={Longitude}&daily=weather_code,temperature_2m_max,temperature_2m_min&forecast_days=3")
        Dim contentValue = Await callResult.Content.ReadAsStringAsync()
        'converts the API result to json object, then converts to class
        Dim obj As JObject = JsonConvert.DeserializeObject(contentValue)
        Dim dailyObj = obj.SelectToken("daily").ToObject(Of Daily)
        Dim lsWeathers As List(Of DayForecast) = New List(Of DayForecast)

        For i As Integer = 0 To dailyObj.Time.Count() - 1
            'loops through each item, and adds response item to list
            lsWeathers.Add(New DayForecast() With {
                           .High = dailyObj.Temperature_2m_max(i),
                           .Low = dailyObj.Temperature_2m_min(i),
                           .WeatherDate = dailyObj.Time(i),
                           .Weather = WeatherDescription.CodeHandler(dailyObj.Weather_code(i))})

        Next

        Return lsWeathers

    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        GC.SuppressFinalize(Me)
    End Sub
End Class
