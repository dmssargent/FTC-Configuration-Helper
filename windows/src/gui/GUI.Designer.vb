<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GUI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GUI))
        Me.grpInstall = New System.Windows.Forms.GroupBox()
        Me.lblJavaLinkDescription = New System.Windows.Forms.Label()
        Me.llblJavaDownload = New System.Windows.Forms.LinkLabel()
        Me.chkAndroidStudioDownload = New System.Windows.Forms.CheckBox()
        Me.chkGitDownload = New System.Windows.Forms.CheckBox()
        Me.txtGitSetupPath = New System.Windows.Forms.TextBox()
        Me.btnAndroidStudioSetupPath = New System.Windows.Forms.Button()
        Me.txtAndroidStudioISetupPath = New System.Windows.Forms.TextBox()
        Me.btnGitSetupPath = New System.Windows.Forms.Button()
        Me.txtJDK_SetupPath = New System.Windows.Forms.TextBox()
        Me.btnJDK_Search = New System.Windows.Forms.Button()
        Me.chkAndroidStudio = New System.Windows.Forms.CheckBox()
        Me.chkGit = New System.Windows.Forms.CheckBox()
        Me.chkJDK = New System.Windows.Forms.CheckBox()
        Me.btnInstall = New System.Windows.Forms.Button()
        Me.grpGitRepo = New System.Windows.Forms.GroupBox()
        Me.radOfficialRepo = New System.Windows.Forms.RadioButton()
        Me.radCommunityRepo = New System.Windows.Forms.RadioButton()
        Me.cmbRepoList = New System.Windows.Forms.ComboBox()
        Me.btnFTC_Browse = New System.Windows.Forms.Button()
        Me.txtFTC_ClonePath = New System.Windows.Forms.TextBox()
        Me.lblFTC_ClonePath = New System.Windows.Forms.Label()
        Me.btnClone = New System.Windows.Forms.Button()
        Me.prgStatus = New System.Windows.Forms.ProgressBar()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.grpInstall.SuspendLayout()
        Me.grpGitRepo.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpInstall
        '
        Me.grpInstall.Controls.Add(Me.lblJavaLinkDescription)
        Me.grpInstall.Controls.Add(Me.llblJavaDownload)
        Me.grpInstall.Controls.Add(Me.chkAndroidStudioDownload)
        Me.grpInstall.Controls.Add(Me.chkGitDownload)
        Me.grpInstall.Controls.Add(Me.txtGitSetupPath)
        Me.grpInstall.Controls.Add(Me.btnInstall)
        Me.grpInstall.Controls.Add(Me.btnAndroidStudioSetupPath)
        Me.grpInstall.Controls.Add(Me.txtAndroidStudioISetupPath)
        Me.grpInstall.Controls.Add(Me.btnGitSetupPath)
        Me.grpInstall.Controls.Add(Me.txtJDK_SetupPath)
        Me.grpInstall.Controls.Add(Me.btnJDK_Search)
        Me.grpInstall.Controls.Add(Me.chkAndroidStudio)
        Me.grpInstall.Controls.Add(Me.chkGit)
        Me.grpInstall.Controls.Add(Me.chkJDK)
        resources.ApplyResources(Me.grpInstall, "grpInstall")
        Me.grpInstall.Name = "grpInstall"
        Me.grpInstall.TabStop = False
        Me.grpInstall.Tag = "ANDROID_STUDIO"
        '
        'lblJavaLinkDescription
        '
        resources.ApplyResources(Me.lblJavaLinkDescription, "lblJavaLinkDescription")
        Me.lblJavaLinkDescription.Name = "lblJavaLinkDescription"
        '
        'llblJavaDownload
        '
        resources.ApplyResources(Me.llblJavaDownload, "llblJavaDownload")
        Me.llblJavaDownload.Name = "llblJavaDownload"
        Me.llblJavaDownload.TabStop = True
        Me.llblJavaDownload.UseCompatibleTextRendering = True
        '
        'chkAndroidStudioDownload
        '
        resources.ApplyResources(Me.chkAndroidStudioDownload, "chkAndroidStudioDownload")
        Me.chkAndroidStudioDownload.Name = "chkAndroidStudioDownload"
        Me.chkAndroidStudioDownload.UseVisualStyleBackColor = True
        '
        'chkGitDownload
        '
        resources.ApplyResources(Me.chkGitDownload, "chkGitDownload")
        Me.chkGitDownload.Name = "chkGitDownload"
        Me.chkGitDownload.UseVisualStyleBackColor = True
        '
        'txtGitSetupPath
        '
        resources.ApplyResources(Me.txtGitSetupPath, "txtGitSetupPath")
        Me.txtGitSetupPath.Name = "txtGitSetupPath"
        '
        'btnAndroidStudioSetupPath
        '
        resources.ApplyResources(Me.btnAndroidStudioSetupPath, "btnAndroidStudioSetupPath")
        Me.btnAndroidStudioSetupPath.Name = "btnAndroidStudioSetupPath"
        Me.btnAndroidStudioSetupPath.UseVisualStyleBackColor = True
        '
        'txtAndroidStudioISetupPath
        '
        resources.ApplyResources(Me.txtAndroidStudioISetupPath, "txtAndroidStudioISetupPath")
        Me.txtAndroidStudioISetupPath.Name = "txtAndroidStudioISetupPath"
        '
        'btnGitSetupPath
        '
        resources.ApplyResources(Me.btnGitSetupPath, "btnGitSetupPath")
        Me.btnGitSetupPath.Name = "btnGitSetupPath"
        Me.btnGitSetupPath.Tag = "GIT"
        Me.btnGitSetupPath.UseVisualStyleBackColor = True
        '
        'txtJDK_SetupPath
        '
        resources.ApplyResources(Me.txtJDK_SetupPath, "txtJDK_SetupPath")
        Me.txtJDK_SetupPath.Name = "txtJDK_SetupPath"
        '
        'btnJDK_Search
        '
        resources.ApplyResources(Me.btnJDK_Search, "btnJDK_Search")
        Me.btnJDK_Search.Name = "btnJDK_Search"
        Me.btnJDK_Search.Tag = "JDK"
        Me.btnJDK_Search.UseVisualStyleBackColor = True
        '
        'chkAndroidStudio
        '
        resources.ApplyResources(Me.chkAndroidStudio, "chkAndroidStudio")
        Me.chkAndroidStudio.Name = "chkAndroidStudio"
        Me.chkAndroidStudio.UseVisualStyleBackColor = True
        '
        'chkGit
        '
        resources.ApplyResources(Me.chkGit, "chkGit")
        Me.chkGit.Name = "chkGit"
        Me.chkGit.UseVisualStyleBackColor = True
        '
        'chkJDK
        '
        resources.ApplyResources(Me.chkJDK, "chkJDK")
        Me.chkJDK.Name = "chkJDK"
        Me.chkJDK.UseVisualStyleBackColor = True
        '
        'btnInstall
        '
        resources.ApplyResources(Me.btnInstall, "btnInstall")
        Me.btnInstall.Name = "btnInstall"
        Me.btnInstall.UseVisualStyleBackColor = True
        '
        'grpGitRepo
        '
        Me.grpGitRepo.Controls.Add(Me.radOfficialRepo)
        Me.grpGitRepo.Controls.Add(Me.radCommunityRepo)
        Me.grpGitRepo.Controls.Add(Me.cmbRepoList)
        Me.grpGitRepo.Controls.Add(Me.btnClone)
        Me.grpGitRepo.Controls.Add(Me.btnFTC_Browse)
        Me.grpGitRepo.Controls.Add(Me.txtFTC_ClonePath)
        Me.grpGitRepo.Controls.Add(Me.lblFTC_ClonePath)
        resources.ApplyResources(Me.grpGitRepo, "grpGitRepo")
        Me.grpGitRepo.Name = "grpGitRepo"
        Me.grpGitRepo.TabStop = False
        '
        'radOfficialRepo
        '
        resources.ApplyResources(Me.radOfficialRepo, "radOfficialRepo")
        Me.radOfficialRepo.Name = "radOfficialRepo"
        Me.radOfficialRepo.TabStop = True
        Me.radOfficialRepo.UseVisualStyleBackColor = True
        '
        'radCommunityRepo
        '
        resources.ApplyResources(Me.radCommunityRepo, "radCommunityRepo")
        Me.radCommunityRepo.Name = "radCommunityRepo"
        Me.radCommunityRepo.TabStop = True
        Me.radCommunityRepo.UseVisualStyleBackColor = True
        '
        'cmbRepoList
        '
        Me.cmbRepoList.FormattingEnabled = True
        resources.ApplyResources(Me.cmbRepoList, "cmbRepoList")
        Me.cmbRepoList.Name = "cmbRepoList"
        '
        'btnFTC_Browse
        '
        resources.ApplyResources(Me.btnFTC_Browse, "btnFTC_Browse")
        Me.btnFTC_Browse.Name = "btnFTC_Browse"
        Me.btnFTC_Browse.Tag = "FTC"
        Me.btnFTC_Browse.UseVisualStyleBackColor = True
        '
        'txtFTC_ClonePath
        '
        resources.ApplyResources(Me.txtFTC_ClonePath, "txtFTC_ClonePath")
        Me.txtFTC_ClonePath.Name = "txtFTC_ClonePath"
        '
        'lblFTC_ClonePath
        '
        resources.ApplyResources(Me.lblFTC_ClonePath, "lblFTC_ClonePath")
        Me.lblFTC_ClonePath.Name = "lblFTC_ClonePath"
        '
        'btnClone
        '
        resources.ApplyResources(Me.btnClone, "btnClone")
        Me.btnClone.Name = "btnClone"
        Me.btnClone.UseVisualStyleBackColor = True
        '
        'prgStatus
        '
        resources.ApplyResources(Me.prgStatus, "prgStatus")
        Me.prgStatus.Name = "prgStatus"
        '
        'lblStatus
        '
        resources.ApplyResources(Me.lblStatus, "lblStatus")
        Me.lblStatus.Name = "lblStatus"
        '
        'btnAbort
        '
        Me.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.btnAbort, "btnAbort")
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.UseVisualStyleBackColor = True
        '
        'GUI
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnAbort
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.prgStatus)
        Me.Controls.Add(Me.grpGitRepo)
        Me.Controls.Add(Me.grpInstall)
        Me.Name = "GUI"
        Me.grpInstall.ResumeLayout(False)
        Me.grpInstall.PerformLayout()
        Me.grpGitRepo.ResumeLayout(False)
        Me.grpGitRepo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpInstall As System.Windows.Forms.GroupBox
    Friend WithEvents txtJDK_SetupPath As System.Windows.Forms.TextBox
    Friend WithEvents btnJDK_Search As System.Windows.Forms.Button
    Friend WithEvents chkAndroidStudio As System.Windows.Forms.CheckBox
    Friend WithEvents chkGit As System.Windows.Forms.CheckBox
    Friend WithEvents chkJDK As System.Windows.Forms.CheckBox
    Friend WithEvents lblJavaLinkDescription As System.Windows.Forms.Label
    Friend WithEvents llblJavaDownload As System.Windows.Forms.LinkLabel
    Friend WithEvents chkAndroidStudioDownload As System.Windows.Forms.CheckBox
    Friend WithEvents chkGitDownload As System.Windows.Forms.CheckBox
    Friend WithEvents txtGitSetupPath As System.Windows.Forms.TextBox
    Friend WithEvents btnAndroidStudioSetupPath As System.Windows.Forms.Button
    Friend WithEvents txtAndroidStudioISetupPath As System.Windows.Forms.TextBox
    Friend WithEvents btnGitSetupPath As System.Windows.Forms.Button
    Friend WithEvents btnInstall As System.Windows.Forms.Button
    Friend WithEvents grpGitRepo As System.Windows.Forms.GroupBox
    Friend WithEvents radOfficialRepo As System.Windows.Forms.RadioButton
    Friend WithEvents radCommunityRepo As System.Windows.Forms.RadioButton
    Friend WithEvents cmbRepoList As System.Windows.Forms.ComboBox
    Friend WithEvents btnFTC_Browse As System.Windows.Forms.Button
    Friend WithEvents txtFTC_ClonePath As System.Windows.Forms.TextBox
    Friend WithEvents lblFTC_ClonePath As System.Windows.Forms.Label
    Friend WithEvents btnClone As System.Windows.Forms.Button
    Friend WithEvents prgStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnAbort As System.Windows.Forms.Button
End Class
