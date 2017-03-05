Imports System.Data.SqlClient

Public Class DAL
    Private conn As SqlConnection = Nothing

    Public Sub New()
        conn = New SqlConnection("Data Source=127.0.0.1;Initial Catalog=Hackathon;User ID=sa;Password=vagrant;")
    End Sub

    Public Sub DisposeAll()
        conn.Dispose()
        conn = Nothing
    End Sub

    Private Function Connect() As Boolean
        Try
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub Close()
        Try
            If conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ExecuteNonQuery(ByVal strNonQuery As String)
        Try
            Using cmd As New SqlCommand(strNonQuery, conn)
                If Connect() Then
                    cmd.ExecuteNonQuery()
                    Close()
                End If
            End Using
        Catch ex As Exception
            Close()
        End Try
    End Sub

    Public Sub ExecuteNonQueryBinary(ByVal strNonQuery As String, ByRef binaryVal As Byte())
        Try
            Using cmd As New SqlCommand(strNonQuery, conn)
                If Connect() Then
                    cmd.Parameters.Add("@binaryVal", SqlDbType.VarBinary, binaryVal.Length).Value = binaryVal
                    cmd.ExecuteNonQuery()
                    Close()
                End If
            End Using
        Catch ex As Exception
            Close()
        End Try
    End Sub

    Public Function ExecuteQueryFile(ByVal strQuery As String) As Byte()
        ExecuteQueryFile = Nothing
        Try
            Using cmd As New SqlCommand(strQuery, conn)
                If Connect() Then
                    Using r As SqlDataReader = cmd.ExecuteReader()
                        If r.Read() Then
                            ExecuteQueryFile = r(0)
                        End If
                    End Using
                    Close()
                End If
            End Using
        Catch ex As Exception
            Close()
        End Try
        Return ExecuteQueryFile
    End Function

    Public Function ExecuteQueryIdentity(ByVal strQuery As String) As Integer
        ExecuteQueryIdentity = -1
        Try
            Using cmd As New SqlCommand(strQuery, conn)
                If Connect() Then
                    Using r As SqlDataReader = cmd.ExecuteReader()
                        If r.Read() Then
                            ExecuteQueryIdentity = r.GetInt32(0)
                        End If
                    End Using
                    Close()
                End If
            End Using
        Catch ex As Exception
            Close()
        End Try
        Return ExecuteQueryIdentity
    End Function

    Public Function ExecuteQuery(ByVal strQuery As String) As DataTable
        Try
            Using cmd As New SqlCommand(strQuery, conn)
                If Connect() Then
                    Dim dtUser As DataTable = create_vgUser()
                    Using r As SqlDataReader = cmd.ExecuteReader()
                        While r.Read
                            Dim drUser As DataRow = dtUser.NewRow
                            drUser(0) = r.GetInt32(0)
                            drUser(1) = r.GetString(1)
                            drUser(2) = r.GetInt32(2)
                            drUser(3) = r.GetInt64(3)
                            drUser(4) = r.GetInt32(4)
                            drUser(5) = r.GetDateTime(5)
                            drUser(6) = r.GetInt32(6)
                            drUser(7) = r.GetInt32(7)
                            dtUser.Rows.Add(drUser)
                        End While
                    End Using
                    Close()
                    Return dtUser
                End If
            End Using
        Catch ex As Exception
            Close()
        End Try
        Return Nothing
    End Function

    Public Function ExecuteQueryExt(ByVal strQuery As String) As DataTable
        Try
            Using cmd As New SqlCommand(strQuery, conn)
                If Connect() Then
                    Dim dtExt As DataTable = create_vgExt()
                    Using r As SqlDataReader = cmd.ExecuteReader()
                        While r.Read
                            Dim drExt As DataRow = dtExt.NewRow
                            drExt(0) = r.GetInt32(0)
                            drExt(1) = r.GetInt32(1)
                            drExt(2) = r.GetString(2)
                            drExt(3) = r.GetString(3)
                            dtExt.Rows.Add(drExt)
                        End While
                    End Using
                    Close()
                    Return dtExt
                End If
            End Using
        Catch ex As Exception
            Close()
        End Try
        Return Nothing
    End Function

    Public Function ExecuteQueryHistory(ByVal strQuery As String) As DataTable
        Try
            Using cmd As New SqlCommand(strQuery, conn)
                If Connect() Then
                    Dim dtFile As DataTable = create_vgFile()
                    Using r As SqlDataReader = cmd.ExecuteReader()
                        While r.Read
                            Dim drFile As DataRow = dtFile.NewRow
                            drFile(0) = r.GetInt32(0)
                            drFile(1) = r.GetInt32(1)
                            drFile(2) = r.GetString(2)
                            drFile(3) = r.GetDateTime(3)
                            drFile(4) = r.GetString(4)
                            dtFile.Rows.Add(drFile)
                        End While
                    End Using
                    Close()
                    Return dtFile
                End If
            End Using
        Catch ex As Exception
            Close()
        End Try
        Return Nothing
    End Function

    Public Function SetOnline(ByVal _username As String) As DataTable
        Try
            Using cmd As New SqlCommand("vgOnline", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@vgUser", _username)
                If Connect() Then
                    Dim dtUser As DataTable = create_vgUser()
                    Using r As SqlDataReader = cmd.ExecuteReader()
                        If r.Read Then
                            Dim drUser As DataRow = dtUser.NewRow
                            drUser(0) = r.GetInt32(0)
                            drUser(1) = r.GetString(1)
                            drUser(2) = r.GetInt32(2)
                            drUser(3) = r.GetInt64(3)
                            drUser(4) = r.GetInt32(4)
                            drUser(5) = r.GetDateTime(5)
                            drUser(6) = r.GetInt32(6)
                            drUser(7) = r.GetInt32(7)
                            dtUser.Rows.Add(drUser)
                        End If
                    End Using
                    Close()
                    Return dtUser
                End If
            End Using
        Catch ex As Exception
            Close()
        End Try
        Return Nothing
    End Function

    Private Function create_vgUser() As DataTable
        Dim vgUser As New DataTable
        vgUser.Columns.Add("UserID", GetType(Integer))
        vgUser.Columns.Add("UserName", GetType(String))
        vgUser.Columns.Add("UserLevel", GetType(Integer))
        vgUser.Columns.Add("UserExp", GetType(Long))
        vgUser.Columns.Add("UserMoney", GetType(Integer))
        vgUser.Columns.Add("LoginDate", GetType(Date))
        vgUser.Columns.Add("StoredToday", GetType(Integer))
        vgUser.Columns.Add("StoredTotal", GetType(Integer))
        Return vgUser
    End Function

    Private Function create_vgFile() As DataTable
        Dim vgUser As New DataTable
        vgUser.Columns.Add("FileID", GetType(Integer))
        vgUser.Columns.Add("UserID", GetType(Integer))
        vgUser.Columns.Add("Filename", GetType(String))
        vgUser.Columns.Add("FileDate", GetType(Date))
        vgUser.Columns.Add("ExternalLocation", GetType(String))
        Return vgUser
    End Function

    Private Function create_vgExt() As DataTable
        Dim vgUser As New DataTable
        vgUser.Columns.Add("ExternalFileID", GetType(Integer))
        vgUser.Columns.Add("UserID", GetType(Integer))
        vgUser.Columns.Add("FileFilter", GetType(String))
        vgUser.Columns.Add("FilePath", GetType(String))
        Return vgUser
    End Function
End Class