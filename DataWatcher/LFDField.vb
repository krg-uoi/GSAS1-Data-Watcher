Public Class LFDField
    Public GNLS_RUN_index As Int32 = -1
    Public FTotalCyclesRun As [String] = [String].Empty
    Public ReadOnly Property TotalCyclesRun() As [String]
        Get
            Return FTotalCyclesRun.Substring(56, 3)
        End Get
    End Property

    Public CRS1_ABC_index As Int32 = -1
    Public FCRS1_ABC As [String] = [String].Empty
    Private _CRS1_ABC As List(Of [String]) = New List(Of String)(3)
    Public ReadOnly Property CRS1_ABC() As List(Of [String])
        Get
            _CRS1_ABC.Clear()
            _CRS1_ABC.Add(FCRS1_ABC.Substring(14, 8))
            _CRS1_ABC.Add(FCRS1_ABC.Substring(24, 8))
            _CRS1_ABC.Add(FCRS1_ABC.Substring(34, 8))
            Return _CRS1_ABC
        End Get
    End Property

    Public CRS1_ABCSIG_index As Int32 = -1
    Public FCRS1_ABCSIG As [String] = [String].Empty
    Private _CRS1_ABCSIG As List(Of [String]) = New List(Of String)(3)
    Public ReadOnly Property CRS1_ABCSIG() As List(Of [String])
        Get
            _CRS1_ABCSIG.Clear()
            _CRS1_ABCSIG.Add(FCRS1_ABCSIG.Substring(14, 8))
            _CRS1_ABCSIG.Add(FCRS1_ABCSIG.Substring(24, 8))
            _CRS1_ABCSIG.Add(FCRS1_ABCSIG.Substring(34, 8))
            Return _CRS1_ABCSIG
        End Get
    End Property

    Public REFN_GDNFT_index As Int32 = -1
    Public FREFN_GDNFT_Reduced_CHI2 As [String] = [String].Empty
    Private _REFN_GDNFT_Reduced_CHI2 As [String] = [String].Empty
    Public ReadOnly Property REFN_GDNFT_Reduced_CHI2() As [String]
        Get
            _REFN_GDNFT_Reduced_CHI2 = FREFN_GDNFT_Reduced_CHI2.Substring(30, 6)
            Return _REFN_GDNFT_Reduced_CHI2
        End Get
    End Property
    Private _REFN_GDFT_NumberOfVariable As [String] = [String].Empty
    Public ReadOnly Property REFN_GDNFT_NumberOfVariable() As [String]
        Get
            _REFN_GDFT_NumberOfVariable = FREFN_GDNFT_Reduced_CHI2.Substring(45, 4)
            Return _REFN_GDFT_NumberOfVariable
        End Get
    End Property

    Public HST_1_HFIL_index As Int32 = -1
    Public FHST_1_HFIL As [String] = [String].Empty
    Private _HST_1_HFIL As [String] = [String].Empty
    Public ReadOnly Property HST_1_HFIL() As [String]
        Get
            _HST_1_HFIL = FHST_1_HFIL.Substring(14, 20)
            Return _HST_1_HFIL
        End Get
    End Property
End Class

Public Class LFDStaticField
    Private _TotalCyclesRun As [String] = [String].Empty
    Public Property TotalCyclesRun() As [String]
        Get
            Return _TotalCyclesRun
        End Get
        Set(value As [String])
            _TotalCyclesRun = value
        End Set
    End Property

    Private _CRS1_ABC As List(Of [String]) = New List(Of String)
    Public Property CRS1_ABC() As List(Of [String])
        Get
            Return _CRS1_ABC
        End Get
        Set(value As List(Of [String]))
            _CRS1_ABC = value
        End Set
    End Property

    Private _CRS1_ABCSIG As List(Of [String]) = New List(Of String)
    Public Property CRS1_ABCSIG() As List(Of [String])
        Get
            Return _CRS1_ABCSIG
        End Get
        Set(value As List(Of [String]))
            _CRS1_ABCSIG = value
        End Set
    End Property

    Private _REFN_GDNFT_Reduced_CHI2 As [String] = [String].Empty
    Public Property REFN_GDNFT_Reduced_CHI2() As [String]
        Get
            Return _REFN_GDNFT_Reduced_CHI2
        End Get
        Set(value As [String])
            _REFN_GDNFT_Reduced_CHI2 = value
        End Set
    End Property

    Private _REFN_GDFT_NumberOfVariable As [String] = [String].Empty
    Public Property REFN_GDNFT_NumberOfVariable() As [String]
        Get
            Return _REFN_GDFT_NumberOfVariable
        End Get
        Set(value As [String])
            _REFN_GDFT_NumberOfVariable = value
        End Set
    End Property

    Private _HST_1_HFIL As [String] = [String].Empty
    Public Property HST_1_HFIL() As [String]
        Get
            Return _HST_1_HFIL
        End Get
        Set(value As [String])
            _HST_1_HFIL = value
        End Set
    End Property

    Public Sub New(crsabclenght As Integer, crsabcsiglength As Integer)
        For i As Integer = 0 To crsabclenght - 1
            _CRS1_ABC.Add([String].Empty)
        Next

        For i As Integer = 0 To crsabcsiglength - 1
            _CRS1_ABCSIG.Add([String].Empty)
        Next
    End Sub

    Public Sub SetCurrentValue(data As LFDReader)
        For i As Integer = 0 To data.MonitoredValue.CRS1_ABC.Count - 1
            If (IsNothing(_CRS1_ABC(i))) Then
                _CRS1_ABC.Add(data.MonitoredValue.CRS1_ABC(i))
            Else
                If (_CRS1_ABC(i) <> data.MonitoredValue.CRS1_ABC(i)) Then
                    _CRS1_ABC(i) = data.MonitoredValue.CRS1_ABC(i)
                End If
            End If
        Next

        For i As Integer = 0 To data.MonitoredValue.CRS1_ABCSIG.Count - 1
            If (IsNothing(_CRS1_ABCSIG(i))) Then
                _CRS1_ABCSIG.Add(data.MonitoredValue.CRS1_ABCSIG(i))
            Else
                If (_CRS1_ABCSIG(i) <> data.MonitoredValue.CRS1_ABCSIG(i)) Then
                    _CRS1_ABCSIG(i) = data.MonitoredValue.CRS1_ABCSIG(i)
                End If
            End If
        Next

        If (_HST_1_HFIL <> data.MonitoredValue.HST_1_HFIL) Then
            _HST_1_HFIL = data.MonitoredValue.HST_1_HFIL
        End If

        If (_REFN_GDNFT_Reduced_CHI2 <> data.MonitoredValue.REFN_GDNFT_Reduced_CHI2) Then
            _REFN_GDNFT_Reduced_CHI2 = data.MonitoredValue.REFN_GDNFT_Reduced_CHI2
        End If

        If (_REFN_GDFT_NumberOfVariable <> data.MonitoredValue.REFN_GDNFT_NumberOfVariable) Then
            _REFN_GDFT_NumberOfVariable = data.MonitoredValue.REFN_GDNFT_NumberOfVariable
        End If

        If (TotalCyclesRun <> data.MonitoredValue.TotalCyclesRun) Then
            TotalCyclesRun = data.MonitoredValue.TotalCyclesRun
        End If
    End Sub
End Class
