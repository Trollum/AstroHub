'tabs=4
' --------------------------------------------------------------------------------
' TODO fill in this information for your driver, then remove this line!
'
' ASCOM Focuser driver for AstroHub
'
' Description:	Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam 
'				nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam 
'				erat, sed diam voluptua. At vero eos et accusam et justo duo 
'				dolores et ea rebum. Stet clita kasd gubergren, no sea takimata 
'				sanctus est Lorem ipsum dolor sit amet.
'
' Implements:	ASCOM Focuser interface version: 1.0
' Author:		(XXX) Your N. Here <your@email.here>
'
' Edit Log:
'
' Date			Who	Vers	Description
' -----------	---	-----	-------------------------------------------------------
' dd-mmm-yyyy	XXX	1.0.0	Initial edit, from Focuser template
' ---------------------------------------------------------------------------------
'
'
' Your driver's ID is ASCOM.AstroHub.Focuser
'
' The Guid attribute sets the CLSID for ASCOM.DeviceName.Focuser
' The ClassInterface/None addribute prevents an empty interface called
' _Focuser from being created and used as the [default] interface
'

' This definition is used to select code that's only applicable for one device type
#Const Device = "Focuser"

Imports ASCOM
Imports ASCOM.Astrometry
Imports ASCOM.Astrometry.AstroUtils
Imports ASCOM.DeviceInterface
Imports ASCOM.Utilities

Imports System
Imports System.IO.Ports
Imports System.Collections
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Text

<Guid("872c3a29-e3d5-4d10-abd5-2aae686943e2")> _
<ClassInterface(ClassInterfaceType.None)> _
Public Class Focuser

    ' The Guid attribute sets the CLSID for ASCOM.AstroHub.Focuser
    ' The ClassInterface/None addribute prevents an empty interface called
    ' _AstroHub from being created and used as the [default] interface

    ' TODO Replace the not implemented exceptions with code to implement the function or
    ' throw the appropriate ASCOM exception.
    '
    Implements IFocuserV2


    '
    ' Driver ID and descriptive string that shows in the Chooser
    '
    Friend Shared driverID As String = "ASCOM.AstroHub.Focuser"
    Private Shared driverDescription As String = "AstroHub Focuser"
    Private Const DRIVER_VERSION As String = "1.1"

    'Friend Shared comPortProfileName As String = "COM Port" 'Constants used for Profile persistence
    'Friend Shared traceStateProfileName As String = "Trace Level"
    'Friend Shared comPortDefault As String = "COM1"
    'Friend Shared traceStateDefault As String = "False"

    'Friend Shared comPort As String ' Variables to hold the currrent device configuration
    'Friend Shared traceState As Boolean

    Private connectedState As Boolean ' Private variable to hold the connected state
    Private utilities As Util ' Private variable to hold an ASCOM Utilities object
    Private astroUtilities As AstroUtils ' Private variable to hold an AstroUtils object to provide the Range method
    Private TL As TraceLogger ' Private variable to hold the trace logger object (creates a diagnostic log file with information that you specify)
    Private monitor As AstroHubViewer
    Private WithEvents ComPort As System.IO.Ports.SerialPort
    Public Event ScanDataRecieved(ByVal data As String)
    Private sensorConnected As Boolean = False

    Friend Shared positionCache As Integer
    Friend Shared Temp As Double
    Friend Shared Hum As Double
    Friend Shared DewPoint As Double
    Friend Shared Temp2 As Double
    Friend Shared Vcc As Double
    Friend Shared Vreg As Double
    Friend Shared isMov As Integer

    '
    ' Constructor - Must be public for COM registration!
    '
    Public Sub New()

        TL = New TraceLogger("", "AstruHub")
        TL.LogMessage("Focuser", "Starting initialisation")

        connectedState = False ' Initialise connected to false
        utilities = New Util() ' Initialise util object
        astroUtilities = New AstroUtils 'Initialise new astro utiliites object

        'TODO: Implement your additional construction here
        positionCache = 0
        Temp = 0.0
        Temp2 = 0.0
        Hum = 0.0
        DewPoint = 0.0
        Vcc = 0.0
        Vreg = 0.0
        isMov = 0

        ComPort = New System.IO.Ports.SerialPort

        monitor = New AstroHubViewer()

        TL.LogMessage("Focuser", "Completed initialisation")
    End Sub

    '
    ' PUBLIC COM INTERFACE IFocuserV2 IMPLEMENTATION
    '

