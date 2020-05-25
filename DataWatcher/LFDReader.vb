Imports System.IO

Public Class LFDReader
    Private _FullPath As [String] = [String].Empty

    Private _ReadSuccess As [Boolean] = False
    Public ReadOnly Property ReadSuccess As [Boolean]
        Get
            Return _ReadSuccess
        End Get
    End Property

    Private _MonitoredValue As New LFDField()
    Public ReadOnly Property MonitoredValue() As LFDField
        Get
            Return _MonitoredValue
        End Get
    End Property

    Private _Contents As New List(Of [String])()
    Public ReadOnly Property Contents() As List(Of [String])
        Get
            Return _Contents
        End Get
    End Property

    Public Sub New(path As String)
        _FullPath = path
        ReadData()
        ParseData()
    End Sub

    Private Sub ReadData()
        Try
            Using s As Stream = New FileStream(_FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Dim sr As New StreamReader(s)

                While Not sr.EndOfStream
                    _Contents.Add(sr.ReadLine())
                End While
            End Using
            _ReadSuccess = True
        Catch
            _ReadSuccess = False
        End Try
    End Sub

    Private Sub ParseData()
        Dim dataKeys As New List(Of String)()

        Dim index As Integer = 0

        For Each line As String In _Contents
            If (line.Length > 0) Then
                dataKeys.Add(line.Substring(0, 12))
            End If

            If line.Contains("GNLS  RUN ") Then
                _MonitoredValue.GNLS_RUN_index = index
                _MonitoredValue.FTotalCyclesRun = line
            End If
            If line.Contains("CRS1  ABC ") Then
                _MonitoredValue.CRS1_ABC_index = index
                _MonitoredValue.FCRS1_ABC = line
            End If
            If line.Contains("CRS1  ABCSIG ") Then
                _MonitoredValue.CRS1_ABCSIG_index = index
                _MonitoredValue.FCRS1_ABCSIG = line
            End If
            If line.Contains("REFN GDNFT ") Then
                _MonitoredValue.REFN_GDNFT_index = index
                _MonitoredValue.FREFN_GDNFT_Reduced_CHI2 = line
            End If
            If line.Contains("HST  1  HFIL ") Then
                _MonitoredValue.HST_1_HFIL_index = index
                _MonitoredValue.FHST_1_HFIL = line
            End If

            index += 1
        Next
    End Sub
End Class
