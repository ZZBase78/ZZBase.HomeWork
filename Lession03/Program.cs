using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Домашнее задание №3
/// Автор: Полторацкий Сергей
/// </summary>
namespace Lession03
{

    #region Классы для оформления (Menu и PressAnyKey)

    /// <summary>
    /// Класс для организации главного меню. с небольшой динамикой
    /// </summary>
    class Menu
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

            string full_empty_string = new String(' ', Console.WindowWidth);
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
            int cur_x = Console.CursorLeft;
            int cur_y = Console.CursorTop;

            ConsoleColor current_color = Console.ForegroundColor;

            Random rnd = new Random();

            Console.CursorVisible = false;
            do
            {
                Console.SetCursorPosition(cur_x, cur_y);
                int cur_color = rnd.Next(0, 16);
                Console.ForegroundColor = (ConsoleColor)Enum.GetValues(typeof(ConsoleColor)).GetValue(cur_color);
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write("Press any key...");
                System.Threading.Thread.Sleep(100);

            } while (!Console.KeyAvailable);

            Console.ForegroundColor = current_color;

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("                ");

            Console.CursorVisible = true;
        }
    }

    #endregion

    #region Классы для случайного заполнения консоли символами

    /// <summary>
    /// Класс обычной точки (X, Y) с конструктором
    /// </summary>
    class ScreenPoint
    {
        public int x;
        public int y;

        /// <summary>
        /// Конструктор точки
        /// </summary>
        /// <param name="new_x"></param> координата X
        /// <param name="new_y"></param> координата Y
        public ScreenPoint(int new_x, int new_y)
        {
            x = new_x;
            y = new_y;
        }
    }

    /// <summary>
    /// Класс для заполнения экрана консоли символами в случайном порядке
    /// </summary>
    class FillScreen
    {
        static List<ScreenPoint> _screenPoints; // коллекция точек экрана
        static Random _rnd; // генератор случайных числе
        static int _width; // ширина консоли
        static int _height; // высота консоли
        static int _pause; // пауза между выводами символов

        /// <summary>
        /// Инициализатор класса
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pause"></param>
        static public void Init(int width, int height, int pause)
        {
            _screenPoints = new List<ScreenPoint>();
            _rnd = new Random();
            _width = width;
            _height = height;
            _pause = pause;
        }

        /// <summary>
        /// заполняет коллекцию всеми точками экрана
        /// </summary>
        static void GenerateList()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _screenPoints.Add(new ScreenPoint(x, y));
                }
            }
        }

        /// <summary>
        /// Выбирает случайный индекс коллекции
        /// </summary>
        /// <returns></returns>
        static int GetRandomIndex()
        {
            return _rnd.Next(0, _screenPoints.Count());
        }

        /// <summary>
        /// метод убирающий точку экрана из коллекции по индексу
        /// </summary>
        /// <param name="index"></param> индекс коллекции
        static void DeleteIndexInList(int index)
        {
            _screenPoints.RemoveAt(index);
        }

        /// <summary>
        /// Метод заполняющий экран консоли переданным символом
        /// </summary>
        /// <param name="ch"></param> символ для заполнения
        /// <param name="pause"></param> пауза (путой цикл)
        static public void Show(char ch, int pause)
        {
            Init(Console.WindowWidth, Console.WindowHeight, pause); //инициазизируем поля класса
            Console.CursorVisible = false;
            GenerateList(); //Генерируем коллекцию точек экрана консоли
            while (_screenPoints.Count() > 0)
            {
                int index = GetRandomIndex(); // выбираем случайную точку экрана
                ScreenPoint p = _screenPoints[index];
                if (p.x != _width - 1 || p.y != _height - 1) //выводим все кроме нижней правой, т.к. будет смещение экрана
                {
                    if (_pause > 0)
                    {
                        //System.Threading.Thread.Sleep(_pause);
                        for (int i = 0; i <= _pause; i++)
                        {
                            //Пустрой цикл
                        }
                    }

                    Console.SetCursorPosition(p.x, p.y);
                    Console.Write(ch);
                }
                DeleteIndexInList(index); //убираем заполненную точку из коллекции
            }
            Console.CursorVisible = true;
        }

    }

    #endregion

    #region Основной класс PROGRAM + классы для ДЗ

    /// <summary>
    /// Класс для операция с десятичными дробями
    /// </summary>
    class Decimal
    {
        //Приватные поля класса
        int _numerator; //числитель
        int _denominator;  //знаменатель

        //Public-свойства, с проверкой установки "0" в знаменатель. Задание 3**
        public int num
        {
            get
            {
                return _numerator;
            }
            set
            {
                _numerator = value;
            }
        }
        public int denom
        {
            get
            {
                return _denominator;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                }
                else
                {
                    _denominator = value;
                }
            }
        }

        /// <summary>
        /// Свойство возвращающее десятичное число равное текущей дроби
        /// </summary>
        public double value
        {
            get
            {
                return Convert.ToDouble(num) / Convert.ToDouble(denom);
            }
        }

        /// <summary>
        /// Внутренний метод для интерактивного ввода целого числа
        /// </summary>
        /// <param name="question"></param> текст вопроса
        /// <returns></returns>
        int ReadInt(string question)
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
        /// Конструктор дроби
        /// </summary>
        /// <param name="num"></param> числитель
        /// <param name="denom"></param> знаменатель
        public Decimal(int num, int denom)
        {
            this.num = num;
            this.denom = denom;
            Reduction();
        }

        /// <summary>
        /// Конструктор дроби без параметров, запрашивает у пользователя числитель и знаменатель
        /// </summary>
        public Decimal()
        {
            num = ReadInt("Введите числитель дроби:");
            denom = ReadInt("Введите знаменатель дроби:");
            Reduction();
        }

        /// <summary>
        /// метод возвращающий строковое продставление дроби
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({num} / {denom})";
        }

        /// <summary>
        /// Метод возвращает наибольший общий делитель
        /// методом Евклида
        /// </summary>
        /// <param name="a"></param> первое число
        /// <param name="b"></param> второе число
        /// <returns></returns>
        static public int NOD(int a, int b)
        {
            //приводим значения к положительныи, для корректного расчета
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a > b)
            {
                int ost = a % b;
                if (ost == 0)
                {
                    return b;
                }
                else
                {
                    return NOD(b, ost);
                }
            }
            else if (a < b)
            {
                return NOD(b, a);
            }
            else // a==b
            {
                return a;
            }
        }

        /// <summary>
        /// Метод сокращения текущей дроби. Задание 3***
        /// Деление на наибольший общий делитель
        /// </summary>
        void Reduction()
        {
            int nod = NOD(num, denom);
            num /= nod;
            denom /= nod;
        }

        /// <summary>
        /// Операция сложения дробей
        /// </summary>
        /// <param name="d1"></param> первая дробь
        /// <param name="d2"></param> вторая дробь
        /// <returns></returns>
        static public Decimal Sum(Decimal d1, Decimal d2)
        {
            int new_num = d1.num * d2.denom + d1.denom * d2.num;
            int new_denom = d1.denom * d2.denom;
            return new Decimal(new_num, new_denom);
        }

        /// <summary>
        /// Операция вычитания дробей
        /// </summary>
        /// <param name="d1"></param> первая дробь
        /// <param name="d2"></param> вторая дробь
        /// <returns></returns>
        static public Decimal Sub(Decimal d1, Decimal d2)
        {
            int new_num = d1.num * d2.denom - d1.denom * d2.num;
            int new_denom = d1.denom * d2.denom;
            return new Decimal(new_num, new_denom);
        }

        /// <summary>
        /// Операция умножения дробей
        /// </summary>
        /// <param name="d1"></param> первая дробь
        /// <param name="d2"></param> вторая дробь
        /// <returns></returns>
        static public Decimal Multiply(Decimal d1, Decimal d2)
        {
            int new_num = d1.num * d2.num;
            int new_denom = d1.denom * d2.denom;
            return new Decimal(new_num, new_denom);
        }

        /// <summary>
        /// Операция деления дробей
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        static public Decimal Div(Decimal d1, Decimal d2)
        {
            int new_num = d1.num * d2.denom;
            int new_denom = d1.denom * d2.num;
            return new Decimal(new_num, new_denom);
        }
    }

    /// <summary>
    /// Класс для комплексных чисел
    /// </summary>
    class C_Complex
    {
        //Сделаем приватными поля, чтобы попробовать эксперементировать со свойствами
        private double _re;
        private double _im;

        //Попробуем использовать свойства, пока пустые геттер и сеттер, т.к. проверять особо нечего
        public double re
        {
            get
            {
                return _re;
            }
            set
            {
                _re = value;
            }
        }
        public double im
        {
            get
            {
                return _im;
            }
            set
            {
                _im = value;
            }
        }


        /// <summary>
        /// Конструктор комплексного числа с переданными параметрами
        /// </summary>
        /// <param name="re"></param> действительная часть
        /// <param name="im"></param> мнимая часть
        public C_Complex(double re, double im)
        {
            _re = re;
            _im = im;
        }

        /// <summary>
        /// Конструктор - комплексное число = "0"
        /// </summary>
        public C_Complex()
        {
            _re = 0;
            _im = 0;
        }

        /// <summary>
        /// Метод добавляющий к текущему комплексному числу переданный параметр
        /// </summary>
        /// <param name="complex"></param> комплексное число
        public void Add(C_Complex complex)
        {
            re = re + complex.re;
            im = im + complex.im;
        }

        /// <summary>
        /// Метод суммирующий два комплексных числа
        /// </summary>
        /// <param name="c1"></param> первое комплексное число
        /// <param name="c2"></param> второе комплексное число
        /// <returns></returns>
        public static C_Complex Add(C_Complex c1, C_Complex c2)
        {
            double new_re = c1.re + c2.re;
            double new_im = c1.im + c2.im;
            return new C_Complex(new_re, new_im);
        }

        /// <summary>
        /// метод вычитающий из текущего комплексного числа переданный параметр
        /// </summary>
        /// <param name="complex"></param> вычитаемое - комплексное число
        public void Sub(C_Complex complex)
        {
            re = re - complex.re;
            im = im - complex.im;
        }

        /// <summary>
        /// Метод вычитания комплексных чисел
        /// </summary>
        /// <param name="c1"></param> уменьшаемое - комплексное число
        /// <param name="c2"></param> вычитаемое - комплексное число
        /// <returns></returns>
        public static C_Complex Sub(C_Complex c1, C_Complex c2)
        {
            double new_re = c1.re - c2.re;
            double new_im = c1.im - c2.im;
            return new C_Complex(new_re, new_im);
        }

        /// <summary>
        /// Метод умножения текущего комплексного числа на переданный параметр
        /// </summary>
        /// <param name="complex"></param> множитель - комплексное число
        public void Multiply(C_Complex complex)
        {
            double _re = re * complex.re - im * complex.im;
            double _im = re * complex.im + complex.re * im;
            re = _re;
            im = _im;
        }

        /// <summary>
        /// Метод умножения комплексных чисел
        /// </summary>
        /// <param name="c1"></param> первое комплексное число
        /// <param name="c2"></param> второе комплексное число
        /// <returns></returns>
        public static C_Complex Multiply(C_Complex c1, C_Complex c2)
        {
            double new_re = c1.re * c2.re - c1.im * c2.im;
            double new_im = c1.re * c2.im + c2.re * c1.im;
            return new C_Complex(new_re, new_im);
        }

        /// <summary>
        /// Метод возвращает делитель для вычисления операций деления комплексных чисел
        /// </summary>
        /// <param name="c"></param> комплексное число
        /// <returns></returns>
        public static double GetDevider(C_Complex c)
        {
            return (c.re * c.re + c.im * c.im);
        }

        /// <summary>
        /// Проверят можно ли делить на переданное комплексное число
        /// </summary>
        /// <param name="c"></param> проверяемое комплексное число
        /// <returns></returns>
        public static bool CanDiv(C_Complex c)
        {
            return GetDevider(c) != 0;
        }

        /// <summary>
        /// Метод деления текущего комплексного числа на делитель
        /// исключение - если деление невозможно
        /// </summary>
        /// <param name="complex"></param> делитель - комплексное число
        public void Div(C_Complex complex)
        {
            if (!CanDiv(complex))
            {
                throw new Exception($"Невозможно выполнить деление коплексных чисел {this} и {complex}");
            }

            double devider = GetDevider(complex);

            double _re = (re * complex.re + im * complex.im) / devider;
            double _im = (complex.re * im - re * complex.im) / devider;
            re = _re;
            im = _im;
        }

        /// <summary>
        /// Метод деления комплексных чисел
        /// вызов исключения при невозможности деления
        /// </summary>
        /// <param name="c1"></param> делимое - комплексное число
        /// <param name="c2"></param> делитель - комплексное число
        /// <returns></returns>
        public static C_Complex Div(C_Complex c1, C_Complex c2)
        {
            if (!CanDiv(c2))
            {
                throw new Exception($"Невозможно выполнить деление коплексных чисел {c1} и {c2}");
            }

            double devider = GetDevider(c2);

            double new_re = (c1.re * c2.re + c1.im * c2.im) / devider;
            double new_im = (c2.re * c1.im - c1.re * c2.im) / devider;
            return new C_Complex(new_re, new_im);
        }

        /// <summary>
        /// Выводит строковой представление комплексного числа
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "";
            if ((re == 0) && (im == 0))
            {
                result = "0";
            }
            else if (im >= 0)
            {
                result = $"({re} + {im}i)";
            }
            else
            {
                result = $"({re} - {-im}i)";
            }
            return result;
        }

        /// <summary>
        /// метод запрашиваем данные текущего комплексного числа у пользователя
        /// </summary>
        /// <param name="title"></param> выводимый текст перед вводом частей числа
        public void AskComplex(string title)
        {
            Program.Message(title);
            re = Program.ReadDouble("Введите действительную часть:");
            im = Program.ReadDouble("Введите мнимую часть:");
        }

        /// <summary>
        /// Метод создания копии текущего комплексного числа
        /// </summary>
        /// <returns></returns>
        public C_Complex Clone()
        {
            return new C_Complex(_re, _im);

        }

    }

    /// <summary>
    /// Основной класс PROGRAM
    /// </summary>
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
        static public string ReadString(string question)
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

        #endregion

        #region Реализация задания 1а и c(switch - выбор операции). Работа со СТРУКТУРОЙ

        /// <summary>
        /// Структура описывающая комплексное число
        /// </summary>
        struct S_Complex
        {
            public double re; // действительная часть
            public double im; // мнимая часть

            /// <summary>
            /// Конструктор структуры комплексного числа
            /// </summary>
            /// <param name="re"></param> действительная часть
            /// <param name="im"></param> мнимая часть
            public S_Complex(double re, double im)
            {
                this.re = re;
                this.im = im;
            }

            /// <summary>
            /// Метод добавляющий к текущему комплексному число, другое комплексное число
            /// </summary>
            /// <param name="complex"></param> комплексное число
            public void Add(S_Complex complex)
            {
                re = re + complex.re;
                im = im + complex.im;
            }

            /// <summary>
            /// Метод вычитающий из текущего комплексного числа, другое комплексное число
            /// </summary>
            /// <param name="complex"></param> комплексное число
            public void Sub(S_Complex complex)
            {
                re = re - complex.re;
                im = im - complex.im;
            }

            /// <summary>
            /// Метод умножения текущего комплексного числа на переданный параметр
            /// </summary>
            /// <param name="complex"></param> параметр - комплексное число
            public void Multiply(S_Complex complex)
            {
                double _re = re * complex.re - im * complex.im;
                double _im = re * complex.im + complex.re * im;
                re = _re;
                im = _im;
            }

            /// <summary>
            /// Метод проверяющий возможность деления на переданное комплексное число
            /// </summary>
            /// <param name="complex"></param> комплексное число
            /// <returns></returns>
            public bool CanDiv(S_Complex complex)
            {
                return (complex.re * complex.re + complex.im * complex.im) != 0;
            }

            /// <summary>
            /// Метод желения текущего комплексного числа на переданный параметр
            /// С проверкой возможности деления и вызовом исключения
            /// </summary>
            /// <param name="complex"></param> делитель - комплексное число
            public void Div(S_Complex complex)
            {
                if (!CanDiv(complex))
                {
                    throw new Exception($"Невозможно выполнить деление коплексных чисел {this} и {complex}");
                }

                double _re = (re * complex.re + im * complex.im) / (complex.re * complex.re + complex.im * complex.im);
                double _im = (complex.re * im - re * complex.im) / (complex.re * complex.re + complex.im * complex.im);
                re = _re;
                im = _im;
            }

            /// <summary>
            /// Выводит строковое представление комплексного числа
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                string result = "";
                if ((re == 0) && (im == 0))
                {
                    result = "0";
                }
                else if (im >= 0)
                {
                    result = $"{re} + {im}i";
                }
                else
                {
                    //для отрицательной мнимой части число выводится с заменой знака
                    result = $"{re} - {-im}i";
                }
                return result;
            }

            /// <summary>
            /// Метод запрашивает действительную и мнимую части комплексного числа
            /// </summary>
            /// <param name="title"></param> текст вопроса
            public void AskComplex(string title)
            {
                Message(title);
                re = ReadDouble("Введите действительную часть:");
                im = ReadDouble("Введите мнимую часть:");
            }

        }

        /// <summary>
        /// Метод запрашивает два комплексных числа.
        /// Комплексные числа - тип СТРУКТУРА
        /// </summary>
        /// <param name="c1"></param> выход первое комплексное число
        /// <param name="c2"></param> выход второе комплексное число
        static void Read2Complex(out S_Complex c1, out S_Complex c2)
        {
            c1 = new S_Complex();
            c1.AskComplex("Введите данные первого комплексного числа");
            Message();
            c2 = new S_Complex();
            c2.AskComplex("Введите данные второго комплексного числа");
        }

        /// <summary>
        /// Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
        /// </summary>
        static void Task01_a()
        {
            NewTask("Задание 1(а). Комплексные числа. Демонстрация работы СТРУКТУРЫ");

            S_Complex c1;
            S_Complex c2;
            S_Complex c_result;

            Read2Complex(out c1, out c2);
            c_result = c1; //копируем значение в result, чтобы оставить c1 неизменной

            string operation;
            do
            {
                do
                {
                    Message("Выберите желаемую операцию (0 - Ввести числа заново, <пусто> - ВЫХОД)");
                    operation = ReadString("Операция (+ - * /):");

                    if (operation == "0")
                    {
                        Read2Complex(out c1, out c2);
                        c_result = c1; //копируем значение в result, чтобы оставить c1 неизменной
                    }

                } while (operation == "0");

                bool correct = false; //содержит флаг корректности ввода операции

                switch (operation)
                {
                    case "+": c_result.Add(c2); correct = true; break;
                    case "-": c_result.Sub(c2); correct = true; break;
                    case "*": c_result.Multiply(c2); correct = true; break;
                    case "/":
                        {
                            if (c_result.CanDiv(c2))
                            {
                                c_result.Div(c2); correct = true; break;
                            }
                            else
                            {
                                Message($"Невозможно выполнить операцию: ({c1}) {operation} ({c2})");
                                correct = false;
                            }
                            break;
                        }
                    default: correct = false; break;
                }

                if (operation != "") //операция была выбрана
                {
                    if (correct) //операция корректная
                    {
                        Message($"Результат операции: ({c1}) {operation} ({c2}) = ({c_result})");
                        // возвращаем первое (оно же результат) к первоначальному значению, в случае выбора повторной операции с этими числами
                        c_result = c1;
                    }
                    else //операция некорректная
                    {
                        Message("Некорректный выбор операции");
                    }
                }

            } while (operation != "");

            FillScreen.Show(' ', 10000);

        }

        #endregion

        #region Реализация задания 1b и c(switch - выбор операции). Работа с КЛАССОМ

        /// <summary>
        /// Метод вводит два комплексных числа последовательно
        /// Комплексные числа - тип КЛАСС
        /// </summary>
        /// <param name="c1"></param> выход первое комплексное число
        /// <param name="c2"></param> выход второе комплексное число
        static void Read2Complex(out C_Complex c1, out C_Complex c2)
        {
            c1 = new C_Complex();
            c1.AskComplex("Введите данные первого комплексного числа");
            Message();
            c2 = new C_Complex();
            c2.AskComplex("Введите данные второго комплексного числа");
        }

        /// <summary>
        /// Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
        /// </summary>
        static void Task01_b()
        {
            NewTask("Задание 1(b). Комплексные числа. Демонстрация работы КЛАССА");

            Read2Complex(out C_Complex c1, out C_Complex c2);

            C_Complex c_result = new C_Complex();

            string operation;
            do
            {
                do
                {
                    Message("Выберите желаемую операцию (0 - Ввести числа заново, <пусто> - ВЫХОД)");
                    operation = ReadString("Операция (+ - * /):");

                    if (operation == "0")
                    {
                        Read2Complex(out c1, out c2);
                    }

                } while (operation == "0");

                bool correct = false; //содержит флаг корректности ввода операции

                switch (operation)
                {
                    case "+": c_result = C_Complex.Add(c1, c2); correct = true; break;
                    case "-": c_result = C_Complex.Sub(c1, c2); correct = true; break;
                    case "*": c_result = C_Complex.Multiply(c1, c2); correct = true; break;
                    case "/":
                        {
                            if (C_Complex.CanDiv(c2))
                            {
                                c_result = C_Complex.Div(c1, c2); correct = true; break;
                            }
                            else
                            {
                                Message($"Невозможно выполнить операцию: {c1} {operation} {c2}");
                                correct = false;
                            }
                            break;
                        }
                    default: correct = false; break;
                }

                if (operation != "") //операция была выбрана
                {
                    if (correct) //операция корректная
                    {
                        Message($"Результат операции: {c1} {operation} {c2} = {c_result}");
                    }
                    else //операция некорректная
                    {
                        Message("Некорректный выбор операции");
                    }
                }

            } while (operation != "");

            FillScreen.Show(' ', 10000);

        }

        #endregion

        #region Реализация задания 2. Последовательность чисел

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
        /// Метод добавляет к строке представление числа через " - "
        /// Первое число добавляется без дефиса
        /// Число "0" к строке не прибавляется
        /// Отрицательные числа заключаются в скобки
        /// </summary>
        /// <param name="s"></param> строка к которой будет добавлено представление числа
        /// <param name="number"></param> добавляемое число
        /// <param name="marker"></param> если true то добавленное число помечается символом "*"
        static void AppendString(ref string s, int number, bool marker)
        {
            if (number != 0)
            {
                if (s == "")
                {
                    s = number > 0 ? number.ToString() : "(" + number.ToString() + ")";
                }
                else
                {
                    s += " - " + (number > 0 ? number.ToString() : "(" + number.ToString() + ")");
                }

                if (marker)
                {
                    s += "*";
                }

            }
        }

        /// <summary>
        /// С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке).
        /// Требуется подсчитать сумму всех нечётных положительных чисел.
        /// Сами числа и сумму вывести на экран, используя tryParse.
        /// </summary>
        static void Task02()
        {
            NewTask("Задание 2. Последовательность чисел");

            int number; // текущее воодимое число
            int sum = 0; // сумма нечетных положительных чисел
            string numbers = ""; // строка для последующего вывода на экран
            do
            {
                //Метод TryParse реализован в методе ReadInt
                number = ReadInt("Введите целое число (0 - ВЫХОД):");
                if (!isEven(number) && isPositive(number))
                {
                    sum += number;
                    AppendString(ref numbers, number, true);
                }
                else
                {
                    AppendString(ref numbers, number, false);
                }

            } while (number != 0);

            Message($"Введенные числа (* - числа добавленные в сумму): {numbers}");
            Message($"Сумма нечетных положительных чисел равна {sum}");

            PressAnyKey.Run();
        }

        #endregion

        #region Реализация задания 3. Десятичные дроби

        /// <summary>
        /// *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
        /// Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
        /// Написать программу, демонстрирующую все разработанные элементы класса.
        /// Добавить свойства типа int для доступа к числителю и знаменателю;
        /// Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа; 
        /// ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
        /// *** Добавить упрощение дробей.
        /// </summary>
        static void Task03()
        {
            NewTask("Задание 3. Десятичные дроби");

            //Ввод начальных дробей, сокращение дробей осуществляется сразу при вводе или при операции
            Message("Введите данные первой дроби");
            Decimal d1 = new Decimal();
            Message("Введите данные второй дроби");
            Decimal d2 = new Decimal();

            // начальное значение для дроби с ответом, инициализируется равной "1", чтобы пользователь не вводил данные
            Decimal result = new Decimal(1, 1);

            string operation;
            do
            {
                do
                {
                    Message("Выберите желаемую операцию (0 - Ввести дроби заново, <пусто> - ВЫХОД)");
                    operation = ReadString("Операция (+ - * /):");

                    if (operation == "0")
                    {
                        Message("Введите данные первой дроби");
                        d1 = new Decimal();
                        Message("Введите данные второй дроби");
                        d2 = new Decimal();
                    }

                } while (operation == "0");

                bool correct = false; //содержит флаг корректности ввода операции

                switch (operation)
                {
                    case "+": result = Decimal.Sum(d1, d2); correct = true; break;
                    case "-": result = Decimal.Sub(d1, d2); correct = true; break;
                    case "*": result = Decimal.Multiply(d1, d2); correct = true; break;
                    case "/": result = Decimal.Div(d1, d2); correct = true; break;
                    default: correct = false; break;
                }

                if (operation != "") //операция была выбрана
                {
                    if (correct) //операция корректная
                    {
                        Message($"Результат операции: {d1} {operation} {d2} = {result} (десятичное значение = {result.value})");
                    }
                    else //операция некорректная
                    {
                        Message("Некорректный выбор операции");
                    }
                }

            } while (operation != "");

            FillScreen.Show(' ', 10000);

        }

        #endregion

        #region MAIN

        /// <summary>
        /// Точка входа в программу. Основное меню.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int menu_number;
            do
            {
                menu_number = Menu.ChooseMenu(new string[] {
                    "Задание 1(а). Комплексные числа. Демонстрация работы СТРУКТУРЫ",
                    "Задание 1(б). Комплексные числа. Демонстрация работы КЛАССА",
                    "Задание 2. Последовательность чисел",
                    "Задание 3. Десятичные дроби"
                });

                switch (menu_number)
                {
                    case 1: Task01_a(); break;
                    case 2: Task01_b(); break;
                    case 3: Task02(); break;
                    case 4: Task03(); break;
                }

            } while (menu_number != 0);

        }

        #endregion

    }

    #endregion

}
