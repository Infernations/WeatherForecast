Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.IO
Imports System.Threading.Tasks
Imports System.Linq

Public Class SqlHelper
    Implements ISqlHelper, IDisposable
    'Gets relative path for excel
    Private connectionPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/sqlite.db")
    Private connectionString As String = $"Data Source={Me.connectionPath};Version=3;"
    Public CommandText As String

    Public Sub New(commandText As String)
        Me.CommandText = commandText
    End Sub

    'Non output queries: i.e inserts, deletes, updates, creates
    Public Async Function NonQuery(Optional params As SqlParameter() = Nothing) As Task Implements ISqlHelper.NonQuery
        Using sql As New SQLiteConnection With {.ConnectionString = Me.connectionString}
            Await sql.OpenAsync()

            Using command As New SQLiteCommand With {.CommandText = Me.CommandText, .Connection = sql}
                If params IsNot Nothing Then
                    For Each param As SqlParameter In params
                        command.Parameters.AddWithValue(param.ParameterName, param.Value)
                    Next
                End If
                Await command.ExecuteNonQueryAsync()
            End Using
            sql.Close()

        End Using
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        'Dispose sql Object once complete
        GC.SuppressFinalize(Me)
    End Sub

    'Output queries: selects
    Public Async Function Query(Optional params() As SqlParameter = Nothing) As Task(Of IEnumerable(Of DataRow)) Implements ISqlHelper.Query
        Using sql As New SQLiteConnection With {.ConnectionString = Me.connectionString}
            Await sql.OpenAsync()

            Using command As New SQLiteCommand With {.CommandText = Me.CommandText, .Connection = sql}
                If params IsNot Nothing Then
                    For Each param As SqlParameter In params
                        command.Parameters.AddWithValue(param.ParameterName, param.Value)
                    Next
                End If

                Using adapter As New SQLiteDataAdapter With {.SelectCommand = command}
                    Dim table As New DataTable
                    adapter.Fill(table)
                    Return table.AsEnumerable()
                End Using
            End Using
        End Using
    End Function

End Class
