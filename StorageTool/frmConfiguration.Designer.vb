<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguration
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
        Me.gpConfig = New System.Windows.Forms.GroupBox()
        Me.pnlExternalFile = New System.Windows.Forms.Panel()
        Me.gpHistory = New System.Windows.Forms.GroupBox()
        Me.dgvHistory = New System.Windows.Forms.DataGridView()
        Me.FileDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Filename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExternalPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Download = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.btnExternalFile = New System.Windows.Forms.Button()
        Me.tmrConfig = New System.Windows.Forms.Timer(Me.components)
        Me.tmrDisplayContent = New System.Windows.Forms.Timer(Me.components)
        Me.gpConfig.SuspendLayout()
        Me.gpHistory.SuspendLayout()
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpConfig
        '
        Me.gpConfig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpConfig.Controls.Add(Me.pnlExternalFile)
        Me.gpConfig.Controls.Add(Me.gpHistory)
        Me.gpConfig.Controls.Add(Me.btnHistory)
        Me.gpConfig.Controls.Add(Me.btnExternalFile)
        Me.gpConfig.Location = New System.Drawing.Point(8, 2)
        Me.gpConfig.Name = "gpConfig"
        Me.gpConfig.Size = New System.Drawing.Size(322, 274)
        Me.gpConfig.TabIndex = 0
        Me.gpConfig.TabStop = False
        Me.gpConfig.Text = "S&ettings Manager"
        Me.gpConfig.Visible = False
        '
        'pnlExternalFile
        '
        Me.pnlExternalFile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlExternalFile.AutoScroll = True
        Me.pnlExternalFile.Location = New System.Drawing.Point(2, 62)
        Me.pnlExternalFile.Name = "pnlExternalFile"
        Me.pnlExternalFile.Size = New System.Drawing.Size(318, 206)
        Me.pnlExternalFile.TabIndex = 1
        Me.pnlExternalFile.Visible = False
        '
        'gpHistory
        '
        Me.gpHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpHistory.Controls.Add(Me.dgvHistory)
        Me.gpHistory.Location = New System.Drawing.Point(0, 62)
        Me.gpHistory.Name = "gpHistory"
        Me.gpHistory.Padding = New System.Windows.Forms.Padding(10)
        Me.gpHistory.Size = New System.Drawing.Size(322, 212)
        Me.gpHistory.TabIndex = 3
        Me.gpHistory.TabStop = False
        Me.gpHistory.Text = "File Transfer History"
        Me.gpHistory.Visible = False
        '
        'dgvHistory
        '
        Me.dgvHistory.AllowUserToAddRows = False
        Me.dgvHistory.AllowUserToDeleteRows = False
        Me.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FileDate, Me.Filename, Me.ExternalPath, Me.Download})
        Me.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHistory.Location = New System.Drawing.Point(10, 23)
        Me.dgvHistory.MultiSelect = False
        Me.dgvHistory.Name = "dgvHistory"
        Me.dgvHistory.ReadOnly = True
        Me.dgvHistory.RowHeadersVisible = False
        Me.dgvHistory.Size = New System.Drawing.Size(302, 179)
        Me.dgvHistory.TabIndex = 0
        '
        'FileDate
        '
        Me.FileDate.HeaderText = "Date"
        Me.FileDate.Name = "FileDate"
        Me.FileDate.ReadOnly = True
        Me.FileDate.Width = 55
        '
        'Filename
        '
        Me.Filename.HeaderText = "Filename"
        Me.Filename.Name = "Filename"
        Me.Filename.ReadOnly = True
        Me.Filename.Width = 74
        '
        'ExternalPath
        '
        Me.ExternalPath.HeaderText = "External Location"
        Me.ExternalPath.Name = "ExternalPath"
        Me.ExternalPath.ReadOnly = True
        Me.ExternalPath.Width = 114
        '
        'Download
        '
        Me.Download.HeaderText = "Download"
        Me.Download.Name = "Download"
        Me.Download.ReadOnly = True
        Me.Download.Width = 61
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.Location = New System.Drawing.Point(181, 21)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(135, 27)
        Me.btnHistory.TabIndex = 1
        Me.btnHistory.Text = "File Transfer History"
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'btnExternalFile
        '
        Me.btnExternalFile.Location = New System.Drawing.Point(6, 21)
        Me.btnExternalFile.Name = "btnExternalFile"
        Me.btnExternalFile.Size = New System.Drawing.Size(135, 27)
        Me.btnExternalFile.TabIndex = 0
        Me.btnExternalFile.Text = "External File Transfer"
        Me.btnExternalFile.UseVisualStyleBackColor = True
        '
        'tmrConfig
        '
        Me.tmrConfig.Interval = 15
        '
        'tmrDisplayContent
        '
        Me.tmrDisplayContent.Interval = 15
        '
        'frmConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 280)
        Me.Controls.Add(Me.gpConfig)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfiguration"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmConfiguration"
        Me.gpConfig.ResumeLayout(False)
        Me.gpHistory.ResumeLayout(False)
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpConfig As System.Windows.Forms.GroupBox
    Friend WithEvents tmrConfig As System.Windows.Forms.Timer
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents btnExternalFile As System.Windows.Forms.Button
    Friend WithEvents gpHistory As System.Windows.Forms.GroupBox
    Friend WithEvents dgvHistory As System.Windows.Forms.DataGridView
    Friend WithEvents FileDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Filename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExternalPath As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Download As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents tmrDisplayContent As System.Windows.Forms.Timer
    Friend WithEvents pnlExternalFile As System.Windows.Forms.Panel
End Class