#Region "Common properties and methods"

    Shared Property PortName As String

    ''' <summary>
    ''' Displays the Setup Dialog form.
    ''' If the user clicks the OK button to dismiss the form, then
    ''' the new settings are saved, otherwise the old values are reloaded.
    ''' THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
    ''' </summary>
    Public Sub SetupDialog() Implements IFocuserV2.SetupDialog
        ' consider only showing the setup dialog if not connected
        ' or call a different dialog if connected
        If IsConnected Then
            System.Windows.Forms.MessageBox.Show("Already connected, just press OK")
        End If

        Using F As SetupDialogForm = New SetupDialogForm()
            Dim result As System.Windows.Forms.DialogResult = F.ShowDialog()
        End Using
    End Sub

    Public ReadOnly Property SupportedActions() As ArrayList Implements IFocuserV2.SupportedActions
        Get
            TL.LogMessage("SupportedActions Get", "Returning empty arraylist")
            Return New ArrayList()
        End Get
    End Property

    Public Function Action(ByVal ActionName As String, ByVal ActionParameters As String) As String Implements IFocuserV2.Action
        Throw New ActionNotImplementedException("Action " & ActionName & " is not supported by this driver")
    End Function

    Public Sub CommandBlind(ByVal Command As String, Optional ByVal Raw As Boolean = False) Implements IFocuserV2.CommandBlind
        CheckConnected("CommandBlind")
        ' Call CommandString and return as soon as it finishes
        Me.CommandString(Command, Raw)
        ' or
        Throw New MethodNotImplementedException("CommandBlind")
    End Sub

    Public Function CommandBool(ByVal Command As String, Optional ByVal Raw As Boolean = False) As Boolean _
        Implements IFocuserV2.CommandBool
        CheckConnected("CommandBool")
        Dim ret As String = CommandString(Command, Raw)
        ' TODO decode the return string and return true or false
        ' or
        Throw New MethodNotImplementedException("CommandBool")
    End Function

    Public Function CommandString(ByVal Command As String, Optional ByVal Raw As Boolean = False) As String Implements IFocuserV2.CommandString
        'CheckConnected("CommandString")
        Dim commandToSend As String = Command
        'commandToSend = Command + Constants.vbLf
        ComPort.Write(commandToSend)
        Dim str2 As String = ComPort.ReadTo(vbNewLine)
        Dim charac = Left(Command, 1)
        Dim answer As String = ""

        'Console.WriteLine(str2)
        Select Case charac

            Case "t"
                answer = Temp.ToString
                'Console.WriteLine(answer)
            Case "h"
                answer = Hum.ToString
                'Console.WriteLine(answer)
            Case "d"
                answer = DewPoint.ToString
                'Console.WriteLine(answer)

        End Select

        Return answer
    End Function

    Private Sub ComPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles ComPort.DataReceived
        Dim str2 As String = ""
        'If e.EventType = SerialData.Chars Then
        '    Do
        '        Dim bytecount As Integer = ComPort.BytesToRead

        '        If bytecount = 0 Then
        '            Exit Do
        '        End If
        '        Dim byteBuffer(bytecount) As Byte
        '        str2 = ComPort.ReadLine()
        '        ComPort.Read(byteBuffer, 0, bytecount)
        '        str = str & System.Text.Encoding.ASCII.GetString(byteBuffer, 0, 1)

        '    Loop
        'End If

        If e.EventType = SerialData.Chars Then
            str2 = ComPort.ReadTo(vbNewLine)
        End If

        Dim charac = Mid(str2, 1, 1)

        Select Case charac

            Case "T"
                Temp = Convert.ToDouble(Val(Mid(str2, 3)))
            Case "W"
                Hum = Convert.ToDouble(Val(Mid(str2, 3)))
            Case "D"
                DewPoint = Convert.ToDouble(Val(Mid(str2, 3)))
            Case "N"
                Temp2 = Convert.ToDouble(Val(Mid(str2, 3)))
            Case "V"
                Vcc = Convert.ToDouble(Val(Mid(str2, 3)))
            Case "C"
                Vreg = Convert.ToDouble(Val(Mid(str2, 3)))
            Case "O"
                positionCache = Convert.ToInt32(Val(Mid(str2, 3)))
            Case "i"
                isMov = Convert.ToInt32(Val(Mid(str2, 3)))
            Case "p"
                positionCache = Convert.ToInt32(Val(Mid(str2, 3)))

        End Select

        'Console.WriteLine(Hum)
        'monitor.TextBox1.AppendText(str)
        'monitor.TextBox1.AppendText(str2)

        RaiseEvent ScanDataRecieved(str2)
    End Sub

    Public Property Connected() As Boolean Implements IFocuserV2.Connected
        Get
            Return IsConnected
        End Get
        Set(ByVal value As Boolean)
            If (value = IsConnect) Then
                Return
            End If
            If (value) Then
                'Dim comPort As String = My.Settings.CommPort
                Connect()
            Else
                Disconnect()
            End If
        End Set
    End Property

    Public ReadOnly Property Description As String Implements IFocuserV2.Description
        Get
            ' this pattern seems to be needed to allow a public property to return a private field
            Dim d As String = driverDescription
            Return d
        End Get
    End Property

    Public ReadOnly Property DriverInfo As String Implements IFocuserV2.DriverInfo
        Get
            Dim d As String = driverDescription + DRIVER_VERSION
            Return d
        End Get
    End Property

    Public ReadOnly Property DriverVersion() As String Implements IFocuserV2.DriverVersion
        Get
            Return DRIVER_VERSION
        End Get
    End Property

    Public ReadOnly Property InterfaceVersion() As Short Implements IFocuserV2.InterfaceVersion
        Get
            Return 2
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IFocuserV2.Name
        Get
            ' this pattern seems to be needed to allow a public property to return a private field
            Dim d As String = driverDescription
            Return d
        End Get
    End Property

    Public Sub Dispose() Implements IFocuserV2.Dispose
        ComPort.Dispose()
    End Sub

