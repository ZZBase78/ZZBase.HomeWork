using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession06
{
    /// <summary>
    /// Класс для организации главного меню. с небольшой динамикой
    /// </summary>
    class SlowMenu
    {
        static List<string> _menu_items = new List<string>(); // коллекция пунктов меню

        static int _pause = 1; // пауза
        static int _max_right_position = 12; // правая позиция с которой двигается меню

        /// <summary>
        /// Метод движения строки справа налево
        /// </summary>
        /// <param name="text"></param> движущийся текст
        /// <param name="x"></param> начальная позиция X
        /// <param name="end_x"></param> конечная козиция X
        /// <param name="y"></param> координата Y по которой движется текст
        /// <param name="pause"></param> задержка в миллисекундах
        static void ScrollMenuItem(string text, int x, int end_x, int y, int pause)
        {
            string empty_text = new String(' ', text.Length);
            do
            {
                Console.SetCursorPosition(x, y);
                Console.Write(empty_text);
                if (x < end_x)
                {
                    x++;
                }
                if (x > end_x)
                {
                    x--;
                }
                Console.SetCursorPosition(x, y);
                Console.Write(text);

                if (x != end_x)
                {
                    System.Threading.Thread.Sleep(pause);
                }

            } while (x != end_x);
        }

        /// <summary>
        /// Добавление одного пункта меню в коллекцию
        /// </summary>
        /// <param name="text"></param>
        static void AddMenuItem(string text)
        {
            _menu_items.Add(text);
        }

        /// <summary>
        /// Добавление массива пунктов меню в коллекцию
        /// </summary>
        /// <param name="array_text"></param>
        static void AddMenuItem(string[] array_text)
        {
            foreach (string text in array_text)
            {
                AddMenuItem(text);
            }
        }

        /// <summary>
        /// Вывод меню по-строчно. Движение каждой строки меню справа до нулевой позиции
        /// </summary>
        static void ShowMenu()
        {
            int y = 0;
            foreach (string menu_text in _menu_items)
            {
                ScrollMenuItem($"{y + 1}. " + menu_text, _max_right_position, 0, y, _pause);
                y++;
            }
        }

        /// <summary>
        /// Очистка коллекции
        /// </summary>
        static void NewLst()
        {
            _menu_items.Clear();
        }

        /// <summary>
        /// Метод выодит на экран меню из переданного массива и вовращает результат выбранный пользователем
        /// </summary>
        /// <param name="menu_items"></param> массив строк меню
        /// <returns></returns>
        static public int ChooseMenu(string[] menu_items)
        {

            Console.Clear();
            string old_title = Console.Title;

            Console.Title = "МЕНЮ";

            string full_empty_string = new String(' ', Console.WindowWidth - 1);
            NewLst(); //иницаилизируем коллекцию
            AddMenuItem(menu_items); //добавляем строки меню

            Console.CursorVisible = false;
            ShowMenu(); // показываем меню, с движением
            ScrollMenuItem("0. ВЫХОД", _max_right_position, 0, _menu_items.Count() + 1, _pause); // добавляем движения меню ВЫХОД
            Console.CursorVisible = true;

            bool correct_answer;
            int int_answer;

            //Выбор меню

            do
            {
                Console.SetCursorPosition(0, _menu_items.Count() + 3);
                Console.Write("Выберите пункт меню:");
                string answer = Console.ReadLine();

                bool correct_int = int.TryParse(answer, out int_answer); // проверка

                correct_answer = correct_int && int_answer >= 0 && int_answer <= _menu_items.Count();

                if (!correct_answer)
                {
                    ConsoleColor current_color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ВВОДА. Повторите ввод.");
                    Console.ForegroundColor = current_color;
                    Console.Beep();
                    System.Threading.Thread.Sleep(500);

                    //очистим старый ввод
                    Console.SetCursorPosition(0, _menu_items.Count() + 3);
                    Console.Write(full_empty_string); // очистка ввода
                    Console.SetCursorPosition(0, _menu_items.Count() + 4);
                    Console.Write(full_empty_string); // очистка сообщение об ошибке
                }

            } while (!correct_answer);

            Console.Title = old_title;

            return int_answer;
        }

    }
}
