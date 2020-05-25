<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.buttonStop = New System.Windows.Forms.Button()
        Me.buttonStart = New System.Windows.Forms.Button()
        Me.checkboxTopMost = New System.Windows.Forms.CheckBox()
        Me.textboxFileName = New System.Windows.Forms.TextBox()
        Me.buttonChooseFile = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.buttonBackup = New System.Windows.Forms.Button()
        Me.textboxDataChange = New System.Windows.Forms.TextBox()
        Me.listviewData = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.buttonStop)
        Me.Panel1.Controls.Add(Me.buttonStart)
        Me.Panel1.Controls.Add(Me.checkboxTopMost)
        Me.Panel1.Controls.Add(Me.textboxFileName)
        Me.Panel1.Controls.Add(Me.buttonChooseFile)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(520, 69)
        Me.Panel1.TabIndex = 0
        '
        'buttonStop
        '
        Me.buttonStop.Location = New System.Drawing.Point(446, 40)
        Me.buttonStop.Name = "buttonStop"
        Me.buttonStop.Size = New System.Drawing.Size(75, 23)
        Me.buttonStop.TabIndex = 4
        Me.buttonStop.Text = "Stop"
        Me.buttonStop.UseVisualStyleBackColor = True
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(365, 40)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 3
        Me.buttonStart.Text = "Start"
        Me.buttonStart.UseVisualStyleBackColor = True
        '
        'checkboxTopMost
        '
        Me.checkboxTopMost.AutoSize = True
        Me.checkboxTopMost.Location = New System.Drawing.Point(6, 44)
        Me.checkboxTopMost.Name = "checkboxTopMost"
        Me.checkboxTopMost.Size = New System.Drawing.Size(96, 17)
        Me.checkboxTopMost.TabIndex = 2
        Me.checkboxTopMost.Text = "Always on Top"
        Me.checkboxTopMost.UseVisualStyleBackColor = True
        '
        'textboxFileName
        '
        Me.textboxFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxFileName.Location = New System.Drawing.Point(141, 5)
        Me.textboxFileName.Name = "textboxFileName"
        Me.textboxFileName.ReadOnly = True
        Me.textboxFileName.Size = New System.Drawing.Size(376, 20)
        Me.textboxFileName.TabIndex = 1
        '
        'buttonChooseFile
        '
        Me.buttonChooseFile.Location = New System.Drawing.Point(60, 5)
        Me.buttonChooseFile.Name = "buttonChooseFile"
        Me.buttonChooseFile.Size = New System.Drawing.Size(75, 23)
        Me.buttonChooseFile.TabIndex = 0
        Me.buttonChooseFile.Text = "Choose File"
        Me.buttonChooseFile.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Location = New System.Drawing.Point(12, 87)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(520, 484)
        Me.Panel2.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.buttonBackup)
        Me.SplitContainer1.Panel1.Controls.Add(Me.textboxDataChange)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.listviewData)
        Me.SplitContainer1.Size = New System.Drawing.Size(514, 478)
        Me.SplitContainer1.SplitterDistance = 248
        Me.SplitContainer1.TabIndex = 2
        '
        'buttonBackup
        '
        Me.buttonBackup.Location = New System.Drawing.Point(3, 3)
        Me.buttonBackup.Name = "buttonBackup"
        Me.buttonBackup.Size = New System.Drawing.Size(75, 23)
        Me.buttonBackup.TabIndex = 6
        Me.buttonBackup.Text = "Backup"
        Me.buttonBackup.UseVisualStyleBackColor = True
        '
        'textboxDataChange
        '
        Me.textboxDataChange.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxDataChange.Location = New System.Drawing.Point(3, 32)
        Me.textboxDataChange.Multiline = True
        Me.textboxDataChange.Name = "textboxDataChange"
        Me.textboxDataChange.ReadOnly = True
        Me.textboxDataChange.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textboxDataChange.Size = New System.Drawing.Size(508, 213)
        Me.textboxDataChange.TabIndex = 1
        '
        'listviewData
        '
        Me.listviewData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listviewData.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.listviewData.Location = New System.Drawing.Point(3, 3)
        Me.listviewData.Name = "listviewData"
        Me.listviewData.Size = New System.Drawing.Size(508, 220)
        Me.listviewData.TabIndex = 2
        Me.listviewData.UseCompatibleStateImageBehavior = False
        Me.listviewData.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Parameter"
        Me.ColumnHeader1.Width = 200
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Index"
        Me.ColumnHeader2.Width = 40
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Current Value"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Previous Value"
        Me.ColumnHeader4.Width = 100
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "About"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 583)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MainForm"
        Me.Text = "GSAS Data Watcher"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents textboxFileName As System.Windows.Forms.TextBox
    Friend WithEvents buttonChooseFile As System.Windows.Forms.Button
    Friend WithEvents checkboxTopMost As System.Windows.Forms.CheckBox
    Friend WithEvents buttonStop As System.Windows.Forms.Button
    Friend WithEvents buttonStart As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents textboxDataChange As System.Windows.Forms.TextBox
    Friend WithEvents listviewData As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents buttonBackup As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
