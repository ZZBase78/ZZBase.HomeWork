using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary; // подключение собственной библиотеки в рамка задания №3(б) и №5

/// <summary>
/// Домашнее задание №4
/// Автор: Полторацкий Сергей
/// </summary>
namespace Lession04
{

    /// <summary>
    /// Статический класс для решения задания №2
    /// </summary>
    static class StaticClass
    {
        /// <summary>
        /// Заполняет массив случайными числами в заданном диапазоне включительно
        /// </summary>
        /// <param name="arr">массив для заполнения</param>
        /// <param name="minValue">минимаьное значение элемента массива</param>
        /// <param name="maxValue">максимальное значение элемента массива</param>
        static public void FillRandom(int[] arr, int minValue, int maxValue)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(minValue, maxValue + 1);
            }
        }

        /// <summary>
        /// Считает количество пар, в которых только одно из числе делится на 3
        /// </summary>
        /// <param name="arr">массив для подсчета пар</param>
        /// <returns></returns>
        static public int CalculatePairs(int[] arr)
        {
            int counter = 0;

            //обход элементов массив до предпоследнего, чтобы не выйти за граници массива при i+1
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool i1mod3 = (arr[i] % 3) == 0;
                bool i2mod3 = (arr[i + 1] % 3) == 0;
                if (i1mod3 ^ i2mod3) counter++;
            }

            return counter;
        }

        /// <summary>
        /// Выводит на экран содержимое массива
        /// </summary>
        /// <param name="arr"></param>
        static public void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} \t");

                if ((i + 1) % 10 == 0) Console.WriteLine(); // каждые 10 элементов, перевод строки
            }
            if (arr.Length % 10 != 0) Console.WriteLine(); // переведем строку, если последняя строка содержит не 10 элементов
        }

        /// <summary>
        /// Читает содержимое массива из файла
        /// </summary>
        /// <param name="filename">полное имя файла с содержимым массива</param>
        /// <returns>массив int[]</returns>
        static public int[] Load(string filename)
        {
            if (!File.Exists(filename))
            {
                My.ErrorSignal($"Файл {filename} не существует");
                return new int[] { }; // возвращаем пустой массив
            }

            int[] result = new int[] { }; //массив для чтения данных
            int index = 0; //указывает на следующий элемент массива для чтения

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    // читаем размер массива
                    int array_count = 0; // переменная для хранения длины массива
                    while (!reader.EndOfStream)
                    {
                        string filestring = reader.ReadLine();
                        if ((filestring.Length == 0) || (filestring[0] == ';')) continue; // пустые строки и комментарии пропускаем

                        if (int.TryParse(filestring, out array_count))
                        {
                            //прочитали переменную содержащую количество элементов массива, выходим из цикла
                            break;
                        }
                        else
                        {
                            My.ErrorSignal($"Не верный формат файла {filename}");
                            return new int[] { }; // возвращаем пустой массив
                        }
                    }

                    if (array_count == 0)
                    {
                        My.ErrorSignal("Нулевой размер массива");
                        return new int[] { };
                    }

                    result = new int[array_count];

                    int current_int = 0; //переменная содерщащая текущее прочитанное из файла число
                    
                    //Читаем содержимое массива
                    while (!reader.EndOfStream)
                    {
                        if (index > result.Length - 1)
                        {
                            //индекс вышел за границы массива, при этом данные из файла продолжают поступать
                            //прекращаем чтение, т.к. массив уже загружен
                            break;
                        }

                        string filestring = reader.ReadLine();
                        if (filestring[0] == ';') continue; // проускаем комменатрии

                        if (int.TryParse(filestring, out current_int))
                        {
                            result[index] = current_int;
                            index++;
                        }
                        else
                        {
                            My.Error($"Ошибка преобразования строки {filestring}, в массив будет записано значение \"0\"");
                            result[index] = 0;
                            index++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                My.Error($"Ошибка чтения файла {filename}");
                My.ErrorSignal($"Исключение:{e}");
            }

            //т.к. индекс должен указывать на следующий элемент массива, то при правильной загрузке он должен быть равен длине массива
            //иначе загрузились не все элементы из файла
            if (index < result.Length)
            {
                My.ErrorSignal($"Количество элементов в файле меньше, чем указанный размер массива");
            }

            return result;

        }
    }

    /// <summary>
    /// Класс для решения задания №3
    /// </summary>
    class MyOneSizeArray
    {
        /// <summary>
        /// поле класса, непосредственно сам массив, с которым работает класс
        /// </summary>
        int[] _arr;

        /// <summary>
        /// свойство возвращает сумму всех элементов массива
        /// </summary>
        public int sum
        {
            get
            {
                return Sum();
            }
        }

        /// <summary>
        /// Возвращает количество максимальных элементов в массиве
        /// </summary>
        public int MaxCount
        {
            get
            {
                return GetCountOfMaxValue();
            }
        }

        /// <summary>
        /// Заполняет массив случайными числами в заданном диапазоне включительно
        /// </summary>
        /// <param name="arr">массив для заполнения</param>
        /// <param name="minValue">минимаьное значение элемента массива</param>
        /// <param name="maxValue">максимальное значение элемента массива</param>
        static public void FillRandom(int[] arr, int minValue, int maxValue)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(minValue, maxValue + 1);
            }
        }

        /// <summary>
        /// Считает количество пар, в которых только одно из числе делится на 3
        /// </summary>
        /// <param name="arr">массив для подсчета пар</param>
        /// <returns></returns>
        static public int CalculatePairs(int[] arr)
        {
            int counter = 0;

            //обход элементов массив до предпоследнего, чтобы не выйти за граници массива при i+1
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool i1mod3 = (arr[i] % 3) == 0;
                bool i2mod3 = (arr[i + 1] % 3) == 0;
                if (i1mod3 ^ i2mod3) counter++;
            }

            return counter;
        }

        /// <summary>
        /// Выводит на экран содержимое текущего массива
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                Console.Write($"{_arr[i]} \t");

                if ((i + 1) % 10 == 0) Console.WriteLine(); // каждые 10 элементов, перевод строки
            }
            if (_arr.Length % 10 != 0) Console.WriteLine(); // переведем строку, если последняя строка содержит не 10 элементов
        }

        /// <summary>
        /// Читает содержимое массива из файла
        /// </summary>
        /// <param name="filename">полное имя файла с содержимым массива</param>
        /// <returns>массив int[]</returns>
        static public int[] Load(string filename)
        {
            if (!File.Exists(filename))
            {
                My.ErrorSignal($"Файл {filename} не существует");
                return new int[] { }; // возвращаем пустой массив
            }

            int[] result = new int[] { }; //массив для чтения данных
            int index = 0; //указывает на следующий элемент массива для чтения

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    // читаем размер массива
                    int array_count = 0; // переменная для хранения длины массива
                    while (!reader.EndOfStream)
                    {
                        string filestring = reader.ReadLine();
                        if (filestring[0] == ';') continue; // проускаем комменатрии

                        if (int.TryParse(filestring, out array_count))
                        {
                            //прочитали переменную содержащую количество элементов массива, выходим из цикла
                            break;
                        }
                        else
                        {
                            My.ErrorSignal($"Не верный формат файла {filename}");
                            return new int[] { }; // возвращаем пустой массив
                        }
                    }

                    if (array_count == 0)
                    {
                        My.ErrorSignal("Нулевой размер массива");
                        return new int[] { };
                    }

                    result = new int[array_count];

                    int current_int = 0; //переменная содерщащая текущее прочитанное из файла число

                    //Читаем содержимое массива
                    while (!reader.EndOfStream)
                    {
                        if (index > result.Length - 1)
                        {
                            //индекс вышел за границы массива, при этом данные из файла продолжают поступать
                            //прекращаем чтение, т.к. массив уже загружен
                            break;
                        }

                        string filestring = reader.ReadLine();
                        if (filestring[0] == ';') continue; // проускаем комменатрии

                        if (int.TryParse(filestring, out current_int))
                        {
                            result[index] = current_int;
                            index++;
                        }
                        else
                        {
                            My.Error($"Ошибка преобразования строки {filestring}, в массив будет записано значение \"0\"");
                            result[index] = 0;
                            index++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                My.Error($"Ошибка чтения файла {filename}");
                My.ErrorSignal($"Исключение:{e}");
            }

            //т.к. индекс должен указывать на следующий элемент массива, то при правильной загрузке он должен быть равен длине массива
            //иначе загрузились не все элементы из файла
            if (index < result.Length)
            {
                My.ErrorSignal($"Количество элементов в файле меньше, чем указанный размер массива");
            }

            return result;

        }

        /// <summary>
        /// Конструктор инициализирует массив заданного размера
        /// и заполняет значениями от начального с заданным шагом
        /// </summary>
        /// <param name="array_size">размер массива</param>
        /// <param name="start_value">начальное значение для заполнения массива</param>
        /// <param name="value_step">шаг значений при шаполнении массива</param>
        public MyOneSizeArray(int array_size, int start_value, int value_step)
        {
            _arr = new int[array_size];
            int current_value = start_value;
            for (int i = 0; i < _arr.Length; i++)
            {
                _arr[i] = current_value;
                current_value += value_step;
            }
        }

        /// <summary>
        /// Контсруктор, создающий экземпляр класса на основании переданного массива
        /// </summary>
        /// <param name="new_array">массив целых чисел</param>
        public MyOneSizeArray(int[] new_array)
        {
            _arr = new_array;
        }

        /// <summary>
        /// Возвращает сумму элементов массива
        /// Метод приватный, т.к. сумму можно получить через публичное свойство sum
        /// </summary>
        /// <returns>сумма элементов массива</returns>
        int Sum()
        {
            int sum = 0;
            for (int i = 0; i < _arr.Length; i++)
            {
                sum += _arr[i];
            }
            return sum;
        }

        /// <summary>
        /// Вовзращает новый массив с измененными знаками каждого из элементов
        /// </summary>
        /// <returns></returns>
        public int[] Inverse()
        {
            int[] new_array = new int[_arr.Length];
            Array.Copy(_arr, new_array, _arr.Length);
            for (int i = 0; i < new_array.Length; i++)
            {
                new_array[i] = -new_array[i];
            }

            return new_array;
        }

        /// <summary>
        /// Метод умножает все элементы массива на переданное число
        /// </summary>
        /// <param name="a">множитель массива</param>
        public void Multi(int a)
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                _arr[i] *= a;
            }
        }

        /// <summary>
        /// Метод возвращает максимальный элемент в массиве
        /// Возвращает ноль при пустом массиве
        /// </summary>
        /// <returns>Максимальное значение в массиве</returns>
        public int GetMaxValue()
        {
            if (_arr.Length == 0) return 0; // Значение при пустом массиве

            int maxvalue = _arr[0]; //начальное значение

            for (int i = 0; i < _arr.Length; i++)
            {
                if (_arr[i] > maxvalue) maxvalue = _arr[i];
            }

            return maxvalue;
        }

        /// <summary>
        /// Метод возвращающий количество максимальных элементов в массиве
        /// Возвращает ноль при пустом массиве
        /// Метод приватный, результат метода можно получить через свойство MaxCount
        /// </summary>
        /// <returns>Количество элементов содержащих максимальное значение</returns>
        int GetCountOfMaxValue()
        {
            if (_arr.Length == 0) return 0; // Значение по умолчанию при пустом массиве

            //Попробуем найти максимальное значение массива и подсчиталь количество сразу в одном цикле
            int maxValue = _arr[0];
            int count = 0;

            for (int i = 0; i < _arr.Length; i++)
            {
                if (_arr[i] > maxValue)
                {
                    maxValue = _arr[i];
                    count = 1;
                }else if (_arr[i] == maxValue)
                {
                    count++;
                }
            }
            return count;
        }
    }
    
    /// <summary>
    /// Структура для решения задачи №4
    /// содержащая логин и пароль
    /// </summary>
    struct Account
    {
        public string login;
        public string password;

        /// <summary>
        /// Конструктор для создания экземпляра
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        public Account(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        /// <summary>
        /// Конструктор пустой структуры
        /// Запрашивает логин и пароль у пользователя если параметр равно true
        /// </summary>
        /// <param name="ask"></param>
        public Account(bool ask)
        {
            if (ask)
            {
                login = My.SlowReadString("Введите имя пользователя:");
                password = My.SlowReadPassword("Введите пароль (ESC - очистка):");
            }
            else
            {
                login = "";
                password = "";
            }
        }

    }

    /// <summary>
    /// Класс для задания №4
    /// Для работы с массивом элементов Account
    /// </summary>
    class AuthentificationControl
    {
        /// <summary>
        /// поле хранит массив логинов и паролей
        /// </summary>
        static Account[] users;

        /// <summary>
        /// Загружает пары логинов и паролей из файла
        /// </summary>
        /// <param name="filename">полное имя файла</param>
        /// <returns>true - файл загружен, false - ошибка</returns>
        public static bool Load(string filename)
        {
            
            if (!File.Exists(filename))
            {
                My.ErrorSignal("Отсутствует файл базы пользователей");
                users = new Account[] { };
                return false;
            }

            //раз уж в 3м задании дошли до словарей, то для загрузки используем его
            //а потом переведем в массив элементов Account
            Dictionary<string, string> dict = new Dictionary<string, string>();

            bool result = true; //по умолчанию считаем что чтение файла удалось

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    int line_number = 0; // номер строки файла, для вывода сообщений
                    while (!reader.EndOfStream)
                    {
                        line_number++;
                        string pair = reader.ReadLine();

                        if ((pair.Length == 0) || (pair[0] == ';')) continue; //пустые строки и комментарии пропускаем

                        string[] pair_array = pair.Split('|');
                        if (pair_array.Length != 2)
                        {
                            My.Error($"в строке {line_number} не указан логин или пароль");
                            continue;
                        }
                        
                        string login = pair_array[0];
                        string password = pair_array[1];
                        if (dict.ContainsKey(login))
                        {
                            My.Error($"в строке {line_number} указан повторяющийся логин");
                            continue;
                        }

                        dict.Add(login, password);
                    }
                }
            }
            catch (Exception e)
            {
                My.ErrorSignal($"ОШИБКА: {e.Message}");
                result = false; // чтение файла не удалось
            }

            //переведен словарь в массив элементов Account
            users = new Account[dict.Count];
            int i = 0; //индекс массива
            foreach(KeyValuePair<string, string> key_value in dict)
            {
                users[i] = new Account(key_value.Key, key_value.Value);
                i++;
            }

            return result;
        }

        /// <summary>
        /// Метод осуществляет проверку с базой логинов и паролей
        /// Возвращает истину если логин и пароль существуют, ложь в противном случае
        /// </summary>
        /// <param name="user">Структура логина и пароля</param>
        /// <returns>true - пользователь существует, false - отсутствует</returns>
        public static bool AuthentificateUser(Account user)
        {
            
            for (int i = 0; i < users.Length; i++)
            {
                if ((string.Compare(users[i].login, user.login, true) == 0) && (users[i].password == user.password)) return true;
            }

            return false;
        }

        /// <summary>
        /// Запрашивает логин пароль и сверяет с базой
        /// количество папыток передается в параметре
        /// </summary>
        /// <param name="try_count">количество папыток</param>
        /// <returns>Доступ разрешен(true)-Запрещен(false)</returns>
        public static bool Authentificate(int try_count)
        {
            int try_left = try_count; //Количество оставшихся попыток
            bool check; // результат проверки
            do
            {
                Account user = new Account(true);
                check = AuthentificateUser(user);
                if (!check)
                {
                    try_left--;
                    if (try_left > 0) 
                        My.ErrorSignal($"Некорректные логин или пароль. Осталось попыток: {try_left}. Повторите ввод.");
                    else
                        My.ErrorSignal("Некорректные логин или пароль.");
                }
            } while ((!check) && (try_left > 0));
            return check;
        }

    }

    /// <summary>
    /// Основной класс реализации заданий
    /// </summary>
    class Program
    {

        #region Реализация задания №1

        /// <summary>
        /// Выводит на экран содержимое одномерного массива
        /// </summary>
        /// <param name="arr"></param>
        static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} \t");

                if ((i + 1) % 10 == 0) Console.WriteLine(); // каждые 10 элементов, перевод строки
            }
            if (arr.Length % 10 != 0) Console.WriteLine(); // переведем строку, если последняя строка содержит не 10 элементов
        }

        /// <summary>
        /// Заполняет массив случайными числами в заданном диапазоне включительно
        /// </summary>
        /// <param name="arr">массив для заполнения</param>
        /// <param name="minValue">минимаьное значение элемента массива</param>
        /// <param name="maxValue">максимальное значение элемента массива</param>
        static void FillRandom(int[] arr, int minValue, int maxValue)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(minValue, maxValue + 1);
            }
        }

        /// <summary>
        /// Считает количество пар, в которых только одно из числе делится на 3
        /// </summary>
        /// <param name="arr">массив для подсчета пар</param>
        /// <returns></returns>
        static int CalculatePairs(int[] arr)
        {
            int counter = 0;

            //обход элементов массив до предпоследнего, чтобы не выйти за граници массива при i+1
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool i1mod3 = (arr[i] % 3) == 0;
                bool i2mod3 = (arr[i + 1] % 3) == 0;
                if (i1mod3 ^ i2mod3) counter++;
            }

            return counter;
        }

        /// <summary>
        /// Задание 1.
        /// Дан целочисленный массив из 20 элементов.
        /// Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
        /// Заполнить случайными числами. Написать программу, позволяющую найти и вывести количество пар элементов массива,
        /// в которых только одно число делится на 3. В данной задаче под парой подразумевается два подряд идущих элемента массива.
        /// </summary>
        static void Task01()
        {
            My.NewTask("Задание 1. Массив. Подсчет пар");

            My.SlowMessage("Инициализация массива из 20 элементов...", false);
            int[] arr = new int[20];
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Запонение массива случайными значениям в интервале (-10000 - 10000)...", false);
            FillRandom(arr, -10000, 10000);
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Содержимое массива:", true);
            Print(arr);

            //arr = new int[5] {6, 2, 9, -3, 6}; // массив для проверки

            My.SlowMessage("Подсчет пар элеметов массива...", false);
            int count = CalculatePairs(arr);
            My.SlowMessage("Выполнено", true);

            My.SlowMessage($"Количество пар удовлетворяющих условию равно {count}", true);

            PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000);
        }

        #endregion

        #region Реализация задания №2

        /// <summary>
        /// Реализуйте задачу 1 в виде статического класса StaticClass;
        /// а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
        /// б) Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
        /// в)*Добавьте обработку ситуации отсутствия файла на диске.
        /// </summary>
        static void Task02()
        {
            My.NewTask("Задание 2. Массив. Подсчет пар используя статический класс");

            int array_length = My.SlowReadInt("Введите количество элеметов массива:");
            int[] arr = new int[array_length];

            My.SlowMessage("Заполнение массива случайными числами от -10000 до 10000...", false);
            StaticClass.FillRandom(arr, -10000, 10000);
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Вывод элементов масссива:", true);
            StaticClass.Print(arr);

            My.SlowMessage($"Количество пар в массиве удовлетворяющих условию задачи равно {StaticClass.CalculatePairs(arr)}", true);

            string filename = AppDomain.CurrentDomain.BaseDirectory + "ArrayData.txt";
            My.SlowMessage($"Чтение элементов массива из файла...", false);
            arr = StaticClass.Load(filename);
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Вывод элеметов масссива:", true);
            StaticClass.Print(arr);

            PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000);
        }

        #endregion

        #region Реализация задания №3(а)

        /// <summary>
        /// Дописать класс для работы с одномерным массивом.Реализовать конструктор, 
        /// создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.
        /// Создать свойство Sum, которое возвращает сумму элементов массива, 
        /// метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений), 
        /// метод Multi, умножающий каждый элемент массива на определённое число, 
        /// свойство MaxCount, возвращающее количество максимальных элементов.
        /// </summary>
        static void Task03_a()
        {
            My.NewTask("Задание 3(а). Класс для работы с одномерным массивом");

            int array_count = My.SlowReadInt("Введите количество элементов массива:");
            int start_value = My.SlowReadInt("Введите начальное значение массива:");
            int value_step = My.SlowReadInt("Введите шаг изменения массива:");

            My.SlowMessage("Инициализируем класс с использованием конструктора...", false);
            MyOneSizeArray array_class = new MyOneSizeArray(array_count, start_value, value_step);
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Содержимое массива:", true);
            array_class.Print();
            My.Message();
            My.SlowMessage($"Сумма всех элеметов массива равна {array_class.sum}", true);

            My.SlowMessage("Используем метод Inverse для получения нового массива...", false);
            MyOneSizeArray array2 = new MyOneSizeArray(array_class.Inverse());
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Содержимое исходного массива \"array_class\":", true);
            array_class.Print();
            My.Message();

            My.SlowMessage("Содержимое нового массива \"array2\":", true);
            array2.Print();
            My.Message();

            int multi_value = My.SlowReadInt("Введите число для умножения массива:");
            My.SlowMessage("Используем метод Multi для умножения исходного массива \"array_class\"...", false);
            array_class.Multi(multi_value);
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Содержимое массива:", true);
            array_class.Print();
            My.Message();

            My.SlowMessage($"Количество максимальных элементов в массиве равно {array_class.MaxCount}", true);

            PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000); // скорось заполнения из расчета замеров
        }

        #endregion

        #region Реализация задания №3(б)

        /// <summary>
        /// ** Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки
        /// *** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)
        /// </summary>
        static void Task03_b()
        {
            //Библиотек подключена в разделе Using MyLibrary
            //Продемонстрируем те же операции как и в задании №3(а)

            //В текущем проекте класс работы с одномерным массивом называется MyOneSizeArray
            //В подключенной библиотеке класс называется OneSizeArray с аналогичным функционалом

            My.NewTask("Задание 3(б). Класс для работы с одномерным массивом с использованием библиотеки");

            int array_count = My.SlowReadInt("Введите количество элементов массива:");
            int start_value = My.SlowReadInt("Введите начальное значение массива:");
            int value_step = My.SlowReadInt("Введите шаг изменения массива:");

            My.SlowMessage("Инициализируем класс с использованием конструктора...", false);
            OneSizeArray array_class = new OneSizeArray(array_count, start_value, value_step);
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Содержимое массива:", true);
            array_class.Print();
            My.Message();
            My.SlowMessage($"Сумма всех элеметов массива равна {array_class.sum}", true);

            My.SlowMessage("Используем метод Inverse для получения нового массива...", false);
            OneSizeArray array2 = new OneSizeArray(array_class.Inverse());
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Содержимое исходного массива \"array_class\":", true);
            array_class.Print();
            My.Message();

            My.SlowMessage("Содержимое нового массива \"array2\":", true);
            array2.Print();
            My.Message();

            int multi_value = My.SlowReadInt("Введите число для умножения массива:");
            My.SlowMessage("Используем метод Multi для умножения исходного массива \"array_class\"...", false);
            array_class.Multi(multi_value);
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Содержимое массива:", true);
            array_class.Print();
            My.Message();

            My.SlowMessage($"Количество максимальных элементов в массиве равно {array_class.MaxCount}", true);

            PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000); // скорось заполнения из расчета замеров
        }

        #endregion

        #region Реализация задания №3(в)

        /// <summary>
        /// Метод возвращает словарь вхождений каждого элемент в массив
        /// </summary>
        /// <param name="arr">Массив для анализа</param>
        /// <returns>Словарь Dictionary<int, int> где ключ - значение массива, value - число вхождений</returns>
        static Dictionary<int, int> Calclulate_Array(int[] arr)
        {
            Dictionary<int, int> table = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int key = arr[i];
                int value = 1;
                if (table.ContainsKey(key))
                {
                    value = table[key] + 1;
                }
                table[key] = value;
            }
            return table;
        }

        /// <summary>
        /// Выводит на экран содержимое переданного словаря
        /// </summary>
        /// <param name="sorted_table">словарь для вывода</param>
        static void PrintSortedDictionary(SortedDictionary<int, int> sorted_table)
        {
            foreach (KeyValuePair<int, int> key_value in sorted_table)
            {
                My.Message($"{key_value.Key} - {key_value.Value}");
            }
        }

        /// <summary>
        /// в) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
        /// </summary>
        static void Task03_c()
        {
            My.NewTask("Задание 3(в).Подсчет вхождений в массив.Использование Dictionary<int, int>");

            int count = My.SlowReadInt("Введите количество элементов массива:");
            int min_value = My.SlowReadInt("Введите минимальное значение массива:");
            int max_value = My.SlowReadInt("Введите максимальное значение массива:");

            My.SlowMessage($"Инициализация массива из {count} элементов и заполнение...", false);
            int[] arr = new int[count];
            MyOneSizeArray.FillRandom(arr, min_value, max_value);
            My.SlowMessage($"Выполнено", true);

            My.SlowMessage($"Подсчет числа вхождений каждого элемента в массив с использованием словаря...", false);
            Dictionary<int, int> table = Calclulate_Array(arr);
            My.SlowMessage($"Выполнено", true);

            My.SlowMessage("Содержимое словаря после анализа массива:", true);

            //Можно использовать лямбда выражения, но этот способ менее прозрачен
            //foreach (KeyValuePair<int, int> key_value in table.OrderBy(key_value => key_value.Key))

            //Сделаем новый словарь отсортированный по ключу
            SortedDictionary<int, int> sorted_table = new SortedDictionary<int, int>(table);
            PrintSortedDictionary(sorted_table);

            PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000); // скорось заполнения из расчета замеров
        }

        #endregion

        #region Реализация заданич №4

        /// <summary>
        /// 4. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.
        /// </summary>
        static void Task04()
        {
            My.NewTask("Задание 4. Работа с логинами и паролями");

            My.SlowMessage("Загрузка базы логинов и паролей из файла...", false);
            bool loaded = AuthentificationControl.Load(AppDomain.CurrentDomain.BaseDirectory + "Users.txt");
            if (!loaded)
            {
                My.ErrorSignal("Ошибка загрузки файла пользователей");
                PressAnyKey.Run();
                FillScreen.Show(' ', My.pause1s / 12000); // скорось заполнения из расчета замеров
                return;
            }
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Ввод данных текущего пользователя...", true);
            bool access = AuthentificationControl.Authentificate(3); // три попытки ввода
            if (access)
            {
                ConsoleColor c = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                My.Message("Доступ разрешен");
                Console.ForegroundColor = c;
            }
            else
            {
                My.ErrorSignal("Доступ запрещен");
            }

            PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000); // скорось заполнения из расчета замеров
        }

        #endregion

        #region Реализация задания №5

        /// <summary>
        /// а) Реализовать библиотеку с классом для работы с двумерным массивом. 
        /// Реализовать конструктор, заполняющий массив случайными числами. 
        /// Создать методы, которые возвращают сумму всех элементов массива, 
        /// сумму всех элементов массива больше заданного, 
        /// свойство, возвращающее минимальный элемент массива, 
        /// свойство, возвращающее максимальный элемент массива, 
        /// метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
        /// *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        /// ** в) Обработать возможные исключительные ситуации при работе с файлами.
        /// </summary>
        static void Task05()
        {
            My.NewTask("Задание 5. Демонстрация работы библиотеки с классом по двумерным массивам");

            //библиотека подключена в разделе Using MyLibrary
            //Имя класса для работы с двумерными массивами TwoSizeArray

            //Полное имя файла для демонстрации чтения и записи
            string filename = AppDomain.CurrentDomain.BaseDirectory + "ArrayData.txt";

            My.SlowMessage("Ввод размерности массива от 1 до 10, для корректного вывода на экран", true);
            My.Message();

            int size1 = My.SlowReadInt("Введите количество строк в массиве (1 - 10):", 1, 10);
            int size2 = My.SlowReadInt("Введите количество столбцов в массиве (1 - 10):", 1, 10);
            int min_value = My.SlowReadInt("Введите минимальное значение для случайного заполнения:");
            int max_value = My.SlowReadInt("Введите максимальное значение для случайного заполнения:");

            My.SlowMessage("Инициализация массива с указанными параметрами...", false);
            TwoSizeArray arr = new TwoSizeArray(size1, size2, min_value, max_value);
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Содержимое массива:", true);
            arr.Print();

            My.SlowReadString("Нажмите Enter для продолжения...");

            My.SlowMessage("Запись массива в файл...", false);
            arr.Save(filename);
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Сброс данных массива (конструктор без параметров)...", false);
            arr = new TwoSizeArray();
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Инициализация массива с помощью конструктора из файла (использование метода Load)...", false);
            arr = new TwoSizeArray(filename); //метод Load вызывается внутри конструктора
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Содержимое прочитанного массива:", true);
            arr.Print();

            My.Message();
            My.SlowMessage($"Минимальное значение массива (использование свойства min_value) равно {arr.min_value}", true);
            My.SlowMessage($"Максимальное значение массива (использование свойства max_value) равно {arr.max_value}", true);
            My.SlowMessage($"Сумма всех элементов массива равна {arr.ArraySum()}", true);

            My.Message();
            int lowvalue = My.SlowReadInt("Введите число для подсчета суммы всех элементов больше указанного:");
            My.SlowMessage($"Сумма всех элементов больше {lowvalue} равна {arr.ArraySummOver(lowvalue)}", true);

            My.Message();
            My.SlowMessage("Поиск максимального значения массива и его индексов с иcпользованием модификатора \"out\"...", false);
            bool search_success = arr.MaxIndexValue(out int y, out int x, out int value);
            My.SlowMessage("Выполнено", true);
            if (search_success)
            {
                My.SlowMessage($"Максимальный элемент равен {value}. Положение: строка {y} столбец {x}", true);
            }
            else
            {
                My.SlowMessage($"Максимальный элемент не найден. Массив пустой", true);
            }

            PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000); // скорось заполнения из расчета замеров
        }

        #endregion

        /// <summary>
        /// Точка входа
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
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
                    "Задание 1. Массив. Подсчет пар",
                    "Задание 2. Массив. Подсчет пар используя статический класс",
                    "Задание 3(а). Класс для работы с одномерным массивом. Демонстрация работы",
                    "Задание 3(б). Класс для работы с одномерным массивом. Демонстрация Библиотеки",
                    "Задание 3(в). Подсчет вхождений в массив. Использование Dictionary<int, int>",
                    "Задание 4. Работа с логинами и паролями",
                    "Задание 5. Демонстрация работы библиотеки с классом по двумерным массивам"
                });

                switch (menu_number)
                {
                    case 1: Task01(); break;
                    case 2: Task02(); break;
                    case 3: Task03_a(); break;
                    case 4: Task03_b(); break;
                    case 5: Task03_c(); break;
                    case 6: Task04(); break;
                    case 7: Task05(); break;
                }

            } while (menu_number != 0);

        }
    }
}
