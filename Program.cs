using System;
using System.Windows.Forms;

namespace BernardBawakA7
{
    // This is where our program starts running
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// When you run the program, this is the first method that gets called.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Turn on the nice-looking modern Windows styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Create and show our main window (the form with the buttons and list)
            Application.Run(new CarForm());
        }
    }
}

