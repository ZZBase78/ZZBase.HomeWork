using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Test
{
    class Menu
    {
        public enum ItemAlign {Left, Center, Right};

        string[] menuitems;

        int menuwidth;
        int menuheight;

        int menu_x;
        int menu_y;

        int current_select;

        void PrintMenuElement(int menuindex)
        {
            Console.SetCursorPosition(menu_x, menu_y + menuindex);
            if (menuindex == current_select)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.Write(menuitems[menuindex]);
        }

        public int ChooseMenu(string[] param_menuitems, int min_menu_width, ItemAlign align)
        {
            Console.CursorVisible = false;

            ConsoleColor lastforeground = Console.ForegroundColor;
            ConsoleColor lastbackground = Console.BackgroundColor;

            menuitems = new string[param_menuitems.Length];

            // запишем меню в массив, и также определим максимальную длину элемента меню
            int max_length = 0;
            for (int i = 0; i < param_menuitems.Length; i++)
            {
                menuitems[i] = param_menuitems[i];
                if (menuitems[i].Length > max_length) max_length = menuitems[i].Length;
            }

            if (max_length < min_menu_width) max_length = min_menu_width;

            //Добавим в каждый элемент меню пробелы справа и слева, до максимальной длины
            for (int i = 0; i < menuitems.Length; i++)
            {
                if (align == ItemAlign.Center)
                {
                    int current_length = menuitems[i].Length;
                    int left_space = (max_length - current_length) / 2;
                    int right_space = (max_length - current_length) - left_space; // за счет округления при предыдущем делении, могут быть ошибки, поэтому используем вычитание

                    menuitems[i] = new string(' ', left_space) + menuitems[i] + new string(' ', right_space); // центрируем меню
                }
                else if (align == ItemAlign.Left)
                {
                    int current_length = menuitems[i].Length;
                    int right_space = max_length - current_length;

                    menuitems[i] = menuitems[i] + new string(' ', right_space);
                }
                else if (align == ItemAlign.Right)
                {
                    int current_length = menuitems[i].Length;
                    int left_space = max_length - current_length;

                    menuitems[i] = new string(' ', left_space) + menuitems[i];
                }
            }

            menuwidth = max_length;
            menuheight = menuitems.Length;

            menu_x = (Console.WindowWidth / 2) - (menuwidth / 2) + Console.WindowLeft;
            menu_y = (Console.WindowHeight / 2) - (menuheight / 2) + Console.WindowTop;

            current_select = 0;

            for (int i = 0; i < menuitems.Length; i++)
            {
                PrintMenuElement(i);
            }

            int return_value = 0;

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (((keyInfo.Key == ConsoleKey.UpArrow) || (keyInfo.Key == ConsoleKey.W)) && (current_select > 0))
                {
                    int last_select = current_select;
                    current_select--;
                    PrintMenuElement(last_select);
                    PrintMenuElement(current_select);
                }else if (((keyInfo.Key == ConsoleKey.DownArrow) || (keyInfo.Key == ConsoleKey.S)) && (current_select < menuitems.Length - 1))
                {
                    int last_select = current_select;
                    current_select++;
                    PrintMenuElement(last_select);
                    PrintMenuElement(current_select);
                }else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    return_value = current_select;
                    break;
                }else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return_value = -1;
                    break;
                }
            } while (true);

            Console.CursorVisible = true;

            Console.ForegroundColor = lastforeground;
            Console.BackgroundColor = lastbackground;

            return return_value;
        }
    }
}
