<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class objExternalFile
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(objExternalFile))
        Me.gpExternalFile = New System.Windows.Forms.GroupBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtExternal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnMinus = New System.Windows.Forms.Button()
        Me.gpExternalFile.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpExternalFile
        '
        Me.gpExternalFile.Controls.Add(Me.btnBrowse)
        Me.gpExternalFile.Controls.Add(Me.txtExternal)
        Me.gpExternalFile.Controls.Add(Me.Label2)
        Me.gpExternalFile.Controls.Add(Me.txtFilter)
        Me.gpExternalFile.Controls.Add(Me.Label1)
        Me.gpExternalFile.Location = New System.Drawing.Point(3, -3)
        Me.gpExternalFile.Name = "gpExternalFile"
        Me.gpExternalFile.Size = New System.Drawing.Size(259, 65)
        Me.gpExternalFile.TabIndex = 3
        Me.gpExternalFile.TabStop = False
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(226, 38)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(28, 23)
        Me.btnBrowse.TabIndex = 9
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtExternal
        '
        Me.txtExternal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExternal.Location = New System.Drawing.Point(102, 40)
        Me.txtExternal.Name = "txtExternal"
        Me.txtExternal.Size = New System.Drawing.Size(122, 20)
        Me.txtExternal.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "External Location"
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(102, 13)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(122, 20)
        Me.txtFilter.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Filename Filter"
        '
        'btnMinus
        '
        Me.btnMinus.Location = New System.Drawing.Point(268, 22)
        Me.btnMinus.Name = "btnMinus"
        Me.btnMinus.Size = New System.Drawing.Size(22, 20)
        Me.btnMinus.TabIndex = 5
        Me.btnMinus.Text = "-"
        Me.btnMinus.UseVisualStyleBackColor = True
        '
        'objExternalFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnMinus)
        Me.Controls.Add(Me.gpExternalFile)
        Me.Name = "objExternalFile"
        Me.Padding = New System.Windows.Forms.Padding(4, 0, 4, 4)
        Me.Size = New System.Drawing.Size(292, 65)
        Me.gpExternalFile.ResumeLayout(False)
        Me.gpExternalFile.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpExternalFile As System.Windows.Forms.GroupBox
    Friend WithEvents txtExternal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fBrowser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnMinus As System.Windows.Forms.Button

End Class
