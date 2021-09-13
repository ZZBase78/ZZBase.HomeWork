using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession04
{
    /// <summary>
    /// Общий класс, для реализации домашних заданий
    /// </summary>
    class My
    {

        /// <summary>
        /// поле для использования пауз в методах
        /// Количество "пустых" циклов за 1 секунду
        /// </summary>
        static public int pause1s = 0;

        /// <summary>
        /// Метод считающий количество проходов пустого цикла за одну секунду
        /// созраняет в статическую переменную pause1s
        /// </summary>
        static public void CalcCPU()
        {
            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(1);
            int count = 0;
            while (DateTime.Now < end)
            {
                count++;
            }
            pause1s = count;
        }

        /// <summary>
        /// Пауза с заданным количеством "пустых" циклов
        /// </summary>
        /// <param name="count">количество пустых циклов</param>
        static void Idle(int count)
        {
            DateTime st = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                //имитация тех же методов, которые использоались при расчете количества циклов
                DateTime dt = DateTime.Now;
                if (st > dt)
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// Метод, подготавливает консоль к новому выводу
        /// Устанавливает заголовок и очищает консоль
        /// </summary>
        /// <param name="title"></param> Заголовок который будет установлен в консоль
        static public void NewTask(string title)
        {
            Console.Title = title;
            Console.Clear();
        }

        /// <summary>
        /// Метод который задает вопрос пользователю, ожидает ответа 
        /// и возвращает результат типа String
        /// </summary>
        /// <param name="question"></param> текст вопроса
        /// <returns></returns>
        static public string ReadString(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        /// <summary>
        /// Метод который задает вопрос пользователю, ожидает ответа 
        /// и возвращает результат типа String
        /// вывод вопроса осуществляется с задержкой
        /// </summary>
        /// <param name="question"></param> текст вопроса
        /// <returns></returns>
        static public string SlowReadString(string question)
        {
            SlowMessage(question, false);
            return Console.ReadLine();
        }

        /// <summary>
        /// Метод который задает вопрос пользователю, ожидает ответа 
        /// Ответ при выводе на экран заменяется *
        /// и возвращает результат типа String
        /// вывод вопроса осуществляется с задержкой
        /// Клавиша ESC очищает ввод
        /// </summary>
        /// <param name="question"></param> текст вопроса
        /// <returns></returns>
        static public string SlowReadPassword(string question)
        {
            string s = "";
            SlowMessage(question, false);
            ConsoleKeyInfo c;
            do
            {
                c = Console.ReadKey(true);
                if ((c.Key != ConsoleKey.Enter) && (c.Key != ConsoleKey.Escape))
                {
                    s += c.KeyChar;
                    Console.Write("*");
                } else if (c.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.WindowWidth - 1));
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(question);
                    s = "";
                }

            } while (c.Key != ConsoleKey.Enter);

            Console.WriteLine();

            return s;
        }

        /// <summary>
        /// Метод который задает вопрос пользователю, ожидает ответа 
        /// и возвращает результат типа Int
        /// </summary>
        /// <param name="question"></param> текст вопроса
        /// <returns></returns>
        static public int ReadInt(string question)
        {
            ConsoleColor current_color = Console.ForegroundColor;
            ConsoleColor error_color = ConsoleColor.Red;
            int result;
            bool correct = false;
            int y = Console.CursorTop;
            string empty_string = new string(' ', Console.WindowWidth - 1);

            do
            {
                Console.SetCursorPosition(0, y);
                Console.Write(empty_string);
                Console.SetCursorPosition(0, y);
                Console.Write(question);
                string answer_string = Console.ReadLine();
                correct = int.TryParse(answer_string, out result);
                if (!correct)
                {
                    Console.SetCursorPosition(0, y);
                    Console.Write(empty_string);
                    Console.SetCursorPosition(0, y);
                    Console.Write(question);
                    Console.ForegroundColor = error_color;
                    Console.Write("ОШИБКА ВВОДА. Повторите ввод...");
                    Console.ForegroundColor = current_color;
                    Console.Beep();
                    System.Threading.Thread.Sleep(500);
                }
            } while (!correct);

            return result;
        }

        /// <summary>
        /// Метод который задает вопрос пользователю, ожидает ответа 
        /// и возвращает результат типа Int
        /// Вывод вопроса осуществляется с задержкой
        /// </summary>
        /// <param name="question"></param> текст вопроса
        /// <returns></returns>
        static public int SlowReadInt(string question)
        {
            ConsoleColor current_color = Console.ForegroundColor;
            ConsoleColor error_color = ConsoleColor.Red;
            int result;
            bool correct = false;
            int y = Console.CursorTop;
            string empty_string = new string(' ', Console.WindowWidth - 1);
            bool first_ask = true; // медленный вывод вопроса, осуществляется только при первом выводе

            do
            {
                Console.SetCursorPosition(0, y);
                Console.Write(empty_string);
                Console.SetCursorPosition(0, y);
                if (first_ask)
                {
                    SlowMessage(question, false);
                    first_ask = false; //если будет ошибка при вводе, то сделующий повтор вопроса будет обычным
                }
                else
                {
                    Console.Write(question);
                }
                
                string answer_string = Console.ReadLine();
                correct = int.TryParse(answer_string, out result);
                if (!correct)
                {
                    Console.SetCursorPosition(0, y);
                    Console.Write(empty_string);
                    Console.SetCursorPosition(0, y);
                    Console.Write(question);
                    Console.ForegroundColor = error_color;
                    Console.Write("ОШИБКА ВВОДА. Повторите ввод...");
                    Console.ForegroundColor = current_color;
                    Console.Beep();
                    System.Threading.Thread.Sleep(500);
                }
            } while (!correct);

            return result;
        }

        /// <summary>
        /// Метод который задает вопрос пользователю, ожидает ответа 
        /// и возвращает результат типа Int в заданном диапазоне
        /// Вывод вопросв осуществляется с задержкой
        /// </summary>
        /// <param name="question">текст вопроса</param> 
        /// <param name="min_value">минимаьное значение</param> 
        /// <param name="max_value">максимальное значение</param> 
        /// <returns></returns>
        static public int SlowReadInt(string question, int min_value, int max_value)
        {
            ConsoleColor current_color = Console.ForegroundColor;
            ConsoleColor error_color = ConsoleColor.Red;
            int result;
            bool correct = false;
            int y = Console.CursorTop;
            string empty_string = new string(' ', Console.WindowWidth - 1);
            bool first_ask = true; // медленный вывод вопроса, осуществляется только при первом выводе

            do
            {
                Console.SetCursorPosition(0, y);
                Console.Write(empty_string);
                Console.SetCursorPosition(0, y);
                if (first_ask)
                {
                    SlowMessage(question, false);
                    first_ask = false; //если будет ошибка при вводе, то сделующий повтор вопроса будет обычным
                }
                else
                {
                    Console.Write(question);
                }

                string answer_string = Console.ReadLine();
                correct = int.TryParse(answer_string, out result);

                //Если введено корректное значение, то проверим вхождение в интервал,
                //если ошибка, то сбросим флаг correct
                if ((correct) && ((result < min_value) || (result > max_value))) correct = false;

                if (!correct)
                {
                    Console.SetCursorPosition(0, y);
                    Console.Write(empty_string);
                    Console.SetCursorPosition(0, y);
                    Console.Write(question);
                    Console.ForegroundColor = error_color;
                    Console.Write("ОШИБКА ВВОДА. Повторите ввод...");
                    Console.ForegroundColor = current_color;
                    Console.Beep();
                    System.Threading.Thread.Sleep(500);
                }
            } while (!correct);

            return result;
        }

        /// <summary>
        /// Метод который задает вопрос пользователю, ожидает ответа 
        /// и возвращает результат типа Double
        /// </summary>
        /// <param name="question"></param> текст вопроса
        /// <returns></returns>
        static public double ReadDouble(string question)
        {
            ConsoleColor current_color = Console.ForegroundColor;
            ConsoleColor error_color = ConsoleColor.Red;
            double result;
            bool correct = false;
            int y = Console.CursorTop;
            string empty_string = new string(' ', Console.WindowWidth - 1);

            do
            {
                Console.SetCursorPosition(0, y);
                Console.Write(empty_string);
                Console.SetCursorPosition(0, y);
                Console.Write(question);
                string answer_string = Console.ReadLine();
                answer_string = answer_string.Replace('.', ',');
                correct = double.TryParse(answer_string, out result);
                if (!correct)
                {
                    Console.SetCursorPosition(0, y);
                    Console.Write(empty_string);
                    Console.SetCursorPosition(0, y);
                    Console.Write(question);
                    Console.ForegroundColor = error_color;
                    Console.Write("ОШИБКА ВВОДА. Повторите ввод...");
                    Console.ForegroundColor = current_color;
                    Console.Beep();
                    System.Threading.Thread.Sleep(500);
                }
            } while (!correct);

            return result;
        }

        /// <summary>
        /// Возвращает истину если переданный параметр находится внитри интервала,
        /// Ложь в противном случае
        /// </summary>
        /// <param name="value"></param> параметр для проверки
        /// <param name="min"></param> нижняя граница интервала
        /// <param name="max"></param> верхняя граница интервала
        /// <returns></returns>
        static public bool isInInterval(double value, double min, double max)
        {
            return (value >= min && value <= max);
        }

        /// <summary>
        /// Перегрзка метода для целых чисел
        /// Возвращает истину если переданный параметр находится внитри интервала,
        /// Ложь в противном случае
        /// </summary>
        /// <param name="value"></param> параметр для проверки
        /// <param name="min"></param> нижняя граница интервала
        /// <param name="max"></param> верхняя граница интервала
        /// <returns></returns>
        static public bool isInInterval(int value, int min, int max)
        {
            return (value >= min && value <= max);
        }

        /// <summary>
        /// Процедура выводит текст аналогично WriteLine
        /// </summary>
        /// <param name="text"></param> текст для вывода
        static public void Message(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Перегрузка метода Message бещ параметров
        /// простой пропуск строки
        /// </summary>
        static public void Message()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Процедура ожидания Enter. Пауза.
        /// </summary>
        static public void Pause()
        {
            Console.ReadLine();
        }

        /// <summary>
        /// Перегрузка метода pause. Выводит сообщение и ожидает Enter.
        /// </summary>
        static public void Pause(string text)
        {
            Console.WriteLine(text);
            Console.ReadLine();
        }

        /// <summary>
        /// Выводит текст ошибки красным цветом и выдает звуковой сигнал
        /// </summary>
        /// <param name="text">текст ошибки</param>
        static public void ErrorSignal(string text)
        {
            ConsoleColor cur_color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Message(text);
            Console.ForegroundColor = cur_color;
            Console.Beep();
        }

        /// <summary>
        /// Выводит текст ошибки красным цветом
        /// </summary>
        /// <param name="text">текст ошибки</param>
        static public void Error(string text)
        {
            ConsoleColor cur_color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Message(text);
            Console.ForegroundColor = cur_color;
            Console.Beep();
        }

        /// <summary>
        /// Выводит переданную строку посимвольно с задержкой
        /// </summary>
        /// <param name="text">текст для вывода</param>
        /// <param name="crlf">флаг нужно ли переводить строку в конце вывода</param>
        static public void SlowMessage(string text, bool crlf)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Idle(pause1s/120); //120 символов в секунду
            }
            if (crlf) Console.WriteLine();
        }
    }
}
