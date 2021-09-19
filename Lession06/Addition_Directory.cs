using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession06
{
    class Addition_Directory
    {

        /// <summary>
        /// Методв выводит содержимое каталога и файлов, включая подкаталоги
        /// </summary>
        /// <param name="directoryInfo">Каталог</param>
        /// <param name="space">строки пропуска перед формирование каталога</param>
        /// <param name="last_element">признай последни ли это элемент в каталоге</param>
        static void Directory_Content(DirectoryInfo directoryInfo, string space, bool last_element)
        {
            Console.Write(space);

            if (last_element)
            {
                Console.Write("└─");
                space += "  ";
            }
            else
            {
                Console.Write("├─");
                space += "│ ";
            }

            Console.WriteLine(directoryInfo.Name.ToUpper()); // все каталоги выводим большими буквами

            DirectoryInfo[] subdirs;
            FileInfo[] subfiles;

            // читаем содержимое каталога
            try
            {
                subdirs = directoryInfo.GetDirectories();
            }
            catch
            {
                // проверка на исключение сделана, т.к. в некоторые системные каталоги нет доступа
                subdirs = new DirectoryInfo[] { };
            }

            try
            {
                subfiles = directoryInfo.GetFiles();
            }
            catch
            {
                // проверка на исключение сделана, т.к. в некоторые системные каталоги нет доступа
                subfiles = new FileInfo[] { };
            }

            

            // выводим структуру подкаталога
            for (int i = 0; i < subdirs.Length; i++)
            {
                // признак последнего элемента, последним каталог считается, если файлов в том же каталоге тоже нет
                bool last = ((i == subdirs.Length - 1) && (subfiles.Length == 0));
                Directory_Content(subdirs[i], space, last); // рекурсивный вывод
            }

            
            //Вывод файлов в каталоге, для файлов рекурсии нет
            for (int i = 0; i < subfiles.Length; i++)
            {
                Console.Write(space);
                if (i == subfiles.Length - 1)
                {
                    Console.Write("└─");
                }
                else
                {
                    Console.Write("├─");
                }
                Console.WriteLine(subfiles[i].Name.ToLower()); // все файлы выводим маленькими буквами
            }
        }

        /// <summary>
        /// Реализация дополнительного задания. по содержимому каталогов
        /// </summary>
        public static void Start()
        {
            My.NewTask("Дополнительно. Структура каталогов");

            DirectoryInfo directoryInfo = new DirectoryInfo("D:\\GeekBrains\\C-Sharp\\HomeWork\\ZZBase.HomeWork");
            //DirectoryInfo directoryInfo = new DirectoryInfo("C:\\");

            Directory_Content(directoryInfo, "", true);

            PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000);
        }

    }
}
