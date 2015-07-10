Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.radComputerDHCP.Checked = True
        Me.radDriverStDHCP.Checked = True
        Me.radRobotCtrlDHCP.Checked = True

        For Each adapter In wlan_manager.ListAdapters()
            Me.lstAdapters.Items.Add(adapter)
        Next
        If lstAdapters.Items.Count > 0 Then
            lstAdapters.SelectedIndex = 0
        End If
    End Sub

    Private Sub radComputerDHCP_CheckedChanged(sender As Object, e As EventArgs) Handles radComputerDHCP.CheckedChanged
        'Me.lblComputer.Enabled = Not Me.radComputerDHCP.Checked
        txtComputer.Enabled = Not radComputerDHCP.Checked
    End Sub

    Private Sub radDriverStDHCP_CheckedChanged(sender As Object, e As EventArgs) Handles radDriverStDHCP.CheckedChanged
        'lblDriverSt.Enabled = Not radDriverStDHCP.Checked
        txtDriverSt.Enabled = Not radDriverStDHCP.Checked
    End Sub

    Private Sub radRobotCtrlDHCP_CheckedChanged(sender As Object, e As EventArgs) Handles radRobotCtrlDHCP.CheckedChanged
        'lblRobotCtrl.Enabled = Not radRobotCtrlDHCP.Checked
        txtRobotCtrl.Enabled = Not radRobotCtrlDHCP.Checked
    End Sub

    Private Sub Address_TextChanged(sender As Object, e As EventArgs) Handles txtDriverSt.TextChanged,
            txtComputer.TextChanged, txtRobotCtrl.TextChanged
        Dim btnAddress As TextBox = sender
        If wlan_manager.IsValidAddress(btnAddress.Text) Then
            btnAddress.ForeColor = Color.Black
            btnSetup.Enabled = True
            btnStart.Enabled = True
        Else
            btnSetup.Enabled = False
            btnStart.Enabled = False
            btnAddress.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        wlan_manager.Start()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        wlan_manager.StopNetwork()
    End Sub

    Private Sub btnSetup_Click(sender As Object, e As EventArgs) Handles btnSetup.Click
        If txtKey.Text.Length > 7 Then
            wlan_manager.Setup(lstAdapters.SelectedItem, txtSSID.Text, txtKey.Text)
        Else
            MsgBox("Key must be at least eight characters.", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub chkDisplay_CheckedChanged(sender As Object, e As EventArgs) Handles chkDisplay.CheckedChanged
        txtKey.UseSystemPasswordChar = Not chkDisplay.Checked
    End Sub
End Class
