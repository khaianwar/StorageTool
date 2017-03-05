Public Class objExternalFile
    Public Event RemObject(ByRef objExtFile As objExternalFile)
    Private _fileFilter As String
    Private _filePath As String
    Public Property fileFilter As String
        Get
            Return _fileFilter
        End Get
        Set(value As String)
            _fileFilter = value
            txtFilter.Text = value
        End Set
    End Property
    Public Property filePath As String
        Get
            Return _filePath
        End Get
        Set(value As String)
            _filePath = value
            txtExternal.Text = value
        End Set
    End Property

    Public Sub RemMinusBtn()
        btnMinus.Visible = False
    End Sub

    Public Sub ShowMinusBtn()
        btnMinus.Visible = True
    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        If fBrowser.ShowDialog() = DialogResult.OK Then
            _filePath = fBrowser.SelectedPath()
        End If
    End Sub

    Private Sub btnMinus_Click(sender As System.Object, e As System.EventArgs) Handles btnMinus.Click
        RaiseEvent RemObject(Me)
    End Sub

    Private Sub txtExternal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtExternal.TextChanged
        _filePath = txtExternal.Text
    End Sub

    Private Sub txtFilter_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFilter.TextChanged
        _fileFilter = txtFilter.Text
    End Sub
End Class
