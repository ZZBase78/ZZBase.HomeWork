using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lession08
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
        static public void MessageToolError(string text)
        {
            if (mainWindow != null)
            {
                mainWindow.MessageToolError(text);
            }
            MessageBox.Show(text, "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
