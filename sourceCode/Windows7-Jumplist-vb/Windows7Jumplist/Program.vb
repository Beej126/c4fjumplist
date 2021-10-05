Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports System.Threading

Module Program

    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <STAThread()> _
    Public Sub Main()
        Dim firstInstance As Boolean = False

        Dim mtx As New Mutex(True, "MSDN.C4F.Win7.Jumplist", firstInstance)

        If firstInstance Then
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New MainForm())
        Else
            ' Send argument to running window
            HandleCmdLineArgs()
        End If
    End Sub

    Public Sub HandleCmdLineArgs()
        If Environment.GetCommandLineArgs().Length > 1 Then
            Select Case Environment.GetCommandLineArgs()(1)
                Case "-1"
                    WindowsMessageHelper.SendMessage("MSDN.C4F.Win7.Jumplist", WindowsMessageHelper.ARG1)
                    Exit Select

                Case "-2"
                    WindowsMessageHelper.SendMessage("MSDN.C4F.Win7.Jumplist", WindowsMessageHelper.ARG2)
                    Exit Select

                Case "-3"
                    WindowsMessageHelper.SendMessage("MSDN.C4F.Win7.Jumplist", WindowsMessageHelper.ARG3)
                    Exit Select
            End Select
        End If
    End Sub
End Module
