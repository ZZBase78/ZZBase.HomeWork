using System;

namespace Lession06
{
    class Program
    {
        static void Main()
        {
            //Расчет скорости компьютера, для корректной задержки при выводе сообщений
            //т.к. данный механизм не тестировался на других компьютерах, возможна ошибка при реализации
            //В случае возникновения таковой, необходимо закомментировать следующие три строки
            My.Message("Подсчет CPU (1 сек)...");
            My.CalcCPU();
            Console.Clear();

            int menu_number;
            do
            {
                menu_number = Menu.ChooseMenu(new string[] {
                    "Задание 1 (из методички). Демонстрация программы из методички",
                    "Задание 1 (доработка). Демонстрация программы с доработанными методами с новой сигнатурой делегата",
                    "Задание 2 (из методички). Нахождение минимума функции из методички",
                    "Задание 2 (доработка). Нахождение минимума функции с использованием делегатов",
                    "Задание 3 (из методички). Работа со списком студентов",
                    "Задание 3 (доработка). Доработанный пример работы со списком студентов",
                    "Дополнительно. Структура каталогов"
                });

                // Все классы по решению заданий в отдельных файлах .cs

                switch (menu_number)
                {
                    case 1: Task01_original.Task01_original_Main(); break;
                    case 2: Task01_updated.Task01_updated_Main(); break;
                    case 3: Task02_original.Task02_original_Main(); break;
                    case 4: Task02_updated.Task02_updated_Main(); break;
                    case 5: Task03_original.Task03_original_Main(); break;
                    case 6: Task03_updated.Task03_updated_Main(); break;
                    case 7: Addition_Directory.Start(); break;
                }

            } while (menu_number != 0);

        }
    }

}
