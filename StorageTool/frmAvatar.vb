Imports System.IO

Public Class frmAvatar
    Private frmConfWidth As Integer
    Private hExtra As Integer = 0
    Private blnAdditionalAnim As Boolean = False
    Private blnExternalPath As Boolean
    Private blnHistory As Boolean
    Private Const frmSmallHeight As Integer = 60
    Private Const hAdditional As Integer = 20
    Private Const hAdditionalAnim As Integer = 3
    Private Const hAdditionalVal As Integer = 10
    Private _UserID As Integer
    Private Shared ResourceStream As Dictionary(Of String, Stream) = Nothing
    Private frmGreeting As frmGreeting = Nothing
    Private ReadOnly ResourceFilename As IList(Of String) = {"boyr.png", "girlr.png", "belandar.png"}

    Public Sub New(ByVal _leftPos As Integer, ByVal UserID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        frmConfWidth = Me.Width
        Me.Location = New Point(_leftPos - frmConfWidth, 0)
        Me.Show()
        Me.Width = 10
        Me.Height = frmSmallHeight
        _UserID = UserID
        tmrConfig.Enabled = True
        PreloadResource()
    End Sub

#Region "Event Handlers"
    Private Sub frmMain_FormClosed(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        For Each iVal As KeyValuePair(Of String, Stream) In ResourceStream
            iVal.Value.Dispose()
        Next
        ResourceStream.Clear()
        ResourceStream = Nothing
    End Sub

    Private Sub btnExternalFile_Click(sender As System.Object, e As System.EventArgs) Handles btnExternalFile.Click
        If Not blnExternalPath Then
            blnExternalPath = True
            If blnHistory Then
                blnHistory = False
                gpShop.Visible = False
                gpSetup.Visible = True
            Else
                StartDisplayContent()
            End If
        Else
            blnExternalPath = False
            StartDisplayContent()
        End If
    End Sub

    Private Sub btnHistory_Click(sender As System.Object, e As System.EventArgs) Handles btnHistory.Click
        If Not blnHistory Then
            blnHistory = True
            If blnExternalPath Then
                blnExternalPath = False
                gpSetup.Visible = False
                gpShop.Visible = True
            Else
                StartDisplayContent()
            End If
        Else
            blnHistory = False
            StartDisplayContent()
        End If
    End Sub

    Private Sub gpSetup_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles gpSetup.VisibleChanged
        If gpSetup.Visible AndAlso DataGridView1.Rows.Count = 0 Then
            DataGridView1.Rows.Add(3)
            DataGridView1.Rows(0).Cells(0).Value = GetImage(0)
            DataGridView1.Rows(1).Cells(0).Value = GetImage(1)
            DataGridView1.Rows(2).Cells(0).Value = GetImage(2)
            DataGridView1.Rows(0).Cells(1).Value = "Gender"
            DataGridView1.Rows(1).Cells(1).Value = "Gender"
            DataGridView1.Rows(2).Cells(1).Value = "Ride"
            DataGridView1.Rows(0).Cells(2).Value = True
            DataGridView1.Rows(1).Cells(2).Value = False
            DataGridView1.Rows(2).Cells(2).Value = True
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If Not DataGridView1.IsDisposed AndAlso e.RowIndex > -1 AndAlso e.ColumnIndex = 2 Then
            If e.RowIndex = 0 Then
                DataGridView1.Rows(0).Cells(e.ColumnIndex).Value = True
                DataGridView1.Rows(1).Cells(e.ColumnIndex).Value = False
            ElseIf e.RowIndex = 1 Then
                DataGridView1.Rows(0).Cells(e.ColumnIndex).Value = False
                DataGridView1.Rows(1).Cells(e.ColumnIndex).Value = True
            ElseIf e.RowIndex = 2 Then
                DataGridView1.Rows(2).Cells(e.ColumnIndex).Value = False
            End If
        End If
    End Sub
#End Region

#Region "Timer"
    Private Sub tmrConfig_Tick(sender As System.Object, e As System.EventArgs) Handles tmrConfig.Tick
        If Not Me.IsDisposed AndAlso Me.Width < frmConfWidth Then
            Me.Width += 10
        Else
            If Not Me.IsDisposed Then
                Me.gpConfig.Visible = True
            End If
            tmrConfig.Enabled = False
        End If
    End Sub

    Private Sub tmrDisplayContent_Tick(sender As System.Object, e As System.EventArgs) Handles tmrDisplayContent.Tick
        If blnHistory OrElse blnExternalPath Then
            If Not blnAdditionalAnim Then
                Me.Height += hAdditionalVal
                hExtra += 1
                If hExtra >= hAdditional + hAdditionalAnim Then
                    blnAdditionalAnim = True
                End If
            Else
                Me.Height -= hAdditionalVal
                hExtra -= 1
                If hExtra = hAdditional Then
                    blnAdditionalAnim = False
                    tmrDisplayContent.Enabled = False
                    If blnHistory Then
                        gpSetup.Visible = False
                        gpShop.Visible = True
                    Else
                        gpShop.Visible = False
                        gpSetup.Visible = True
                    End If
                End If
            End If
        Else
            If Not blnAdditionalAnim Then
                Me.Height -= hAdditionalVal
                hExtra -= 1
                If hExtra <= 0 - hAdditionalAnim Then
                    blnAdditionalAnim = True
                End If
            Else
                Me.Height += hAdditionalVal
                hExtra += 1
                If hExtra = 0 Then
                    blnAdditionalAnim = False
                    tmrDisplayContent.Enabled = False
                    gpShop.Visible = False
                    gpSetup.Visible = False
                End If
            End If
        End If
    End Sub
#End Region

#Region "Sub"
    Private Sub StartDisplayContent()
        blnAdditionalAnim = False
        If Not tmrDisplayContent.Enabled Then
            tmrDisplayContent.Enabled = True
        End If
    End Sub

    Private Sub PreloadResource()
        Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim _prevName As String = String.Empty
        ResourceStream = New Dictionary(Of String, Stream)
        Try
            For Each _filename As String In ResourceFilename
                _prevName = _filename
                For Each _streamName As String In Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames()
                    If InStr(_streamName, _filename) <> 0 Then
                        _filename = _streamName
                        Exit For
                    End If
                Next
                If Not ResourceStream.ContainsKey(_prevName) Then
                    ResourceStream.Add(_prevName, myAssembly.GetManifestResourceStream(_filename))
                End If
            Next
        Catch ex As Exception

        Finally
            myAssembly = Nothing
        End Try
    End Sub

    Private Function GetImage(ByVal _ImageIndex As Integer) As Image
        Try
            Dim strFilename As String = ResourceFilename(_ImageIndex)
            If ResourceStream.ContainsKey(strFilename) AndAlso ResourceStream.Item(strFilename) IsNot Nothing Then
                Return Image.FromStream(ResourceStream.Item(strFilename))
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub DisplayGreetingForm()
        If frmGreeting IsNot Nothing AndAlso Not frmGreeting.IsDisposed Then
            frmGreeting.Close()
        End If
        frmGreeting = New frmGreeting
        frmGreeting.Show()
        frmGreeting.Location = New Point(Me.Left - frmGreeting.Width - 5, 0)
    End Sub
#End Region
End Class