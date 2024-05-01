

Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports System.Linq
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Net.Mime
Public Class FileUploadController
    Inherits Controller
    <HttpGet>
    Public Function UploadData() As ActionResult
        Return View()
    End Function

    <HttpPost>
    Public Async Function UploadData(responseFile As HttpPostedFile) As Task(Of ActionResult)
        Dim ls As List(Of ExcelFileResponse) = New List(Of ExcelFileResponse)
        Using excel As New ExcelHandler
            If Request.Files.Count > 0 Then
                'Gets the file uploaded and returns a list of rows
                If Request.Files(0).ContentType = "text/csv" Then
                    Dim file As HttpPostedFileBase = Request.Files(0)
                    ls = Await excel.ReturnData(file)
                Else
                    Return RedirectToAction(NameOf(Forecast))
                End If
            End If
            'Auotomatically disposes the excel handler freeing potentially needed memory
        End Using
        TempData("weatherData") = JsonConvert.SerializeObject(ls) ', New With {.value = TempData("weatherData")}
        'creates a sql object, inserts into database and removes the sql instance
        Using sql As New SqlHelper("INSERT INTO HistoricRequests (jsonVal, dateRan) VALUES (@jsonVal, @dateRan)")
            Dim params As SqlParameter() = {New SqlParameter("@jsonVal", TempData("weatherdata")), New SqlParameter("@dateRan", Date.Now)}
            Await sql.NonQuery(params)
        End Using

        'originally passed in the serialised object as a parameter to forecast, but returned as query string
        Return RedirectToAction(NameOf(Forecast))
    End Function

    <HttpGet()> 'work out why its also acting as a parameter in url 'value As String
    Public Async Function Forecast(Optional ByVal id As Integer = 0) As Task(Of ActionResult)
        Dim value As String
        If id <> 0 Then
            Using sql As New SqlHelper("SELECT * FROM HistoricRequests WHERE Id = @id")
                Dim params As SqlParameter() = {New SqlParameter("@id", id)}
                Dim tbl As DataRow = (Await sql.Query(params)).FirstOrDefault()
                value = tbl(1)
            End Using
        Else
            value = TempData("weatherData")
            TempData.Clear() 'clear temporary
        End If
        Try
            Dim response As IEnumerable(Of WeatherResponse) = Await WeatherResponseHandler.ReturnResponses(JsonConvert.DeserializeObject(Of IEnumerable(Of WeatherLocation))(value))
            Return View(response)
        Catch ex As Exception
            Return View()
        End Try
        'Desiralised json object gets passed handler to then call api.

    End Function

    <HttpGet()>
    Public Async Function Historic() As Task(Of ActionResult)
        Using sql As New SqlHelper("SELECT * FROM HistoricRequests")
            Dim tbl As IEnumerable(Of DataRow) = Await sql.Query()
            Dim convertedVal As List(Of HistoricResponse) = Await WeatherResponseHandler.ConvertDataTable(tbl)
            Return View(convertedVal)
        End Using
    End Function

    Public Async Function Delete(Optional id As Integer = 0) As Task(Of ActionResult)
        If id <> 0 Then
            Using sql As New SqlHelper("DELETE FROM HistoricRequests WHERE Id = @id")
                Dim params As SqlParameter() = {New SqlParameter("@id", id)}
                Await sql.NonQuery(params)
            End Using
        End If
        Return RedirectToAction(NameOf(Historic))
    End Function
End Class
