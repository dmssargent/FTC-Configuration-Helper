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
        Me.btnSetup = New System.Windows.Forms.Button()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.prgStatus = New System.Windows.Forms.ProgressBar()
        Me.grpConfigure = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblGitStatus = New System.Windows.Forms.Label()
        Me.lstGit = New System.Windows.Forms.ListBox()
        Me.lblGit = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblAndroidStudioStatus = New System.Windows.Forms.Label()
        Me.lstAndroidStudio = New System.Windows.Forms.ListBox()
        Me.lblAndroidStudio = New System.Windows.Forms.Label()
        Me.pnlJava = New System.Windows.Forms.Panel()
        Me.lblJavaStatus = New System.Windows.Forms.Label()
        Me.lstJava = New System.Windows.Forms.ListBox()
        Me.lblJava = New System.Windows.Forms.Label()
        Me.grpConfigure.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlJava.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSetup
        '
        resources.ApplyResources(Me.btnSetup, "btnSetup")
        Me.btnSetup.Name = "btnSetup"
        Me.btnSetup.UseVisualStyleBackColor = True
        '
        'btnCheck
        '
        resources.ApplyResources(Me.btnCheck, "btnCheck")
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'prgStatus
        '
        resources.ApplyResources(Me.prgStatus, "prgStatus")
        Me.prgStatus.Name = "prgStatus"
        '
        'grpConfigure
        '
        resources.ApplyResources(Me.grpConfigure, "grpConfigure")
        Me.grpConfigure.Controls.Add(Me.Panel3)
        Me.grpConfigure.Controls.Add(Me.Panel1)
        Me.grpConfigure.Controls.Add(Me.Panel2)
        Me.grpConfigure.Controls.Add(Me.pnlJava)
        Me.grpConfigure.Name = "grpConfigure"
        Me.grpConfigure.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblStatus)
        Me.Panel3.Controls.Add(Me.prgStatus)
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.Name = "Panel3"
        '
        'lblStatus
        '
        resources.ApplyResources(Me.lblStatus, "lblStatus")
        Me.lblStatus.Name = "lblStatus"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblGitStatus)
        Me.Panel1.Controls.Add(Me.lstGit)
        Me.Panel1.Controls.Add(Me.lblGit)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'lblGitStatus
        '
        resources.ApplyResources(Me.lblGitStatus, "lblGitStatus")
        Me.lblGitStatus.Name = "lblGitStatus"
        '
        'lstGit
        '
        Me.lstGit.FormattingEnabled = True
        resources.ApplyResources(Me.lstGit, "lstGit")
        Me.lstGit.Name = "lstGit"
        '
        'lblGit
        '
        resources.ApplyResources(Me.lblGit, "lblGit")
        Me.lblGit.Name = "lblGit"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblAndroidStudioStatus)
        Me.Panel2.Controls.Add(Me.lstAndroidStudio)
        Me.Panel2.Controls.Add(Me.lblAndroidStudio)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'lblAndroidStudioStatus
        '
        resources.ApplyResources(Me.lblAndroidStudioStatus, "lblAndroidStudioStatus")
        Me.lblAndroidStudioStatus.Name = "lblAndroidStudioStatus"
        '
        'lstAndroidStudio
        '
        Me.lstAndroidStudio.FormattingEnabled = True
        resources.ApplyResources(Me.lstAndroidStudio, "lstAndroidStudio")
        Me.lstAndroidStudio.Name = "lstAndroidStudio"
        '
        'lblAndroidStudio
        '
        resources.ApplyResources(Me.lblAndroidStudio, "lblAndroidStudio")
        Me.lblAndroidStudio.Name = "lblAndroidStudio"
        '
        'pnlJava
        '
        Me.pnlJava.Controls.Add(Me.lblJavaStatus)
        Me.pnlJava.Controls.Add(Me.lstJava)
        Me.pnlJava.Controls.Add(Me.lblJava)
        resources.ApplyResources(Me.pnlJava, "pnlJava")
        Me.pnlJava.Name = "pnlJava"
        '
        'lblJavaStatus
        '
        resources.ApplyResources(Me.lblJavaStatus, "lblJavaStatus")
        Me.lblJavaStatus.Name = "lblJavaStatus"
        '
        'lstJava
        '
        Me.lstJava.FormattingEnabled = True
        resources.ApplyResources(Me.lstJava, "lstJava")
        Me.lstJava.Name = "lstJava"
        '
        'lblJava
        '
        resources.ApplyResources(Me.lblJava, "lblJava")
        Me.lblJava.Name = "lblJava"
        '
        'GUI
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.grpConfigure)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.btnSetup)
        Me.Name = "GUI"
        Me.grpConfigure.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnlJava.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSetup As System.Windows.Forms.Button
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents prgStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents grpConfigure As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lstGit As System.Windows.Forms.ListBox
    Friend WithEvents lblGit As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lstAndroidStudio As System.Windows.Forms.ListBox
    Friend WithEvents lblAndroidStudio As System.Windows.Forms.Label
    Friend WithEvents pnlJava As System.Windows.Forms.Panel
    Friend WithEvents lstJava As System.Windows.Forms.ListBox
    Friend WithEvents lblJava As System.Windows.Forms.Label
    Friend WithEvents lblGitStatus As System.Windows.Forms.Label
    Friend WithEvents lblAndroidStudioStatus As System.Windows.Forms.Label
    Friend WithEvents lblJavaStatus As System.Windows.Forms.Label

End Class
