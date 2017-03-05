Imports System.IO

Public Class frmGreeting
    Private Shared ResourceStream As Dictionary(Of String, Stream) = Nothing
    Private _blnGender As Boolean = False
    Private ReadOnly ResourceFilename As IList(Of String) = {"boyr.png", "girlr.png", "belandar.png"}

    Public Sub New(Optional ByVal blnGender As Boolean = False)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _blnGender = blnGender
    End Sub

    Private Sub frmGreeting_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        tmrStartClose.Enabled = True
    End Sub

    Private Sub tmrClose_Tick(sender As System.Object, e As System.EventArgs) Handles tmrClose.Tick
        Me.Opacity -= 0.05D
        If Me.Opacity <= 0 Then
            tmrClose.Enabled = False
            Me.Close()
        End If
    End Sub

    Private Sub tmrStartClose_Tick(sender As System.Object, e As System.EventArgs) Handles tmrStartClose.Tick
        tmrStartClose.Enabled = False
        tmrClose.Enabled = True
    End Sub

    Private Sub frmGreeting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PreloadResource()
        picRide.Image = GetImage(2)
        picRide.BackgroundImageLayout = ImageLayout.Center
        picAvatar.Parent = picRide
        If _blnGender Then
            picAvatar.Image = GetImage(1)
        Else
            picAvatar.Image = GetImage(0)
        End If
        picAvatar.BackColor = Color.Transparent
    End Sub

    Private Sub frmMain_FormClosed(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        For Each iVal As KeyValuePair(Of String, Stream) In ResourceStream
            iVal.Value.Dispose()
        Next
        ResourceStream.Clear()
        ResourceStream = Nothing
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
End Class