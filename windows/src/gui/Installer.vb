Public Class Installer
    Public Const GIT_DOWNLOAD_URL As String = "https://github.com/msysgit/msysgit/releases/download/Git-1.9.5-preview20150319/Git-1.9.5-preview20150319.exe"
    Public Const ANDROID_STUDIO_DOWNLOAD_URL As String = "https://dl.google.com/dl/android/studio/install/1.2.2.0/android-studio-bundle-141.1980579-windows.exe"
    Public Const JAVA_DOWNLOAD_URL As String = "http://www.oracle.com/technetwork/java/javase/downloads/jdk7-downloads-1880260.html"

    Private callerGUI As GUI
    Private StatusDisplay As StatusControls

    Public Structure StatusControls
        Private prgStatus As Windows.Forms.ProgressBar
        Public Property ProgressBarStatus As Windows.Forms.ProgressBar
            Get
                Return prgStatus
            End Get
            Set(value As Windows.Forms.ProgressBar)
                prgStatus = value
            End Set
        End Property

        Private lblStatus As Windows.Forms.Label
        Public Property labelStatus As Windows.Forms.Label
            Get
                Return lblStatus
            End Get
            Set(value As Windows.Forms.Label)
                lblStatus = value
            End Set
        End Property

    End Structure

    Public Structure InstallerDetails
        Private url As String
        Public Property downloadURL As String
            Get
                Return url
            End Get
            Set(value As String)
                url = value
            End Set
        End Property

        Private path As String
        Public Property filePath As String
            Get
                Return path
            End Get
            Set(value As String)
                If My.Computer.FileSystem.FileExists(value) Then
                    path = value
                Else
                    Throw New System.IO.FileNotFoundException
                End If
            End Set
        End Property

        Private name As String
        Public Property displayName As String
            Get
                Return name
            End Get
            Set(value As String)
                name = value
            End Set
        End Property

        Friend caller As GUI
        Public ReadOnly Property callerGUI As GUI
            Get
                Return caller
            End Get
        End Property
    End Structure

    Sub New(ByRef status As StatusControls, ByRef caller As GUI)
        StatusDisplay = status
        callerGUI = caller
    End Sub

    ''' <summary>
    ''' Setups Setup for a given application
    ''' </summary>
    ''' <param name="setupName">name of setup</param>
    ''' <param name="setupFile">filename of JDK setup to run</param>
    ''' <param name="silent">Whether to run the installer silently or not</param>
    ''' <returns>JDK setup exit code</returns>
    ''' <remarks></remarks>
    Public Shared Function Setup(ByVal setupName As String, ByVal setupFile As String, ByVal silent As Boolean, Optional ByVal otherArgs As String = "") As Integer
        If Not My.Computer.FileSystem.FileExists(setupFile) Then
            Throw New System.IO.FileNotFoundException("Cannot find" & setupName & " Setup", setupFile)
        End If

        Dim args As System.Text.StringBuilder = New System.Text.StringBuilder("")
        args.Append(otherArgs)
        If silent Then
            args.Append(" /silent")
        End If

        'Launch Java Setup and save the result as javaExec
        Dim javaExec As Integer = 0
        While True
            Try
                javaExec = LaunchSetup(setupFile, args.ToString)
                Exit While
            Catch e As Exception
                MsgBox(e.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                If MsgBox("Do you want to retry " & setupName & " setup?", MsgBoxStyle.RetryCancel + MsgBoxStyle.Question, "JDK Setup") = MsgBoxResult.Retry Then
                    Continue While
                Else
                    Throw
                    Exit While
                End If
            End Try
        End While

        If javaExec <> 0 Then
            MsgBox(setupName & " returned an error. Error Code: " & javaExec, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "JDK Setup")
        End If

        Return javaExec
    End Function

    ''' <summary>
    ''' Streamlines launching the setup as process and the the arguments passed to it
    ''' </summary>
    ''' <param name="setup">file name of the Setup to run</param>
    ''' <param name="args">arguments to pass to setup</param>
    ''' <returns>Setup Exit Code</returns>
    ''' <remarks></remarks>
    Private Shared Function LaunchSetup(ByRef setup As String, ByRef args As String) As Integer
        Dim setupExec As Process = New Process()
        Try
            'Setup StartInfo
            setupExec.StartInfo.FileName = setup
            setupExec.StartInfo.Arguments = args.ToString
            setupExec.StartInfo.ErrorDialog = True

            'Launch and wait for setup to complete
            setupExec.Start()
            setupExec.WaitForExit()
        Catch e As Exception
            MsgBox("An error occurred launching setup.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Setup Failed")
            setupExec.Dispose()
            Throw
        End Try

        'Save the exit code before destroying the process
        Dim exitCode As Integer = setupExec.ExitCode
        setupExec.Dispose()

        'Return the exit code to the caller
        Return exitCode
    End Function

    Public Sub VerifyCanInstall()
        If Not (callerGUI.chkJDK.Checked Or callerGUI.chkGit.Checked Or callerGUI.chkAndroidStudio.Checked) Then
            callerGUI.btnInstall.Enabled = False
            Exit Sub
        Else
            callerGUI.btnInstall.Enabled = True
        End If

        'Check to make sure setup files exist
        Dim failedNotFound As Boolean = False
        If callerGUI.chkJDK.Checked And My.Computer.FileSystem.FileExists(callerGUI.txtJDK_SetupPath.Text) Then
            callerGUI.txtJDK_SetupPath.ForeColor = Color.Black
        ElseIf callerGUI.chkJDK.Checked And Not My.Computer.FileSystem.FileExists(callerGUI.txtJDK_SetupPath.Text) Then
            callerGUI.txtJDK_SetupPath.ForeColor = Color.Red
            callerGUI.btnInstall.Enabled = False
            failedNotFound = True
        End If

        If callerGUI.chkGit.Checked And My.Computer.FileSystem.FileExists(callerGUI.txtGitSetupPath.Text) Then
            callerGUI.txtGitSetupPath.ForeColor = Color.Black
        ElseIf callerGUI.chkGit.Checked And Not My.Computer.FileSystem.FileExists(callerGUI.txtJDK_SetupPath.Text) Then
            callerGUI.txtGitSetupPath.ForeColor = Color.Red
            If Not callerGUI.chkGitDownload.Checked Then
                callerGUI.btnInstall.Enabled = False
                failedNotFound = True
            End If
        End If

        If callerGUI.chkAndroidStudio.Checked And My.Computer.FileSystem.FileExists(callerGUI.txtAndroidStudioISetupPath.Text) Then
            callerGUI.txtAndroidStudioISetupPath.ForeColor = Color.Black
        ElseIf callerGUI.chkAndroidStudio.Checked And My.Computer.FileSystem.FileExists(callerGUI.txtJDK_SetupPath.Text) Then
            callerGUI.txtAndroidStudioISetupPath.ForeColor = Color.Red
            If Not callerGUI.chkAndroidStudioDownload.Checked Then
                callerGUI.btnInstall.Enabled = False
                failedNotFound = True
            End If
        End If

        If Not failedNotFound Then
            callerGUI.btnInstall.Enabled = True
        End If


    End Sub


    Public Sub Installer()
        Dim packageDetails() As InstallerDetails = {New InstallerDetails(), New InstallerDetails()}
        Dim downloadTasks(packageDetails.Length - 1) As Task

        Dim setupDir As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\FTC-Setup-Helper\"
        My.Computer.FileSystem.CreateDirectory(setupDir)

        Dim downloadDir As String = setupDir & "tmp\"
        My.Computer.FileSystem.CreateDirectory(downloadDir)

        For i As Integer = 0 To packageDetails.Length - 1
            packageDetails(i).caller = Me.callerGUI
        Next

        If callerGUI.chkAndroidStudioDownload.Checked And callerGUI.chkAndroidStudio.Checked Then
            packageDetails(0).filePath = downloadDir & "android-studio-setup.exe"
            If Not My.Computer.FileSystem.FileExists(downloadDir & "android-studio-setup.exe") Then
                packageDetails(0).downloadURL = ANDROID_STUDIO_DOWNLOAD_URL
                packageDetails(0).displayName = "Android Studio Setup"
                'callerGUI.btnAbort.Enabled = True
            ElseIf MsgBox("Android Studio Setup has already been downloaded. Do you want to get it again?", _
                         MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                packageDetails(0).downloadURL = ANDROID_STUDIO_DOWNLOAD_URL
                packageDetails(0).displayName = "Android Studio Setup"
                'callerGUI.btnAbort.Enabled = True
            End If
        End If

        If callerGUI.chkGit.Checked And callerGUI.chkGitDownload.Checked Then
            packageDetails(1).filePath = downloadDir & "git-setup.exe"
            If Not My.Computer.FileSystem.FileExists(downloadDir & "git-setup.exe") Then
                packageDetails(1).downloadURL = GIT_DOWNLOAD_URL
                packageDetails(1).displayName = "Git Setup"
                'callerGUI.btnAbort.Enabled = True
            ElseIf MsgBox("Git Setup has already been downloaded. Do you want to get it again?", _
                          MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                packageDetails(1).downloadURL = GIT_DOWNLOAD_URL
                packageDetails(1).displayName = "Git Setup"
            End If
        End If

        For i As Integer = 0 To packageDetails.Length - 1
            downloadTasks(i) = New Task(AddressOf Downloader.GetInstaller, packageDetails(i))
            downloadTasks(i).Start()
        Next

        'Wait for download completion
        Dim statusThread As New Threading.Thread(Sub()
                                                     For i As Integer = 0 To downloadTasks.Length - 1
                                                         If Not downloadTasks(i).IsCompleted Then
                                                             downloadTasks(i).Wait()
                                                         End If
                                                     Next
                                                 End Sub)
        'Setup the thread to watch
        statusThread.Priority = Threading.ThreadPriority.Lowest
        statusThread.Start()
        statusThread.Join()

        'Remember to only read values from the Form
        If callerGUI.chkJDK.Checked Then
            If My.Computer.FileSystem.FileExists(callerGUI.txtJDK_SetupPath.Text) Then
                callerGUI.prgStatusClear()
                callerGUI.SetStatusText("Installing JDK...")
                callerGUI.prgStatusStep(50)
                Setup("JDK 7", callerGUI.txtJDK_SetupPath.Text, False, " /s /l " & setupDir & "java-setup.log")
                callerGUI.prgStatusStep(100)
            Else
                MsgBox("JDK Setup File does not exist!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            End If
        End If

        If IsAborted() Then
            Exit Sub
        End If
        If callerGUI.chkGit.Checked Then
            If callerGUI.chkGitDownload.Checked And My.Computer.FileSystem.FileExists(packageDetails(1).filePath) Then
                callerGUI.prgStatusClear()
                callerGUI.SetStatusText("Installing Git...")
                callerGUI.prgStatusStep(50)
                Setup("Git", packageDetails(1).filePath.ToString, True)
                callerGUI.prgStatusStep(100)
            ElseIf Not callerGUI.chkGitDownload.Checked And My.Computer.FileSystem.FileExists(callerGUI.txtGitSetupPath.Text) Then
                callerGUI.prgStatusClear()
                callerGUI.SetStatusText("Installing Git...")
                callerGUI.prgStatusStep(50)
                Setup("Git", callerGUI.txtGitSetupPath.Text, True)
                callerGUI.prgStatusStep(100)
            Else
                MsgBox("Git Setup file does not exist.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End If
        End If

        If IsAborted() Then
            Exit Sub
        End If

        If callerGUI.chkAndroidStudio.Checked Then
            If callerGUI.chkAndroidStudioDownload.Checked And My.Computer.FileSystem.FileExists(packageDetails(0).filePath) Then
                callerGUI.prgStatusClear()
                callerGUI.SetStatusText("Installing Android Studio...")
                callerGUI.prgStatusStep(50)
                Setup("Android Studio", packageDetails(0).filePath.ToString, True)
                callerGUI.prgStatusStep(100)
            ElseIf Not callerGUI.chkGitDownload.Checked And My.Computer.FileSystem.FileExists(callerGUI.txtGitSetupPath.Text) Then
                callerGUI.prgStatusClear()
                callerGUI.SetStatusText("Installing Android Studio...")
                callerGUI.prgStatusStep(50)
                Setup("Android Studio", callerGUI.txtGitSetupPath.Text, True)
                callerGUI.prgStatusStep(100)
            Else
                MsgBox("Android Studio Setup file does not exist.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End If
        End If
        callerGUI.prgStatusStep(100)
        callerGUI.SetStatusText("Done! Setup is finished.")
        MsgBox("Setup is done!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
    End Sub

    Private Function IsAborted() As Boolean
        Return callerGUI.abort
    End Function
End Class
