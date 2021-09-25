using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Main_Window_2
{
    static class Program
    {

        static MainWindow mainWindow;

        static public void MessageTool(string text)
        {
            if (mainWindow != null)
            {
                mainWindow.MessageTool(text);
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainWindow = new MainWindow();
            Application.Run(mainWindow);
        }
    }
}
