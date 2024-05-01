Imports System.Threading.Tasks

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Public Async Function Index() As Task(Of ActionResult)
        Dim locations As New List(Of WeatherLocation)({New WeatherLocation With {
            .Lat = 51.063751,
                                                                                                    .Longitude = -0.327,
                                                                                                    .Name = "Horsham,UK"
                                                  }, New WeatherLocation With {
                                                  .Lat = 51.507351,
                                                                                                    .Longitude = -0.127758,
                                                                                                    .Name = "London,UK"
                                                  }, New WeatherLocation With {
                                                  .Lat = 55.864239,
                                                                                                    .Longitude = -4.251806,
                                                                                                    .Name = "Glasgow,UK"
                                                  }, New WeatherLocation With {
                                                                              .Lat = 51.4837,
                                                                              .Longitude = 3.1681,
                                                                              .Name = "Cardiff,UK"
                                                  }, New WeatherLocation With {
                                                  .Lat = 37.7749,
                                                  .Longitude = -122.4194,
                                                  .Name = "San Francisco, USA"
                                                  }
                                                  })



        'Dim newls As List(Of ExcelFileResponse) = New List(Of ExcelFileResponse) {
        '    ExcelFileResponse() With {
        '                                                                                            .Lat = 51.063751,
        '                                                                                            .Longitude = -0.327,
        '                                                                                            .Name = "Horsham,UK"
        '                                                                                        }}
        'Dim ls As List(Of ExcelFileResponse)( {New ExcelFileResponse With {
        '                                                                                            .Lat = 51.063751,
        '                                                                                            .Longitude = -0.327,
        '                                                                                            .Name = "Horsham,UK"
        '                                                                                        }, New ExcelFileResponse With {
        '                                                                                            .Lat = 51.507351,
        '                                                                                            .Longitude = -0.127758,
        '                                                                                            .Name = "London,UK"
        '                                                                                           }, New ExcelFileResponse With {
        '                                                                                            .Lat = 55.864239,
        '                                                                                            .Longitude = -4.251806,
        '                                                                                            .Name = "Glasgow,UK"
        '                                                                                            }})
        Return View(Await WeatherResponseHandler.ReturnResponses(locations))
    End Function

End Class
