Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Runtime.InteropServices

Public Class WindowsMessageHelper
    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function RegisterWindowMessage(ByVal msgName As String) As Integer
    End Function

    ' Custom messages we need
    Private Shared _MessageTypes As New Dictionary(Of String, Integer)()
    Public Shared ARG1 As Integer, ARG2 As Integer, ARG3 As Integer

    Shared Sub New()
        ARG1 = RegisterWindowMessage("MSDN.C4F.Win7.Jumplist.Arg1")
        ARG2 = RegisterWindowMessage("MSDN.C4F.Win7.Jumplist.Arg2")
        ARG3 = RegisterWindowMessage("MSDN.C4F.Win7.Jumplist.Arg3")
    End Sub

    Public Shared Function RegisterMessage(ByVal msgName As String) As Integer
        Return RegisterWindowMessage(msgName)
    End Function

    Public Shared Sub SendMessage(ByVal windowTitle As String, ByVal msgId As Integer)
        SendMessage(windowTitle, msgId, IntPtr.Zero, IntPtr.Zero)
    End Sub

    Public Shared Function SendMessage(ByVal windowTitle As String, ByVal msgId As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Boolean
        Dim WindowToFind As IntPtr = FindWindow(Nothing, windowTitle)
        If WindowToFind = IntPtr.Zero Then
            Return False
        End If

        Dim result As Long = SendMessage(WindowToFind, msgId, wParam, lParam)

        If result = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
