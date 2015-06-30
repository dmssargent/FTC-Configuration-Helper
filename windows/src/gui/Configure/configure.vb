Public Class Configure
    Private display As GUI
    Private mutex_full As Threading.Mutex
    Private mutex_status As Threading.Mutex

    Private Const NUM_OF_CHECKS = 3
    Private displayPosition As Double

    Sub New(ByRef caller As GUI)
        display = caller
        mutex_full = New Threading.Mutex()
        mutex_status = New Threading.Mutex()
        displayPosition = 0
    End Sub

    Public Function FullCheck() As Integer
        'Start up
        mutex_full.WaitOne()
        display.LockCheck()
        displayPosition = 0
        display.StatusText("Preparing...")

        'Make the threads
        Dim checks(NUM_OF_CHECKS - 1) As Threading.Thread
        checks(0) = New Threading.Thread(AddressOf JavaCheck)
        checks(1) = New Threading.Thread(AddressOf GitCheck)
        checks(2) = New Threading.Thread(AddressOf AndroidStudioCheck)

        'Start every thread
        For i As Integer = 0 To checks.Length - 1
            checks(i).Start()
        Next i
        display.StatusText("Configuring...")

        'Wait for every thread to complete
        For i As Integer = 0 To checks.Length - 1
            checks(i).Join()
        Next

        'Finish
        'Cleanup progressbar
        displayPosition = 100
        display.StatusBar(displayPosition)

        display.StatusText("Done!")
        MsgBox("Done!")
        mutex_full.ReleaseMutex()
        display.UnlockCheck()
        Return 0
    End Function

    Private Function JavaCheck() As Integer
        display.JavaStatusClear()
        Dim status As String = "GOOD"

        Dim statusbarStep As Integer = (100 / NUM_OF_CHECKS) / 4


        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Development Kit", "CurrentVersion", "NotFound") <> "NotFound" Then
            display.JavaStatusAdd("Java Found!")

            Statusbar(statusbarStep)
            display.JavaStatusAdd("JDK Found!")
            Statusbar(statusbarStep)
            If Double.Parse(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Development Kit", "CurrentVersion", 0.1)) >= 1.7 Then
                display.JavaStatusAdd("JDK is recent enough!")
            Else
                display.JavaStatusAdd("JDK is too old!")
                status = "WARN"
            End If
            Statusbar(statusbarStep)

            Dim JavaHome As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Development Kit\" & _
                                                                               My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Development Kit", "CurrentVersion", Nothing), _
                                                                               "JavaHome", Nothing)

            If My.Computer.FileSystem.FileExists(JavaHome & "\bin\java.exe") = True Then
                Dim javaTest As New Process()
                javaTest.StartInfo.FileName = JavaHome & "\bin\java.exe"
                javaTest.StartInfo.Arguments = "-version"
                javaTest.StartInfo.UseShellExecute = False
                javaTest.StartInfo.RedirectStandardError = True
                javaTest.StartInfo.CreateNoWindow = True

                javaTest.Start()
                Dim javaOutputStream As IO.StreamReader = javaTest.StandardError

                javaTest.WaitForExit()

                If javaTest.ExitCode <> 0 Then
                    display.JavaStatusAdd("Java could not run properly")
                    status = "ERROR"
                Else
                    display.JavaStatusAdd("Java Version Info:")
                    Dim versionInfo As String = javaOutputStream.ReadToEnd.ToString
                    Dim version() As String = versionInfo.Split(vbCrLf)
                    For i As Integer = 0 To version.Length - 1
                        display.JavaStatusAdd(vbTab & version(i))
                    Next
                End If
            Else
                display.JavaStatusAdd("java.exe could not be found at: " & JavaHome & "bin\java.exe")
            End If
            Statusbar(statusbarStep)
        Else
            display.JavaStatusAdd("Java is not installed")
            status = "ERROR"
        End If
        display.JavaStatus(status)
        Return 0
    End Function

    Private Function GitCheck() As Integer
        display.GitStatusClear()
        Dim status As String = "GOOD"

        Dim barStep = 100 / NUM_OF_CHECKS / 2

        Dim paths() As String = Environment.GetEnvironmentVariable("PATH").Split(";")
        Dim gitFound As Boolean = False
        For i As Integer = 0 To paths.Length
            If My.Computer.FileSystem.FileExists(paths(i) & "\git.exe") Then
                gitFound = True
                Exit For
            End If
        Next

        If gitFound Then
            display.GitStatusAdd("Git Found!")
            Statusbar(barStep)

            'Test that git works
            Dim git As New Process
            git.StartInfo.FileName = "git"
            git.StartInfo.Arguments = "--version"
            git.StartInfo.CreateNoWindow = True
            git.StartInfo.RedirectStandardOutput = True
            git.StartInfo.UseShellExecute = False
            git.Start()
            Dim gitOutput As IO.StreamReader = git.StandardOutput
            git.WaitForExit()

            If git.ExitCode = 0 Then
                display.GitStatusAdd("Git Version:")
                display.GitStatusAdd(vbTab & gitOutput.ReadToEnd)
            Else
                display.GitStatusAdd("Git does not run!")
                status = "ERROR"
            End If
            Statusbar(barStep)
        Else
            display.GitStatusAdd("Git Not Found!")
            status = "ERROR"
            Statusbar(barStep * 2)
        End If

        display.GitStatus(status)
        Return 0
    End Function

    Private Function AndroidStudioCheck() As Integer
        Const NUM_SUB_CHECKS As Integer = 2
        Const prgStep As Double = 100 / NUM_OF_CHECKS / NUM_SUB_CHECKS
        Dim status As String = "GOOD"


        display.AndroidStudioStatusClear()

        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Android Studio", "Path", Nothing) IsNot Nothing Then
            Statusbar(prgStep)
            display.AndroidStudioStatusAdd("Android Studio has been found!")
            If My.Computer.FileSystem.DirectoryExists(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Android Studio", "Path", Nothing)) Then
                Statusbar(prgStep)
                display.AndroidStudioStatusAdd("Android Studio's install directory exists")
            Else
                Statusbar(prgStep)
                display.AndroidStudioStatusAdd("Android Studio's install directory does not exist")
                ChangeCheckState(status, "ERROR")
            End If
        Else
            Statusbar(prgStep)
            display.AndroidStudioStatusAdd("Android Studio not found!")
            ChangeCheckState(status, "ERROR")
        End If

        display.AndroidStudioStatus(status)
        Return 0
    End Function

    Sub Statusbar(ByVal segment As Double)
        mutex_status.WaitOne()
        If segment > 100 / NUM_OF_CHECKS Then
            Throw New ArgumentException("Invalid amount of increment to do")
        End If
        displayPosition += segment
        display.StatusBar(displayPosition)
        mutex_status.ReleaseMutex()
    End Sub

    Private Sub ChangeCheckState(ByRef state As String, ByVal newState As String)
        If state = "ERROR" Then
            Exit Sub
        End If

        If newState = "ERROR" Then
            state = newState
        End If

        If state = "WARN" Then
            Exit Sub
        End If


        If newState = "WARN" Then
            state = newState
        End If
    End Sub
End Class
