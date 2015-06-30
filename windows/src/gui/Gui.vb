<Assembly: CLSCompliant(True)> 

''' <summary>
''' Provides what needs to be setup via just running or a GUI
''' </summary>
''' <remarks></remarks>
Public Class GUI
    Private installer As Installer

    Private abortNeeded As Boolean = False
    'Declare delegates
    Private Delegate Sub SetDoubleCallback(ByVal value As Double)
    Private Delegate Sub SetVoidCallback()
    Private Delegate Sub SetTextCallback(ByVal text As String)

    Public ReadOnly Property abort
        Get
            Return abortNeeded
        End Get
    End Property

    'GUI Classes
    Private Sub chkJDK_CheckedChanged(sender As Object, e As EventArgs) Handles chkJDK.CheckedChanged
        Me.txtJDK_SetupPath.Enabled = chkJDK.Checked
        Me.btnJDK_Search.Enabled = chkJDK.Checked
        Me.lblJavaLinkDescription.Enabled = chkJDK.Checked
        Me.llblJavaDownload.Enabled = chkJDK.Checked
        installer.VerifyCanInstall()
    End Sub


    Private Sub chkGit_CheckedChanged(sender As Object, e As EventArgs) Handles chkGit.CheckedChanged
        Me.txtGitSetupPath.Enabled = chkGit.Checked
        Me.btnGitSetupPath.Enabled = chkGit.Checked
        Me.chkGitDownload.Enabled = chkGit.Checked

        'Make checks right
        Me.txtGitSetupPath.Enabled = Not chkGitDownload.Checked
        Me.btnGitSetupPath.Enabled = Not chkGitDownload.Checked
        installer.VerifyCanInstall()
    End Sub

    Private Sub chkGitDownload_CheckedChanged(sender As Object, e As EventArgs) Handles chkGitDownload.CheckedChanged
        Me.txtGitSetupPath.Enabled = Not chkGitDownload.Checked
        Me.btnGitSetupPath.Enabled = Not chkGitDownload.Checked
        installer.VerifyCanInstall()
    End Sub


    Private Sub chkAndroidStudio_CheckedChanged(sender As Object, e As EventArgs) Handles chkAndroidStudio.CheckedChanged
        Me.txtAndroidStudioISetupPath.Enabled = chkAndroidStudio.Checked
        Me.btnAndroidStudioSetupPath.Enabled = chkAndroidStudio.Checked
        Me.chkAndroidStudioDownload.Enabled = chkAndroidStudio.Checked

        'Make checks right
        Me.txtAndroidStudioISetupPath.Enabled = Not Me.chkAndroidStudioDownload.Checked
        Me.btnAndroidStudioSetupPath.Enabled = Not Me.chkAndroidStudioDownload.Checked

        installer.VerifyCanInstall()
    End Sub


    Private Sub chkAndroidStudioDownload_CheckedChanged(sender As Object, e As EventArgs) Handles chkAndroidStudioDownload.CheckedChanged
        Me.txtAndroidStudioISetupPath.Enabled = Not Me.chkAndroidStudioDownload.Checked
        Me.btnAndroidStudioSetupPath.Enabled = Not Me.chkAndroidStudioDownload.Checked
        installer.VerifyCanInstall()
    End Sub


    Private Sub radCommunityRepo_CheckedChanged(sender As Object, e As EventArgs) Handles radCommunityRepo.CheckedChanged
        Me.cmbRepoList.Enabled = Me.radCommunityRepo.Checked
        installer.VerifyCanInstall()
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
        Try
            folders.ShowDialog()
        Catch ex As Exception
            folders.Dispose()
            Throw
        End Try

        Me.txtFTC_ClonePath.Text = folders.SelectedPath
        folders.Dispose()
    End Sub

    'Handle text change
    Private Sub paths_TextChanged(sender As Object, e As EventArgs) Handles txtAndroidStudioISetupPath.TextChanged, txtGitSetupPath.TextChanged, txtJDK_SetupPath.TextChanged
        installer.VerifyCanInstall()
    End Sub

    Private Sub btnInstall_Click(sender As Object, e As EventArgs) Handles btnInstall.Click
        installer.VerifyCanInstall()
        'Detect if button changed state
        If Not Me.btnInstall.Enabled Then
            Exit Sub
        End If
        Dim installerThread As New Threading.Thread(AddressOf installer.Installer)
        installerThread.Start()
    End Sub

    Private Sub GUI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Threading.Thread.Yield()
        abortNeeded = True
    End Sub

    Private Sub setup_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim status As New Installer.StatusControls
        status.labelStatus = Me.lblStatus
        status.ProgressBarStatus = Me.prgStatus
        Me.installer = New Installer(status, Me)

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

        Me.CenterToScreen()
    End Sub

    'Thread Safe Progress Bar
    Public Sub SetProgressBarStep(ByVal [step] As Double)
        If Me.prgStatus.InvokeRequired Then
            Dim d As New SetDoubleCallback(AddressOf SetProgressBarStep)
            Me.Invoke(d, New Object() {[step]})
        Else
            Me.prgStatus.Step = [step]
        End If
    End Sub

    Public Sub prgStatusStep(ByVal newPos As Double)
        If Me.prgStatus.InvokeRequired Then
            Dim d As New SetDoubleCallback(AddressOf prgStatusStep)
            Me.Invoke(d, newPos)
        Else
            Me.prgStatus.Value = newPos
        End If
    End Sub

    Public Sub prgStatusClear()
        If Me.prgStatus.InvokeRequired Then
            Dim d As New SetVoidCallback(AddressOf prgStatusClear)
            Me.Invoke(d)
        Else
            Me.prgStatus.Value = 0
        End If
    End Sub

    'Thread Safe Status Text
    Public Sub SetStatusText(ByVal [text] As String)
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

    Private Sub llblJavaDownload_Click(sender As Object, e As EventArgs) Handles llblJavaDownload.Click
        Dim browserLauch As Threading.Thread = New Threading.Thread(Sub()
                                                                        Dim browser As New Process()
                                                                        browser.StartInfo.FileName = installer.JAVA_DOWNLOAD_URL
                                                                        browser.Start()
                                                                        browser.WaitForExit()
                                                                        browser.Dispose()
                                                                    End Sub)
    End Sub
End Class