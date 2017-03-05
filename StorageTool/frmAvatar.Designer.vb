<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAvatar
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
        Me.gpSetup = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Equip = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.gpShop = New System.Windows.Forms.GroupBox()
        Me.dgvHistory = New System.Windows.Forms.DataGridView()
        Me.Item = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Buy = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.btnExternalFile = New System.Windows.Forms.Button()
        Me.tmrConfig = New System.Windows.Forms.Timer(Me.components)
        Me.tmrDisplayContent = New System.Windows.Forms.Timer(Me.components)
        Me.gpConfig.SuspendLayout()
        Me.gpSetup.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpShop.SuspendLayout()
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpConfig
        '
        Me.gpConfig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpConfig.Controls.Add(Me.gpSetup)
        Me.gpConfig.Controls.Add(Me.gpShop)
        Me.gpConfig.Controls.Add(Me.btnHistory)
        Me.gpConfig.Controls.Add(Me.btnExternalFile)
        Me.gpConfig.Location = New System.Drawing.Point(8, 2)
        Me.gpConfig.Name = "gpConfig"
        Me.gpConfig.Size = New System.Drawing.Size(322, 274)
        Me.gpConfig.TabIndex = 0
        Me.gpConfig.TabStop = False
        Me.gpConfig.Text = "Av&atar Manager"
        Me.gpConfig.Visible = False
        '
        'gpSetup
        '
        Me.gpSetup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpSetup.Controls.Add(Me.DataGridView1)
        Me.gpSetup.Location = New System.Drawing.Point(0, 62)
        Me.gpSetup.Name = "gpSetup"
        Me.gpSetup.Padding = New System.Windows.Forms.Padding(10)
        Me.gpSetup.Size = New System.Drawing.Size(322, 212)
        Me.gpSetup.TabIndex = 4
        Me.gpSetup.TabStop = False
        Me.gpSetup.Text = "Av&atar S&etup"
        Me.gpSetup.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewImageColumn1, Me.Type, Me.Equip})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(10, 23)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(302, 179)
        Me.DataGridView1.TabIndex = 0
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "Item"
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        '
        'Equip
        '
        Me.Equip.HeaderText = "Equip"
        Me.Equip.Name = "Equip"
        '
        'gpShop
        '
        Me.gpShop.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpShop.Controls.Add(Me.dgvHistory)
        Me.gpShop.Location = New System.Drawing.Point(0, 62)
        Me.gpShop.Name = "gpShop"
        Me.gpShop.Padding = New System.Windows.Forms.Padding(10)
        Me.gpShop.Size = New System.Drawing.Size(322, 212)
        Me.gpShop.TabIndex = 3
        Me.gpShop.TabStop = False
        Me.gpShop.Text = "Av&atar Sh&op"
        Me.gpShop.Visible = False
        '
        'dgvHistory
        '
        Me.dgvHistory.AllowUserToAddRows = False
        Me.dgvHistory.AllowUserToDeleteRows = False
        Me.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.Price, Me.Buy})
        Me.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHistory.Location = New System.Drawing.Point(10, 23)
        Me.dgvHistory.MultiSelect = False
        Me.dgvHistory.Name = "dgvHistory"
        Me.dgvHistory.ReadOnly = True
        Me.dgvHistory.RowHeadersVisible = False
        Me.dgvHistory.Size = New System.Drawing.Size(302, 179)
        Me.dgvHistory.TabIndex = 0
        '
        'Item
        '
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        Me.Item.ReadOnly = True
        '
        'Price
        '
        Me.Price.HeaderText = "Price"
        Me.Price.Name = "Price"
        Me.Price.ReadOnly = True
        '
        'Buy
        '
        Me.Buy.HeaderText = "Buy"
        Me.Buy.Name = "Buy"
        Me.Buy.ReadOnly = True
        '
        'btnHistory
        '
        Me.btnHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistory.Location = New System.Drawing.Point(181, 21)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(135, 27)
        Me.btnHistory.TabIndex = 1
        Me.btnHistory.Text = "Avatar Shop"
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'btnExternalFile
        '
        Me.btnExternalFile.Location = New System.Drawing.Point(6, 21)
        Me.btnExternalFile.Name = "btnExternalFile"
        Me.btnExternalFile.Size = New System.Drawing.Size(135, 27)
        Me.btnExternalFile.TabIndex = 0
        Me.btnExternalFile.Text = "Avatar Setup"
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
        'frmAvatar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 280)
        Me.Controls.Add(Me.gpConfig)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAvatar"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmConfiguration"
        Me.gpConfig.ResumeLayout(False)
        Me.gpSetup.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpShop.ResumeLayout(False)
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpConfig As System.Windows.Forms.GroupBox
    Friend WithEvents tmrConfig As System.Windows.Forms.Timer
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents btnExternalFile As System.Windows.Forms.Button
    Friend WithEvents gpShop As System.Windows.Forms.GroupBox
    Friend WithEvents dgvHistory As System.Windows.Forms.DataGridView
    Friend WithEvents tmrDisplayContent As System.Windows.Forms.Timer
    Friend WithEvents Item As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Buy As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents gpSetup As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Equip As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
