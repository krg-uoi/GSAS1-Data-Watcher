'Copyright (c) 2017-2018 Nikos Kourkoumelis (http://users.uoi.gr/nkourkou) 
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.


Imports Microsoft.Win32

Public Class MainForm
    Private _FileName As [String] = [String].Empty
    Private lfdWatcher As LFDWatcher = Nothing
    Private isRunning As Boolean = False
    Private prevValues As LFDStaticField = New LFDStaticField(3, 3)
    Private currValues As LFDStaticField = New LFDStaticField(3, 3)
    Private backupDir As [String] = "datawatcher_backup"
    Private backupFilename As [String] = "file"

    Private ReadOnly Property backupfilePath As [String]
        Get
            Return My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + backupDir
        End Get
    End Property

    Private Sub checkboxTopMost_CheckedChanged(sender As Object, e As EventArgs) Handles checkboxTopMost.CheckedChanged
        Me.TopMost = CType(sender, CheckBox).Checked
        MessageBox.Show(My.Computer.FileSystem.SpecialDirectories.MyDocuments)
    End Sub

    Private Sub buttonStart_Click(sender As Object, e As EventArgs) Handles buttonStart.Click
        If (IsNothing(lfdWatcher) Or _FileName = [String].Empty) Then
            Return
        End If

        lfdWatcher.Watch()
        UpdateButtonState()
    End Sub

    Private Sub buttonStop_Click(sender As Object, e As EventArgs) Handles buttonStop.Click
        lfdWatcher.Unwatch()
        UpdateButtonState()
    End Sub

    Private Sub buttonChooseFile_Click(sender As Object, e As EventArgs) Handles buttonChooseFile.Click
        Dim dlg As New OpenFileDialog
        dlg.Filter = "*.exp|*.exp|All files (*.*)|*.*"

        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            _FileName = dlg.FileName
            textboxFileName.Text = _FileName

            If lfdWatcher.IsRunning Then
                lfdWatcher.Unwatch()
            End If

            lfdWatcher.FullPath = _FileName
            AddHandler lfdWatcher.WriteLog, AddressOf OnWriteLog
            UpdateButtonState()
        End If
    End Sub

    Private Sub UpdateButtonState()
        isRunning = lfdWatcher.IsRunning

        buttonStart.Enabled = Not isRunning
        buttonStop.Enabled = isRunning
    End Sub

    Private Sub OnWriteLog(sender As Object, e As EventArgs)
        Invoke(DirectCast(Sub()
                              Dim reader As LFDReader = Nothing
                              reader = New LFDReader(_FileName)
                              If (reader.ReadSuccess) Then
                                  Dim log As String = [String].Empty
                                  log = String.Join(vbNewLine, reader.Contents.ToArray())
                                  textboxDataChange.Text = log

                                  UpdateValues(reader)
                                  UpdateListViewData(reader)
                              End If
                          End Sub, Action))
    End Sub

    Private Function Dispatcher() As Object
        Throw New NotImplementedException
    End Function

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lfdWatcher = New LFDWatcher()

        buttonStart.Enabled = False
        buttonStop.Enabled = False
    End Sub

    Private Sub UpdateValues(reader As LFDReader)
        For i As Integer = 0 To reader.MonitoredValue.CRS1_ABC.Count - 1
            If (currValues.CRS1_ABC(i) <> reader.MonitoredValue.CRS1_ABC(i)) Then
                prevValues.CRS1_ABC(i) = currValues.CRS1_ABC(i)
            End If
        Next
        For i As Integer = 0 To reader.MonitoredValue.CRS1_ABCSIG.Count - 1
            If (currValues.CRS1_ABCSIG(i) <> reader.MonitoredValue.CRS1_ABCSIG(i)) Then
                prevValues.CRS1_ABCSIG(i) = currValues.CRS1_ABCSIG(i)
            End If
        Next
        If (currValues.TotalCyclesRun <> reader.MonitoredValue.TotalCyclesRun) Then
            prevValues.TotalCyclesRun = currValues.TotalCyclesRun
        End If
        If (currValues.REFN_GDNFT_Reduced_CHI2 <> reader.MonitoredValue.REFN_GDNFT_Reduced_CHI2) Then
            prevValues.REFN_GDNFT_Reduced_CHI2 = currValues.REFN_GDNFT_Reduced_CHI2
        End If
        If (currValues.REFN_GDNFT_NumberOfVariable <> reader.MonitoredValue.REFN_GDNFT_NumberOfVariable) Then
            prevValues.REFN_GDNFT_NumberOfVariable = currValues.REFN_GDNFT_NumberOfVariable
        End If
        If (currValues.HST_1_HFIL <> reader.MonitoredValue.HST_1_HFIL) Then
            prevValues.HST_1_HFIL = currValues.HST_1_HFIL
        End If

        currValues.SetCurrentValue(reader)
    End Sub

    Private Sub UpdateListViewData(reader As LFDReader)
        listviewData.Items.Clear()
        Dim lvdata As ListViewItem

        lvdata = New ListViewItem
        lvdata.Text = "Total Cycles Run"
        lvdata.SubItems.Add([String].Empty)
        lvdata.SubItems.Add(reader.MonitoredValue.TotalCyclesRun)
        lvdata.SubItems.Add(prevValues.TotalCyclesRun)
        listviewData.Items.Add(lvdata)

        For i As Integer = 0 To reader.MonitoredValue.CRS1_ABC.Count - 1
            lvdata = New ListViewItem
            lvdata.Text = "CRS1  ABC"
            lvdata.SubItems.Add((i + 1).ToString())
            lvdata.SubItems.Add(reader.MonitoredValue.CRS1_ABC(i))
            lvdata.SubItems.Add(prevValues.CRS1_ABC(i))
            listviewData.Items.Add(lvdata)
        Next

        For i As Integer = 0 To reader.MonitoredValue.CRS1_ABCSIG.Count - 1
            lvdata = New ListViewItem
            lvdata.Text = "CRS1  ABCSIG"
            lvdata.SubItems.Add((i + 1).ToString())
            lvdata.SubItems.Add(reader.MonitoredValue.CRS1_ABCSIG(i))
            lvdata.SubItems.Add(prevValues.CRS1_ABCSIG(i))
            listviewData.Items.Add(lvdata)
        Next

        lvdata = New ListViewItem
        lvdata.Text = "REFN GDNFT  Reduced CHI**2"
        lvdata.SubItems.Add([String].Empty)
        lvdata.SubItems.Add(reader.MonitoredValue.REFN_GDNFT_Reduced_CHI2)
        lvdata.SubItems.Add(prevValues.REFN_GDNFT_Reduced_CHI2)
        listviewData.Items.Add(lvdata)

        lvdata = New ListViewItem
        lvdata.Text = "Reduced CHI**2 Number Of Variables"
        lvdata.SubItems.Add([String].Empty)
        lvdata.SubItems.Add(reader.MonitoredValue.REFN_GDNFT_NumberOfVariable)
        lvdata.SubItems.Add(prevValues.REFN_GDNFT_NumberOfVariable)
        listviewData.Items.Add(lvdata)

        lvdata = New ListViewItem
        lvdata.Text = "HST 1 HFIL"
        lvdata.SubItems.Add([String].Empty)
        lvdata.SubItems.Add(reader.MonitoredValue.HST_1_HFIL)
        lvdata.SubItems.Add(prevValues.HST_1_HFIL)
        listviewData.Items.Add(lvdata)
    End Sub

    Private Sub buttonBackup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonBackup.Click
        Dim isconfigured As Boolean
        Try
            isconfigured = (GetSetting("DataWatcher", "Param", "IsConfigured"))
        Catch ex As Exception
            SaveSetting("DataWatcher", "Param", "FileIncrement", "1")
            SaveSetting("DataWatcher", "Param", "IsConfigured", "TRUE")
        End Try

        Try
            Dim backupFileInc As Integer = Integer.Parse(GetSetting("DataWatcher", "Param", "FileIncrement"))
            Dim backupFullPath As [String]
            backupFullPath = backupfilePath + "\" + backupFilename + "_" + backupFileInc.ToString() + ".ent"

            If (Not My.Computer.FileSystem.DirectoryExists(backupfilePath)) Then
                System.IO.Directory.CreateDirectory(backupfilePath)
            End If

            If (textboxDataChange.Text <> [String].Empty) Then
                My.Computer.FileSystem.WriteAllText(backupFullPath, textboxDataChange.Text, False)
                SaveSetting("DataWatcher", "Param", "FileIncrement", backupFileInc + 1)
            End If
        Catch ex As Exception
            MessageBox.Show("Backup failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        MessageBox.Show("GSAS Data Watcher by Nikos Kourkoumelis (users.uoi.gr/nkourkou)")
    End Sub
End Class