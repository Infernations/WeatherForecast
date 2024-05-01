Public Class ExcelFileResponse


    Public Lat As Decimal
    Public Longitude As Decimal
    Public Name As String
    Public Sub New()

    End Sub
    Public Sub New(val As String())
        Me.Lat = Decimal.Parse(val(0))
        Me.Longitude = Decimal.Parse(val(1))
        Me.Name = val(2).TrimStart(""""c).TrimEnd(""""c) 'trims start and end
    End Sub
End Class
