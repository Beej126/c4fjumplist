using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Windows7Jumplist
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool firstInstance = false;

            Mutex mtx = new Mutex(true, "MSDN.C4F.Win7.Jumplist", out firstInstance);

            if (firstInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                // Send argument to running window
                HandleCmdLineArgs();
            }
        }

        public static void HandleCmdLineArgs()
        {
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                switch (Environment.GetCommandLineArgs()[1])
                {
                    case "-1":
                        WindowsMessageHelper.SendMessage("MSDN.C4F.Win7.Jumplist", WindowsMessageHelper.ARG1);
                        break;

                    case "-2":
                        WindowsMessageHelper.SendMessage("MSDN.C4F.Win7.Jumplist", WindowsMessageHelper.ARG2);
                        break;

                    case "-3":
                        WindowsMessageHelper.SendMessage("MSDN.C4F.Win7.Jumplist", WindowsMessageHelper.ARG3);
                        break;
                }
            }
        }
    }
}
