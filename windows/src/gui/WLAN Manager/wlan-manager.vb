Public Module wlan_manager
    Public Function IsValidAddress(ByVal str As String) As Boolean
        Dim address As Net.IPAddress
        Return Net.IPAddress.TryParse(str, address)
    End Function

    Private Function BuildNetsh() As Process
        Dim netsh As Process = New Process()
        netsh.StartInfo.FileName = "netsh"
        netsh.StartInfo.CreateNoWindow = True
        netsh.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        Return netsh
    End Function

    Public Sub Start()
        Dim netsh As Process = BuildNetsh()
        netsh.StartInfo.Arguments = "wlan start hostednetwork"
        netsh.Start()
        netsh.WaitForExit()
        If netsh.ExitCode <> 0 Then
            MsgBox("Network failed to launch!", MsgBoxStyle.Exclamation, MsgBoxStyle.OkOnly)
        End If
        netsh.Dispose()
    End Sub

    Public Sub StopNetwork()
        Dim netsh As Process = BuildNetsh()
        netsh.StartInfo.Arguments = "wlan stop hostednetwork"
        netsh.Start()
        netsh.WaitForExit()
        If netsh.ExitCode <> 0 Then
            MsgBox("Network failed to stop!", MsgBoxStyle.Exclamation, MsgBoxStyle.OkOnly)
        End If
        netsh.Dispose()
    End Sub

    Public Function ListAdapters() As String()
        Dim nics() As Net.NetworkInformation.NetworkInterface = Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
        Dim nicNames(nics.Length - 1) As String

        For i As Integer = 0 To nics.Length - 1
            nicNames(i) = nics(i).Name
        Next

        Return nicNames
    End Function

    Public Sub Setup(ByVal adapterName As String, ByVal ssid As String, ByVal key As String)
        Dim netsh As Process = BuildNetsh()

        netsh.StartInfo.Arguments = "wlan set hostednetwork mode=allow ssid=" & ssid & " key=" & key
        netsh.StartInfo.RedirectStandardOutput = True
        netsh.StartInfo.UseShellExecute = False
        netsh.Start()
        Dim netshStream As IO.StreamReader = netsh.StandardOutput
        netsh.WaitForExit()
        If netsh.ExitCode <> 0 Then
            MsgBox("Network setup failed!" & vbCrLf & netshStream.ReadToEnd.ToString, MsgBoxStyle.Exclamation, MsgBoxStyle.OkOnly)
        End If
        netsh.Dispose()
    End Sub
End Module
