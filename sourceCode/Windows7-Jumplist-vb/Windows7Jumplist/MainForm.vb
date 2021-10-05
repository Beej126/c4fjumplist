Imports Microsoft.WindowsAPICodePack.Taskbar
Imports Microsoft.WindowsAPICodePack.Shell
Imports System.IO
Imports System.Reflection

Partial Public Class MainForm

    Inherits Form
    ' Keep a reference to the Taskbar instance
    Private windowsTaskbar As TaskbarManager = TaskbarManager.Instance

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        If TaskbarManager.IsPlatformSupported Then
            CreateJumpList()

            windowsTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress)
        End If

        Program.HandleCmdLineArgs()
    End Sub


    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WindowsMessageHelper.ARG1 Then
            lblMessage.Text = "Arg1"
            lblMessage.BackColor = Color.LightGreen
        ElseIf m.Msg = WindowsMessageHelper.ARG2 Then
            lblMessage.Text = "Arg1"
            lblMessage.BackColor = Color.LightBlue
        ElseIf m.Msg = WindowsMessageHelper.ARG3 Then
            lblMessage.Text = "Arg1"
            lblMessage.BackColor = Color.Yellow
        Else
            MyBase.WndProc(m)
        End If
    End Sub

    Private Sub CreateJumpList()
        Dim jl As JumpList = JumpList.CreateJumpList()

        ' Show user files: Recent, Frequent, or None
        jl.KnownCategoryToDisplay = JumpListKnownCategoryType.Recent

        ' Add my own links (nouns)
        Dim catActions As New JumpListCustomCategory("Destinations")

        catActions.AddJumpListItems( _
            New JumpListLink(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "My Pictures"), _
            New JumpListLink("http://blogs.msdn.com/coding4fun", "Visit Coding4Fun"), _
            New JumpListLink("http://code.msdn.microsoft.com/WindowsAPICodePack", "Windows API Code Pack"))
        'new JumpListItem(@"c:\Test1.c4f")

        jl.AddCustomCategories(catActions)

        ' Path to Windows system folder
        Dim systemFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.System)

        ' Add our user tasks (verbs)
        jl.AddUserTasks(New JumpListLink(Path.Combine(systemFolder, "notepad.exe"), "Open Notepad") _
                        With {.IconReference = New IconReference(Path.Combine(systemFolder, "notepad.exe"), 0)})

        jl.AddUserTasks(New JumpListLink(Path.Combine(systemFolder, "mspaint.exe"), "Open Paint") _
                        With {.IconReference = New IconReference(Path.Combine(systemFolder, "mspaint.exe"), 0)})

        jl.AddUserTasks(New JumpListSeparator())

        jl.AddUserTasks(New JumpListLink(Assembly.GetEntryAssembly().Location, "Action 1 (Green)") _
                        With {.Arguments = "-1", .IconReference = New IconReference(Assembly.GetEntryAssembly().Location, 0)})

        jl.AddUserTasks(New JumpListLink(Assembly.GetEntryAssembly().Location, "Action 2 (Blue)") _
                        With {.Arguments = "-2", .IconReference = New IconReference(Assembly.GetEntryAssembly().Location, 0)})

        jl.AddUserTasks(New JumpListLink(Assembly.GetEntryAssembly().Location, "Action 3 (Yellow)") _
                        With {.Arguments = "-3", .IconReference = New IconReference(Assembly.GetEntryAssembly().Location, 0)})

        jl.Refresh()
    End Sub

End Class
