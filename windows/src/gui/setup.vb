''' <summary>
''' Provides what needs to be setup via just running or a GUI
''' </summary>
''' <remarks></remarks>
Public Class setup
    ''' <summary>
    ''' Handle any arguments that need to be passed
    ''' </summary>
    ''' <param name="argv">The arguments to pass</param>
    ''' <param name="argc">The number of arguments</param>
    ''' <remarks></remarks>
    Sub ArgumentHandler(ByRef argv As System.Collections.ObjectModel.ReadOnlyCollection(Of String), ByVal argc As Integer)
        For i As Integer = 0 To argc
            Dim setupFile As OpenFileDialog = New OpenFileDialog()
            Select Case argv.Item(i).ToLower
                Case "-java"
                    setupFile.Title = "JDK Setup"
                    setupFile.ShowDialog()
                    Setup("JDK", setupFile.FileName, True)
                Case "-git"
                    setupFile.Title = "Git Setup"
                    setupFile.ShowDialog()
                    Setup("Git", setupFile.FileName, True)
                Case "-android-studio"
                    setupFile.Title = "Android Studio Setup"
                    setupFile.ShowDialog()
                    Setup("Android Studio", setupFile.FileName, True)
            End Select
        Next
    End Sub

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
                If MsgBox("Do you want to retry " & setupName & " setup?", MsgBoxStyle.RetryCancel + MsgBoxStyle.Question, "JDK Setup") = MsgBoxResult.Retry Then
                    Continue While
                Else
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
    Private Function LaunchSetup(ByRef setup As String, ByRef args As Integer) As Integer
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
            Throw e
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
        Me.txtGitSetupPath.Enabled = chkGit.Checked
        Me.btnGitSetupPath.Enabled = chkGit.Checked
        Me.chkGitDownload.Enabled = chkGit.Checked

        'Make checks right
        Me.txtGitSetupPath.Enabled = Not chkGitDownload.Checked
        Me.btnGitSetupPath.Enabled = Not chkGitDownload.Checked

        VerifyCanInstall()
    End Sub

    Private Sub chkGitDownload_CheckedChanged(sender As Object, e As EventArgs) Handles chkGitDownload.CheckedChanged
        Me.txtGitSetupPath.Enabled = Not chkGitDownload.Checked
        Me.btnGitSetupPath.Enabled = Not chkGitDownload.Checked
        VerifyCanInstall()
    End Sub


    Private Sub chkAndroidStudio_CheckedChanged(sender As Object, e As EventArgs) Handles chkAndroidStudio.CheckedChanged
        Me.txtAndroidStudioISetupPath.Enabled = chkAndroidStudio.Checked
        Me.btnAndroidStudioSetupPath.Enabled = chkAndroidStudio.Checked
        Me.chkAndroidStudioDownload.Enabled = chkAndroidStudio.Checked

        'Make checks right
        Me.txtAndroidStudioISetupPath.Enabled = Not Me.chkAndroidStudioDownload.Checked
        Me.btnAndroidStudioSetupPath.Enabled = Not Me.chkAndroidStudioDownload.Checked

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
            MsgBox("fail")
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
        MsgBox(failedNotFound)
        If Me.chkGit.Checked And My.Computer.FileSystem.FileExists(Me.txtGitSetupPath.Text) Then
            Me.txtGitSetupPath.ForeColor = Color.Black
        ElseIf Not My.Computer.FileSystem.FileExists(Me.txtJDK_SetupPath.Text) Then
            Me.txtGitSetupPath.ForeColor = Color.Red
            If Not Me.chkGitDownload.Checked Then
                Me.btnInstall.Enabled = False
                failedNotFound = True
            End If
        End If
        MsgBox(failedNotFound)

        If Me.chkAndroidStudio.Checked And My.Computer.FileSystem.FileExists(Me.txtAndroidStudioISetupPath.Text) Then
            Me.txtAndroidStudioISetupPath.ForeColor = Color.Black
        ElseIf Not My.Computer.FileSystem.FileExists(Me.txtJDK_SetupPath.Text) Then
            Me.txtAndroidStudioISetupPath.ForeColor = Color.Red
            Me.btnInstall.Enabled = False
            failedNotFound = True
            If Not Me.chkAndroidStudioDownload.Checked Then
                Me.btnInstall.Enabled = False
                failedNotFound = True
            End If
        End If
        MsgBox(failedNotFound)
        If Not failedNotFound Then
            Me.btnInstall.Enabled = True
        End If
    End Sub



    Private Sub btnInstall_Click(sender As Object, e As EventArgs) Handles btnInstall.Click
        VerifyCanInstall()
        'Detect if button changed state
        If Not Me.btnInstall.Enabled Then
            Exit Sub
        End If

        MsgBox("Hello, World!")
    End Sub
End Class