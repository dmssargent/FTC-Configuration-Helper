''' <summary>
''' Provides what needs to be setup via just running or a GUI
''' </summary>
''' <remarks></remarks>
Public Class Gui
    Private Const GIT_DOWNLOAD_URL As String = "https://github.com/msysgit/msysgit/releases/download/Git-1.9.5-preview20150319/Git-1.9.5-preview20150319.exe"
    Private Const ANDROID_STUDIO_DOWNLOAD_URL As String = "https://dl.google.com/dl/android/studio/install/1.2.2.0/android-studio-bundle-141.1980579-windows.exe"
    Private Const JAVA_DOWNLOAD_URL As String = "https://www.oracle.com"

    Private Structure InstallerDetails
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
                    Throw New Exception("File Not Found")
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
    End Structure

    Private abortNeeded As Boolean = False
    'Declare delegates
    Private Delegate Sub SetDoubleCallback(ByVal value As Double)
    Private Delegate Sub SetVoidCallback()
    Private Delegate Sub SetTextCallback(ByVal text As String)


    ''' <summary>
    ''' Setups Setup for a given application
    ''' </summary>
    ''' <param name="setupName">name of setup</param>
    ''' <param name="setupFile">filename of JDK setup to run</param>
    ''' <param name="silent">Whether to run the installer silently or not</param>
    ''' <returns>JDK setup exit code</returns>
    ''' <remarks></remarks>
    Private Function Setup(ByVal setupName As String, ByVal setupFile As String, ByVal silent As Boolean) As Integer
        If Not My.Computer.FileSystem.FileExists(setupFile) Then
            Throw New System.IO.FileNotFoundException("Cannot find" & setupName & " Setup", setupFile)
        End If

        Dim args As System.Text.StringBuilder = New System.Text.StringBuilder("")
        If silent Then
            args.Append(" /silent")
        End If

        'Launch Java Setup and save the result as javaExec
        Dim javaExec As Integer = 0
        While True
            Try
                javaExec = LaunchSetup(setupFile, args.ToString)
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
    Private Shared Function LaunchSetup(ByRef setup As String, ByRef args As Integer) As Integer
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

    'GUI Classes
    Private Sub chkJDK_CheckedChanged(sender As Object, e As EventArgs) Handles chkJDK.CheckedChanged
        Me.txtJDK_SetupPath.Enabled = chkJDK.Checked
        Me.btnJDK_Search.Enabled = chkJDK.Checked
        Me.lblJavaLinkDescription.Enabled = chkJDK.Checked
        Me.llblJavaDownload.Enabled = chkJDK.Checked
        VerifyCanInstall()
    End Sub


    Private Sub chkGit_CheckedChanged(sender As Object, e As EventArgs) Handles chkGit.CheckedChanged
        'Make checks right
        Me.txtGitSetupPath.Enabled = Not chkGitDownload.Checked
        Me.btnGitSetupPath.Enabled = Not chkGitDownload.Checked

        Me.txtGitSetupPath.Enabled = chkGit.Checked
        Me.btnGitSetupPath.Enabled = chkGit.Checked
        Me.chkGitDownload.Enabled = chkGit.Checked

        VerifyCanInstall()
    End Sub

    Private Sub chkGitDownload_CheckedChanged(sender As Object, e As EventArgs) Handles chkGitDownload.CheckedChanged
        Me.txtGitSetupPath.Enabled = Not chkGitDownload.Checked
        Me.btnGitSetupPath.Enabled = Not chkGitDownload.Checked
        VerifyCanInstall()
    End Sub


    Private Sub chkAndroidStudio_CheckedChanged(sender As Object, e As EventArgs) Handles chkAndroidStudio.CheckedChanged
        'Make checks right
        Me.txtAndroidStudioISetupPath.Enabled = Not Me.chkAndroidStudioDownload.Checked
        Me.btnAndroidStudioSetupPath.Enabled = Not Me.chkAndroidStudioDownload.Checked


        Me.txtAndroidStudioISetupPath.Enabled = chkAndroidStudio.Checked
        Me.btnAndroidStudioSetupPath.Enabled = chkAndroidStudio.Checked
        Me.chkAndroidStudioDownload.Enabled = chkAndroidStudio.Checked

        VerifyCanInstall()
    End Sub


    Private Sub chkAndroidStudioDownload_CheckedChanged(sender As Object, e As EventArgs) Handles chkAndroidStudioDownload.CheckedChanged
        Me.txtAndroidStudioISetupPath.Enabled = Not Me.chkAndroidStudioDownload.Checked
        Me.btnAndroidStudioSetupPath.Enabled = Not Me.chkAndroidStudioDownload.Checked
        VerifyCanInstall()
    End Sub


    Private Sub radCommunityRepo_CheckedChanged(sender As Object, e As EventArgs) Handles radCommunityRepo.CheckedChanged
        Me.cmbRepoList.Enabled = Me.radCommunityRepo.Checked
        VerifyCanInstall()
    End Sub

    Private Sub VerifyCanInstall()
        If Not (Me.chkJDK.Checked Or Me.chkGit.Checked Or Me.chkAndroidStudio.Checked) Then
            Me.btnInstall.Enabled = False
            Exit Sub
        Else
            Me.btnInstall.Enabled = True
        End If

        'Check to make sure setup files exist
        Dim failedNotFound As Boolean = False
        If Me.chkJDK.Checked And My.Computer.FileSystem.FileExists(Me.txtJDK_SetupPath.Text) Then
            Me.txtJDK_SetupPath.ForeColor = Color.Black
        ElseIf Me.chkJDK.Checked And Not My.Computer.FileSystem.FileExists(Me.txtJDK_SetupPath.Text) Then
            Me.txtJDK_SetupPath.ForeColor = Color.Red
            Me.btnInstall.Enabled = False
            failedNotFound = True
        End If

        If Me.chkGit.Checked And My.Computer.FileSystem.FileExists(Me.txtGitSetupPath.Text) Then
            Me.txtGitSetupPath.ForeColor = Color.Black
        ElseIf Me.chkGit.Checked And Not My.Computer.FileSystem.FileExists(Me.txtJDK_SetupPath.Text) Then
            Me.txtGitSetupPath.ForeColor = Color.Red
            If Not Me.chkGitDownload.Checked Then
                Me.btnInstall.Enabled = False
                failedNotFound = True
            End If
        End If

        If Me.chkAndroidStudio.Checked And My.Computer.FileSystem.FileExists(Me.txtAndroidStudioISetupPath.Text) Then
            Me.txtAndroidStudioISetupPath.ForeColor = Color.Black
        ElseIf Me.chkAndroidStudio.Checked And My.Computer.FileSystem.FileExists(Me.txtJDK_SetupPath.Text) Then
            Me.txtAndroidStudioISetupPath.ForeColor = Color.Red
            If Not Me.chkAndroidStudioDownload.Checked Then
                Me.btnInstall.Enabled = False
                failedNotFound = True
            End If
        End If

        If Not failedNotFound Then
            Me.btnInstall.Enabled = True
        End If


    End Sub

    'Handle browse buttons
    Private Sub Browse_Click(sender As Object, e As EventArgs) Handles btnAndroidStudioSetupPath.Click, _
        btnGitSetupPath.Click, btnJDK_Search.Click
        Dim btnSender As Button = sender
        Dim files As OpenFileDialog = New OpenFileDialog()
        files.Title = "Select Setup Installer"
        files.Multiselect = False
        files.CheckFileExists = True
        files.CheckPathExists = True
        files.AddExtension = True
        files.Filter = "Executables |*.exe| Microsoft Installer Packages |*.msi| All Files |*.*"
        Try
            files.ShowDialog()
        Catch
            files.Dispose()
            Throw
        End Try

        Select Case btnSender.Tag
            Case "JDK"
                Me.txtJDK_SetupPath.Text = files.FileName
            Case "ANDROID_STUDIO"
                Me.txtAndroidStudioISetupPath.Text = files.FileName
            Case "GIT"
                Me.txtGitSetupPath.Text = files.FileName
        End Select

        files.Dispose()
    End Sub


    Private Sub btnFTC_Browse_Click(sender As Object, e As EventArgs) Handles btnFTC_Browse.Click
        Dim folders As FolderBrowserDialog = New FolderBrowserDialog()
        folders.SelectedPath = Me.txtFTC_ClonePath.Text
        folders.ShowNewFolderButton = True
        folders.ShowDialog()

        Me.txtFTC_ClonePath.Text = folders.SelectedPath
        folders.Dispose()
    End Sub

    'Handle text change
    Private Sub paths_TextChanged(sender As Object, e As EventArgs) Handles txtAndroidStudioISetupPath.TextChanged, txtGitSetupPath.TextChanged, txtJDK_SetupPath.TextChanged
        VerifyCanInstall()
    End Sub

    Private Sub btnInstall_Click(sender As Object, e As EventArgs) Handles btnInstall.Click
        VerifyCanInstall()
        'Detect if button changed state
        If Not Me.btnInstall.Enabled Then
            Exit Sub
        End If
        Dim installerThread As New Threading.Thread(AddressOf Installer)
        installerThread.Start()
    End Sub

    Private Sub Installer()
        Dim packageDetails() As InstallerDetails = {New InstallerDetails(), New InstallerDetails()}
        Dim downloadTasks(packageDetails.Length - 1) As Task

        Dim setupDir As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\FTC-Setup-Helper\"
        My.Computer.FileSystem.CreateDirectory(setupDir)

        Dim downloadDir As String = setupDir & "tmp\"
        My.Computer.FileSystem.CreateDirectory(downloadDir)

        If chkAndroidStudioDownload.Checked And chkAndroidStudio.Checked Then
            packageDetails(0).DownloadURL = ANDROID_STUDIO_DOWNLOAD_URL
            packageDetails(0).filePath = downloadDir & "android-studio-setup.exe"
            packageDetails(0).displayName = "Android Studio Setup"
            'Me.btnAbort.Enabled = True
        ElseIf MsgBox("Android Studio Setup has already been downloaded. Do you want to get it again?", _
                     MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            packageDetails(0).DownloadURL = ANDROID_STUDIO_DOWNLOAD_URL
            packageDetails(0).filePath = downloadDir & "android-studio-setup.exe"
            packageDetails(0).displayName = "Android Studio Setup"
            'Me.btnAbort.Enabled = True
        End If

        If chkGit.Checked And chkGitDownload.Checked Then
            If Not My.Computer.FileSystem.FileExists(downloadDir & "git-setup.exe") Then
                packageDetails(1).downloadURL = GIT_DOWNLOAD_URL
                packageDetails(1).filePath = downloadDir & "git-setup.exe"
                packageDetails(1).displayName = "Git Setup"
                'Me.btnAbort.Enabled = True
            ElseIf MsgBox("Git Setup has already been downloaded. Do you want to get it again?", _
                          MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                packageDetails(1).downloadURL = GIT_DOWNLOAD_URL
                packageDetails(1).filePath = downloadDir & "git-setup.exe"
                packageDetails(1).displayName = "Git Setup"
            End If
        End If

        For i As Integer = 0 To packageDetails.Length - 1
            downloadTasks(i) = New Task(AddressOf GetInstaller, packageDetails(i))
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
        If chkJDK.Checked Then
            If My.Computer.FileSystem.FileExists(Me.txtJDK_SetupPath.Text) Then
                Setup("JDK 7", Me.txtJDK_SetupPath.Text, True)
            Else
                MsgBox("JDK Setup File does not exist!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            End If
        End If

        If chkGit.Checked Then
            If chkGitDownload.Checked And My.Computer.FileSystem.FileExists(packageDetails(1).filePath.ToString) Then
                Setup("Git", packageDetails(1).filePath.ToString, True)
            ElseIf Not chkGitDownload.Checked And My.Computer.FileSystem.FileExists(Me.txtGitSetupPath.Text) Then
                Setup("Git", Me.txtGitSetupPath.Text, True)
            Else
                MsgBox("Git Setup file does not exist.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End If
        End If

        If chkAndroidStudio.Checked Then
            If chkAndroidStudioDownload.Checked And My.Computer.FileSystem.FileExists(packageDetails(0).filePath.ToString) Then
                Setup("Android Studio", packageDetails(0).filePath.ToString, True)
            ElseIf Not chkGitDownload.Checked And My.Computer.FileSystem.FileExists(Me.txtGitSetupPath.Text) Then
                Setup("Android Studio", Me.txtGitSetupPath.Text, True)
            Else
                MsgBox("Android Studio Setup file does not exist.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End If
        End If

        MsgBox("Setup is done!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
    End Sub

    Private Sub setup_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.radOfficialRepo.Select()
        Me.chkAndroidStudio.Checked = True
        Me.chkAndroidStudioDownload.Checked = True
        Me.chkJDK.Checked = True
        Me.chkGitDownload.Checked = True

        'Pass components thorugh CheckChanged
        chkAndroidStudio_CheckedChanged(Me.chkAndroidStudio, New System.EventArgs)
        chkGit_CheckedChanged(Me.chkGit, New System.EventArgs)
        chkJDK_CheckedChanged(Me.chkJDK, New System.EventArgs)
        radCommunityRepo_CheckedChanged(Me.radCommunityRepo, New System.EventArgs)

        Me.btnAbort.Enabled = False
        Me.CenterToScreen()
    End Sub

    Private Sub GetInstaller(ByVal details As InstallerDetails)
        'Detect if installerDetails is setup correctly, otherwise just quit
        If details.DownloadURL Is Nothing Then
            Exit Sub
        End If

        Dim response As Net.HttpWebResponse
        Dim request As Net.HttpWebRequest

        Try
            request = Net.HttpWebRequest.Create(details.DownloadURL)
            response = request.GetResponse()
        Catch ex As Exception
            MsgBox("An error occurred getting " & details.DownloadURL, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            MsgBox(ex.StackTrace, MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
            Throw
        End Try

        Dim size As Long = response.ContentLength
        Dim writeStream As IO.FileStream = New IO.FileStream(details.filePath, IO.FileMode.Create)

        Dim read As Integer = 0

        Dim readBytes(4095) As Byte
        Dim bytesRead As Integer = 0

        'Step progress bar step to stream read progress
        prgStatusClear()
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
            If abortNeeded Then
                Exit Do
            End If

            Try
                bytesRead = response.GetResponseStream.Read(readBytes, 0, 4096)
            Catch ex As Exception
                MsgBox("An error occurred during download.")
                Throw
                Exit Sub
            End Try

            read += bytesRead
            If bytesRead = 0 Then
                Exit Do
            End If

            writeStream.Write(readBytes, 0, bytesRead)

            'Take care of outputting status
            'MsgBox(Int((read / size) * 100) & " " & read)
            If (Int((read / size) * 100)) > percent Then
                percent += 1
                currPrgPos += prgStep
                prgStatusStep(currPrgPos)
            End If

            SetStatusText(FormatPercent(percent / 100, 0) & " Downloading - " & details.displayName)
            Threading.Thread.Yield()
        Loop

        response.GetResponseStream.Close()
        writeStream.Close()
    End Sub

    'Thread Safe Progress Bar
    Private Sub SetProgressBarStep(ByVal [step] As Double)
        If Me.prgStatus.InvokeRequired Then
            Dim d As New SetDoubleCallback(AddressOf SetProgressBarStep)
            Me.Invoke(d, New Object() {[step]})
        Else
            Me.prgStatus.Step = [step]
        End If
    End Sub

    Private Sub prgStatusStep(ByVal newPos As Double)
        If Me.prgStatus.InvokeRequired Then
            Dim d As New SetDoubleCallback(AddressOf prgStatusStep)
            Me.Invoke(d, newPos)
        Else
            Me.prgStatus.Value = newPos
        End If
    End Sub

    Private Sub prgStatusClear()
        If Me.prgStatus.InvokeRequired Then
            Dim d As New SetVoidCallback(AddressOf prgStatusClear)
            Me.Invoke(d)
        Else
            Me.prgStatus.Value = 0
        End If
    End Sub

    'Thread Safe Status Text
    Private Sub SetStatusText(ByVal [text] As String)
        If Me.lblStatus.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetStatusText)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.lblStatus.Text = [text]
        End If
    End Sub


    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        abortNeeded = True
    End Sub
End Class