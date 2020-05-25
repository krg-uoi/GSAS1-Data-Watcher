Imports System.IO
Imports System.Security.Permissions

Public Class LFDWatcher
    Public Event WriteLog As EventHandler

    Private filesystemWatcher As New FileSystemWatcher()
    Private _LastReadTime As DateTime = DateTime.MinValue

    Private _FullPath As [String]
    Public Property FullPath() As [String]
        Get
            Return _FullPath
        End Get
        Set(value As [String])
            _FullPath = value
        End Set
    End Property

    Public ReadOnly Property DirectoryName() As [String]
        Get
            Return Path.GetDirectoryName(_FullPath)
        End Get
    End Property

    Public ReadOnly Property FileName() As [String]
        Get
            Return Path.GetFileName(_FullPath)
        End Get
    End Property

    Public ReadOnly Property IsRunning() As [Boolean]
        Get
            Return filesystemWatcher.EnableRaisingEvents
        End Get
    End Property

    Public Sub New()
    End Sub

    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
    Public Sub Watch()
        filesystemWatcher.Path = DirectoryName
        filesystemWatcher.NotifyFilter = NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName
        filesystemWatcher.Filter = FileName

        filesystemWatcher.EnableRaisingEvents = True

        AddHandler filesystemWatcher.Changed, New FileSystemEventHandler(AddressOf OnChanged)
    End Sub

    Public Sub Unwatch()
        filesystemWatcher.EnableRaisingEvents = False
        RemoveHandler filesystemWatcher.Changed, New FileSystemEventHandler(AddressOf OnChanged)
    End Sub

    Protected Sub OnChanged(source As Object, e As FileSystemEventArgs)
        Dim lastwriteTime As DateTime = File.GetLastWriteTime(_FullPath)

        If lastwriteTime <> _LastReadTime Then
            RaiseEvent WriteLog(Me, New EventArgs)
            _LastReadTime = lastwriteTime
        End If
    End Sub
End Class
