Imports System.Threading.Tasks
Imports Newtonsoft.Json


Public Class WeatherResponseHandler
    'Shared method due to reusability and being more effective to just call these instead of creating a new object.
    Public Shared Async Function ReturnResponses(ByVal weathers As IEnumerable(Of WeatherLocation)) As Task(Of List(Of WeatherResponse))
        Dim result = weathers.Select(Async Function(x) New WeatherResponse With {.Location = x, .Weathers = Await GetApiData(x.Lat, x.Longitude)})
        Dim response = Await Task.WhenAll(result)
        'will return the data once all threads have been excecuted correctly.
        Return response.ToList()
    End Function

    'Shared method due to reusability and being more effective to just call these instead of creating a new object.
    Public Shared Async Function GetApiData(ByVal lat As Decimal, ByVal longitude As Decimal) As Task(Of List(Of DayForecast))

        Using api As New ApiConnection With {.Latitude = lat, .Longitude = longitude}
            'due to apiconnection being instansiated through each loop, and as being asynchrnous, makes sense to take into account memory useage
            Return Await api.ReturnData()
        End Using
    End Function

    Public Shared Async Function ConvertDataTable(ByVal results As IEnumerable(Of DataRow)) As Task(Of List(Of HistoricResponse))
        Dim ls As List(Of HistoricResponse) = New List(Of HistoricResponse)
        'results.ForEach(Sub(x) AddToList(ls, x(1)))
        'TODO: idea, convert the for each loop to a linq .ForEach(Function(x)) style
        For Each row As DataRow In results
            ls.Add(New HistoricResponse With {.DateRan = row(2), .Id = row(0), .LocationNames = Returndata(row(1)).Select(Function(x) x.Name).ToArray()})
        Next
        Return ls
    End Function

    Public Shared Function Returndata(data As String) As IEnumerable(Of WeatherLocation)
        Return JsonConvert.DeserializeObject(Of IEnumerable(Of WeatherLocation))(data)
    End Function


End Class
