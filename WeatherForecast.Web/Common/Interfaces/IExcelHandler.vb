Imports System.Threading.Tasks

Public Interface IExcelHandler
    Function ReturnData(ByVal excelData As HttpPostedFileBase) As Task(Of IEnumerable(Of ExcelFileResponse))
End Interface
