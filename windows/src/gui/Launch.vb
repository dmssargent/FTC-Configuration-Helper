Public Class Launch
    Public Sub New()
        Dim argv As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
        Dim argc As Integer = argv.ToArray.Length
        Dim action As Form

        For i As Integer = 0 To argc
            If argv.Item(i) = "-configure" Then
                action = configure
            End If

            If argv.Item(i) = "-wlan" Then
                action = wlan_manager
            End If

            If argv.Item(i) = "-setup" Then
                action = setup

            End If
        Next i


    End Sub
End Class
