Imports System.Text
Imports System.Threading.Tasks
Imports System.Web
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class FileUploadControllerTest

    <TestMethod()>
    Public Sub UploadData()
        Dim controller As New FileUploadController()
        Dim result As ViewResult = DirectCast(controller.UploadData(), ViewResult)
        Assert.IsNotNull(result)
    End Sub

    <TestMethod()>
    Public Async Function Forecast() As Task
        Dim controller As New FileUploadController()
        Dim result = Await controller.Forecast()
        Assert.IsNotNull(result)
    End Function

End Class