#End Region

#Region "IFocuser Implementation"

    Private focuserPosition As Integer = 0 ' Class level variable to hold the current focuser position
    Private Const focuserSteps As Integer = 1000000

    Public ReadOnly Property Absolute() As Boolean Implements IFocuserV2.Absolute
        Get
            Return True
        End Get
    End Property

    Public Sub Halt() Implements IFocuserV2.Halt
        CommandString("H:1" + vbNewLine)
    End Sub

    Public ReadOnly Property IsMoving() As Boolean Implements IFocuserV2.IsMoving
        Get
            If (focuserPosition <> positionCache) Then
                Return True
            Else
                Return False
            End If
            'If (Not answer.StartsWith("i")) Then
            '    Throw New ASCOM.DriverException("Wrong device answer: expected i, got " + answer)
            'End If
            'Dim values() As String = Split(answer, ":")
        End Get
    End Property

    Public Property Link() As Boolean Implements IFocuserV2.Link
        Get
            Return IsConnected
        End Get
        Set(ByVal value As Boolean)
            Connected = value
        End Set
    End Property

    Public ReadOnly Property MaxIncrement() As Integer Implements IFocuserV2.MaxIncrement
        Get
            TL.LogMessage("MaxIncrement Get", focuserSteps.ToString())
            Return focuserSteps ' Maximum change in one move
        End Get
    End Property

    Public ReadOnly Property MaxStep() As Integer Implements IFocuserV2.MaxStep
        Get
            TL.LogMessage("MaxStep Get", focuserSteps.ToString())
            Return focuserSteps ' Maximum extent of the focuser, so position range is 0 to 10,000
        End Get
    End Property

    Public Sub Move(ByVal Position As Integer) Implements IFocuserV2.Move
        CommandString("S:" + Position.ToString + vbNewLine)
        focuserPosition = Position ' Set the focuser position
    End Sub

    Public ReadOnly Property Position() As Integer Implements IFocuserV2.Position
        Get
            'CommandString("p" + vbNewLine)
            'Dim charac = Mid(answer, 1, 1)
            'If (charac <> "p") Then
            '    Throw New ASCOM.DriverException("Wrong device answer: expected p, got " + answer)
            '    'loginfo("Wrong device answer: expected p, got " + answer)
            'Else
            '    positionCache = Convert.ToInt32(Val(Mid(answer, 3)))
            '    'monitor.Motor_Display.Text = positionCache
            'End If
            Return positionCache
        End Get
    End Property

    Public ReadOnly Property StepSize() As Double Implements IFocuserV2.StepSize
        Get
            TL.LogMessage("StepSize Get", "Not implemented")
            Throw New ASCOM.PropertyNotImplementedException("StepSize", False)
        End Get
    End Property

    Public Property TempComp() As Boolean Implements IFocuserV2.TempComp
        Get
            Return False
        End Get
        Set(value As Boolean)
            value = False
        End Set
    End Property

    Public ReadOnly Property TempCompAvailable() As Boolean Implements IFocuserV2.TempCompAvailable
        Get
            Return False ' Temperature compensation is not available in this driver
        End Get
    End Property

    Public ReadOnly Property Temperature() As Double Implements IFocuserV2.Temperature
        Get
            Return Temp
        End Get
    End Property

