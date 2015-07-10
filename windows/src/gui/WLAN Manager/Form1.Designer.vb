<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtDriverSt = New System.Windows.Forms.TextBox()
        Me.txtRobotCtrl = New System.Windows.Forms.TextBox()
        Me.txtComputer = New System.Windows.Forms.TextBox()
        Me.grpRobot = New System.Windows.Forms.GroupBox()
        Me.radRobot = New System.Windows.Forms.RadioButton()
        Me.radRobotCtrlDHCP = New System.Windows.Forms.RadioButton()
        Me.grpDriver = New System.Windows.Forms.GroupBox()
        Me.radDriverSt = New System.Windows.Forms.RadioButton()
        Me.radDriverStDHCP = New System.Windows.Forms.RadioButton()
        Me.grpComputer = New System.Windows.Forms.GroupBox()
        Me.radComputer = New System.Windows.Forms.RadioButton()
        Me.radComputerDHCP = New System.Windows.Forms.RadioButton()
        Me.lstAdapters = New System.Windows.Forms.ListBox()
        Me.btnSetup = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSSID = New System.Windows.Forms.TextBox()
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.lblSSID = New System.Windows.Forms.Label()
        Me.lblKey = New System.Windows.Forms.Label()
        Me.chkDisplay = New System.Windows.Forms.CheckBox()
        Me.grpRobot.SuspendLayout()
        Me.grpDriver.SuspendLayout()
        Me.grpComputer.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDriverSt
        '
        Me.txtDriverSt.Location = New System.Drawing.Point(103, 19)
        Me.txtDriverSt.Name = "txtDriverSt"
        Me.txtDriverSt.Size = New System.Drawing.Size(90, 20)
        Me.txtDriverSt.TabIndex = 3
        '
        'txtRobotCtrl
        '
        Me.txtRobotCtrl.Location = New System.Drawing.Point(103, 19)
        Me.txtRobotCtrl.Name = "txtRobotCtrl"
        Me.txtRobotCtrl.Size = New System.Drawing.Size(90, 20)
        Me.txtRobotCtrl.TabIndex = 4
        '
        'txtComputer
        '
        Me.txtComputer.Location = New System.Drawing.Point(103, 18)
        Me.txtComputer.Name = "txtComputer"
        Me.txtComputer.Size = New System.Drawing.Size(90, 20)
        Me.txtComputer.TabIndex = 5
        '
        'grpRobot
        '
        Me.grpRobot.Controls.Add(Me.radRobot)
        Me.grpRobot.Controls.Add(Me.radRobotCtrlDHCP)
        Me.grpRobot.Controls.Add(Me.txtRobotCtrl)
        Me.grpRobot.Location = New System.Drawing.Point(18, 87)
        Me.grpRobot.Name = "grpRobot"
        Me.grpRobot.Size = New System.Drawing.Size(260, 47)
        Me.grpRobot.TabIndex = 6
        Me.grpRobot.TabStop = False
        Me.grpRobot.Text = "Robot Controller"
        '
        'radRobot
        '
        Me.radRobot.AutoSize = True
        Me.radRobot.Location = New System.Drawing.Point(6, 20)
        Me.radRobot.Name = "radRobot"
        Me.radRobot.Size = New System.Drawing.Size(91, 17)
        Me.radRobot.TabIndex = 5
        Me.radRobot.TabStop = True
        Me.radRobot.Text = "IPv4 Address:"
        Me.radRobot.UseVisualStyleBackColor = True
        '
        'radRobotCtrlDHCP
        '
        Me.radRobotCtrlDHCP.AutoSize = True
        Me.radRobotCtrlDHCP.Location = New System.Drawing.Point(199, 20)
        Me.radRobotCtrlDHCP.Name = "radRobotCtrlDHCP"
        Me.radRobotCtrlDHCP.Size = New System.Drawing.Size(55, 17)
        Me.radRobotCtrlDHCP.TabIndex = 0
        Me.radRobotCtrlDHCP.TabStop = True
        Me.radRobotCtrlDHCP.Text = "DHCP"
        Me.radRobotCtrlDHCP.UseVisualStyleBackColor = True
        '
        'grpDriver
        '
        Me.grpDriver.Controls.Add(Me.radDriverSt)
        Me.grpDriver.Controls.Add(Me.radDriverStDHCP)
        Me.grpDriver.Controls.Add(Me.txtDriverSt)
        Me.grpDriver.Location = New System.Drawing.Point(18, 140)
        Me.grpDriver.Name = "grpDriver"
        Me.grpDriver.Size = New System.Drawing.Size(260, 49)
        Me.grpDriver.TabIndex = 7
        Me.grpDriver.TabStop = False
        Me.grpDriver.Text = "Driver Station"
        '
        'radDriverSt
        '
        Me.radDriverSt.AutoSize = True
        Me.radDriverSt.Location = New System.Drawing.Point(6, 20)
        Me.radDriverSt.Name = "radDriverSt"
        Me.radDriverSt.Size = New System.Drawing.Size(91, 17)
        Me.radDriverSt.TabIndex = 6
        Me.radDriverSt.TabStop = True
        Me.radDriverSt.Text = "IPv4 Address:"
        Me.radDriverSt.UseVisualStyleBackColor = True
        '
        'radDriverStDHCP
        '
        Me.radDriverStDHCP.AutoSize = True
        Me.radDriverStDHCP.Location = New System.Drawing.Point(199, 20)
        Me.radDriverStDHCP.Name = "radDriverStDHCP"
        Me.radDriverStDHCP.Size = New System.Drawing.Size(55, 17)
        Me.radDriverStDHCP.TabIndex = 0
        Me.radDriverStDHCP.TabStop = True
        Me.radDriverStDHCP.Text = "DHCP"
        Me.radDriverStDHCP.UseVisualStyleBackColor = True
        '
        'grpComputer
        '
        Me.grpComputer.Controls.Add(Me.radComputer)
        Me.grpComputer.Controls.Add(Me.radComputerDHCP)
        Me.grpComputer.Controls.Add(Me.txtComputer)
        Me.grpComputer.Location = New System.Drawing.Point(18, 195)
        Me.grpComputer.Name = "grpComputer"
        Me.grpComputer.Size = New System.Drawing.Size(260, 55)
        Me.grpComputer.TabIndex = 8
        Me.grpComputer.TabStop = False
        Me.grpComputer.Text = "Development Computer"
        '
        'radComputer
        '
        Me.radComputer.AutoSize = True
        Me.radComputer.Location = New System.Drawing.Point(6, 19)
        Me.radComputer.Name = "radComputer"
        Me.radComputer.Size = New System.Drawing.Size(91, 17)
        Me.radComputer.TabIndex = 6
        Me.radComputer.TabStop = True
        Me.radComputer.Text = "IPv4 Address:"
        Me.radComputer.UseVisualStyleBackColor = True
        '
        'radComputerDHCP
        '
        Me.radComputerDHCP.AutoSize = True
        Me.radComputerDHCP.Location = New System.Drawing.Point(199, 19)
        Me.radComputerDHCP.Name = "radComputerDHCP"
        Me.radComputerDHCP.Size = New System.Drawing.Size(55, 17)
        Me.radComputerDHCP.TabIndex = 0
        Me.radComputerDHCP.TabStop = True
        Me.radComputerDHCP.Text = "DHCP"
        Me.radComputerDHCP.UseVisualStyleBackColor = True
        '
        'lstAdapters
        '
        Me.lstAdapters.FormattingEnabled = True
        Me.lstAdapters.Location = New System.Drawing.Point(18, 256)
        Me.lstAdapters.Name = "lstAdapters"
        Me.lstAdapters.Size = New System.Drawing.Size(177, 82)
        Me.lstAdapters.TabIndex = 9
        '
        'btnSetup
        '
        Me.btnSetup.Location = New System.Drawing.Point(202, 257)
        Me.btnSetup.Name = "btnSetup"
        Me.btnSetup.Size = New System.Drawing.Size(75, 23)
        Me.btnSetup.TabIndex = 10
        Me.btnSetup.Text = "Setup"
        Me.btnSetup.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnStart.Location = New System.Drawing.Point(202, 287)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 11
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.ForeColor = System.Drawing.Color.Red
        Me.btnStop.Location = New System.Drawing.Point(202, 317)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 12
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDisplay)
        Me.GroupBox1.Controls.Add(Me.lblKey)
        Me.GroupBox1.Controls.Add(Me.lblSSID)
        Me.GroupBox1.Controls.Add(Me.txtKey)
        Me.GroupBox1.Controls.Add(Me.txtSSID)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(324, 68)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'txtSSID
        '
        Me.txtSSID.Location = New System.Drawing.Point(50, 20)
        Me.txtSSID.Name = "txtSSID"
        Me.txtSSID.Size = New System.Drawing.Size(100, 20)
        Me.txtSSID.TabIndex = 0
        '
        'txtKey
        '
        Me.txtKey.Location = New System.Drawing.Point(193, 19)
        Me.txtKey.Name = "txtKey"
        Me.txtKey.Size = New System.Drawing.Size(100, 20)
        Me.txtKey.TabIndex = 1
        '
        'lblSSID
        '
        Me.lblSSID.AutoSize = True
        Me.lblSSID.Location = New System.Drawing.Point(9, 24)
        Me.lblSSID.Name = "lblSSID"
        Me.lblSSID.Size = New System.Drawing.Size(35, 13)
        Me.lblSSID.TabIndex = 2
        Me.lblSSID.Text = "SSID:"
        '
        'lblKey
        '
        Me.lblKey.AutoSize = True
        Me.lblKey.Location = New System.Drawing.Point(159, 24)
        Me.lblKey.Name = "lblKey"
        Me.lblKey.Size = New System.Drawing.Size(28, 13)
        Me.lblKey.TabIndex = 3
        Me.lblKey.Text = "Key:"
        '
        'chkDisplay
        '
        Me.chkDisplay.AutoSize = True
        Me.chkDisplay.Location = New System.Drawing.Point(193, 45)
        Me.chkDisplay.Name = "chkDisplay"
        Me.chkDisplay.Size = New System.Drawing.Size(102, 17)
        Me.chkDisplay.TabIndex = 4
        Me.chkDisplay.Text = "Show Password"
        Me.chkDisplay.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 344)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnSetup)
        Me.Controls.Add(Me.lstAdapters)
        Me.Controls.Add(Me.grpComputer)
        Me.Controls.Add(Me.grpDriver)
        Me.Controls.Add(Me.grpRobot)
        Me.Name = "Form1"
        Me.Text = "WLAN Manager"
        Me.grpRobot.ResumeLayout(False)
        Me.grpRobot.PerformLayout()
        Me.grpDriver.ResumeLayout(False)
        Me.grpDriver.PerformLayout()
        Me.grpComputer.ResumeLayout(False)
        Me.grpComputer.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtDriverSt As TextBox
    Friend WithEvents txtRobotCtrl As TextBox
    Friend WithEvents txtComputer As TextBox
    Friend WithEvents grpRobot As GroupBox
    Friend WithEvents radRobotCtrlDHCP As RadioButton
    Friend WithEvents grpDriver As GroupBox
    Friend WithEvents radDriverStDHCP As RadioButton
    Friend WithEvents grpComputer As GroupBox
    Friend WithEvents radComputerDHCP As RadioButton
    Friend WithEvents lstAdapters As ListBox
    Friend WithEvents btnSetup As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents radRobot As RadioButton
    Friend WithEvents radDriverSt As RadioButton
    Friend WithEvents radComputer As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblKey As Label
    Friend WithEvents lblSSID As Label
    Friend WithEvents txtKey As TextBox
    Friend WithEvents txtSSID As TextBox
    Friend WithEvents chkDisplay As CheckBox
End Class
