Public Class GUI
    Private helper As Configure

    Private Delegate Sub SetDoubleCallback(ByVal value As Double)
    Private Delegate Sub SetVoidCallback()
    Private Delegate Sub SetTextCallback(ByVal message As String)

    Private Sub GUI_Load(sender As Object, e As EventArgs) Handles Me.Load
        helper = New Configure(Me)

        Me.prgStatus.Step = 33
        Me.lblStatus.Text = "Preparing"

        Me.lstJava.Items.Add("Pending")
        Me.prgStatus.PerformStep()
        Me.lstAndroidStudio.Items.Add("Pending")
        Me.prgStatus.PerformStep()
        Me.lstGit.Items.Add("Pending")
        Me.prgStatus.PerformStep()

        Me.prgStatus.Value = 0
        Me.lblStatus.Text = "Waiting"
    End Sub



    Private Sub btnConfigure_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim configureThread As New Threading.Thread(AddressOf helper.FullCheck)
        configureThread.Start()
    End Sub

    Private Sub btnSetup_Click(sender As Object, e As EventArgs) Handles btnSetup.Click
        Dim setupForm As New Setup.GUI()
        setupForm.Show()
        setupForm.BringToFront()
        setupForm.Focus()
    End Sub

    Public Sub LockCheck()
        If Me.btnCheck.InvokeRequired Then
            Dim d As New SetVoidCallback(AddressOf LockCheck)
            Me.Invoke(d)
        Else
            Me.btnCheck.Enabled = False
        End If
    End Sub

    Public Sub UnlockCheck()
        If Me.btnCheck.InvokeRequired Then
            Dim d As New SetVoidCallback(AddressOf UnlockCheck)
            Me.Invoke(d)
        Else
            Me.btnCheck.Enabled = True
        End If
    End Sub

    Public Sub JavaStatusAdd(ByVal message As String)
        If Me.lstJava.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf JavaStatusAdd)
            Me.Invoke(d, message)
        Else
            Me.lstJava.Items.Add(message)
        End If
    End Sub

    Public Sub JavaStatusClear()
        If Me.lstJava.InvokeRequired Then
            Dim d As New SetVoidCallback(AddressOf JavaStatusClear)
            Me.Invoke(d)
        Else
            Me.lstJava.Items.Clear()
        End If
    End Sub

    Public Sub JavaStatus(ByVal text As String)
        If Me.lblJava.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf JavaStatus)
            Me.Invoke(d, text)
        Else
            Me.lblJavaStatus.Text = text
            Select Case text.ToUpper
                Case "ERROR"
                    Me.lblJavaStatus.ForeColor = Color.Red
                Case "WARN"
                    Me.lblJavaStatus.ForeColor = Color.Yellow
                Case "GOOD"
                    Me.lblJavaStatus.ForeColor = Color.Green
                Case Else
                    Me.lblJavaStatus.ForeColor = Color.Black
            End Select
        End If
    End Sub

    Public Sub GitStatusAdd(ByVal message As String)
        If Me.lstGit.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf GitStatusAdd)
            Me.Invoke(d, message)
        Else
            Me.lstGit.Items.Add(message)
        End If
    End Sub

    Public Sub GitStatusClear()
        If Me.lstGit.InvokeRequired Then
            Dim d As New SetVoidCallback(AddressOf GitStatusClear)
            Me.Invoke(d)
        Else
            Me.lstGit.Items.Clear()
        End If
    End Sub

    Public Sub GitStatus(ByVal text As String)
        If Me.lblGit.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf GitStatus)
            Me.Invoke(d, text)
        Else
            Me.lblGitStatus.Text = text
            Select Case text.ToUpper
                Case "ERROR"
                    Me.lblGitStatus.ForeColor = Color.Red
                Case "WARN"
                    Me.lblGitStatus.ForeColor = Color.Yellow
                Case "GOOD"
                    Me.lblGitStatus.ForeColor = Color.Green
                Case Else
                    Me.lblGitStatus.ForeColor = Color.Black
            End Select
        End If
    End Sub

    Public Sub AndroidStudioStatusAdd(ByVal message As String)
        If Me.lstAndroidStudio.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf AndroidStudioStatusAdd)
            Me.Invoke(d, message)
        Else
            Me.lstAndroidStudio.Items.Add(message)
        End If
    End Sub

    Public Sub AndroidStudioStatusClear()
        If Me.lstAndroidStudio.InvokeRequired Then
            Dim d As New SetVoidCallback(AddressOf AndroidStudioStatusClear)
            Me.Invoke(d)
        Else
            Me.lstAndroidStudio.Items.Clear()
        End If
    End Sub

    Public Sub AndroidStudioStatus(ByVal text As String)
        If Me.lblAndroidStudio.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf AndroidStudioStatus)
            Me.Invoke(d, text)
        Else
            Me.lblAndroidStudioStatus.Text = text
            Select Case text.ToUpper
                Case "ERROR"
                    Me.lblAndroidStudioStatus.ForeColor = Color.Red
                Case "WARN"
                    Me.lblAndroidStudioStatus.ForeColor = Color.Yellow
                Case "GOOD"
                    Me.lblAndroidStudioStatus.ForeColor = Color.Green
                Case Else
                    Me.lblAndroidStudioStatus.ForeColor = Color.Black
            End Select
        End If
    End Sub

    Public Sub StatusText(ByVal text As String)
        If Me.lblStatus.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf StatusText)
            Me.Invoke(d, text)
        Else
            Me.lblStatus.Text = text
        End If
    End Sub

    Public Sub StatusBar(ByVal position As Double)
        If Me.prgStatus.InvokeRequired Then
            Dim d As New SetDoubleCallback(AddressOf StatusBar)
            Me.Invoke(d, position)
        Else
            If position <= 100 Then
                Me.prgStatus.Value = position
            Else
                Me.prgStatus.Value = 100
            End If
        End If
    End Sub
End Class