#End Region

#Region "Private properties and methods"
    ' here are some useful properties and methods that can be used as required
    ' to help with

    Private ReadOnly Property IsConnect() As Boolean
        Get
            Return (Not (ComPort Is Nothing) AndAlso (ComPort.IsOpen))
        End Get
    End Property

    Private Sub Connect()
        ComPort.PortName = My.Settings.CommPort
        ComPort.BaudRate = 9600
        ComPort.ReadTimeout = 2000
        ComPort.Encoding = System.Text.Encoding.ASCII

        Try
            If (ComPort.IsOpen) Then
                ComPort.Close()
                System.Threading.Thread.Sleep(500)
            End If
            ComPort.Open()
            'Console.WriteLine("Dot Net Perls")
        Catch ex As System.IO.IOException
            Dim msg As String = "Invalid port state: " & ex.Message & " : " & ex.Data.ToString
            Throw New ASCOM.NotConnectedException(msg)
        Catch ex As System.InvalidOperationException
            Dim msg As String = "Port already opened: " & ex.Message & " : " & ex.Data.ToString
            Throw New ASCOM.NotConnectedException(msg)
        Catch ex As System.UnauthorizedAccessException
            Dim msg As String = "RS access denied: " & ex.Message & " : " & ex.Data.ToString
            Throw New ASCOM.NotConnectedException(msg)
        End Try

        monitor.focuser = Me
        monitor.Show()
    End Sub

    Private Sub Disconnect()
        monitor.Hide()

        Try
            ComPort.Close()
        Catch ex As System.InvalidOperationException
            Throw New ASCOM.InvalidOperationException("Asked to disconnect, but port already closed")
        End Try
    End Sub

#Region "ASCOM Registration"

    Private Shared Sub RegUnregASCOM(ByVal bRegister As Boolean)

        Using P As New Profile() With {.DeviceType = "Focuser"}
            If bRegister Then
                P.Register(driverID, driverDescription)
            Else
                P.Unregister(driverID)
            End If
        End Using

    End Sub

    <ComRegisterFunction()> _
    Public Shared Sub RegisterASCOM(ByVal T As Type)

        RegUnregASCOM(True)

    End Sub

    <ComUnregisterFunction()> _
    Public Shared Sub UnregisterASCOM(ByVal T As Type)

        RegUnregASCOM(False)

    End Sub

#End Region

    ''' <summary>
    ''' Returns true if there is a valid connection to the driver hardware
    ''' </summary>
    Private ReadOnly Property IsConnected As Boolean
        Get
            Return (Not (ComPort Is Nothing) AndAlso (ComPort.IsOpen))
        End Get
    End Property

    ''' <summary>
    ''' Use this function to throw an exception if we aren't connected to the hardware
    ''' </summary>
    ''' <param name="message"></param>
    Private Sub CheckConnected(ByVal message As String)
        If Not IsConnected Then
            Throw New NotConnectedException(message)
        End If
    End Sub

#End Region

End Class
