using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Домашнее задание №7
/// Автор: Полторацкий Сергей
/// </summary>
namespace Lession07
{
    static class Program
    {

        /// <summary>
        /// Переменная хранить ссылку на форму, которую необходимо открыть после закрытия основного меню
        /// </summary>
        public static Form nextform;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            do
            {
                nextform = null;
                Application.Run(new StartForm());

                if (nextform != null) Application.Run(nextform);

            } while (nextform != null);


        }
    }
}
