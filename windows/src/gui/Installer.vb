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
        ''Temp
        'Dim downloads() As DownloadDetails = {New DownloadDetails("Android Studio", ANDROID_STUDIO_DOWNLOAD_URL, _
        '                                                          "9730ba606c4bfc7bc6f1acf6288ea49704bf92925db2a44b3d6b03a598f14f2ab9b9ccc2dd8a764bb90bcd0595011de8e8ea8e2efc7f4d5a6baa05a7ffef3791", _
        '                                                          "android-studio-setup.exe"), _
        '                                      New DownloadDetails("Git", GIT_DOWNLOAD_URL, _
        '                                                          "f046629b9a390ec22122fb96fea43c6a6b79458b1a754090cf00f8f0c005b9777859aec7a1221f55d9ddf553c4d6282ef3c831b7d1442584af85f08494a275cd", _
        '                                                          "git-setup.exe")}
        'WriteDownloads(downloads)
        'MsgBox("Done!")
        ''End temp
        Dim downloadDetails() As DownloadDetails = Me.ReadDownloads()
        Dim packageDetails(downloadDetails.Length - 1) As InstallerDetails
        Dim downloadTasks(packageDetails.Length - 1) As Task

        Dim setupDir As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\FTC-Setup-Helper\"
        My.Computer.FileSystem.CreateDirectory(setupDir)

        Dim downloadDir As String = setupDir & "tmp\"
        My.Computer.FileSystem.CreateDirectory(downloadDir)

        For i As Integer = 0 To packageDetails.Length - 1
            packageDetails(i).caller = Me.callerGUI
            packageDetails(i).filePath = downloadDir & downloadDetails(i).File
            packageDetails(i).displayName = downloadDetails(i).setupName
            packageDetails(i).downloadURL = downloadDetails(i).FetchUrl
        Next i

        For i As Integer = 0 To downloadTasks.Length - 1
            downloadTasks(i) = New Task(AddressOf Downloader.GetInstaller, packageDetails(i))
        Next

        If callerGUI.chkAndroidStudioDownload.Checked And callerGUI.chkAndroidStudio.Checked Then
            If My.Computer.FileSystem.FileExists(packageDetails(0).filePath) Then
                If MsgBox(packageDetails(0).displayName & " Setup has already been downloaded. Do you want to get it again?", _
                         MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    downloadTasks(0).Start()
                End If
            Else
                downloadTasks(0).Start()
            End If
        End If

        If callerGUI.chkGit.Checked And callerGUI.chkGitDownload.Checked Then
            If (My.Computer.FileSystem.FileExists(packageDetails(1).filePath)) Then
                If MsgBox(packageDetails(1).displayName & " has already been downloaded. Do you want to get it again?", _
                          MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    downloadTasks(1).Start()
                Else

                End If
            Else
                downloadTasks(1).Start()
            End If
        End If


        'Wait for download completion
        Dim statusThread As New Threading.Thread(Sub()
                                                     For i As Integer = 0 To downloadTasks.Length - 1
                                                         If Not downloadTasks(i).Status = TaskStatus.RanToCompletion And downloadTasks(i).Status = TaskStatus.Running Then
                                                             downloadTasks(i).Wait()
                                                         End If
                                                     Next
                                                 End Sub)
        'Setup the thread to watch
        statusThread.Priority = Threading.ThreadPriority.Lowest
        statusThread.Start()
        statusThread.Join()

        If callerGUI.abort Then
            MsgBox("Aborted", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            callerGUI.SetStatusText("Aborted!")
            Exit Sub
        End If

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

    Private Sub WriteDownloads(ByRef downloads() As DownloadDetails)
        Dim fileStream As New IO.FileStream("downloads.xml", IO.FileMode.Create)
        Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(DownloadDetails.saveState()))

        Dim save(downloads.Length - 1) As DownloadDetails.saveState
        For i As Integer = 0 To downloads.Length - 1
            save(i) = downloads(i).BuildSave
        Next

        Try
            serializer.Serialize(fileStream, save)
        Catch e As Runtime.Serialization.SerializationException
            MsgBox("Write failed:" & vbCrLf & e.ToString, MsgBoxStyle.Critical)
        Catch e As Exception
            MsgBox("An unknown exception occurred while writing" & vbCrLf & e.ToString)
            Throw

        Finally
            fileStream.Close()
            fileStream.Dispose()
        End Try
    End Sub

    Private Function ReadDownloads() As DownloadDetails()
        Dim fileStream As IO.FileStream
        Try
            fileStream = New IO.FileStream("downloads.xml", IO.FileMode.Open)
        Catch ex As IO.FileNotFoundException
            MsgBox("I cannot find out what to download! Missing 'downloads.xml' in current directory.", MsgBoxStyle.Critical)
            Throw
        End Try

        Dim serializer As New System.Xml.Serialization.XmlSerializer(GetType(DownloadDetails.saveState()))

        Dim details() As DownloadDetails.saveState = serializer.Deserialize(fileStream)
        Dim downloads(details.Length - 1) As DownloadDetails
        For i As Integer = 0 To details.Length - 1
            downloads(i) = DownloadDetails.LoadSaved(details(i))
        Next

        Return downloads
    End Function
End Class
