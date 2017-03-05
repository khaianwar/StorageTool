<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGreeting
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
        Me.tmrClose = New System.Windows.Forms.Timer(Me.components)
        Me.tmrStartClose = New System.Windows.Forms.Timer(Me.components)
        Me.picAvatar = New System.Windows.Forms.PictureBox()
        Me.picRide = New System.Windows.Forms.PictureBox()
        CType(Me.picAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrClose
        '
        '
        'tmrStartClose
        '
        Me.tmrStartClose.Interval = 2000
        '
        'picAvatar
        '
        Me.picAvatar.BackColor = System.Drawing.Color.Transparent
        Me.picAvatar.Location = New System.Drawing.Point(30, 12)
        Me.picAvatar.Name = "picAvatar"
        Me.picAvatar.Size = New System.Drawing.Size(43, 58)
        Me.picAvatar.TabIndex = 0
        Me.picAvatar.TabStop = False
        '
        'picRide
        '
        Me.picRide.BackColor = System.Drawing.Color.Transparent
        Me.picRide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picRide.Location = New System.Drawing.Point(3, 12)
        Me.picRide.Name = "picRide"
        Me.picRide.Padding = New System.Windows.Forms.Padding(15, 25, 0, 0)
        Me.picRide.Size = New System.Drawing.Size(98, 110)
        Me.picRide.TabIndex = 1
        Me.picRide.TabStop = False
        '
        'frmGreeting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(105, 128)
        Me.Controls.Add(Me.picAvatar)
        Me.Controls.Add(Me.picRide)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGreeting"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.picAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrClose As System.Windows.Forms.Timer
    Friend WithEvents tmrStartClose As System.Windows.Forms.Timer
    Friend WithEvents picAvatar As System.Windows.Forms.PictureBox
    Friend WithEvents picRide As System.Windows.Forms.PictureBox
End Class
