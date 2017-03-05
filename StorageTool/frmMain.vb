Imports System.IO
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports System.Collections.Concurrent

Public Class frmMain
#Region "WinAPI declarations"
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SetParent(ByVal child As IntPtr, ByVal parent As IntPtr) As Integer
    End Function
#End Region

#Region "Private Variables"
    Private frmSize As Size = New Size(296, 166)
    Private Const hAdditional As Integer = 22
    Private Const hAdditionalAnim As Integer = 3
    Private Const hAdditionalVal As Integer = 10
    Private blnAdditionalAnim As Boolean = False
    Private hExtra As Integer = 0
    Private ReadOnly ResourceFilename As IList(Of String) = {"Folder.png", "Folder_Animated.gif", "trophy_gold.png", "trophy_silver.png", "trophy_bronze.png"}
    Private Enum FileImage
        Folder = 0
        Folder_Animate = 1
    End Enum
    Private Shared ResourceStream As Dictionary(Of String, Stream) = Nothing
    Private blnAvatarAnimate As Boolean = False
    Private blnSettings As Boolean = False
    Private blnAvatar As Boolean = False
    Private frmGreeting As frmGreeting = Nothing
    Private frmConfig As Form = Nothing
    Private dbConBg1 As DAL = Nothing
    Private dbConBg2 As DAL = Nothing
    Private dbConBg3 As DAL = Nothing
    Private dbConBg4 As DAL = Nothing
    Private vgUser As DataTable = Nothing
    Private vgFame As DataTable = Nothing
    Private userLevel As Integer = 1
    Private userMoney As Integer = 1
    Private userExp As Long = 0
    Private userExpGain As Long = 0
    Private userToday As Integer = 0
    Private userTotal As Integer = 0
    Private UserID As Integer = -1
    Private Const queryFame As String = "SELECT TOP 3 * from vgUser ORDER BY UserExp DESC"
    Private Const queryExternalFile As String = "SELECT * from vgExternalFile WHERE UserID={0}"
    Private Const queryInsertFile As String = "INSERT INTO vgFile (UserID,Filename,FileDate,ExternalLocation) VALUES ({0},'{1}',GETDATE(),'{2}'); SELECT FileID from vgFile where FileID=@@IDENTITY;"
    Private Const queryInsertFileByte As String = "INSERT INTO vgFileByte (FileID,FileBytes) VALUES ({0},@binaryVal)"
    Private ConcurrentFiles As New Stack(Of String)
#End Region

