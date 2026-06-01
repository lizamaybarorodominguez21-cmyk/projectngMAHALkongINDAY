<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        TableLayoutPanel1 = New TableLayoutPanel()
        Intersection1 = New GroupBox()
        lblCount1 = New Label()
        picRed1 = New PictureBox()
        Intersection2 = New GroupBox()
        Intersection3 = New GroupBox()
        picYellow1 = New PictureBox()
        picGreen1 = New PictureBox()
        picleft1 = New PictureBox()
        picLeft2 = New PictureBox()
        picGreen2 = New PictureBox()
        picYellow2 = New PictureBox()
        lblCount2 = New Label()
        picRed2 = New PictureBox()
        picLeft3 = New PictureBox()
        picGreen3 = New PictureBox()
        picYellow3 = New PictureBox()
        lblCount3 = New Label()
        picRed3 = New PictureBox()
        tmrTraffic = New Timer(components)
        TableLayoutPanel1.SuspendLayout()
        Intersection1.SuspendLayout()
        CType(picRed1, ComponentModel.ISupportInitialize).BeginInit()
        Intersection2.SuspendLayout()
        Intersection3.SuspendLayout()
        CType(picYellow1, ComponentModel.ISupportInitialize).BeginInit()
        CType(picGreen1, ComponentModel.ISupportInitialize).BeginInit()
        CType(picleft1, ComponentModel.ISupportInitialize).BeginInit()
        CType(picLeft2, ComponentModel.ISupportInitialize).BeginInit()
        CType(picGreen2, ComponentModel.ISupportInitialize).BeginInit()
        CType(picYellow2, ComponentModel.ISupportInitialize).BeginInit()
        CType(picRed2, ComponentModel.ISupportInitialize).BeginInit()
        CType(picLeft3, ComponentModel.ISupportInitialize).BeginInit()
        CType(picGreen3, ComponentModel.ISupportInitialize).BeginInit()
        CType(picYellow3, ComponentModel.ISupportInitialize).BeginInit()
        CType(picRed3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
        TableLayoutPanel1.Controls.Add(Intersection1, 0, 0)
        TableLayoutPanel1.Controls.Add(Intersection2, 1, 0)
        TableLayoutPanel1.Controls.Add(Intersection3, 2, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Size = New Size(800, 450)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' Intersection1
        ' 
        Intersection1.Controls.Add(picleft1)
        Intersection1.Controls.Add(picGreen1)
        Intersection1.Controls.Add(picYellow1)
        Intersection1.Controls.Add(lblCount1)
        Intersection1.Controls.Add(picRed1)
        Intersection1.Location = New Point(3, 3)
        Intersection1.Name = "Intersection1"
        Intersection1.Size = New Size(260, 444)
        Intersection1.TabIndex = 0
        Intersection1.TabStop = False
        Intersection1.Text = "Intersection 1"
        ' 
        ' lblCount1
        ' 
        lblCount1.AutoSize = True
        lblCount1.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCount1.Location = New Point(77, 354)
        lblCount1.Name = "lblCount1"
        lblCount1.Size = New Size(28, 25)
        lblCount1.TabIndex = 4
        lblCount1.Text = "--"
        ' 
        ' picRed1
        ' 
        picRed1.BackColor = Color.DarkRed
        picRed1.Location = New Point(63, 40)
        picRed1.Name = "picRed1"
        picRed1.Size = New Size(60, 60)
        picRed1.TabIndex = 0
        picRed1.TabStop = False
        ' 
        ' Intersection2
        ' 
        Intersection2.Controls.Add(picLeft2)
        Intersection2.Controls.Add(picRed2)
        Intersection2.Controls.Add(picGreen2)
        Intersection2.Controls.Add(lblCount2)
        Intersection2.Controls.Add(picYellow2)
        Intersection2.Location = New Point(269, 3)
        Intersection2.Name = "Intersection2"
        Intersection2.Size = New Size(260, 444)
        Intersection2.TabIndex = 1
        Intersection2.TabStop = False
        Intersection2.Text = "Intersection 2"
        ' 
        ' Intersection3
        ' 
        Intersection3.Controls.Add(picLeft3)
        Intersection3.Controls.Add(picRed3)
        Intersection3.Controls.Add(picGreen3)
        Intersection3.Controls.Add(lblCount3)
        Intersection3.Controls.Add(picYellow3)
        Intersection3.Location = New Point(535, 3)
        Intersection3.Name = "Intersection3"
        Intersection3.Size = New Size(262, 444)
        Intersection3.TabIndex = 2
        Intersection3.TabStop = False
        Intersection3.Text = "Intersection 3"
        ' 
        ' picYellow1
        ' 
        picYellow1.BackColor = Color.Olive
        picYellow1.Location = New Point(63, 123)
        picYellow1.Name = "picYellow1"
        picYellow1.Size = New Size(60, 60)
        picYellow1.TabIndex = 5
        picYellow1.TabStop = False
        ' 
        ' picGreen1
        ' 
        picGreen1.BackColor = Color.DarkGreen
        picGreen1.Location = New Point(63, 200)
        picGreen1.Name = "picGreen1"
        picGreen1.Size = New Size(60, 60)
        picGreen1.TabIndex = 6
        picGreen1.TabStop = False
        ' 
        ' picleft1
        ' 
        picleft1.BackColor = Color.Gray
        picleft1.Location = New Point(63, 276)
        picleft1.Name = "picleft1"
        picleft1.Size = New Size(60, 60)
        picleft1.TabIndex = 7
        picleft1.TabStop = False
        ' 
        ' picLeft2
        ' 
        picLeft2.BackColor = Color.Gray
        picLeft2.Location = New Point(91, 276)
        picLeft2.Name = "picLeft2"
        picLeft2.Size = New Size(60, 60)
        picLeft2.TabIndex = 12
        picLeft2.TabStop = False
        ' 
        ' picGreen2
        ' 
        picGreen2.BackColor = Color.DarkGreen
        picGreen2.Location = New Point(91, 200)
        picGreen2.Name = "picGreen2"
        picGreen2.Size = New Size(60, 60)
        picGreen2.TabIndex = 11
        picGreen2.TabStop = False
        ' 
        ' picYellow2
        ' 
        picYellow2.BackColor = Color.Olive
        picYellow2.Location = New Point(91, 123)
        picYellow2.Name = "picYellow2"
        picYellow2.Size = New Size(60, 60)
        picYellow2.TabIndex = 10
        picYellow2.TabStop = False
        ' 
        ' lblCount2
        ' 
        lblCount2.AutoSize = True
        lblCount2.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCount2.Location = New Point(107, 354)
        lblCount2.Name = "lblCount2"
        lblCount2.Size = New Size(28, 25)
        lblCount2.TabIndex = 9
        lblCount2.Text = "--"
        ' 
        ' picRed2
        ' 
        picRed2.BackColor = Color.DarkRed
        picRed2.Location = New Point(91, 40)
        picRed2.Name = "picRed2"
        picRed2.Size = New Size(60, 60)
        picRed2.TabIndex = 8
        picRed2.TabStop = False
        ' 
        ' picLeft3
        ' 
        picLeft3.BackColor = Color.Gray
        picLeft3.Location = New Point(119, 276)
        picLeft3.Name = "picLeft3"
        picLeft3.Size = New Size(60, 60)
        picLeft3.TabIndex = 17
        picLeft3.TabStop = False
        ' 
        ' picGreen3
        ' 
        picGreen3.BackColor = Color.DarkGreen
        picGreen3.Location = New Point(119, 200)
        picGreen3.Name = "picGreen3"
        picGreen3.Size = New Size(60, 60)
        picGreen3.TabIndex = 16
        picGreen3.TabStop = False
        ' 
        ' picYellow3
        ' 
        picYellow3.BackColor = Color.Olive
        picYellow3.Location = New Point(119, 123)
        picYellow3.Name = "picYellow3"
        picYellow3.Size = New Size(60, 60)
        picYellow3.TabIndex = 15
        picYellow3.TabStop = False
        ' 
        ' lblCount3
        ' 
        lblCount3.AutoSize = True
        lblCount3.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCount3.Location = New Point(135, 354)
        lblCount3.Name = "lblCount3"
        lblCount3.Size = New Size(28, 25)
        lblCount3.TabIndex = 14
        lblCount3.Text = "--"
        ' 
        ' picRed3
        ' 
        picRed3.BackColor = Color.DarkRed
        picRed3.Location = New Point(119, 40)
        picRed3.Name = "picRed3"
        picRed3.Size = New Size(60, 60)
        picRed3.TabIndex = 13
        picRed3.TabStop = False
        ' 
        ' tmrTraffic
        ' 
        tmrTraffic.Interval = 1000
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TableLayoutPanel1)
        Name = "Form1"
        Text = "Form1"
        TableLayoutPanel1.ResumeLayout(False)
        Intersection1.ResumeLayout(False)
        Intersection1.PerformLayout()
        CType(picRed1, ComponentModel.ISupportInitialize).EndInit()
        Intersection2.ResumeLayout(False)
        Intersection2.PerformLayout()
        Intersection3.ResumeLayout(False)
        Intersection3.PerformLayout()
        CType(picYellow1, ComponentModel.ISupportInitialize).EndInit()
        CType(picGreen1, ComponentModel.ISupportInitialize).EndInit()
        CType(picleft1, ComponentModel.ISupportInitialize).EndInit()
        CType(picLeft2, ComponentModel.ISupportInitialize).EndInit()
        CType(picGreen2, ComponentModel.ISupportInitialize).EndInit()
        CType(picYellow2, ComponentModel.ISupportInitialize).EndInit()
        CType(picRed2, ComponentModel.ISupportInitialize).EndInit()
        CType(picLeft3, ComponentModel.ISupportInitialize).EndInit()
        CType(picGreen3, ComponentModel.ISupportInitialize).EndInit()
        CType(picYellow3, ComponentModel.ISupportInitialize).EndInit()
        CType(picRed3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Intersection1 As GroupBox
    Friend WithEvents Intersection2 As GroupBox
    Friend WithEvents Intersection3 As GroupBox
    Friend WithEvents lblCount1 As Label
    Friend WithEvents picRed1 As PictureBox
    Friend WithEvents picleft1 As PictureBox
    Friend WithEvents picGreen1 As PictureBox
    Friend WithEvents picYellow1 As PictureBox
    Friend WithEvents picLeft2 As PictureBox
    Friend WithEvents picRed2 As PictureBox
    Friend WithEvents picGreen2 As PictureBox
    Friend WithEvents lblCount2 As Label
    Friend WithEvents picYellow2 As PictureBox
    Friend WithEvents picLeft3 As PictureBox
    Friend WithEvents picRed3 As PictureBox
    Friend WithEvents picGreen3 As PictureBox
    Friend WithEvents lblCount3 As Label
    Friend WithEvents picYellow3 As PictureBox
    Friend WithEvents tmrTraffic As Timer

End Class
