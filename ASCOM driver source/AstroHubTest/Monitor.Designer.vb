<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AstroHubViewer
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
        Me.PWM1_Slider = New System.Windows.Forms.TrackBar()
        Me.PWM2_Slider = New System.Windows.Forms.TrackBar()
        Me.PWM3_Slider = New System.Windows.Forms.TrackBar()
        Me.PWM4_Slider = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PWM1_Check = New System.Windows.Forms.CheckBox()
        Me.PWM2_Check = New System.Windows.Forms.CheckBox()
        Me.PWM3_Check = New System.Windows.Forms.CheckBox()
        Me.PWM4_Check = New System.Windows.Forms.CheckBox()
        Me.PWM4_Heater = New System.Windows.Forms.CheckBox()
        Me.PWM3_Heater = New System.Windows.Forms.CheckBox()
        Me.PWM2_Heater = New System.Windows.Forms.CheckBox()
        Me.PWM1_Heater = New System.Windows.Forms.CheckBox()
        Me.PWM1_Display = New System.Windows.Forms.Label()
        Me.PWM2_Display = New System.Windows.Forms.Label()
        Me.PWM3_Display = New System.Windows.Forms.Label()
        Me.PWM4_Display = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Temperature_Display = New System.Windows.Forms.Label()
        Me.Humidity_Display = New System.Windows.Forms.Label()
        Me.Temperature2_Display = New System.Windows.Forms.Label()
        Me.Vcc_Display = New System.Windows.Forms.Label()
        Me.DewPoint_Display = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Vreg_Display = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Motor_Display = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Move_Button = New System.Windows.Forms.Button()
        Me.MoveTo_Button = New System.Windows.Forms.Button()
        Me.Move_Edit = New System.Windows.Forms.NumericUpDown()
        Me.MoveTo_Edit = New System.Windows.Forms.NumericUpDown()
        Me.Pos1_Button = New System.Windows.Forms.Button()
        Me.Pos2_Button = New System.Windows.Forms.Button()
        Me.Pos3_Button = New System.Windows.Forms.Button()
        Me.Pos4_Button = New System.Windows.Forms.Button()
        Me.P1000_Button = New System.Windows.Forms.Button()
        Me.P100_Button = New System.Windows.Forms.Button()
        Me.P10_Button = New System.Windows.Forms.Button()
        Me.P1_Button = New System.Windows.Forms.Button()
        Me.Stop_Button = New System.Windows.Forms.Button()
        Me.M10_Button = New System.Windows.Forms.Button()
        Me.M1_Button = New System.Windows.Forms.Button()
        Me.M1000_Button = New System.Windows.Forms.Button()
        Me.M100_Button = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Dir_Check = New System.Windows.Forms.CheckBox()
        CType(Me.PWM1_Slider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PWM2_Slider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PWM3_Slider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PWM4_Slider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Move_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MoveTo_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PWM1_Slider
        '
        Me.PWM1_Slider.Enabled = False
        Me.PWM1_Slider.LargeChange = 10
        Me.PWM1_Slider.Location = New System.Drawing.Point(59, 12)
        Me.PWM1_Slider.Maximum = 100
        Me.PWM1_Slider.Name = "PWM1_Slider"
        Me.PWM1_Slider.Size = New System.Drawing.Size(197, 45)
        Me.PWM1_Slider.TabIndex = 0
        '
        'PWM2_Slider
        '
        Me.PWM2_Slider.Enabled = False
        Me.PWM2_Slider.LargeChange = 10
        Me.PWM2_Slider.Location = New System.Drawing.Point(58, 60)
        Me.PWM2_Slider.Maximum = 100
        Me.PWM2_Slider.Name = "PWM2_Slider"
        Me.PWM2_Slider.Size = New System.Drawing.Size(197, 45)
        Me.PWM2_Slider.TabIndex = 1
        '
        'PWM3_Slider
        '
        Me.PWM3_Slider.Enabled = False
        Me.PWM3_Slider.LargeChange = 10
        Me.PWM3_Slider.Location = New System.Drawing.Point(58, 111)
        Me.PWM3_Slider.Maximum = 100
        Me.PWM3_Slider.Name = "PWM3_Slider"
        Me.PWM3_Slider.Size = New System.Drawing.Size(197, 45)
        Me.PWM3_Slider.TabIndex = 2
        '
        'PWM4_Slider
        '
        Me.PWM4_Slider.Enabled = False
        Me.PWM4_Slider.LargeChange = 10
        Me.PWM4_Slider.Location = New System.Drawing.Point(58, 162)
        Me.PWM4_Slider.Maximum = 100
        Me.PWM4_Slider.Name = "PWM4_Slider"
        Me.PWM4_Slider.Size = New System.Drawing.Size(197, 45)
        Me.PWM4_Slider.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "PWM1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "PWM2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "PWM3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "PWM4"
        '
        'PWM1_Check
        '
        Me.PWM1_Check.AutoSize = True
        Me.PWM1_Check.Location = New System.Drawing.Point(308, 12)
        Me.PWM1_Check.Name = "PWM1_Check"
        Me.PWM1_Check.Size = New System.Drawing.Size(63, 17)
        Me.PWM1_Check.TabIndex = 8
        Me.PWM1_Check.Text = "Turn on"
        Me.PWM1_Check.UseVisualStyleBackColor = True
        '
        'PWM2_Check
        '
        Me.PWM2_Check.AutoSize = True
        Me.PWM2_Check.Location = New System.Drawing.Point(308, 60)
        Me.PWM2_Check.Name = "PWM2_Check"
        Me.PWM2_Check.Size = New System.Drawing.Size(63, 17)
        Me.PWM2_Check.TabIndex = 9
        Me.PWM2_Check.Text = "Turn on"
        Me.PWM2_Check.UseVisualStyleBackColor = True
        '
        'PWM3_Check
        '
        Me.PWM3_Check.AutoSize = True
        Me.PWM3_Check.Location = New System.Drawing.Point(308, 111)
        Me.PWM3_Check.Name = "PWM3_Check"
        Me.PWM3_Check.Size = New System.Drawing.Size(63, 17)
        Me.PWM3_Check.TabIndex = 10
        Me.PWM3_Check.Text = "Turn on"
        Me.PWM3_Check.UseVisualStyleBackColor = True
        '
        'PWM4_Check
        '
        Me.PWM4_Check.AutoSize = True
        Me.PWM4_Check.Location = New System.Drawing.Point(308, 162)
        Me.PWM4_Check.Name = "PWM4_Check"
        Me.PWM4_Check.Size = New System.Drawing.Size(63, 17)
        Me.PWM4_Check.TabIndex = 11
        Me.PWM4_Check.Text = "Turn on"
        Me.PWM4_Check.UseVisualStyleBackColor = True
        '
        'PWM4_Heater
        '
        Me.PWM4_Heater.Enabled = False
        Me.PWM4_Heater.Location = New System.Drawing.Point(368, 154)
        Me.PWM4_Heater.Name = "PWM4_Heater"
        Me.PWM4_Heater.Size = New System.Drawing.Size(58, 32)
        Me.PWM4_Heater.TabIndex = 15
        Me.PWM4_Heater.Text = "Heater (Auto)"
        Me.PWM4_Heater.UseVisualStyleBackColor = True
        '
        'PWM3_Heater
        '
        Me.PWM3_Heater.Enabled = False
        Me.PWM3_Heater.Location = New System.Drawing.Point(368, 102)
        Me.PWM3_Heater.Name = "PWM3_Heater"
        Me.PWM3_Heater.Size = New System.Drawing.Size(58, 32)
        Me.PWM3_Heater.TabIndex = 14
        Me.PWM3_Heater.Text = "Heater (Auto)"
        Me.PWM3_Heater.UseVisualStyleBackColor = True
        '
        'PWM2_Heater
        '
        Me.PWM2_Heater.Enabled = False
        Me.PWM2_Heater.Location = New System.Drawing.Point(368, 52)
        Me.PWM2_Heater.Name = "PWM2_Heater"
        Me.PWM2_Heater.Size = New System.Drawing.Size(58, 32)
        Me.PWM2_Heater.TabIndex = 13
        Me.PWM2_Heater.Text = "Heater (Auto)"
        Me.PWM2_Heater.UseVisualStyleBackColor = True
        '
        'PWM1_Heater
        '
        Me.PWM1_Heater.Enabled = False
        Me.PWM1_Heater.Location = New System.Drawing.Point(368, 4)
        Me.PWM1_Heater.Name = "PWM1_Heater"
        Me.PWM1_Heater.Size = New System.Drawing.Size(58, 32)
        Me.PWM1_Heater.TabIndex = 12
        Me.PWM1_Heater.Text = "Heater (Auto)"
        Me.PWM1_Heater.UseVisualStyleBackColor = True
        '
        'PWM1_Display
        '
        Me.PWM1_Display.BackColor = System.Drawing.SystemColors.Info
        Me.PWM1_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PWM1_Display.Location = New System.Drawing.Point(262, 12)
        Me.PWM1_Display.Name = "PWM1_Display"
        Me.PWM1_Display.Size = New System.Drawing.Size(40, 16)
        Me.PWM1_Display.TabIndex = 9
        Me.PWM1_Display.Text = "0"
        Me.PWM1_Display.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PWM2_Display
        '
        Me.PWM2_Display.BackColor = System.Drawing.SystemColors.Info
        Me.PWM2_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PWM2_Display.Location = New System.Drawing.Point(262, 60)
        Me.PWM2_Display.Name = "PWM2_Display"
        Me.PWM2_Display.Size = New System.Drawing.Size(40, 16)
        Me.PWM2_Display.TabIndex = 16
        Me.PWM2_Display.Text = "0"
        Me.PWM2_Display.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PWM3_Display
        '
        Me.PWM3_Display.BackColor = System.Drawing.SystemColors.Info
        Me.PWM3_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PWM3_Display.Location = New System.Drawing.Point(262, 110)
        Me.PWM3_Display.Name = "PWM3_Display"
        Me.PWM3_Display.Size = New System.Drawing.Size(40, 16)
        Me.PWM3_Display.TabIndex = 17
        Me.PWM3_Display.Text = "0"
        Me.PWM3_Display.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PWM4_Display
        '
        Me.PWM4_Display.BackColor = System.Drawing.SystemColors.Info
        Me.PWM4_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PWM4_Display.Location = New System.Drawing.Point(262, 162)
        Me.PWM4_Display.Name = "PWM4_Display"
        Me.PWM4_Display.Size = New System.Drawing.Size(40, 16)
        Me.PWM4_Display.TabIndex = 18
        Me.PWM4_Display.Text = "0"
        Me.PWM4_Display.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Temperature"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 238)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Humidity"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 263)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Dew Point"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(62, 313)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Vcc"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Temperature_Display
        '
        Me.Temperature_Display.BackColor = System.Drawing.SystemColors.Info
        Me.Temperature_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Temperature_Display.Location = New System.Drawing.Point(94, 210)
        Me.Temperature_Display.Name = "Temperature_Display"
        Me.Temperature_Display.Size = New System.Drawing.Size(53, 16)
        Me.Temperature_Display.TabIndex = 23
        Me.Temperature_Display.Text = "0"
        Me.Temperature_Display.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Humidity_Display
        '
        Me.Humidity_Display.BackColor = System.Drawing.SystemColors.Info
        Me.Humidity_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Humidity_Display.Location = New System.Drawing.Point(94, 235)
        Me.Humidity_Display.Name = "Humidity_Display"
        Me.Humidity_Display.Size = New System.Drawing.Size(53, 16)
        Me.Humidity_Display.TabIndex = 24
        Me.Humidity_Display.Text = "0"
        Me.Humidity_Display.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Temperature2_Display
        '
        Me.Temperature2_Display.BackColor = System.Drawing.SystemColors.Info
        Me.Temperature2_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Temperature2_Display.Location = New System.Drawing.Point(94, 285)
        Me.Temperature2_Display.Name = "Temperature2_Display"
        Me.Temperature2_Display.Size = New System.Drawing.Size(53, 16)
        Me.Temperature2_Display.TabIndex = 25
        Me.Temperature2_Display.Text = "0"
        Me.Temperature2_Display.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Vcc_Display
        '
        Me.Vcc_Display.BackColor = System.Drawing.SystemColors.Info
        Me.Vcc_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Vcc_Display.Location = New System.Drawing.Point(94, 310)
        Me.Vcc_Display.Name = "Vcc_Display"
        Me.Vcc_Display.Size = New System.Drawing.Size(53, 16)
        Me.Vcc_Display.TabIndex = 26
        Me.Vcc_Display.Text = "0"
        Me.Vcc_Display.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'DewPoint_Display
        '
        Me.DewPoint_Display.BackColor = System.Drawing.SystemColors.Info
        Me.DewPoint_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DewPoint_Display.Location = New System.Drawing.Point(94, 260)
        Me.DewPoint_Display.Name = "DewPoint_Display"
        Me.DewPoint_Display.Size = New System.Drawing.Size(53, 16)
        Me.DewPoint_Display.TabIndex = 28
        Me.DewPoint_Display.Text = "0"
        Me.DewPoint_Display.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(59, 338)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Vreg"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Vreg_Display
        '
        Me.Vreg_Display.BackColor = System.Drawing.SystemColors.Info
        Me.Vreg_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Vreg_Display.Location = New System.Drawing.Point(94, 335)
        Me.Vreg_Display.Name = "Vreg_Display"
        Me.Vreg_Display.Size = New System.Drawing.Size(53, 16)
        Me.Vreg_Display.TabIndex = 30
        Me.Vreg_Display.Text = "0"
        Me.Vreg_Display.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 288)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "2 Temperature"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Motor_Display
        '
        Me.Motor_Display.BackColor = System.Drawing.SystemColors.Info
        Me.Motor_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Motor_Display.Location = New System.Drawing.Point(230, 210)
        Me.Motor_Display.Name = "Motor_Display"
        Me.Motor_Display.Size = New System.Drawing.Size(72, 16)
        Me.Motor_Display.TabIndex = 31
        Me.Motor_Display.Text = "0"
        Me.Motor_Display.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(180, 213)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Position"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Move_Button
        '
        Me.Move_Button.Location = New System.Drawing.Point(166, 263)
        Me.Move_Button.Name = "Move_Button"
        Me.Move_Button.Size = New System.Drawing.Size(58, 20)
        Me.Move_Button.TabIndex = 33
        Me.Move_Button.Text = "Move"
        Me.Move_Button.UseVisualStyleBackColor = True
        '
        'MoveTo_Button
        '
        Me.MoveTo_Button.Location = New System.Drawing.Point(166, 288)
        Me.MoveTo_Button.Name = "MoveTo_Button"
        Me.MoveTo_Button.Size = New System.Drawing.Size(58, 20)
        Me.MoveTo_Button.TabIndex = 34
        Me.MoveTo_Button.Text = "Move To"
        Me.MoveTo_Button.UseVisualStyleBackColor = True
        '
        'Move_Edit
        '
        Me.Move_Edit.Location = New System.Drawing.Point(230, 263)
        Me.Move_Edit.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.Move_Edit.Minimum = New Decimal(New Integer() {99999, 0, 0, -2147483648})
        Me.Move_Edit.Name = "Move_Edit"
        Me.Move_Edit.Size = New System.Drawing.Size(72, 20)
        Me.Move_Edit.TabIndex = 35
        '
        'MoveTo_Edit
        '
        Me.MoveTo_Edit.Location = New System.Drawing.Point(230, 288)
        Me.MoveTo_Edit.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.MoveTo_Edit.Minimum = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.MoveTo_Edit.Name = "MoveTo_Edit"
        Me.MoveTo_Edit.Size = New System.Drawing.Size(72, 20)
        Me.MoveTo_Edit.TabIndex = 36
        '
        'Pos1_Button
        '
        Me.Pos1_Button.Location = New System.Drawing.Point(166, 313)
        Me.Pos1_Button.Name = "Pos1_Button"
        Me.Pos1_Button.Size = New System.Drawing.Size(29, 38)
        Me.Pos1_Button.TabIndex = 37
        Me.Pos1_Button.Text = "1"
        Me.Pos1_Button.UseVisualStyleBackColor = True
        '
        'Pos2_Button
        '
        Me.Pos2_Button.Location = New System.Drawing.Point(202, 313)
        Me.Pos2_Button.Name = "Pos2_Button"
        Me.Pos2_Button.Size = New System.Drawing.Size(29, 38)
        Me.Pos2_Button.TabIndex = 38
        Me.Pos2_Button.Text = "2"
        Me.Pos2_Button.UseVisualStyleBackColor = True
        '
        'Pos3_Button
        '
        Me.Pos3_Button.Location = New System.Drawing.Point(237, 313)
        Me.Pos3_Button.Name = "Pos3_Button"
        Me.Pos3_Button.Size = New System.Drawing.Size(29, 38)
        Me.Pos3_Button.TabIndex = 39
        Me.Pos3_Button.Text = "3"
        Me.Pos3_Button.UseVisualStyleBackColor = True
        '
        'Pos4_Button
        '
        Me.Pos4_Button.Location = New System.Drawing.Point(273, 313)
        Me.Pos4_Button.Name = "Pos4_Button"
        Me.Pos4_Button.Size = New System.Drawing.Size(29, 38)
        Me.Pos4_Button.TabIndex = 40
        Me.Pos4_Button.Text = "4"
        Me.Pos4_Button.UseVisualStyleBackColor = True
        '
        'P1000_Button
        '
        Me.P1000_Button.Location = New System.Drawing.Point(322, 208)
        Me.P1000_Button.Name = "P1000_Button"
        Me.P1000_Button.Size = New System.Drawing.Size(49, 23)
        Me.P1000_Button.TabIndex = 41
        Me.P1000_Button.Text = "+1000"
        Me.P1000_Button.UseVisualStyleBackColor = True
        '
        'P100_Button
        '
        Me.P100_Button.Location = New System.Drawing.Point(377, 208)
        Me.P100_Button.Name = "P100_Button"
        Me.P100_Button.Size = New System.Drawing.Size(49, 23)
        Me.P100_Button.TabIndex = 42
        Me.P100_Button.Text = "+100"
        Me.P100_Button.UseVisualStyleBackColor = True
        '
        'P10_Button
        '
        Me.P10_Button.Location = New System.Drawing.Point(322, 237)
        Me.P10_Button.Name = "P10_Button"
        Me.P10_Button.Size = New System.Drawing.Size(49, 23)
        Me.P10_Button.TabIndex = 43
        Me.P10_Button.Text = "+10"
        Me.P10_Button.UseVisualStyleBackColor = True
        '
        'P1_Button
        '
        Me.P1_Button.Location = New System.Drawing.Point(377, 237)
        Me.P1_Button.Name = "P1_Button"
        Me.P1_Button.Size = New System.Drawing.Size(49, 23)
        Me.P1_Button.TabIndex = 44
        Me.P1_Button.Text = "+1"
        Me.P1_Button.UseVisualStyleBackColor = True
        '
        'Stop_Button
        '
        Me.Stop_Button.BackColor = System.Drawing.Color.Red
        Me.Stop_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Stop_Button.ForeColor = System.Drawing.Color.Black
        Me.Stop_Button.Location = New System.Drawing.Point(322, 268)
        Me.Stop_Button.Name = "Stop_Button"
        Me.Stop_Button.Size = New System.Drawing.Size(104, 23)
        Me.Stop_Button.TabIndex = 45
        Me.Stop_Button.Text = "STOP"
        Me.Stop_Button.UseVisualStyleBackColor = False
        '
        'M10_Button
        '
        Me.M10_Button.Location = New System.Drawing.Point(322, 299)
        Me.M10_Button.Name = "M10_Button"
        Me.M10_Button.Size = New System.Drawing.Size(49, 23)
        Me.M10_Button.TabIndex = 46
        Me.M10_Button.Text = "-10"
        Me.M10_Button.UseVisualStyleBackColor = True
        '
        'M1_Button
        '
        Me.M1_Button.Location = New System.Drawing.Point(377, 299)
        Me.M1_Button.Name = "M1_Button"
        Me.M1_Button.Size = New System.Drawing.Size(49, 23)
        Me.M1_Button.TabIndex = 47
        Me.M1_Button.Text = "-1"
        Me.M1_Button.UseVisualStyleBackColor = True
        '
        'M1000_Button
        '
        Me.M1000_Button.Location = New System.Drawing.Point(322, 328)
        Me.M1000_Button.Name = "M1000_Button"
        Me.M1000_Button.Size = New System.Drawing.Size(49, 23)
        Me.M1000_Button.TabIndex = 48
        Me.M1000_Button.Text = "-1000"
        Me.M1000_Button.UseVisualStyleBackColor = True
        '
        'M100_Button
        '
        Me.M100_Button.Location = New System.Drawing.Point(377, 328)
        Me.M100_Button.Name = "M100_Button"
        Me.M100_Button.Size = New System.Drawing.Size(49, 23)
        Me.M100_Button.TabIndex = 49
        Me.M100_Button.Text = "-100"
        Me.M100_Button.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.TextBox1.BackColor = System.Drawing.Color.Black
        Me.TextBox1.ForeColor = System.Drawing.Color.Lime
        Me.TextBox1.Location = New System.Drawing.Point(477, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(243, 279)
        Me.TextBox1.TabIndex = 51
        '
        'Dir_Check
        '
        Me.Dir_Check.AutoSize = True
        Me.Dir_Check.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Dir_Check.Location = New System.Drawing.Point(166, 237)
        Me.Dir_Check.Name = "Dir_Check"
        Me.Dir_Check.Size = New System.Drawing.Size(104, 17)
        Me.Dir_Check.TabIndex = 53
        Me.Dir_Check.Text = "Reverse stepper"
        Me.Dir_Check.UseVisualStyleBackColor = True
        '
        'AstroHubViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 359)
        Me.Controls.Add(Me.Dir_Check)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.M100_Button)
        Me.Controls.Add(Me.M1000_Button)
        Me.Controls.Add(Me.M1_Button)
        Me.Controls.Add(Me.M10_Button)
        Me.Controls.Add(Me.Stop_Button)
        Me.Controls.Add(Me.P1_Button)
        Me.Controls.Add(Me.P10_Button)
        Me.Controls.Add(Me.P100_Button)
        Me.Controls.Add(Me.P1000_Button)
        Me.Controls.Add(Me.Pos4_Button)
        Me.Controls.Add(Me.Pos3_Button)
        Me.Controls.Add(Me.Pos2_Button)
        Me.Controls.Add(Me.Pos1_Button)
        Me.Controls.Add(Me.MoveTo_Edit)
        Me.Controls.Add(Me.Move_Edit)
        Me.Controls.Add(Me.MoveTo_Button)
        Me.Controls.Add(Me.Move_Button)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Motor_Display)
        Me.Controls.Add(Me.Vreg_Display)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.DewPoint_Display)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Vcc_Display)
        Me.Controls.Add(Me.Temperature2_Display)
        Me.Controls.Add(Me.Humidity_Display)
        Me.Controls.Add(Me.Temperature_Display)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PWM4_Display)
        Me.Controls.Add(Me.PWM3_Display)
        Me.Controls.Add(Me.PWM2_Display)
        Me.Controls.Add(Me.PWM1_Display)
        Me.Controls.Add(Me.PWM4_Heater)
        Me.Controls.Add(Me.PWM3_Heater)
        Me.Controls.Add(Me.PWM2_Heater)
        Me.Controls.Add(Me.PWM1_Heater)
        Me.Controls.Add(Me.PWM4_Check)
        Me.Controls.Add(Me.PWM3_Check)
        Me.Controls.Add(Me.PWM2_Check)
        Me.Controls.Add(Me.PWM1_Check)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PWM4_Slider)
        Me.Controls.Add(Me.PWM3_Slider)
        Me.Controls.Add(Me.PWM2_Slider)
        Me.Controls.Add(Me.PWM1_Slider)
        Me.Name = "AstroHubViewer"
        Me.Text = "AstroHub"
        CType(Me.PWM1_Slider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PWM2_Slider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PWM3_Slider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PWM4_Slider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Move_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MoveTo_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PWM1_Slider As System.Windows.Forms.TrackBar
    Friend WithEvents PWM2_Slider As System.Windows.Forms.TrackBar
    Friend WithEvents PWM3_Slider As System.Windows.Forms.TrackBar
    Friend WithEvents PWM4_Slider As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PWM1_Check As System.Windows.Forms.CheckBox
    Friend WithEvents PWM2_Check As System.Windows.Forms.CheckBox
    Friend WithEvents PWM3_Check As System.Windows.Forms.CheckBox
    Friend WithEvents PWM4_Check As System.Windows.Forms.CheckBox
    Friend WithEvents PWM4_Heater As System.Windows.Forms.CheckBox
    Friend WithEvents PWM3_Heater As System.Windows.Forms.CheckBox
    Friend WithEvents PWM2_Heater As System.Windows.Forms.CheckBox
    Friend WithEvents PWM1_Heater As System.Windows.Forms.CheckBox
    Friend WithEvents PWM1_Display As System.Windows.Forms.Label
    Friend WithEvents PWM2_Display As System.Windows.Forms.Label
    Friend WithEvents PWM3_Display As System.Windows.Forms.Label
    Friend WithEvents PWM4_Display As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Temperature_Display As System.Windows.Forms.Label
    Friend WithEvents Humidity_Display As System.Windows.Forms.Label
    Friend WithEvents Temperature2_Display As System.Windows.Forms.Label
    Friend WithEvents Vcc_Display As System.Windows.Forms.Label
    Friend WithEvents DewPoint_Display As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Vreg_Display As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Motor_Display As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Move_Button As System.Windows.Forms.Button
    Friend WithEvents MoveTo_Button As System.Windows.Forms.Button
    Friend WithEvents Move_Edit As System.Windows.Forms.NumericUpDown
    Friend WithEvents MoveTo_Edit As System.Windows.Forms.NumericUpDown
    Friend WithEvents Pos1_Button As System.Windows.Forms.Button
    Friend WithEvents Pos2_Button As System.Windows.Forms.Button
    Friend WithEvents Pos3_Button As System.Windows.Forms.Button
    Friend WithEvents Pos4_Button As System.Windows.Forms.Button
    Friend WithEvents P1000_Button As System.Windows.Forms.Button
    Friend WithEvents P100_Button As System.Windows.Forms.Button
    Friend WithEvents P10_Button As System.Windows.Forms.Button
    Friend WithEvents P1_Button As System.Windows.Forms.Button
    Friend WithEvents Stop_Button As System.Windows.Forms.Button
    Friend WithEvents M10_Button As System.Windows.Forms.Button
    Friend WithEvents M1_Button As System.Windows.Forms.Button
    Friend WithEvents M1000_Button As System.Windows.Forms.Button
    Friend WithEvents M100_Button As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Dir_Check As System.Windows.Forms.CheckBox
End Class
