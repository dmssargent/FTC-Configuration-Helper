<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setup
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
        Me.grpInstall = New System.Windows.Forms.GroupBox()
        Me.txtJDK_SetupPath = New System.Windows.Forms.TextBox()
        Me.btnJDK_Search = New System.Windows.Forms.Button()
        Me.chkAndroidStudio = New System.Windows.Forms.CheckBox()
        Me.chkGit = New System.Windows.Forms.CheckBox()
        Me.chkJDK = New System.Windows.Forms.CheckBox()
        Me.txtAndroidStudioISetupPath = New System.Windows.Forms.TextBox()
        Me.btnGitSetupPath = New System.Windows.Forms.Button()
        Me.txtGitSetupPath = New System.Windows.Forms.TextBox()
        Me.btnAndroidStudioSetupPath = New System.Windows.Forms.Button()
        Me.chkGitDownload = New System.Windows.Forms.CheckBox()
        Me.chkAndroidStudioDownload = New System.Windows.Forms.CheckBox()
        Me.llblJavaDownload = New System.Windows.Forms.LinkLabel()
        Me.lblJavaLinkDescription = New System.Windows.Forms.Label()
        Me.btnInstall = New System.Windows.Forms.Button()
        Me.grpGitRepo = New System.Windows.Forms.GroupBox()
        Me.lblFTC_ClonePath = New System.Windows.Forms.Label()
        Me.txtFTC_ClonePath = New System.Windows.Forms.TextBox()
        Me.btnFTC_Browse = New System.Windows.Forms.Button()
        Me.cmbRepoList = New System.Windows.Forms.ComboBox()
        Me.radCommunityRepo = New System.Windows.Forms.RadioButton()
        Me.radOfficialRepo = New System.Windows.Forms.RadioButton()
        Me.btnClone = New System.Windows.Forms.Button()
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
        Me.grpInstall.Controls.Add(Me.btnAndroidStudioSetupPath)
        Me.grpInstall.Controls.Add(Me.txtAndroidStudioISetupPath)
        Me.grpInstall.Controls.Add(Me.btnGitSetupPath)
        Me.grpInstall.Controls.Add(Me.txtJDK_SetupPath)
        Me.grpInstall.Controls.Add(Me.btnJDK_Search)
        Me.grpInstall.Controls.Add(Me.chkAndroidStudio)
        Me.grpInstall.Controls.Add(Me.chkGit)
        Me.grpInstall.Controls.Add(Me.chkJDK)
        Me.grpInstall.Location = New System.Drawing.Point(12, 12)
        Me.grpInstall.Name = "grpInstall"
        Me.grpInstall.Size = New System.Drawing.Size(537, 200)
        Me.grpInstall.TabIndex = 0
        Me.grpInstall.TabStop = False
        Me.grpInstall.Text = "Select Items to Install:"
        '
        'txtJDK_SetupPath
        '
        Me.txtJDK_SetupPath.Location = New System.Drawing.Point(136, 22)
        Me.txtJDK_SetupPath.Name = "txtJDK_SetupPath"
        Me.txtJDK_SetupPath.Size = New System.Drawing.Size(289, 22)
        Me.txtJDK_SetupPath.TabIndex = 4
        '
        'btnJDK_Search
        '
        Me.btnJDK_Search.Location = New System.Drawing.Point(431, 22)
        Me.btnJDK_Search.Name = "btnJDK_Search"
        Me.btnJDK_Search.Size = New System.Drawing.Size(100, 23)
        Me.btnJDK_Search.TabIndex = 3
        Me.btnJDK_Search.Text = "Browse..."
        Me.btnJDK_Search.UseVisualStyleBackColor = True
        '
        'chkAndroidStudio
        '
        Me.chkAndroidStudio.AutoSize = True
        Me.chkAndroidStudio.Location = New System.Drawing.Point(7, 143)
        Me.chkAndroidStudio.Name = "chkAndroidStudio"
        Me.chkAndroidStudio.Size = New System.Drawing.Size(123, 21)
        Me.chkAndroidStudio.TabIndex = 2
        Me.chkAndroidStudio.Text = "Android Studio"
        Me.chkAndroidStudio.UseVisualStyleBackColor = True
        '
        'chkGit
        '
        Me.chkGit.AutoSize = True
        Me.chkGit.Location = New System.Drawing.Point(7, 88)
        Me.chkGit.Name = "chkGit"
        Me.chkGit.Size = New System.Drawing.Size(48, 21)
        Me.chkGit.TabIndex = 1
        Me.chkGit.Text = "Git"
        Me.chkGit.UseVisualStyleBackColor = True
        '
        'chkJDK
        '
        Me.chkJDK.AutoSize = True
        Me.chkJDK.Location = New System.Drawing.Point(7, 22)
        Me.chkJDK.Name = "chkJDK"
        Me.chkJDK.Size = New System.Drawing.Size(56, 21)
        Me.chkJDK.TabIndex = 0
        Me.chkJDK.Text = "JDK"
        Me.chkJDK.UseVisualStyleBackColor = True
        '
        'txtAndroidStudioISetupPath
        '
        Me.txtAndroidStudioISetupPath.Location = New System.Drawing.Point(136, 143)
        Me.txtAndroidStudioISetupPath.Name = "txtAndroidStudioISetupPath"
        Me.txtAndroidStudioISetupPath.Size = New System.Drawing.Size(289, 22)
        Me.txtAndroidStudioISetupPath.TabIndex = 6
        '
        'btnGitSetupPath
        '
        Me.btnGitSetupPath.Location = New System.Drawing.Point(431, 85)
        Me.btnGitSetupPath.Name = "btnGitSetupPath"
        Me.btnGitSetupPath.Size = New System.Drawing.Size(100, 23)
        Me.btnGitSetupPath.TabIndex = 5
        Me.btnGitSetupPath.Text = "Browse..."
        Me.btnGitSetupPath.UseVisualStyleBackColor = True
        '
        'txtGitSetupPath
        '
        Me.txtGitSetupPath.Location = New System.Drawing.Point(136, 86)
        Me.txtGitSetupPath.Name = "txtGitSetupPath"
        Me.txtGitSetupPath.Size = New System.Drawing.Size(289, 22)
        Me.txtGitSetupPath.TabIndex = 8
        '
        'btnAndroidStudioSetupPath
        '
        Me.btnAndroidStudioSetupPath.Location = New System.Drawing.Point(431, 143)
        Me.btnAndroidStudioSetupPath.Name = "btnAndroidStudioSetupPath"
        Me.btnAndroidStudioSetupPath.Size = New System.Drawing.Size(100, 23)
        Me.btnAndroidStudioSetupPath.TabIndex = 7
        Me.btnAndroidStudioSetupPath.Text = "Browse..."
        Me.btnAndroidStudioSetupPath.UseVisualStyleBackColor = True
        '
        'chkGitDownload
        '
        Me.chkGitDownload.AutoSize = True
        Me.chkGitDownload.Location = New System.Drawing.Point(136, 115)
        Me.chkGitDownload.Name = "chkGitDownload"
        Me.chkGitDownload.Size = New System.Drawing.Size(200, 21)
        Me.chkGitDownload.TabIndex = 9
        Me.chkGitDownload.Text = "Install from Internet instead"
        Me.chkGitDownload.UseVisualStyleBackColor = True
        '
        'chkAndroidStudioDownload
        '
        Me.chkAndroidStudioDownload.AutoSize = True
        Me.chkAndroidStudioDownload.Location = New System.Drawing.Point(136, 171)
        Me.chkAndroidStudioDownload.Name = "chkAndroidStudioDownload"
        Me.chkAndroidStudioDownload.Size = New System.Drawing.Size(200, 21)
        Me.chkAndroidStudioDownload.TabIndex = 10
        Me.chkAndroidStudioDownload.Text = "Install from Internet instead"
        Me.chkAndroidStudioDownload.UseVisualStyleBackColor = True
        '
        'llblJavaDownload
        '
        Me.llblJavaDownload.AutoSize = True
        Me.llblJavaDownload.Location = New System.Drawing.Point(272, 51)
        Me.llblJavaDownload.Name = "llblJavaDownload"
        Me.llblJavaDownload.Size = New System.Drawing.Size(164, 20)
        Me.llblJavaDownload.TabIndex = 11
        Me.llblJavaDownload.TabStop = True
        Me.llblJavaDownload.Text = "Java SE JDK 7 Downloads"
        Me.llblJavaDownload.UseCompatibleTextRendering = True
        '
        'lblJavaLinkDescription
        '
        Me.lblJavaLinkDescription.AutoSize = True
        Me.lblJavaLinkDescription.Location = New System.Drawing.Point(136, 51)
        Me.lblJavaLinkDescription.Name = "lblJavaLinkDescription"
        Me.lblJavaLinkDescription.Size = New System.Drawing.Size(139, 17)
        Me.lblJavaLinkDescription.TabIndex = 12
        Me.lblJavaLinkDescription.Text = "Download from here:"
        '
        'btnInstall
        '
        Me.btnInstall.Location = New System.Drawing.Point(185, 218)
        Me.btnInstall.Name = "btnInstall"
        Me.btnInstall.Size = New System.Drawing.Size(174, 56)
        Me.btnInstall.TabIndex = 1
        Me.btnInstall.Text = "Install Programs"
        Me.btnInstall.UseVisualStyleBackColor = True
        '
        'grpGitRepo
        '
        Me.grpGitRepo.Controls.Add(Me.radOfficialRepo)
        Me.grpGitRepo.Controls.Add(Me.radCommunityRepo)
        Me.grpGitRepo.Controls.Add(Me.cmbRepoList)
        Me.grpGitRepo.Controls.Add(Me.btnFTC_Browse)
        Me.grpGitRepo.Controls.Add(Me.txtFTC_ClonePath)
        Me.grpGitRepo.Controls.Add(Me.lblFTC_ClonePath)
        Me.grpGitRepo.Location = New System.Drawing.Point(12, 285)
        Me.grpGitRepo.Name = "grpGitRepo"
        Me.grpGitRepo.Size = New System.Drawing.Size(537, 119)
        Me.grpGitRepo.TabIndex = 2
        Me.grpGitRepo.TabStop = False
        Me.grpGitRepo.Text = "Get a FTC SDK (via Git):"
        '
        'lblFTC_ClonePath
        '
        Me.lblFTC_ClonePath.AutoSize = True
        Me.lblFTC_ClonePath.Location = New System.Drawing.Point(6, 24)
        Me.lblFTC_ClonePath.Name = "lblFTC_ClonePath"
        Me.lblFTC_ClonePath.Size = New System.Drawing.Size(128, 17)
        Me.lblFTC_ClonePath.TabIndex = 0
        Me.lblFTC_ClonePath.Text = "FTC SDK Location:"
        '
        'txtFTC_ClonePath
        '
        Me.txtFTC_ClonePath.Location = New System.Drawing.Point(140, 22)
        Me.txtFTC_ClonePath.Name = "txtFTC_ClonePath"
        Me.txtFTC_ClonePath.Size = New System.Drawing.Size(296, 22)
        Me.txtFTC_ClonePath.TabIndex = 1
        '
        'btnFTC_Browse
        '
        Me.btnFTC_Browse.Location = New System.Drawing.Point(445, 21)
        Me.btnFTC_Browse.Name = "btnFTC_Browse"
        Me.btnFTC_Browse.Size = New System.Drawing.Size(86, 23)
        Me.btnFTC_Browse.TabIndex = 2
        Me.btnFTC_Browse.Text = "Browse..."
        Me.btnFTC_Browse.UseVisualStyleBackColor = True
        '
        'cmbRepoList
        '
        Me.cmbRepoList.FormattingEnabled = True
        Me.cmbRepoList.Location = New System.Drawing.Point(314, 76)
        Me.cmbRepoList.Name = "cmbRepoList"
        Me.cmbRepoList.Size = New System.Drawing.Size(217, 24)
        Me.cmbRepoList.TabIndex = 3
        '
        'radCommunityRepo
        '
        Me.radCommunityRepo.AutoSize = True
        Me.radCommunityRepo.Location = New System.Drawing.Point(140, 77)
        Me.radCommunityRepo.Name = "radCommunityRepo"
        Me.radCommunityRepo.Size = New System.Drawing.Size(168, 21)
        Me.radCommunityRepo.TabIndex = 4
        Me.radCommunityRepo.TabStop = True
        Me.radCommunityRepo.Text = "Use community made:"
        Me.radCommunityRepo.UseVisualStyleBackColor = True
        '
        'radOfficialRepo
        '
        Me.radOfficialRepo.AutoSize = True
        Me.radOfficialRepo.Location = New System.Drawing.Point(140, 50)
        Me.radOfficialRepo.Name = "radOfficialRepo"
        Me.radOfficialRepo.Size = New System.Drawing.Size(98, 21)
        Me.radOfficialRepo.TabIndex = 5
        Me.radOfficialRepo.TabStop = True
        Me.radOfficialRepo.Text = "Use official"
        Me.radOfficialRepo.UseVisualStyleBackColor = True
        '
        'btnClone
        '
        Me.btnClone.Location = New System.Drawing.Point(221, 410)
        Me.btnClone.Name = "btnClone"
        Me.btnClone.Size = New System.Drawing.Size(99, 27)
        Me.btnClone.TabIndex = 3
        Me.btnClone.Text = "Clone"
        Me.btnClone.UseVisualStyleBackColor = True
        '
        'setup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 449)
        Me.Controls.Add(Me.btnClone)
        Me.Controls.Add(Me.grpGitRepo)
        Me.Controls.Add(Me.btnInstall)
        Me.Controls.Add(Me.grpInstall)
        Me.Name = "setup"
        Me.Text = "Setup"
        Me.grpInstall.ResumeLayout(False)
        Me.grpInstall.PerformLayout()
        Me.grpGitRepo.ResumeLayout(False)
        Me.grpGitRepo.PerformLayout()
        Me.ResumeLayout(False)

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
End Class
