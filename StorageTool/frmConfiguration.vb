Imports System.IO

Public Class frmConfiguration
    Private frmConfWidth As Integer
    Private hExtra As Integer = 0
    Private blnAdditionalAnim As Boolean = False
    Private blnExternalPath As Boolean
    Private blnHistory As Boolean
    Private Const frmSmallHeight As Integer = 60
    Private Const hAdditional As Integer = 20
    Private Const hAdditionalAnim As Integer = 3
    Private Const hAdditionalVal As Integer = 10
    Private dbCon As DAL = Nothing
    Private dbCon2 As DAL = Nothing
    Private dbCon3 As DAL = Nothing
    Private vgExternalFile As DataTable = Nothing
    Private vgFileHistory As DataTable = Nothing
    Private _UserID As Integer
    Private Const queryExternalFile As String = "SELECT * from vgExternalFile WHERE UserID={0}"
    Private Const nonqueryExtDelete As String = "DELETE from vgExternalFile WHERE UserID={0}"
    Private Const queryFileHistory As String = "SELECT * from vgFile WHERE UserID={0}"
    Private Const queryFileByte As String = "SELECT FileBytes from vgFileByte WHERE FileID={0}"
    Private Const nonqueryInsertExt As String = "INSERT INTO vgExternalFile (UserID,FileFilter,FilePath) VALUES ({0},'{1}','{2}')"
    Private objExternalFiles As New List(Of objExternalFile)
    Private objBtnAdd As Button = Nothing
    Private Const intGap As Integer = 1

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
    End Sub

