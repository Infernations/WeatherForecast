Public Class WeatherDescription
    Public Shared Function CodeHandler(ByVal code As Integer) As String
        'Would normally use a database to join the information against to assign a normalised ID to the result
        Select Case code
            Case 0
                Return "Clear Sky"
            Case 1, 2, 3
                ', partly cloudy, and overcast
                Return "Mainly clear"
            Case 45, 48
                ' and depositing rime fog
                Return "Fog"
            Case 51, 53, 55
                ': Light, moderate and dense intensity
                Return "Drizzle"
            Case 56, 57
                ': Light and dense intensity
                Return "Freezing Drizzle"
            Case 61, 63, 65
                ': Slight, moderate and heavy intensity
                Return "Rain"
            Case 66, 67
                ': Light and heavy intensity
                Return "Freezing Rain"
            Case 71, 73, 75
                ': Slight, moderate and heavy intensity
                Return "Snow fall"
            Case 77
                Return "Snow grains"
            Case 80, 81, 82
                ': Slight, moderate, and violent
                Return "Rain showers"
            Case 85, 86
                ' slight and heavy
                Return "Snow showers"
            Case 95
                ': Slight or moderate
                Return "Thunderstorm"
            Case 96, 99
                'slight and heavy
                Return "Thunderstorm with hail"
            Case Else
                Return "unknown"
        End Select
    End Function
End Class
