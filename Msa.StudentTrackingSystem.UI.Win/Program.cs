using Msa.StudentTrackingSystem.UI.Win.GeneralForms;
using System;
using System.Windows.Forms;

namespace Msa.StudentTrackingSystem.UI.Win
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}