#Region "Event Handlers"
    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.ShowInTaskbar = False
        Me.Size = frmSize
        trayIcon.Icon = Me.Icon
        DisplayTray()
        DefaultLocation()
        PreloadResource()
        PrealoadHallofFame()
        LoadAvatarImage(FileImage.Folder)
        SetParent(Me.Handle, FindWindow("progman", Microsoft.VisualBasic.vbNullString))
        Me.gpMain.Text = Environment.UserName
        bgVgUser.RunWorkerAsync()
    End Sub

    Private Sub bgVgUser_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgVgUser.DoWork
        dbConBg1 = New DAL
        vgUser = dbConBg1.SetOnline(gpMain.Text)
    End Sub

    Private Sub bgVgUser_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgVgUser.RunWorkerCompleted
        If e.Cancelled = True Then
        ElseIf e.Error IsNot Nothing Then
        Else
            If vgUser IsNot Nothing AndAlso vgUser.Rows.Count > 0 Then
                With vgUser.Rows(0)
                    userLevel = .Item("UserLevel")
                    userMoney = .Item("UserMoney")
                    lblMoney.Text = String.Format("$ {0}", userMoney.ToString)
                    userToday = .Item("StoredToday")
                    userTotal = .Item("StoredTotal")
                    lblToday.Text = userToday.ToString
                    lblTotal.Text = userTotal.ToString
                    lblLevel.Text = userLevel.ToString
                    userExp = .Item("UserExp")
                    UserID = .Item("UserID")
                End With
            End If
        End If
        dbConBg1.DisposeAll()
        dbConBg1 = Nothing
    End Sub

    Private Sub bgVgFame_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgVgFame.DoWork
        dbConBg2 = New DAL
        vgFame = dbConBg2.ExecuteQuery(queryFame)
    End Sub

    Private Sub bgVgFame_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgVgFame.RunWorkerCompleted
        If e.Cancelled = True Then
        ElseIf e.Error IsNot Nothing Then
        Else
            If vgFame IsNot Nothing AndAlso vgFame.Rows.Count > 0 Then
                For i As Integer = 0 To vgFame.Rows.Count - 1
                    With vgFame.Rows(i)
                        dgvFame.Rows(i).Cells(1).Value = .Item("UserName")
                    End With
                Next
            End If
        End If
        dbConBg2.DisposeAll()
        dbConBg2 = Nothing
    End Sub

    Private Sub bgProcessFile_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgProcessFile.DoWork
        Dim strFilePath As String = String.Empty
        Dim vgExternalFile As DataTable = Nothing
        dbConBg3 = New DAL
        vgExternalFile = dbConBg3.ExecuteQueryExt(String.Format(queryExternalFile, UserID.ToString))
        While ConcurrentFiles.Count > 0
            strFilePath = ConcurrentFiles.Pop()
            BackupToDB(strFilePath, CopyToExternal(strFilePath, vgExternalFile))
            userExpGain += 1
            userToday += 1
            userTotal += 1
        End While
    End Sub

    Private Sub bgProcessFile_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgProcessFile.RunWorkerCompleted
        If blnAvatarAnimate Then
            LoadAvatarImage(FileImage.Folder)
            blnAvatarAnimate = False
        End If
        tmrGainExp.Enabled = True
        dbConBg3.DisposeAll()
        dbConBg3 = Nothing
    End Sub

    Private Sub frmMain_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
            LoadAvatarImage(FileImage.Folder_Animate)
            blnAvatarAnimate = True
        End If
    End Sub

    Private Sub frmMain_DragLeave(sender As System.Object, e As System.EventArgs) Handles MyBase.DragLeave
        If blnAvatarAnimate Then
            LoadAvatarImage(FileImage.Folder)
            blnAvatarAnimate = False
        End If
    End Sub

    Private Sub frmMain_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path As String In files
            ConcurrentFiles.Push(path)
        Next
        If Not bgProcessFile.IsBusy Then
            bgProcessFile.RunWorkerAsync()
        End If
    End Sub

    Private Sub frmMain_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        If frmGreeting Is Nothing Then
            DisplayGreetingForm()
        End If
    End Sub

    Private Sub btnConfigureFile_Click(sender As System.Object, e As System.EventArgs) Handles btnSettingsMgr.Click
        If blnSettings Then
            blnSettings = False
        Else
            blnSettings = True
            If blnAvatar Then
                blnAvatar = False
                DisplayConfigForm()
            End If
        End If
        DisplayConfigForm()
    End Sub

    Private Sub btnAvatarMgr_Click(sender As System.Object, e As System.EventArgs) Handles btnAvatarMgr.Click
        If blnAvatar Then
            blnAvatar = False
        Else
            blnAvatar = True
            If blnSettings Then
                blnSettings = False
                DisplayConfigForm()
            End If
        End If
        DisplayConfigForm()
    End Sub

    Private Sub frmMain_FormClosed(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosed
        HideTray()
        For Each iVal As KeyValuePair(Of String, Stream) In ResourceStream
            iVal.Value.Dispose()
        Next
        ResourceStream.Clear()
        ResourceStream = Nothing
    End Sub

    Private Sub ExitToolStripMenuItem_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ExitToolStripMenuItem.MouseUp
        Me.Close()
    End Sub

    Private Sub btnDisplayMore_Click(sender As System.Object, e As System.EventArgs) Handles btnDisplayMore.Click
        btnDisplayMore.Visible = False
        tmrDisplayMore.Enabled = True
    End Sub

    Private Sub btnDisplayLess_Click(sender As System.Object, e As System.EventArgs) Handles btnDisplayLess.Click
        btnDisplayLess.Visible = False
        tmrDisplayLess.Enabled = True
        blnAvatar = False
        blnSettings = False
        If frmConfig IsNot Nothing AndAlso Not frmConfig.IsDisposed Then
            frmConfig.Close()
        End If
    End Sub

    Private Sub gpExtras_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles gpExtras.VisibleChanged
        If gpExtras.Visible AndAlso Not bgVgFame.IsBusy Then
            bgVgFame.RunWorkerAsync()
        End If
    End Sub
#End Region

#Region "Timer"
    Private Sub tmrDisplayMore_Tick(sender As System.Object, e As System.EventArgs) Handles tmrDisplayMore.Tick
        If Not blnAdditionalAnim Then
            Me.Height += hAdditionalVal
            hExtra += 1
            If hExtra = hAdditional + hAdditionalAnim Then
                blnAdditionalAnim = True
            End If
        Else
            Me.Height -= hAdditionalVal
            hExtra -= 1
            If hExtra = hAdditional Then
                blnAdditionalAnim = False
                tmrDisplayMore.Enabled = False
                btnDisplayLess.Visible = True
                gpExtras.Visible = True
                gpAvatar.Visible = True
                gpSetting.Visible = True
            End If
        End If
    End Sub

    Private Sub tmrDisplayLess_Tick(sender As System.Object, e As System.EventArgs) Handles tmrDisplayLess.Tick
        If Not blnAdditionalAnim Then
            Me.Height -= hAdditionalVal
            hExtra -= 1
            If hExtra = 0 - hAdditionalAnim Then
                blnAdditionalAnim = True
            End If
        Else
            Me.Height += hAdditionalVal
            hExtra += 1
            If hExtra = 0 Then
                blnAdditionalAnim = False
                tmrDisplayLess.Enabled = False
                gpExtras.Visible = False
                gpAvatar.Visible = False
                gpSetting.Visible = False
                btnDisplayMore.Visible = True
            End If
        End If
    End Sub

    Private Sub tmrGainExp_Tick(sender As System.Object, e As System.EventArgs) Handles tmrGainExp.Tick
        If userExp < userExpGain Then
            userExp += 1
            progressExp.PerformStep()
            If progressExp.Value >= progressExp.Maximum Then
                AnimateLevelUp()
            End If
        Else
            tmrGainExp.Enabled = False
            lblToday.Text = userToday.ToString
            lblTotal.Text = userTotal.ToString
            If ConcurrentFiles.Count > 0 AndAlso Not bgProcessFile.IsBusy Then
                bgProcessFile.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub tmrStopAnimLvl_Tick(sender As System.Object, e As System.EventArgs) Handles tmrStopAnimLvl.Tick
        progressExp.Value = 0
        picLevelUp.Visible = False
        tmrStopAnimLvl.Enabled = False
    End Sub
#End Region

#Region "Tray Icon Setup"
    Private Sub DisplayTray()
        trayIcon.BalloonTipIcon = ToolTipIcon.Info
        trayIcon.Visible = True
        trayIcon.BalloonTipTitle = "Vagrant - Storage Tool"
        trayIcon.BalloonTipText = "Application Started"
        trayIcon.ShowBalloonTip(2000)
    End Sub

    Private Sub HideTray()
        trayIcon.Visible = False
        trayIcon.Dispose()
        trayIcon = Nothing
    End Sub

    Private Sub DefaultLocation()
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, 0)
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

    Private Sub PrealoadHallofFame()
        dgvFame.Rows.Add(3)
        dgvFame.Rows(0).Cells(0).Value = GetImage(2)
        dgvFame.Rows(1).Cells(0).Value = GetImage(3)
        dgvFame.Rows(2).Cells(0).Value = GetImage(4)
    End Sub

    Private Sub LoadAvatarImage(ByVal _ImageIndex As Integer)
        Try
            Dim strFilename As String = ResourceFilename(_ImageIndex)
            If ResourceStream.ContainsKey(strFilename) AndAlso ResourceStream.Item(strFilename) IsNot Nothing Then
                picAvatar.Image = Image.FromStream(ResourceStream.Item(strFilename))
            End If
        Catch ex As Exception

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
        frmGreeting = New frmGreeting
        frmGreeting.Show()
        frmGreeting.Location = New Point(Me.Left - frmGreeting.Width - 5, 0)
    End Sub

    Private Sub DisplayConfigForm()
        If frmConfig Is Nothing OrElse frmConfig.IsDisposed Then
            If blnAvatar Then
                frmConfig = New frmAvatar(Me.Left, UserID)
            ElseIf blnSettings Then
                frmConfig = New frmConfiguration(Me.Left, UserID)
            End If
        Else
            frmConfig.Close()
        End If
    End Sub

    Private Sub AnimateLevelUp()
        userLevel += 1
        userMoney += userLevel
        picLevelUp.Visible = True
        lblLevel.Text = (userLevel).ToString
        lblMoney.Text = String.Format("$ {0}", userMoney.ToString)
        tmrStopAnimLvl.Enabled = True
    End Sub

    Private Function CopyToExternal(ByVal _path As String, ByRef _vgExternalFile As DataTable) As String
        Try
            Dim _filename As String = GetFileName(_path)
            CopyToExternal = Nothing
            Using tmpTbl As New DataTable
                tmpTbl.Columns.Add("FilePath", GetType(String))
                tmpTbl.Rows.Add(tmpTbl.NewRow())
                tmpTbl.Rows(0).Item(0) = _filename
                For Each _dr As DataRow In _vgExternalFile.Rows
                    If tmpTbl.Select("FilePath like '" & Replace(_dr.Item("FileFilter").ToString, "*", "%") & "'").Length > 0 Then
                        File.Copy(_path, CheckProperDir(_dr.Item("FilePath").ToString) & _filename, True)
                        CopyToExternal = _dr.Item("FilePath").ToString
                    End If
                Next
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function CheckProperDir(ByVal _strPath As String) As String
        Dim _strRight As Char = Microsoft.VisualBasic.Right(_strPath, 1)
        If _strRight <> "/"c AndAlso _strRight <> "\"c Then
            Return _strPath & "\"
        End If
        Return _strPath
    End Function

    Private Sub BackupToDB(ByVal _path As String, ByVal _extpath As String)
        Try
            Dim _filename As String = Nothing
            Dim identID As Integer
            Dim binaryVal As Byte() = File.ReadAllBytes(_path)
            dbConBg4 = New DAL
            _filename = GetFileName(_path)
            identID = dbConBg4.ExecuteQueryIdentity(String.Format(queryInsertFile, UserID.ToString, _filename, _extpath))
            If identID > 0 Then
                dbConBg4.ExecuteNonQueryBinary(String.Format(queryInsertFileByte, identID.ToString), binaryVal)
            End If
        Catch ex As Exception
        Finally
            dbConBg4.DisposeAll()
            dbConBg4 = Nothing
        End Try
    End Sub

    Private Function GetFileName(ByVal _path As String) As String
        Dim bIndex As Integer = InStrRev(_path, "/"c)
        Dim fIndex As Integer = InStrRev(_path, "\"c)
        If bIndex > fIndex Then
            Return Mid(_path, bIndex + 1)
        Else
            Return Mid(_path, fIndex + 1)
        End If
    End Function
#End Region
End Class