#Region "Event Handlers"
    Private Sub MeFormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If pnlExternalFile.Visible Then
                dbCon2 = New DAL
                dbCon2.ExecuteNonQuery(String.Format(nonqueryExtDelete, _UserID.ToString))
                For Each objExt As objExternalFile In objExternalFiles
                    If objExt.fileFilter <> "" AndAlso objExt.filePath <> "" AndAlso objExt.fileFilter.Trim <> "" AndAlso Directory.Exists(objExt.filePath.Trim) Then
                        dbCon2.ExecuteNonQuery(String.Format(nonqueryInsertExt, _UserID.ToString, objExt.fileFilter.Trim, objExt.filePath.Trim))
                    End If
                Next
                dbCon2.DisposeAll()
                dbCon2 = Nothing
            End If
        Catch ex As Exception
            dbCon2 = Nothing
        End Try
    End Sub

    Private Sub MeFormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If pnlExternalFile.Visible Then
            pnlExternalFile.Visible = False
        End If
    End Sub

    Private Sub btnExternalFile_Click(sender As System.Object, e As System.EventArgs) Handles btnExternalFile.Click
        If Not blnExternalPath Then
            blnExternalPath = True
            If blnHistory Then
                blnHistory = False
                gpHistory.Visible = False
                pnlExternalFile.Visible = True
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
                pnlExternalFile.Visible = False
                gpHistory.Visible = True
            Else
                StartDisplayContent()
            End If
        Else
            blnHistory = False
            StartDisplayContent()
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
                        pnlExternalFile.Visible = False
                        gpHistory.Visible = True
                    Else
                        gpHistory.Visible = False
                        pnlExternalFile.Visible = True
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
                    gpHistory.Visible = False
                    pnlExternalFile.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub pnlExternalFile_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles pnlExternalFile.VisibleChanged
        If pnlExternalFile.Visible Then
            Dim objlbl As New Label
            pnlExternalFile.Controls.Add(objlbl)
            objlbl.Text = "External File Transfer"
            objlbl.AutoSize = True
            objlbl.Location = New Point(7, 2)
            Dim objConf As New objExternalFile
            pnlExternalFile.Controls.Add(objConf)
            objConf.Location = New Point(5, 15)
            objExternalFiles.Add(objConf)
            PreloadExternalFile()
            PopulateExternalFile()
        Else
            Dim xControl As Control
            objExternalFiles.Clear()
            For i As Integer = pnlExternalFile.Controls.Count - 1 To 0 Step -1
                xControl = pnlExternalFile.Controls(i)
                pnlExternalFile.Controls.Remove(xControl)
                xControl.Dispose()
                xControl = Nothing
            Next
        End If
    End Sub

    Private Sub gpHistory_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles gpHistory.VisibleChanged
        If gpHistory.Visible Then
            PreloadFileHistory()
        End If
    End Sub

    Private Sub pnlExternalFile_ControlAdded(sender As System.Object, e As System.Windows.Forms.ControlEventArgs) Handles pnlExternalFile.ControlAdded
        If e.Control.GetType().IsEquivalentTo(GetType(objExternalFile)) Then
            Dim eObjCast As objExternalFile = e.Control
            AddHandler eObjCast.RemObject, AddressOf RemObjectExternalFile
        End If
    End Sub

    Private Sub pnlExternalFile_ControlRemoved(sender As System.Object, e As System.Windows.Forms.ControlEventArgs) Handles pnlExternalFile.ControlRemoved
        If e.Control.GetType().IsEquivalentTo(GetType(objExternalFile)) Then
            Dim eObjCast As objExternalFile = e.Control
            RemoveHandler eObjCast.RemObject, AddressOf RemObjectExternalFile
        End If
    End Sub

    Private Sub dgvHistory_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHistory.CellContentClick
        Try
            Dim fbyte As Byte() = Nothing
            Dim filename As String = ""
            Dim strPath As String = System.AppDomain.CurrentDomain.BaseDirectory()
            dbCon3 = New DAL
            For Each _dr As DataRow In vgFileHistory.Select(String.Format("Filename='{0}'", dgvHistory.Rows(e.RowIndex).Cells(1).Value))
                filename = _dr.Item("Filename").ToString
                fbyte = dbCon3.ExecuteQueryFile(String.Format(queryFileByte, _dr.Item("FileID")))
                Exit For
            Next
            If fbyte IsNot Nothing AndAlso fbyte.Length > 0 AndAlso Not File.Exists(strPath & "\" & filename) Then
                File.WriteAllBytes(strPath & filename, fbyte)
            End If
            dbCon3.DisposeAll()
            dbCon3 = Nothing
        Catch ex As Exception
            dbCon3 = Nothing
        End Try
    End Sub
#End Region

#Region "Sub"
    Private Sub StartDisplayContent()
        blnAdditionalAnim = False
        If Not tmrDisplayContent.Enabled Then
            tmrDisplayContent.Enabled = True
        End If
    End Sub

    Private Sub RemObjectExternalFile(ByRef objExtFile As objExternalFile)
        pnlExternalFile.Controls.Remove(objExtFile)
        objExternalFiles.Remove(objExtFile)
        objExtFile.Dispose()
        objExtFile = Nothing
        If objExternalFiles.Count = 1 Then
            objExternalFiles(0).RemMinusBtn()
        End If
        ReOrganizeExternalObj()
    End Sub

    Private Sub PreloadExternalFile()
        Try
            If _UserID > 0 Then
                dbCon = New DAL
                vgExternalFile = dbCon.ExecuteQueryExt(String.Format(queryExternalFile, _UserID.ToString))
                dbCon.DisposeAll()
                dbCon = Nothing
            End If
        Catch ex As Exception
            dbCon = Nothing
        End Try
    End Sub

    Private Sub PreloadFileHistory()
        Try
            If _UserID > 0 Then
                dbCon = New DAL
                vgFileHistory = dbCon.ExecuteQueryHistory(String.Format(queryFileHistory, _UserID.ToString))
                If vgFileHistory IsNot Nothing AndAlso vgFileHistory.Rows.Count > 0 Then
                    dgvHistory.Rows.Add(vgFileHistory.Rows.Count)
                    For i As Integer = 0 To vgFileHistory.Rows.Count - 1
                        dgvHistory.Rows(i).Cells(0).Value = vgFileHistory.Rows(i).Item("FileDate")
                        dgvHistory.Rows(i).Cells(1).Value = vgFileHistory.Rows(i).Item("Filename").ToString
                        dgvHistory.Rows(i).Cells(2).Value = vgFileHistory.Rows(i).Item("ExternalLocation").ToString
                    Next
                End If
                dbCon.DisposeAll()
                dbCon = Nothing
            End If
        Catch ex As Exception
            dbCon = Nothing
        End Try
    End Sub

    Private Sub PopulateExternalFile()
        If vgExternalFile IsNot Nothing AndAlso vgExternalFile.Rows.Count > 0 Then
            With vgExternalFile.Rows(0)
                objExternalFiles(0).fileFilter = .Item("FileFilter").ToString
                objExternalFiles(0).filePath = .Item("FilePath").ToString
            End With
            If vgExternalFile.Rows.Count > 1 Then
                For i As Integer = 1 To vgExternalFile.Rows.Count - 1
                    AddExternalFileObj(Nothing, Nothing)
                Next
            Else
                objExternalFiles(0).RemMinusBtn()
            End If
        Else
            objExternalFiles(0).RemMinusBtn()
        End If
        If objBtnAdd IsNot Nothing Then
            RemoveHandler objBtnAdd.Click, AddressOf AddExternalFileObj
            objBtnAdd = Nothing
        End If
        objBtnAdd = New Button
        objBtnAdd.Size = New Size(22, 20)
        objBtnAdd.Text = "+"
        objBtnAdd.TextAlign = ContentAlignment.MiddleRight
        AddHandler objBtnAdd.Click, AddressOf AddExternalFileObj
        pnlExternalFile.Controls.Add(objBtnAdd)
        objBtnAdd.Location = New Point(5 + objExternalFiles(0).Width / 2, 15 + ((objExternalFiles(0).Height + intGap) * objExternalFiles.Count) - pnlExternalFile.VerticalScroll.Value)
    End Sub

    Private Sub AddExternalFileObj(sender As System.Object, e As System.EventArgs)
        Dim objConf As New objExternalFile
        pnlExternalFile.Controls.Add(objConf)
        objConf.Location = New Point(5, 15 + (objConf.Height * objExternalFiles.Count) - pnlExternalFile.VerticalScroll.Value)
        objExternalFiles.Add(objConf)
        objBtnAdd.Location = New Point(5 + objExternalFiles(0).Width / 2, 15 + ((objExternalFiles(0).Height + intGap) * objExternalFiles.Count) - pnlExternalFile.VerticalScroll.Value)
    End Sub

    Private Sub ReOrganizeExternalObj()
        For i As Integer = 0 To objExternalFiles.Count - 1
            objExternalFiles(i).Location = New Point(5, 15 + (objExternalFiles(i).Height * i) - pnlExternalFile.VerticalScroll.Value)
        Next
        objBtnAdd.Location = New Point(5 + objExternalFiles(0).Width / 2, 15 + ((objExternalFiles(0).Height + intGap) * objExternalFiles.Count) - pnlExternalFile.VerticalScroll.Value)
    End Sub
#End Region
End Class