Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Threading.Tasks
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports WeatherForecast.Web

<TestClass()> Public Class HomeControllerTest

    '<TestMethod()> Public Sub Index()
    '    ' Arrange
    '    Dim controller As New HomeController()

    '    ' Act
    '    Dim result As ViewResult = DirectCast(controller.Index(), ViewResult)

    '    ' Assert
    '    Assert.IsNotNull(result)
    'End Sub

    '<TestMethod()> Public Sub About()
    '    ' Arrange
    '    Dim controller As New HomeController()

    '    ' Act
    '    Dim result As ViewResult = DirectCast(controller.About(), ViewResult)

    '    ' Assert
    '    Dim viewData As ViewDataDictionary = result.ViewData
    '    Assert.AreEqual("Your application description page.", viewData("Message"))
    'End Sub

    '<TestMethod()> Public Sub Contact()
    '    ' Arrange
    '    Dim controller As New HomeController()

    '    ' Act
    '    Dim result As ViewResult = DirectCast(controller.Contact(), ViewResult)

    '    ' Assert
    '    Assert.IsNotNull(result)
    'End Sub

    <TestMethod()>
    Public Async Function Index() As Task
        Dim controller As New HomeController()

        Assert.IsNotNull((Await controller.Index()).GetType())
        Assert.AreEqual(GetType(ViewResult), controller.Index().Result.GetType())
    End Function
End Class
