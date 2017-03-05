<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.trayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.trayPopup = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.picAvatar = New System.Windows.Forms.PictureBox()
        Me.progressExp = New System.Windows.Forms.ProgressBar()
        Me.tmrAvatar = New System.Windows.Forms.Timer(Me.components)
        Me.btnDisplayMore = New System.Windows.Forms.Button()
        Me.btnDisplayLess = New System.Windows.Forms.Button()
        Me.tmrDisplayMore = New System.Windows.Forms.Timer(Me.components)
        Me.tmrDisplayLess = New System.Windows.Forms.Timer(Me.components)
        Me.gpExtras = New System.Windows.Forms.GroupBox()
        Me.dgvFame = New System.Windows.Forms.DataGridView()
        Me.Award = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gpSetting = New System.Windows.Forms.GroupBox()
        Me.btnSettingsMgr = New System.Windows.Forms.Button()
        Me.gpMain = New System.Windows.Forms.GroupBox()
        Me.lblToday = New System.Windows.Forms.Label()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.picLevelUp = New System.Windows.Forms.PictureBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblMoney = New System.Windows.Forms.Label()
        Me.picGold = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gpAvatar = New System.Windows.Forms.GroupBox()
        Me.btnAvatarMgr = New System.Windows.Forms.Button()
        Me.bgVgUser = New System.ComponentModel.BackgroundWorker()
        Me.bgVgFame = New System.ComponentModel.BackgroundWorker()
        Me.tmrGainExp = New System.Windows.Forms.Timer(Me.components)
        Me.bgProcessFile = New System.ComponentModel.BackgroundWorker()
        Me.tmrStopAnimLvl = New System.Windows.Forms.Timer(Me.components)
        Me.trayPopup.SuspendLayout()
        CType(Me.picAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpExtras.SuspendLayout()
        CType(Me.dgvFame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpSetting.SuspendLayout()
        Me.gpMain.SuspendLayout()
        CType(Me.picLevelUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picGold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpAvatar.SuspendLayout()
        Me.SuspendLayout()
        '
        'trayIcon
        '
        Me.trayIcon.ContextMenuStrip = Me.trayPopup
        Me.trayIcon.Text = "Vagrant - Storage Tool"
        Me.trayIcon.Visible = True
        '
        'trayPopup
        '
        Me.trayPopup.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.trayPopup.Name = "trayPopup"
        Me.trayPopup.Size = New System.Drawing.Size(93, 26)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'picAvatar
        '
        Me.picAvatar.Location = New System.Drawing.Point(182, 12)
        Me.picAvatar.Name = "picAvatar"
        Me.picAvatar.Size = New System.Drawing.Size(102, 98)
        Me.picAvatar.TabIndex = 1
        Me.picAvatar.TabStop = False
        '
        'progressExp
        '
        Me.progressExp.Location = New System.Drawing.Point(12, 122)
        Me.progressExp.Name = "progressExp"
        Me.progressExp.Size = New System.Drawing.Size(272, 19)
        Me.progressExp.Step = 50
        Me.progressExp.TabIndex = 2
        '
        'btnDisplayMore
        '
        Me.btnDisplayMore.Image = CType(resources.GetObject("btnDisplayMore.Image"), System.Drawing.Image)
        Me.btnDisplayMore.Location = New System.Drawing.Point(128, 150)
        Me.btnDisplayMore.Name = "btnDisplayMore"
        Me.btnDisplayMore.Size = New System.Drawing.Size(43, 14)
        Me.btnDisplayMore.TabIndex = 3
        Me.btnDisplayMore.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDisplayMore.UseVisualStyleBackColor = True
        '
        'btnDisplayLess
        '
        Me.btnDisplayLess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDisplayLess.Image = CType(resources.GetObject("btnDisplayLess.Image"), System.Drawing.Image)
        Me.btnDisplayLess.Location = New System.Drawing.Point(128, 370)
        Me.btnDisplayLess.Name = "btnDisplayLess"
        Me.btnDisplayLess.Size = New System.Drawing.Size(43, 14)
        Me.btnDisplayLess.TabIndex = 8
        Me.btnDisplayLess.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDisplayLess.UseVisualStyleBackColor = True
        Me.btnDisplayLess.Visible = False
        '
        'tmrDisplayMore
        '
        Me.tmrDisplayMore.Interval = 15
        '
        'tmrDisplayLess
        '
        Me.tmrDisplayLess.Interval = 15
        '
        'gpExtras
        '
        Me.gpExtras.Controls.Add(Me.dgvFame)
        Me.gpExtras.Location = New System.Drawing.Point(12, 156)
        Me.gpExtras.Name = "gpExtras"
        Me.gpExtras.Padding = New System.Windows.Forms.Padding(5)
        Me.gpExtras.Size = New System.Drawing.Size(272, 113)
        Me.gpExtras.TabIndex = 5
        Me.gpExtras.TabStop = False
        Me.gpExtras.Text = "Hall of F&ame"
        Me.gpExtras.Visible = False
        '
        'dgvFame
        '
        Me.dgvFame.AllowUserToAddRows = False
        Me.dgvFame.AllowUserToDeleteRows = False
        Me.dgvFame.AllowUserToResizeColumns = False
        Me.dgvFame.AllowUserToResizeRows = False
        Me.dgvFame.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFame.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvFame.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Award, Me.Username})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFame.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvFame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFame.Location = New System.Drawing.Point(5, 18)
        Me.dgvFame.MultiSelect = False
        Me.dgvFame.Name = "dgvFame"
        Me.dgvFame.ReadOnly = True
        Me.dgvFame.RowHeadersVisible = False
        Me.dgvFame.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvFame.Size = New System.Drawing.Size(262, 90)
        Me.dgvFame.TabIndex = 0
        '
        'Award
        '
        Me.Award.HeaderText = "Award"
        Me.Award.Name = "Award"
        Me.Award.ReadOnly = True
        '
        'Username
        '
        Me.Username.HeaderText = "Username"
        Me.Username.Name = "Username"
        Me.Username.ReadOnly = True
        '
        'gpSetting
        '
        Me.gpSetting.Controls.Add(Me.btnSettingsMgr)
        Me.gpSetting.Location = New System.Drawing.Point(12, 319)
        Me.gpSetting.Name = "gpSetting"
        Me.gpSetting.Size = New System.Drawing.Size(272, 48)
        Me.gpSetting.TabIndex = 7
        Me.gpSetting.TabStop = False
        Me.gpSetting.Text = "S&ettings"
        Me.gpSetting.Visible = False
        '
        'btnSettingsMgr
        '
        Me.btnSettingsMgr.Location = New System.Drawing.Point(55, 16)
        Me.btnSettingsMgr.Name = "btnSettingsMgr"
        Me.btnSettingsMgr.Size = New System.Drawing.Size(164, 24)
        Me.btnSettingsMgr.TabIndex = 0
        Me.btnSettingsMgr.Text = "View Settings Manager"
        Me.btnSettingsMgr.UseVisualStyleBackColor = True
        '
        'gpMain
        '
        Me.gpMain.Controls.Add(Me.picLevelUp)
        Me.gpMain.Controls.Add(Me.lblToday)
        Me.gpMain.Controls.Add(Me.lblLevel)
        Me.gpMain.Controls.Add(Me.lblTotal)
        Me.gpMain.Controls.Add(Me.lblMoney)
        Me.gpMain.Controls.Add(Me.picGold)
        Me.gpMain.Controls.Add(Me.Label4)
        Me.gpMain.Controls.Add(Me.Label3)
        Me.gpMain.Controls.Add(Me.Label2)
        Me.gpMain.Controls.Add(Me.Label1)
        Me.gpMain.Controls.Add(Me.Label5)
        Me.gpMain.Controls.Add(Me.Label8)
        Me.gpMain.Controls.Add(Me.Label7)
        Me.gpMain.Location = New System.Drawing.Point(12, 12)
        Me.gpMain.Name = "gpMain"
        Me.gpMain.Size = New System.Drawing.Size(159, 98)
        Me.gpMain.TabIndex = 0
        Me.gpMain.TabStop = False
        '
        'lblToday
        '
        Me.lblToday.AutoSize = True
        Me.lblToday.Location = New System.Drawing.Point(58, 58)
        Me.lblToday.Name = "lblToday"
        Me.lblToday.Size = New System.Drawing.Size(13, 13)
        Me.lblToday.TabIndex = 12
        Me.lblToday.Text = "0"
        '
        'lblLevel
        '
        Me.lblLevel.AutoSize = True
        Me.lblLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevel.Location = New System.Drawing.Point(58, 16)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(14, 13)
        Me.lblLevel.TabIndex = 10
        Me.lblLevel.Text = "1"
        '
        'picLevelUp
        '
        Me.picLevelUp.BackColor = System.Drawing.Color.Transparent
        Me.picLevelUp.Image = CType(resources.GetObject("picLevelUp.Image"), System.Drawing.Image)
        Me.picLevelUp.Location = New System.Drawing.Point(70, 8)
        Me.picLevelUp.Name = "picLevelUp"
        Me.picLevelUp.Size = New System.Drawing.Size(55, 50)
        Me.picLevelUp.TabIndex = 14
        Me.picLevelUp.TabStop = False
        Me.picLevelUp.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(58, 76)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(13, 13)
        Me.lblTotal.TabIndex = 13
        Me.lblTotal.Text = "0"
        '
        'lblMoney
        '
        Me.lblMoney.Location = New System.Drawing.Point(98, 44)
        Me.lblMoney.Name = "lblMoney"
        Me.lblMoney.Size = New System.Drawing.Size(55, 46)
        Me.lblMoney.TabIndex = 5
        Me.lblMoney.Text = "$ 0"
        Me.lblMoney.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'picGold
        '
        Me.picGold.Image = CType(resources.GetObject("picGold.Image"), System.Drawing.Image)
        Me.picGold.Location = New System.Drawing.Point(126, 15)
        Me.picGold.Name = "picGold"
        Me.picGold.Size = New System.Drawing.Size(27, 26)
        Me.picGold.TabIndex = 4
        Me.picGold.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Level"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Total"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Today"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File Stored"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(49, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(49, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(49, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = ":"
        '
        'gpAvatar
        '
        Me.gpAvatar.Controls.Add(Me.btnAvatarMgr)
        Me.gpAvatar.Location = New System.Drawing.Point(12, 271)
        Me.gpAvatar.Name = "gpAvatar"
        Me.gpAvatar.Size = New System.Drawing.Size(272, 48)
        Me.gpAvatar.TabIndex = 6
        Me.gpAvatar.TabStop = False
        Me.gpAvatar.Text = "My Av&atar"
        Me.gpAvatar.Visible = False
        '
        'btnAvatarMgr
        '
        Me.btnAvatarMgr.Location = New System.Drawing.Point(55, 16)
        Me.btnAvatarMgr.Name = "btnAvatarMgr"
        Me.btnAvatarMgr.Size = New System.Drawing.Size(164, 24)
        Me.btnAvatarMgr.TabIndex = 0
        Me.btnAvatarMgr.Text = "View Avatar Manager"
        Me.btnAvatarMgr.UseVisualStyleBackColor = True
        '
        'bgVgUser
        '
        '
        'bgVgFame
        '
        '
        'tmrGainExp
        '
        Me.tmrGainExp.Interval = 15
        '
        'bgProcessFile
        '
        '
        'tmrStopAnimLvl
        '
        Me.tmrStopAnimLvl.Interval = 3500
        '
        'frmMain
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 386)
        Me.Controls.Add(Me.gpAvatar)
        Me.Controls.Add(Me.gpMain)
        Me.Controls.Add(Me.btnDisplayMore)
        Me.Controls.Add(Me.gpSetting)
        Me.Controls.Add(Me.gpExtras)
        Me.Controls.Add(Me.btnDisplayLess)
        Me.Controls.Add(Me.progressExp)
        Me.Controls.Add(Me.picAvatar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.trayPopup.ResumeLayout(False)
        CType(Me.picAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpExtras.ResumeLayout(False)
        CType(Me.dgvFame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpSetting.ResumeLayout(False)
        Me.gpMain.ResumeLayout(False)
        Me.gpMain.PerformLayout()
        CType(Me.picLevelUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picGold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpAvatar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents trayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents trayPopup As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picAvatar As System.Windows.Forms.PictureBox
    Friend WithEvents progressExp As System.Windows.Forms.ProgressBar
    Friend WithEvents tmrAvatar As System.Windows.Forms.Timer
    Friend WithEvents btnDisplayMore As System.Windows.Forms.Button
    Friend WithEvents btnDisplayLess As System.Windows.Forms.Button
    Friend WithEvents tmrDisplayMore As System.Windows.Forms.Timer
    Friend WithEvents tmrDisplayLess As System.Windows.Forms.Timer
    Friend WithEvents gpExtras As System.Windows.Forms.GroupBox
    Friend WithEvents gpSetting As System.Windows.Forms.GroupBox
    Friend WithEvents btnSettingsMgr As System.Windows.Forms.Button
    Friend WithEvents gpMain As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMoney As System.Windows.Forms.Label
    Friend WithEvents picGold As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblToday As System.Windows.Forms.Label
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents dgvFame As System.Windows.Forms.DataGridView
    Friend WithEvents Award As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Username As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gpAvatar As System.Windows.Forms.GroupBox
    Friend WithEvents btnAvatarMgr As System.Windows.Forms.Button
    Friend WithEvents bgVgUser As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgVgFame As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmrGainExp As System.Windows.Forms.Timer
    Friend WithEvents picLevelUp As System.Windows.Forms.PictureBox
    Friend WithEvents bgProcessFile As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmrStopAnimLvl As System.Windows.Forms.Timer

End Class
