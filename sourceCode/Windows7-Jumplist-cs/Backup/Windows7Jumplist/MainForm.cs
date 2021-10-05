using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack.Taskbar;
using Microsoft.WindowsAPICodePack.Shell;
using System.Reflection;

namespace Windows7Jumplist
{
    public partial class MainForm : Form
    {
        // Keep a reference to the Taskbar instance
        private TaskbarManager windowsTaskbar = TaskbarManager.Instance;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (TaskbarManager.IsPlatformSupported)
            {
                CreateJumpList();

                windowsTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress);
            }

            Program.HandleCmdLineArgs();
        }

        
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WindowsMessageHelper.ARG1)
            {
                lblMessage.Text = "Arg1"; 
                lblMessage.BackColor = Color.LightGreen;
            }
            else if (m.Msg == WindowsMessageHelper.ARG2)
            {
                lblMessage.Text = "Arg1";
                lblMessage.BackColor = Color.LightBlue;
            }
            else if (m.Msg == WindowsMessageHelper.ARG3)
            {
                lblMessage.Text = "Arg1";
                lblMessage.BackColor = Color.Yellow;
            }
            else base.WndProc(ref m);
        }

        private void CreateJumpList()
        {
            JumpList jl = JumpList.CreateJumpList();

            // Show user files: Recent, Frequent, or None
            jl.KnownCategoryToDisplay = JumpListKnownCategoryType.Recent;

            // Add my own links (nouns)
            JumpListCustomCategory catActions = new JumpListCustomCategory("Destinations");
            catActions.AddJumpListItems(
                new JumpListLink(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "My Pictures"),
                new JumpListLink("http://blogs.msdn.com/coding4fun", "Visit Coding4Fun"),
                new JumpListLink("http://code.msdn.microsoft.com/WindowsAPICodePack", "Windows API Code Pack")
                //new JumpListItem(@"c:\Test1.c4f")
                );

            jl.AddCustomCategories( catActions);

            // Path to Windows system folder
            string systemFolder = Environment.GetFolderPath(Environment.SpecialFolder.System);

            // Add our user tasks (verbs)

            jl.AddUserTasks(new JumpListLink(Path.Combine(systemFolder, "notepad.exe"), "Open Notepad")
            {
                IconReference = new IconReference(Path.Combine(systemFolder, "notepad.exe"), 0)
            });

            jl.AddUserTasks(new JumpListLink(Path.Combine(systemFolder, "mspaint.exe"), "Open Paint")
            {
                IconReference = new IconReference(Path.Combine(systemFolder, "mspaint.exe"), 0)
            });

            jl.AddUserTasks(new JumpListSeparator());

            jl.AddUserTasks(new JumpListLink(Assembly.GetEntryAssembly().Location, "Action 1 (Green)")
            {
                IconReference = new IconReference(Assembly.GetEntryAssembly().Location, 0),
                Arguments = "-1"
            });

            jl.AddUserTasks(new JumpListLink(Assembly.GetEntryAssembly().Location, "Action 2 (Blue)")
            {
                IconReference = new IconReference(Assembly.GetEntryAssembly().Location, 0),
                Arguments = "-2"
            });

            jl.AddUserTasks(new JumpListLink(Assembly.GetEntryAssembly().Location, "Action 3 (Yellow)")
            {
                IconReference = new IconReference(Assembly.GetEntryAssembly().Location, 0),
                Arguments = "-3"
            });

            jl.Refresh();
        }

    }
}
