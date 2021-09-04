using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// ДЗ №2
/// Автор: Полторацкий Сергей
/// </summary>
namespace Lession02
{
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
            Console.Write(question);
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
            Console.Write(question);
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Метод который задает вопрос пользователю, ожидает ответа 
        /// и возвращает результат типа Double
        /// </summary>
        /// <param name="question"></param> текст вопроса
        /// <returns></returns>
        static double ReadDouble(string question)
        {
            Console.Write(question);
            string answer = Console.ReadLine();

            //заменяем точку на запятую, для корректного преобразования в тип double
            answer = answer.Replace('.', ',');

            return double.Parse(answer);
        }

        /// <summary>
        /// Возвращает истину если переданный параметр находится внитри интервала,
        /// Ложь в противном случае
        /// </summary>
        /// <param name="value"></param> параметр для проверки
        /// <param name="min"></param> нижняя граница интервала
        /// <param name="max"></param> верхняя граница интервала
        /// <returns></returns>
        static bool isInInterval(double value, double min, double max)
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
        static bool isInInterval(int value, int min, int max)
        {
            return (value >= min && value <= max);
        }

        /// <summary>
        /// Процедура выводит текст аналогично WriteLine
        /// </summary>
        /// <param name="text"></param> текст для вывода
        static void Message(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Перегрузка метода Message бещ параметров
        /// простой пропуск строки
        /// </summary>
        static void Message()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Процедура ожидания Enter. Пауза.
        /// </summary>
        static void Pause()
        {
            Console.ReadLine();
        }

        /// <summary>
        /// Перегрузка метода pause. Выводит сообщение и ожидает Enter.
        /// </summary>
        static void Pause(string text)
        {
            Console.WriteLine(text);
            Console.ReadLine();
        }

        #endregion

        #region Основное меню

        /// <summary>
        /// Основное меню программы
        /// Вызывается при начале работы и после каждой задачи
        /// </summary>
        /// <returns></returns>
        static int MainMenu()
        {
            int answer; // ответ пользователя
            bool answer_is_correct; // корректность ответа

            do
            {
                NewTask("Выбор задания");

                Message("Задание 1. Минимальное из трёх чисел. ");
                Message("Задание 2. Подсчет количества цифр числа.");
                Message("Задание 3. Подсчет суммы всех нечетных положительных чисел.");
                Message("Задание 4. Проверка логина и пароля");
                Message("Задание 5. Индекс массы тела");
                Message("Задание 6. \"Хорошие\" числа");
                Message("Задание 7. Рекурсия");
                Message();
                Message("0. Выход из программы");

                Message();
                answer = ReadInt("Выберите номер задания:");
                answer_is_correct = isInInterval(answer, 0, 7);
                if (!answer_is_correct) 
                {
                    Pause("ОШИБКА: Некорректный ввод");
                }

            } while (!answer_is_correct);

            return answer;
        }

        #endregion

        #region Процедуры реализации заданий

        #region Задание №1

        /// <summary>
        /// Метод возвращающий минимальное число из двух
        /// </summary>
        /// <param name="a"></param> первое число
        /// <param name="b"></param> второе число
        /// <returns></returns>
        static int Min(int a, int b)
        {
            return a < b ? a : b; //Взамен Math.Min
        }

        /// <summary>
        /// Перегрузка метода Min,  возвращающий минимальное число из трех
        /// </summary>
        /// <param name="a"></param> первое число
        /// <param name="b"></param> второе число
        /// <param name="c"></param> третье число
        /// <returns></returns>
        static int Min(int a, int b, int c)
        {
            return Min(a, Min(b, c));
        }

        /// <summary>
        /// 1. Написать метод, возвращающий минимальное из трёх чисел.
        /// </summary>
        static void Task01()
        {
            NewTask("Задание 1. Минимальное из трёх чисел.");

            int a = ReadInt("Введите первое число:");
            int b = ReadInt("Введите второе число:");
            int c = ReadInt("Введите третье число:");

            int min = Min(a, b, c);

            Message();
            Message($"Минимальное число из трех равно {min}");

            Pause();
        }

        #endregion

        #region Задание №2

        /// <summary>
        /// Метод возвращающий количество цифр в числе
        /// </summary>
        /// <param name="value"></param> анализируемое число
        /// <returns></returns>
        static int DigitCount(int value)
        {
            //string.Length - не интересно

            //Переведем параметр в строку и подсчитаем количество символов в строке
            string str = value.ToString();

            int counter = 0;

            foreach (char ch in str) 
            {
                //новый символ, увеличиваем счетчик
                counter++;
            }
            return counter;
        }

        /// <summary>
        /// 2. Написать метод подсчета количества цифр числа.
        /// </summary>
        static void Task02()
        {
            NewTask("Задание 2. Подсчет количества цифр числа.");

            //т.к. по заданию вводится именно число, а не строка,
            //то запросим именно int
            int a = ReadInt("Введите число:");

            int count = DigitCount(a);

            Message();
            Message($"Число цифр = {count}");

            Pause();
        }

        #endregion

        #region Задание №3

        /// <summary>
        /// Метод проверяющий четное число или нет
        /// </summary>
        /// <param name="value"></param> проверяемое число
        /// <returns></returns>
        static bool isEven(int value)
        {
            return (value % 2 == 0);
        }

        /// <summary>
        /// Метод проверяющий является ли число положительным
        /// </summary>
        /// <param name="value"></param> проверяемое число
        /// <returns></returns>
        static bool isPositive(int value)
        {
            return value > 0;
        }

        /// <summary>
        /// 3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
        /// </summary>
        static void Task03()
        {
            NewTask("Задание 3. Подсчет суммы всех нечетных положительных чисел.");

            int value; // текущее введенное число
            int sum = 0; // подсчет суммы всех нечетных положительных

            do
            {
                value = ReadInt("Введите число (0 - выход):");

                if (!isEven(value) && isPositive(value))
                {
                    sum = sum + value;
                }

            } while (value != 0);

            Message($"Сумма всех нечетных положительных числе равна {sum}");

            Pause();
        }

        #endregion

        #region Задание №4

        /// <summary>
        /// Метод проверяющий корректность ввода логина и пароля
        /// логин не чуствителен к регистру, пароль чуствителен
        /// </summary>
        /// <param name="username"></param> логин
        /// <param name="password"></param> пароль
        /// <returns></returns>
        static bool CheckAuthorization(string username, string password)
        {
            bool login_corrent = (string.Compare(username, "root", true) == 0);
            bool password_correct = (password == "GeekBrains");
            return login_corrent && password_correct;
        }

        /// <summary>
        /// 4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
        /// На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
        /// Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
        /// С помощью цикла do while ограничить ввод пароля тремя попытками.
        /// </summary>
        static void Task04()
        {
            NewTask("Задание 4. Проверка логина и пароля");

            bool authorized; //признак - авторизован ли пользователь
            int try_left = 3; //счетчик оставшихся попыток ввода пароля

            do
            {
                string username = ReadString("Введите логин:");
                string password = ReadString("Введите пароль:");

                try_left--;

                authorized = CheckAuthorization(username, password);
                if (authorized)
                {
                    Message("Авторизация пройдена...");
                }
                else if (try_left > 0)
                {
                    Message("Некорректные логин или пароль...");
                    Message($"Осталось попыток - {try_left}");
                }
                else
                {
                    Message("Доступ запрещен");
                }

            } while (!authorized && try_left > 0);

            Pause();
        }

        #endregion

        #region Задание №5

        /// <summary>
        /// Метод определяет в каком интервале находится переданный параметр индекса массы тела
        /// Возвращает номер интервала
        /// </summary>
        /// <param name="imt"></param> индекс массы тела
        /// <returns></returns>
        static int FatInterval(double imt, double i1, double i2, double i3, double i4, double i5, double i6)
        {

            int result;

            //Проверка интервалов идет в последовательности от нормы вниз и потом наверх
            //для корректной обработки границ интервалов,
            //т.к. граница интервала будет принадлежать двум интервалам одновременно
            //Считаем ее находящейся в интервале ближе к норме

            if (isInInterval(imt, i2, i3))
            {
                result = 3; // норма
            }
            else if (isInInterval(imt, i1, i2))
            {
                result = 2;
            }
            else if (imt <= i1)
            {
                result = 1;
            }
            else if (isInInterval(imt, i3, i4))
            {
                result = 4;
            }
            else if (isInInterval(imt, i4, i5))
            {
                result = 5;
            }
            else if (isInInterval(imt, i5, i6))
            {
                result = 6;
            }
            else
            {
                result = 7;
            }

            return result;
        }
        
        /// <summary>
        /// Метод возвращает строковое описание переданного номера интервала ИМТ
        /// </summary>
        /// <param name="interval_number"></param> номер интервала
        /// <returns></returns>
        static string FatIntervalDescription(int interval_number)
        {
            string result;

            switch (interval_number)
            {
                case 1: result = "Выраженный дефицит массы тела"; break;
                case 2: result = "Недостаточная (дефицит) масса тела"; break;
                case 3: result = "Норма"; break;
                case 4: result = "Избыточная масса тела (предожирение)"; break;
                case 5: result = "Ожирение 1 степени"; break;
                case 6: result = "Ожирение 2 степени"; break;
                case 7: result = "Ожирение 3 степени"; break;
                default: result = "<ЧТО-ТО НОВОЕ>"; break; //по алгоритму в данный метод должен поступать номер от 1 до 7. Данная строка никогда не должна выполниться
            }

            return result;
        }

        /// <summary>
        /// Метод возвращает вес, который соответствует указанному росту и ИМТ
        /// </summary>
        /// <param name="imt"></param> Индекс массы тела
        /// <param name="height"></param> Рост в метрах
        /// <returns></returns>
        static int GetWeightFromIMT(double imt, double height)
        {
            return Convert.ToInt32(imt * height * height);
        }

        /// <summary>
        /// 5.
        /// а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
        /// б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
        /// </summary>
        static void Task05()
        {
            NewTask("Задание 5. Индекс массы тела");

            //Сделаем 6 границ интервалов ИМТ согласно википедии )))
            //ИМТ между i2 и i3 считаем нормой
            double i1 = 16;
            double i2 = 18.5;
            double i3 = 25;
            double i4 = 30;
            double i5 = 35;
            double i6 = 40;

            double height = ReadDouble("Введите свой рост в метрах:");
            int weight = ReadInt("Введите свой вес в кг:");

            double imt = weight / Math.Pow(height, 2);
            Message($"Ваш индекс массы тела равен {imt:F2}"); //форматируем вывод 2 знака после запятой
            
            int interval = FatInterval(imt, i1, i2, i3, i4, i5, i6);
            Message($"Ваше состояние здоровья оценивается как {FatIntervalDescription(interval)}");

            int min_weigth = GetWeightFromIMT(i2, height);
            int max_weigth = GetWeightFromIMT(i3, height);

            if (weight < min_weigth)
            {
                Message($"для нормализации веса Вам необходимо поправится хотя бы на {min_weigth - weight} кг");
            }else if (weight > max_weigth)
            {
                Message($"для нормализации веса Вам необходимо сбросить вес хотя бы на {weight - max_weigth} кг");
            }
            else
            {
                Message($"Так держать!!!");
            }

            Pause();
        }

        #endregion

        #region Задание №6

        /// <summary>
        /// Метод возвращает суммы цифр переданного числа
        /// </summary>
        /// <param name="value"></param> число для подсчета цифр
        /// <returns></returns>
        static int GetSumDigit(int value)
        {
            string str = value.ToString();
            int result = 0; // сумма цифр
            foreach (char ch in str)
            {
                result = result + Convert.ToInt32(ch);
            }
            return result;
        }

        /// <summary>
        /// Метод определяющий, "Хорошее" ли число или нет
        /// "Хорошим" считается число которое делится на сумму своих цифр
        /// </summary>
        /// <param name="value"></param> число для проверки
        /// <returns></returns>
        static bool isGoodNumber(int value)
        {
            return (value % GetSumDigit(value) == 0);
        }

        /// <summary>
        /// 6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
        /// «Хорошим» называется число, которое делится на сумму своих цифр. 
        /// Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
        /// </summary>
        static void Task06()
        {
            NewTask("Задание 6. \"Хорошие\" числа");

            Pause("Нажмите Enter для начала подсчета");
            DateTime dt_start = DateTime.Now;
            Message($"Время начала подсчета: {dt_start}");

            int count = 0; //счетчик для подсчета хороших чисел

            for (int i = 1; i<=1000000000; i++)
            {
                if (isGoodNumber(i))
                {
                    count++;
                }
            }

            DateTime dt_end = DateTime.Now;
            Message($"Время окончания подсчета: {dt_end}");

            Message($"Прошло времени: {dt_end - dt_start}");

            Message($"Найдено \"Хороших\" чисел: {count}");

            Pause();
        }

        #endregion

        #region Задание №7

        /// <summary>
        /// Метод выводит на экран все числа от a до b. Методом рекурсии
        /// </summary>
        /// <param name="a"></param> начально число
        /// <param name="b"></param> конечное число
        static void PrintRecursion(int a, int b)
        {
            if (a >= b)
            {
                //достигли конечного числа, проверка на "больше" нужна чтобы избежать зацикливания при a>b
                Console.Write(a);
            }
            else
            {
                Console.Write($"{a} - "); // знак "-" для разделения числа от следующего
                PrintRecursion(a + 1, b);
            }
        }

        /// <summary>
        /// Метод возвращает сумму всех целых числе в интервале от a до b (включительно). Методом рекурсии
        /// </summary>
        /// <param name="a"></param> начально число
        /// <param name="b"></param> конечное число
        /// <returns></returns>
        static int SummRecursion(int a, int b)
        {
            if (a >= b)
            {
                return a;
            }
            else
            {
                return a + SummRecursion(a + 1, b);
            }
        }

        /// <summary>
        /// 7.
        /// a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
        /// б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
        /// </summary>
        static void Task07()
        {
            NewTask("Задание 7. Рекурсия");

            int a;
            int b;

            //Введем числа с проверкой, чтобы избежать возможного зацикливания в рекурсии

            do
            {
                a = ReadInt("Введите начальное число:");
                b = ReadInt("Введите конечное число:");

                if (a > b)
                {
                    Message("Начальное число не должно быть больше конечного");
                }
            } while (a > b);

            PrintRecursion(a, b);

            Message();

            Message($"Сумма всех чисел в указанном интервале равна {SummRecursion(a, b)}");

            Pause();
        }

        #endregion

        #endregion

        #region MAIN

        /// <summary>
        /// Точка входа. 
        /// Выбор задания. Вызов реализации задания.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int answer;
            do
            {
                //Проверка корректности внутри метода MainMenu
                answer = MainMenu();

                switch (answer)
                {
                    case 1: Task01(); break;
                    case 2: Task02(); break;
                    case 3: Task03(); break;
                    case 4: Task04(); break;
                    case 5: Task05(); break;
                    case 6: Task06(); break;
                    case 7: Task07(); break;
                }

            } while (answer != 0);
        }

        #endregion
    }
}
