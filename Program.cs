// File: Program.cs
using System;
using System.Windows.Forms;

namespace MyKioskApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // This line makes sure your WelcomeForm starts first.
            Application.Run(new WelcomeForm());
        }
    }
}