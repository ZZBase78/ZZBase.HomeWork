using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession01
{

    #region Новый общий класс Common. в рамках задания №6

    /// <summary>
    /// Создание общего класса для различных общих методов
    /// В рамках задачи №6
    /// </summary>
    class Common
    {
        /// <summary>
        /// Метод печатающий текст в консоль по середине экрана по X
        /// А также с учетом смещения текста от центра консоли по Y
        /// </summary>
        /// <param name="text"></param> Текст который выводится на экран
        /// <param name="y_offset"></param> Необходимое смещение по Y от центра консоли
        static public void PrintCenter(string text, int y_offset)
        {
            int x_position = GetTextPosition_X(text);
            int y_position = GetTextPosition_Y(y_offset);
            Console.SetCursorPosition(x_position, y_position);
            Console.Write(text);
        }

        /// <summary>
        /// Реализует метод аналогичный методу Console.WriteLine
        /// В рамках задачи №6
        /// </summary>
        /// <param name="text"></param>
        static public void PrintLn(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Реализует метод аналогичный методу Console.Write
        /// В рамках задачи №6
        /// </summary>
        /// <param name="text"></param>
        static public void Print(string text)
        {
            Console.Write(text);
        }
        
        /// <summary>
        /// Метод вычисляющий позицию х начала печати текста
        /// чтобы напечатанный текст был в центре консоли по X
        /// Сам текст не выводится
        /// </summary>
        /// <param name="text"></param> Текст, для которого вычисляется координата начала X
        /// <returns></returns>
        static public int GetTextPosition_X(string text)
        {
            return (Console.WindowWidth - text.Length) / 2;
        }

        /// <summary>
        /// Метод вычисляющий позицию y начала печати текста,
        /// с учетом смещения координаты относительно центра консоли
        /// </summary>
        /// <param name="y_offset"></param> Необходимое смещение от центра по Y
        /// <returns></returns>
        static public int GetTextPosition_Y(int y_offset)
        {
            return (Console.WindowHeight / 2) + y_offset;
        }
        
        /// <summary>
        /// Реализует метод аналогичный методу Console.ReadLine
        /// В рамках задачи №6
        /// </summary>
        static public void Pause()
        {
            Console.ReadLine();
        }
    }

    #endregion

    class Program
    {

        #region Общие методы для реализации заданий

        /// <summary>
        /// Метод, подготавливает консоль к новому выводу
        /// Устанавливает заголовок и очищает консоль
        /// </summary>
        /// <param name="title"></param> Заголовок который будет установлен в консоль
        static void NewTask(string title)
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
        static string ReadString(string question)
        {
            Common.Print(question);
            return Console.ReadLine();
        }

        /// <summary>
        /// Метод который задает вопрос пользователю, ожидает ответа 
        /// и возвращает результат типа Int
        /// </summary>
        /// <param name="question"></param> текст вопроса
        /// <returns></returns>
        static int ReadInt(string question)
        {
            Common.Print(question);
            string answer = Console.ReadLine();
            return int.Parse(answer);
        }

        /// <summary>
        /// Метод который задает вопрос пользователю, ожидает ответа 
        /// и возвращает результат типа Double
        /// </summary>
        /// <param name="question"></param> текст вопроса
        /// <returns></returns>
        static double ReadDouble(string question)
        {
            Common.Print(question);
            string answer = Console.ReadLine();
            
            //заменяем точку на запятую, для корректного преобразования в тип double
            answer = answer.Replace('.', ',');

            return double.Parse(answer);
        }

        /// <summary>
        /// Метод возвращает расстояние между двумя точками
        /// </summary>
        /// <param name="x1"></param> Координата X 1й точки
        /// <param name="y1"></param> Координата Y 1й точки
        /// <param name="x2"></param> Координата X 2й точки
        /// <param name="y2"></param> Координата Y 2й точки
        /// <returns></returns>
        static double Destination(double x1, double y1, double x2, double y2)
        {
            double dest = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return dest;
        }

        #endregion

        #region Реализация задания №1

        /// <summary>
        /// Реализации задания №1.
        /// Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
        /// а) используя склеивание;
        /// б) используя форматированный вывод;
        /// в) используя вывод со знаком $.
        /// </summary>
        /// <param name="title"></param> Заголовок консоли
        static void Task01(string title)
        {
            NewTask(title);

            //Использование метода Common.PrintLn, только для демонстрации работы метода
            //Реализуется только в этой задаче

            Common.PrintLn("Заполните анкету:");
            Common.PrintLn("");

            string name = ReadString("Имя:");
            string surname = ReadString("Фамилия:");
            int age = ReadInt("Возраст:");
            int height = ReadInt("Рост (в см):");
            int weight = ReadInt("Вес:");

            //Вывод склеиванием
            Common.PrintLn("");
            Common.PrintLn("Вывод результата методом склеивания:");
            Common.PrintLn(surname + " " + name + ": возраст " + age + ", рост " + height + ", вес " + weight);
            Common.PrintLn("");

            //Вывод форматированием
            Common.PrintLn("Вывод результата методом форматирования:");
            Console.WriteLine("{0} {1}: возраст {2}, рост {3}, вес {4}", surname, name, age, height, weight);
            Common.PrintLn("");

            //Вывод интерполяцией
            Common.PrintLn("Вывод результата методом интеполяции:");
            Common.PrintLn($"{surname} {name}: возраст {age}, рост {height}, вес {weight}");
            Common.PrintLn("");

            Common.Pause();
        }

        #endregion

        #region Реализация задания №2

        /// <summary>
        /// Реализации задания №2.
        /// Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.
        /// </summary>
        /// <param name="title"></param> Заголовок консоли
        static void Task02(string title)
        {
            NewTask(title);

            double height = ReadDouble("Введите свой рост в метрах:");
            int weight = ReadInt("Введите свой вес в кг:");

            double imt = weight / Math.Pow(height, 2);

            Console.WriteLine();
            Console.WriteLine("Ваш индекс массы тела равен {0:F2}", imt); //форматируем вывод 2 знака после запятой

            Common.Pause();
        }

        #endregion

        #region Реализация задания №3

        /// <summary>
        /// Реализация заданич №3.
        /// а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 
        /// по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
        /// б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
        /// </summary>
        /// <param name="title"></param> Заголовок консоли
        static void Task03(string title)
        {
            NewTask(title);

            double x1 = ReadDouble("Введите координату X первой точки:");
            double y1 = ReadDouble("Введите координату Y первой точки:");
            double x2 = ReadDouble("Введите координату X второй точки:");
            double y2 = ReadDouble("Введите координату Y второй точки:");

            double dest = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            Console.WriteLine();
            Console.WriteLine("Расстояние между точками равно {0:F2}", dest);

            //Использование метода расчета расстояния
            Console.WriteLine();
            Console.WriteLine("Расстояние между точками с использованием метода расчета равно {0:F2}", Destination(x1, y1, x2, y2));

            Common.Pause();
        }
        
        #endregion

        #region Реализация задания №4

        /// <summary>
        /// Реализация задания №4.
        /// Написать программу обмена значениями двух переменных типа int без использования вспомогательных методов.
        /// а) с использованием третьей переменной;
        /// б) *без использования третьей переменной.
        /// </summary>
        /// <param name="title"></param> Заголовок консоли
        static void Task04(string title)
        {
            NewTask(title);

            int a = ReadInt("Введите значение первой переменной (A):");
            int b = ReadInt("Введите значение первой переменной (B):");

            Console.WriteLine();
            Console.WriteLine("Значения переменных до обмена:");
            Console.WriteLine("A = {0}; B = {1}", a, b);

            //Обмен значениями с использованием третьей переменной
            int c = a;
            a = b;
            b = c;
            Console.WriteLine("Значения переменных после обмена С использованием третьей переменной:");
            Console.WriteLine("A = {0}; B = {1}", a, b);

            //Возврат переменных в первоначальное состояние, для проверки результата обмена другим методом
            c = a; a = b; b = c;

            //Обмен значениями без использования третьей переменной
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine("Значения переменных после обмена БЕЗ использованием третьей переменной:");
            Console.WriteLine("A = {0}; B = {1}", a, b);

            Common.Pause();
        }

        #endregion

        #region Реализация задания №5

        /// <summary>
        /// Реализация задания №5.
        /// а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
        /// б) Сделать задание, только вывод организовать в центре экрана.
        /// в) *Сделать задание б с использованием собственных методов (например, Print(string ms, int x, int y).
        /// </summary>
        /// <param name="title"></param> Заголовок консоли
        static void Task05(string title)
        {
            NewTask(title + " Ввод данных");

            Console.WriteLine("Введите данные:");
            Console.WriteLine();

            string name = ReadString("Имя:");
            string surname = ReadString("Фамилия:");
            string city = ReadString("Город проживания:");

            NewTask(title + " Простой вывод данных");
            Console.WriteLine($"Вас зовут: {surname} {name}");
            Console.WriteLine($"Вы проживаете в городе {city}");
            Common.Pause();

            NewTask(title + " Вывод данных по центру экрана");
            string text = $"Вас зовут: {surname} {name}";
            int x = Common.GetTextPosition_X(text);
            int y = Common.GetTextPosition_Y(-1); // Смещение выше центра на 1 позицию
            Console.SetCursorPosition(x, y);
            Console.Write(text);
            text = $"Вы проживаете в городе {city}";
            x = Common.GetTextPosition_X(text);
            y = Common.GetTextPosition_Y(0); // по центру без смещения
            Console.SetCursorPosition(x, y);
            Console.Write(text);
            Common.Pause();

            NewTask(title + " Вывод данных по центру экрана, с использованием метода");
            Common.PrintCenter($"Вас зовут: {surname} {name}", -1); // Смещение выше центра на 1 позицию
            Common.PrintCenter($"Вы проживаете в городе {city}", 0); // по центру без смещения
            Common.Pause();
        }

        #endregion

        #region Точка входа

        /// <summary>
        /// Основной Метод программы. Точка входа.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Task01("Задание 1. Программа \"Анкета\"");

            Task02("Задание 2. Расчет индекса массы тела");

            Task03("Задание 3. Расчет расстояния между точками");

            Task04("Задание 4. Программа обмена значениями двух переменных");

            Task05("Задание 5.");
        }

        #endregion

    }
}
