Imports System.Data.SqlClient
Imports System.Threading.Tasks

Public Interface ISqlHelper
    Function NonQuery(Optional params As SqlParameter() = Nothing) As Task
    Function Query(Optional params As SqlParameter() = Nothing) As Task(Of IEnumerable(Of DataRow))
End Interface
