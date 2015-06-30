Public Module Downloader
    Public Sub GetInstaller(ByVal details As Installer.InstallerDetails)
        'Detect if installerDetails is setup correctly, otherwise just quit
        If details.downloadURL Is Nothing Then
            Exit Sub
        End If

        Dim callerGUI As GUI = details.callerGUI
        Dim response As Net.HttpWebResponse
        Dim request As Net.HttpWebRequest

        Try
            request = Net.HttpWebRequest.Create(New System.Uri(details.downloadURL))
            response = request.GetResponse()
        Catch ex As Exception
            MsgBox("An error occurred getting " & details.downloadURL, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            MsgBox(ex.StackTrace, MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
            Throw
        End Try

        Dim size As Long = response.ContentLength
        Dim writeStream As IO.FileStream = New IO.FileStream(details.filePath, IO.FileMode.Create)

        Dim read As Integer = 0

        Dim readBytes(4095) As Byte
        Dim bytesRead As Integer = 0

        'Step progress bar step to stream read progress
        callerGUI.prgStatusClear()
        Dim prgStep As Double
        If 4096 / size > 1 Then
            prgStep = 4096 / size
        Else
            prgStep = 1
        End If

        'Increments this for every one percent done
        Dim percent As Integer = 0
        'Variable for current progress bar position (to make it async)
        Dim currPrgPos = 0
        Do
            If callerGUI.abort Then
                writeStream.Close()
                response.GetResponseStream.Close()
                Exit Sub
            End If

            Try
                bytesRead = response.GetResponseStream.Read(readBytes, 0, 4096)
            Catch ex As Exception
                MsgBox("An error occurred during download.")
                writeStream.Close()
                response.GetResponseStream.Close()
                Throw
            End Try

            read += bytesRead
            If bytesRead = 0 Then
                Exit Do
            End If

            writeStream.Write(readBytes, 0, bytesRead)

            'Take care of outputting status
            If (Int((read / size) * 100)) > percent Then
                percent += 1
                currPrgPos += prgStep
            End If

            callerGUI.prgStatusStep(currPrgPos)
            callerGUI.SetStatusText(FormatPercent(percent / 100, 0) & " Downloading - " & details.displayName)
            Threading.Thread.Yield()
        Loop
        'Cleanup
        response.GetResponseStream.Close()
        writeStream.Close()
    End Sub
End Module
