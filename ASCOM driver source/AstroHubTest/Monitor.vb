Imports ASCOM.Utilities
Imports ASCOM.AstroHub
Imports ASCOM.DeviceInterface

Public Class AstroHubViewer

    Delegate Sub SetMotorCallback(ByVal pos As Integer)
    Delegate Sub SetTemperatureCallback(ByVal temp As Double)
    Delegate Sub SetHumidityCallback(ByVal hum As Double)
    Delegate Sub SetDewPointCallback(ByVal dewpoint As Double)
    Delegate Sub SetTemperature2Callback(ByVal temp2 As Double)
    Delegate Sub SetVccCallback(ByVal vcc As Double)
    Delegate Sub SetVregCallback(ByVal vreg As Double)

    Private DirCheck As Integer = 1
    Private VDivider As Double = 4.25
    Private AHub As Focuser
    Private monitorTimer As System.Timers.Timer

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        monitorTimer = New System.Timers.Timer()
        monitorTimer.Interval = 250
        monitorTimer.Enabled = True
        AddHandler monitorTimer.Elapsed, AddressOf OnMonitorTimer

    End Sub

    Private Sub OnMonitorTimer(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs)
        SetMotor(AstroHub.Focuser.positionCache)
        SetTemperature(AstroHub.Focuser.Temp)
        SetHumidity(AstroHub.Focuser.Hum)
        SetDewPoint(AstroHub.Focuser.DewPoint)
        SetTemperature2(AstroHub.Focuser.Temp2)
        SetVcc(AstroHub.Focuser.Vcc)
        SetVreg(AstroHub.Focuser.Vreg)
    End Sub

    Public WriteOnly Property focuser() As Focuser
        Set(ByVal value As Focuser)
            AHub = value
        End Set
    End Property

    Private Sub PWM1_Check_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles PWM1_Check.CheckedChanged
        Dim state As Boolean = PWM1_Check.Checked
        PWM1_Heater.Enabled = PWM1_Check.Checked
        If state Then
            PWM1_Heater.Enabled = state
            PWM1_Slider.Enabled = state
        Else
            PWM1_Heater.Checked = False
            PWM1_Heater.Enabled = state
            PWM1_Slider.Enabled = state
            PWM1_Slider.Value = 0
            PWM1_Display.Text = 0
            TextBox1.AppendText("P:1:0" + vbNewLine)
            AHub.CommandString("P:1:0" + vbNewLine)
        End If
    End Sub

    Private Sub PWM2_Check_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles PWM2_Check.CheckedChanged
        Dim state As Boolean = PWM2_Check.Checked
        PWM2_Heater.Enabled = PWM2_Check.Checked
        If state Then
            PWM2_Heater.Enabled = state
            PWM2_Slider.Enabled = state
        Else
            PWM2_Heater.Checked = False
            PWM2_Heater.Enabled = state
            PWM2_Slider.Enabled = state
            PWM2_Slider.Value = 0
            PWM2_Display.Text = 0
            TextBox1.AppendText("P:2:0" + vbNewLine)
            AHub.CommandString("P:2:0" + vbNewLine)
        End If
    End Sub

    Private Sub PWM3_Check_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles PWM3_Check.CheckedChanged
        Dim state As Boolean = PWM3_Check.Checked
        PWM3_Heater.Enabled = PWM3_Check.Checked
        If state Then
            PWM3_Heater.Enabled = state
            PWM3_Slider.Enabled = state
        Else
            PWM3_Heater.Checked = False
            PWM3_Heater.Enabled = state
            PWM3_Slider.Enabled = state
            PWM3_Slider.Value = 0
            PWM3_Display.Text = 0
            TextBox1.AppendText("P:3:0" + vbNewLine)
            AHub.CommandString("P:3:0" + vbNewLine)
        End If
    End Sub

    Private Sub PWM4_Check_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles PWM4_Check.CheckedChanged
        Dim state As Boolean = PWM4_Check.Checked
        PWM4_Heater.Enabled = PWM4_Check.Checked
        If state Then
            PWM4_Heater.Enabled = state
            PWM4_Slider.Enabled = state
        Else
            PWM4_Heater.Checked = False
            PWM4_Heater.Enabled = state
            PWM4_Slider.Enabled = state
            PWM4_Slider.Value = 0
            PWM4_Display.Text = 0
            TextBox1.AppendText("P:4:0" + vbNewLine)
            AHub.CommandString("P:4:0" + vbNewLine)
        End If
    End Sub

    Private Sub PWM1_Slider_Scroll(sender As System.Object, e As System.EventArgs) Handles PWM1_Slider.Scroll
        Dim send As String = "P:1:" + PWM1_Slider.Value.ToString + vbNewLine
        PWM1_Display.Text = PWM1_Slider.Value.ToString
        'send.StartsWith()
        TextBox1.AppendText(send)
        AHub.CommandString(send)
    End Sub

    Private Sub PWM2_Slider_Scroll(sender As System.Object, e As System.EventArgs) Handles PWM2_Slider.Scroll
        Dim send As String = "P:2:" + PWM2_Slider.Value.ToString + vbNewLine
        PWM2_Display.Text = PWM2_Slider.Value.ToString
        TextBox1.AppendText(send)
        AHub.CommandString(send)
    End Sub

    Private Sub PWM3_Slider_Scroll(sender As System.Object, e As System.EventArgs) Handles PWM3_Slider.Scroll
        Dim send As String = "P:3:" + PWM3_Slider.Value.ToString + vbNewLine
        PWM3_Display.Text = PWM3_Slider.Value.ToString
        TextBox1.AppendText(send)
        AHub.CommandString(send)
    End Sub

    Private Sub PWM4_Slider_Scroll(sender As System.Object, e As System.EventArgs) Handles PWM4_Slider.Scroll
        Dim send As String = "P:4:" + PWM4_Slider.Value.ToString + vbNewLine
        PWM4_Display.Text = PWM4_Slider.Value.ToString
        TextBox1.AppendText(send)
        AHub.CommandString(send)
    End Sub

    Private Sub moveStepper(ByRef value As Integer)
        Dim send As String = "M:" + value.ToString + vbNewLine
        Dim steps As Integer = AstroHub.Focuser.positionCache + value
        AHub.Move(steps)
        TextBox1.AppendText(send)
    End Sub

    Private Sub P1000_Button_Click(sender As System.Object, e As System.EventArgs) Handles P1000_Button.Click
        moveStepper(1000 * DirCheck)
    End Sub

    Private Sub P100_Button_Click(sender As System.Object, e As System.EventArgs) Handles P100_Button.Click
        moveStepper(100 * DirCheck)
    End Sub

    Private Sub P10_Button_Click(sender As System.Object, e As System.EventArgs) Handles P10_Button.Click
        moveStepper(10 * DirCheck)
    End Sub

    Private Sub P1_Button_Click(sender As System.Object, e As System.EventArgs) Handles P1_Button.Click
        moveStepper(1 * DirCheck)
    End Sub

    Private Sub Stop_Button_Click(sender As System.Object, e As System.EventArgs) Handles Stop_Button.Click
        Dim send As String = "H:1" + vbNewLine
        AHub.Halt()
        TextBox1.AppendText(send)
    End Sub

    Private Sub M1_Button_Click(sender As System.Object, e As System.EventArgs) Handles M1_Button.Click
        moveStepper(-1 * DirCheck)
    End Sub

    Private Sub M10_Button_Click(sender As System.Object, e As System.EventArgs) Handles M10_Button.Click
        moveStepper(-10 * DirCheck)
    End Sub

    Private Sub M100_Button_Click(sender As System.Object, e As System.EventArgs) Handles M100_Button.Click
        moveStepper(-100 * DirCheck)
    End Sub

    Private Sub M1000_Button_Click(sender As System.Object, e As System.EventArgs) Handles M1000_Button.Click
        moveStepper(-1000 * DirCheck)
    End Sub

    Private Sub Move_Button_Click(sender As System.Object, e As System.EventArgs) Handles Move_Button.Click
        moveStepper(Move_Edit.Value * DirCheck)
    End Sub

    Private Sub MoveTo_Button_Click(sender As System.Object, e As System.EventArgs) Handles MoveTo_Button.Click
        Dim send As String = "S:" + MoveTo_Edit.Value.ToString + vbNewLine
        AHub.Move(send)
        TextBox1.AppendText(send)
    End Sub

    Private Sub Dir_Check_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Dir_Check.CheckedChanged
        Dim state As Boolean = Dir_Check.Checked
        If state Then
            DirCheck = -1
        Else
            DirCheck = 1
        End If
    End Sub

    Private Sub PWM1_Heater_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles PWM1_Heater.CheckedChanged
        Dim state As Boolean = PWM1_Heater.Checked
        PWM1_Slider.Enabled = Not state
    End Sub

    Private Sub PWM2_Heater_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles PWM2_Heater.CheckedChanged
        Dim state As Boolean = PWM2_Heater.Checked
        PWM2_Slider.Enabled = Not state
    End Sub

    Private Sub PWM3_Heater_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles PWM3_Heater.CheckedChanged
        Dim state As Boolean = PWM3_Heater.Checked
        PWM3_Slider.Enabled = Not state
    End Sub

    Private Sub PWM4_Heater_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles PWM4_Heater.CheckedChanged
        Dim state As Boolean = PWM4_Heater.Checked
        PWM4_Slider.Enabled = Not state
    End Sub

    Private Sub SetMotor(ByVal pos As Integer)
        If Me.Motor_Display.InvokeRequired Then
            Dim d As New SetMotorCallback(AddressOf SetMotor)
            Me.Invoke(d, New Object() {pos})
        Else
            Me.Motor_Display.Text = pos.ToString
        End If
    End Sub

    Private Sub SetTemperature(ByVal temp As Double)
        If Me.Temperature_Display.InvokeRequired Then
            Dim d As New SetTemperatureCallback(AddressOf SetTemperature)
            Me.Invoke(d, New Object() {temp})
        Else
            Me.Temperature_Display.Text = String.Format("{0:F2}", temp)
        End If
    End Sub

    Private Sub SetHumidity(ByVal hum As Double)
        If Me.Humidity_Display.InvokeRequired Then
            Dim d As New SetHumidityCallback(AddressOf SetHumidity)
            Me.Invoke(d, New Object() {hum})
        Else
            Me.Humidity_Display.Text = String.Format("{0:F2}", hum)
        End If
    End Sub

    Private Sub SetDewPoint(ByVal dewpoint As Double)
        If Me.DewPoint_Display.InvokeRequired Then
            Dim d As New SetDewPointCallback(AddressOf SetDewPoint)
            Me.Invoke(d, New Object() {dewpoint})
        Else
            Me.DewPoint_Display.Text = String.Format("{0:F2}", dewpoint)
        End If
    End Sub

    Private Sub SetTemperature2(ByVal temp2 As Double)
        If Me.Temperature2_Display.InvokeRequired Then
            Dim d As New SetTemperature2Callback(AddressOf SetTemperature2)
            Me.Invoke(d, New Object() {temp2})
        Else
            Me.Temperature2_Display.Text = String.Format("{0:F2}", temp2)
        End If
    End Sub

    Private Sub SetVcc(ByVal vcc As Double)
        If Me.Vcc_Display.InvokeRequired Then
            Dim d As New SetVccCallback(AddressOf SetVcc)
            Me.Invoke(d, New Object() {vcc})
        Else
            Me.Vcc_Display.Text = String.Format("{0:F2}", ((vcc / 1023) * 5 * VDivider))
        End If
    End Sub

    Private Sub SetVreg(ByVal vreg As Double)
        If Me.Vreg_Display.InvokeRequired Then
            Dim d As New SetVregCallback(AddressOf SetVreg)
            Me.Invoke(d, New Object() {vreg})
        Else
            Me.Vreg_Display.Text = String.Format("{0:F2}", ((vreg / 1023) * 5 * VDivider))
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        AHub.CommandString("h")
    End Sub
End Class