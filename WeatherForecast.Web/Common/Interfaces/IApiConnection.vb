Imports System.Threading.Tasks

Public Interface IApiConnection
    Function ReturnData() As Task(Of IEnumerable(Of DayForecast))
End Interface
