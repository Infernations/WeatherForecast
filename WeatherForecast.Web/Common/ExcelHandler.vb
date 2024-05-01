Imports System.IO
Imports System.Threading.Tasks
Imports System.Text.RegularExpressions

Public Class ExcelHandler
    Implements IExcelHandler, IDisposable

    Public Sub Dispose() Implements IDisposable.Dispose
        GC.SuppressFinalize(Me)
    End Sub

    Public Async Function ReturnData(excelData As HttpPostedFileBase) As Task(Of IEnumerable(Of ExcelFileResponse)) Implements IExcelHandler.ReturnData
        Dim dec As Decimal
        Dim ls As List(Of String()) = New List(Of String())
        If excelData IsNot Nothing AndAlso excelData.ContentLength > 0 Then
            Using reader As New StreamReader(excelData.InputStream)
                'using statement with reader to automatically dispose once the csv  has been read
                While Not reader.EndOfStream
                    Dim line As String = Await reader.ReadLineAsync()
                    'Escapes any commas
                    Dim newStr As String() = Regex.Split(line, ",(?=(?:[^\""]*\""[^\""]*"")*[^\""]*$)")
                    'Dim str As String() = line.Split(","c)
                    'Handles if the first row is titles/headers
                    If Decimal.TryParse(newStr(0), dec) AndAlso Decimal.TryParse(newStr(1), dec) Then
                        ls.Add(newStr) 'line.Split(","c))
                    End If
                End While
            End Using
        End If
        Return ls.Select(Function(x) New ExcelFileResponse(x)).ToList()
    End Function

End Class
