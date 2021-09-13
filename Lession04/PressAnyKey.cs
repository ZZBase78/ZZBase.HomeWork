using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession04
{
    /// <summary>
    /// Ожидание нажатия любой клавиши с цветным сообщением
    /// </summary>
    class PressAnyKey
    {
        /// <summary>
        /// Метод ожидающий нажатия любой клавиши
        /// Динамически меняет цвета надписи
        /// </summary>
        static public void Run()
        {

            ConsoleColor current_color = Console.ForegroundColor;

            Random rnd = new Random();

            //Очистим буфер ввода перед началом паузы
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            Console.CursorVisible = false;
            do
            {
                int cur_color = rnd.Next(0, 16);
                Console.ForegroundColor = (ConsoleColor)Enum.GetValues(typeof(ConsoleColor)).GetValue(cur_color);
                Console.SetCursorPosition(0, Console.WindowTop + Console.WindowHeight - 1);
                Console.Write("Press any key...");
                System.Threading.Thread.Sleep(100);

            } while (!Console.KeyAvailable);

            Console.ForegroundColor = current_color;

            //Очистим буфер ввода после окончания паузы
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            Console.SetCursorPosition(0, Console.WindowTop + Console.WindowHeight - 1);
            Console.Write("                ");

            Console.CursorVisible = true;
        }
    }

}
