<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pbCanvas = New System.Windows.Forms.PictureBox()
        CType(Me.pbCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'pbCanvas
        '
        Me.pbCanvas.BackColor = System.Drawing.Color.Black
        Me.pbCanvas.BackgroundImage = Global.GPong_Francis.My.Resources.Resources.background2
        Me.pbCanvas.Location = New System.Drawing.Point(0, 0)
        Me.pbCanvas.Name = "pbCanvas"
        Me.pbCanvas.Size = New System.Drawing.Size(1578, 685)
        Me.pbCanvas.TabIndex = 0
        Me.pbCanvas.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1574, 683)
        Me.Controls.Add(Me.pbCanvas)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1590, 722)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1590, 722)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.pbCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents pbCanvas As System.Windows.Forms.PictureBox

End Class
