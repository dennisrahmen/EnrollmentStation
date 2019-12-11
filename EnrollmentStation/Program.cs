using System;
using System.Windows.Forms;
using YubicoLib.YubikeyManager;

namespace EnrollmentStation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string YKbinary = @"Binaries\YubikeyManager\ykman.exe";
            const string WorkingDirectory = @"Binaries\YubikeyManager";
            YubmanConsole.setYKManPath(YKbinary, WorkingDirectory);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
