using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Lession05
{

    class Program
    {
        #region Реализация заданич №1

        /// <summary>
        /// Метод контроля логина без использования регулярных выражений
        /// </summary>
        /// <param name="login">логин</param>
        /// <returns>true - проверка пройдена</returns>
        static bool CheckLogin_Normal(string login)
        {
            bool result = true; //считаем проверку по умолчанию пройденной
            string latinLetters = "abcdefghijklmnopqrstuvwxyz"; //набор символов английского алфавита
            string digitLetters = "0123456789"; // набор цифр
            string content = ""; // строка котоая будет содержать набор символов при проверке

            //1. Корректным логином будет строка от 2 до 10 символов,
            if (!My.isInInterval(login.Length, 2, 10))
            {
                My.ErrorSignal("ОШИБКА: Логин должен быть от 2 до 10 символов");
                result = false;
            }

            //2. содержащая только буквы латинского алфавита или цифры,
            content = latinLetters + latinLetters.ToUpper() + digitLetters;

            foreach (char c in login)
            {
                if (content.IndexOf(c) == -1)
                {
                    My.ErrorSignal("ОШИБКА: Логин должен содержать только буквы латинского алфавита или цифры");
                    result = false;
                    break; //цикл продолжать не имеет смысла
                }
            }

            //3. при этом цифра не может быть первой:
            content = digitLetters;
            if ((login.Length > 0) && (content.IndexOf(login[0]) != -1))
            {
                My.ErrorSignal("ОШИБКА: Первая буква не может быть цифрой");
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Метод проверки логина с использованием регулярных выражений
        /// </summary>
        /// <param name="login">логи для проверки</param>
        /// <returns>true - проверка пройдена</returns>
        static bool CheckLogin_Regex(string login)
        {
            Regex r = new Regex("^[a-zA-Z][a-zA-Z0-9]{1,9}$");
            return r.IsMatch(login);
        }

        /// <summary>
        /// Создать программу, которая будет проверять корректность ввода логина.
        /// Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры,
        /// при этом цифра не может быть первой:
        /// а) без использования регулярных выражений;
        /// б) **с использованием регулярных выражений.
        /// </summary>
        static void Task01()
        {
            My.NewTask("Задание 1. Проверка корректности логинов");

            while (true)
            {
                bool result;

                string login = My.SlowReadString("Введите логин для проверки (<пусто> - ВЫХОД):");
                if (login == "") break;

                My.SlowMessage("Проверка логина БЕЗ ИСПОЛЬЗОВАНИЯ регулярных выражений", true);
                result = CheckLogin_Normal(login);
                if (result)
                    My.Message("Логин правильного формата", ConsoleColor.Green);
                else
                    My.ErrorSignal("ОШИБКА: Формат логина не соответствует правилам");


                My.SlowMessage("Проверка логина С ИСПОЛЬЗОВАНИЕМ регулярных выражений", true);
                result = CheckLogin_Regex(login);
                if (result)
                    My.Message("Логин правильного формата", ConsoleColor.Green);
                else
                    My.ErrorSignal("ОШИБКА: Формат логина не соответствует правилам");
            }

            //PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000);
        }

        #endregion

        #region Реализация задания №2

        //Класс необходимый для задания находится в отдельном файле проекта "Message.cs"

        /// <summary>
        /// Реализация Задание 2(а)
        /// Вывести только те слова сообщения, которые содержат не более N букв
        /// </summary>
        /// <param name="text">текст для анализа</param>
        static void Task02_1(string text)
        {
            My.SlowMessage("а) Вывести только те слова сообщения, которые содержат не более N букв", true);
            int maxlength = 0;
            do
            {
                maxlength = My.SlowReadInt("Введите максимальную длину слова (0 - ВЫХОД):");
                if (maxlength != 0)
                {
                    string[] words = Message.GetWordsNotLonger(text, maxlength);
                    Message.PrintStringArray(words);
                }

            } while (maxlength != 0);

            My.Message();
        }

        /// <summary>
        /// Реализация задания №2(б)
        /// Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        /// </summary>
        /// <param name="text">текст для анализа</param>
        static void Task02_2(string text)
        {
            // Проблема реаизации этого задания в том, что при выборе например символа 'И' и если в текст есть предлог "И"
            // То замена данного предлога на <пусто>, вызовет удаление всех символов 'и' из всех слов по всей строке
            // для правильной реализации нужно использовать регулярные выражения

            My.SlowMessage("б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.", true);
            string answer;
            do
            {
                answer = My.SlowReadString("Введите символ (<пусто> - ВЫХОД):");
                if (answer.Length == 1)
                {
                    string result = Message.RemoveWordsEndedByChar(text, answer[0]);

                    My.Message("Результат обработки текста:");
                    Message.PrintText(result, Console.WindowWidth - 1);
                    My.Message();
                }
                else if (answer.Length > 1)
                {
                    My.ErrorSignal("Ошибка: необходимо ввести один символ.");
                }

            } while (answer.Length != 0);

            My.Message();
        }

        /// <summary>
        /// Реализация задания №2(д)
        /// д) ***Создать метод, который производит частотный анализ текста.
        /// В качестве параметра в него передается массив слов и текст,
        /// в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.
        /// Здесь требуется использовать класс Dictionary.
        /// </summary>
        /// <param name="text">исходный текст</param>
        static void Task02_3(string text)
        {
            My.SlowMessage("б) частотный анализ слов в тексте", true);

            string answer;
            do
            {

                answer = My.SlowReadString("Введите слова для анализа через <пробел> (<пусто> - ВЫХОД):");
                if (answer.Length != 0)
                {
                    string[] words = Message.GetWordsFromInput(answer);
                    Dictionary<string, int> dict = Message.WordsFrequence(text, words);
                    My.SlowMessage("Результат частотного анализа:", true);
                    Message.PrintDictionary(dict);
                }

            } while (answer.Length != 0);

            My.Message();
        }

        /// <summary>
        /// Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
        /// а) Вывести только те слова сообщения, которые содержат не более n букв.
        /// б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        /// в) Найти самое длинное слово сообщения.
        /// г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        /// д) ***Создать метод, который производит частотный анализ текста.
        /// В качестве параметра в него передается массив слов и текст, 
        /// в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.
        /// Здесь требуется использовать класс Dictionary.
        /// </summary>
        static void Task02()
        {
            My.NewTask("Задание 2. Демонстрация работы методов класса Message для обработки текста");

            My.SlowMessage("Чтение строки из файла...", false);
            string original_text = Message.Load(AppDomain.CurrentDomain.BaseDirectory + "Text.txt");
            My.SlowMessage("Выполнено", true);
            My.Message();

            My.SlowMessage("Вывод содержимого файла (исходный текст):", true);
            Message.PrintText(original_text, Console.WindowWidth - 1);
            My.Message();

            Task02_1(original_text); // Задание (а) Вывести только те слова сообщения, которые содержат не более N букв

            Task02_2(original_text); // Задание (б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.

            My.SlowMessage("Поиск самого длинного слова...", false);
            string longest_word = Message.FindLongestWord(original_text);
            My.SlowMessage("Выполнено", true);
            My.Message($"Самое длинное слово в тексте равно \"{longest_word}\"");
            My.Message();

            My.SlowMessage("Формирование строки с помощью StringBuilder из самых длинных слов сообщения....", false);
            string longest_words = Message.LongestWords(original_text);
            My.SlowMessage("Выполнено", true);
            My.Message("Строка состоящая из самых длиннных слов равна:");
            My.Message($"{longest_words}");
            My.Message();

            // д) ***Создать метод, который производит частотный анализ текста.
            // В качестве параметра в него передается массив слов и текст,
            // в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.
            // Здесь требуется использовать класс Dictionary.
            Task02_3(original_text);

            //PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000);
        }

        #endregion

        #region Реализация задания №3

        /// <summary>
        /// Метод возвращает частотный словарь символов по переданной строке
        /// регистр буев не учитывается
        /// </summary>
        /// <param name="s">строка для анализа</param>
        /// <returns>Частотный словарь символов</returns>
        static Dictionary<char, int> GetDictionaryFromString(string s)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();

            foreach (char ch in s)
            {
                if (!result.ContainsKey(char.ToLower(ch))) result[char.ToLower(ch)] = 0;

                result[char.ToLower(ch)]++;
            }

            return result;
        }

        /// <summary>
        /// Метод проверяет идентичность словарей
        /// </summary>
        /// <param name="d1">первый словарь</param>
        /// <param name="d2">второй словарь</param>
        /// <returns>true - словари идентичны</returns>
        static bool IsDictionaryEquals(Dictionary<char, int> d1, Dictionary<char, int> d2)
        {
            if (d1.Count != d2.Count) return false;

            foreach (KeyValuePair<char, int> key_value in d1)
            {
                if (!d2.ContainsKey(key_value.Key)) return false; // не найден ключ, словари не равны
                if (d2[key_value.Key] != key_value.Value) return false; //разные значения у одинаковых ключей, словари не равны
            }
            return true; //все проверки пройдены словари равны
        }

        /// <summary>
        /// Метод проверяет является ли одна строка перестановкой другой строки
        /// </summary>
        /// <param name="s1">первая строка</param>
        /// <param name="s2">вторая строка</param>
        /// <returns>true - строки являются перестановкой</returns>
        static bool IsAnagram(string s1, string s2)
        {
            //для решения будем использовать словари символов и частотное их повторение
            //Если словари будут одинаковыми то строки являются перестановками

            Dictionary<char, int> d1 = GetDictionaryFromString(s1);
            Dictionary<char, int> d2 = GetDictionaryFromString(s2);

            return IsDictionaryEquals(d1, d2);
        }

        /// <summary>
        /// Задание №3
        /// 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
        /// Например: badc являются перестановкой abcd.
        /// </summary>
        static void Task03()
        {
            My.NewTask("Задание 3. Определение перестановки строк");

            My.SlowMessage("При сравнении перестановки строк регистр символов не учитывается", true);

            My.SlowMessage("Введите две строки (ввод пустых строк - ВЫХОД)", true);

            string s1;
            string s2;

            do
            {
                s1 = My.SlowReadString("Введите первую строку:");
                s2 = My.SlowReadString("Введите вторую строку:");

                if (s1.Length + s2.Length != 0)
                {
                    bool result = IsAnagram(s1, s2);
                    if (result)
                    {
                        My.Message("Введенные строки ЯВЛЯЮТСЯ перестановкой друг друга");
                    }
                    else
                    {
                        My.Message("Введенные строки НЕ ЯВЛЯЮТСЯ перестановкой друг друга");
                    }
                }

            } while (s1.Length + s2.Length != 0);

            //PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000);
        }

        #endregion

        #region Реализация задания №4

        //Класс Student для данного задания находится в файле Student.cs

        /// <summary>
        /// Метод герерирует файл данных студентов для последующей обработки
        /// </summary>
        /// <param name="filename">имя файла</param>
        /// <returns>количество сгенерированных студентов</returns>
        static int GenerateFileOfStudens(string filename)
        {
            string full_filename = AppDomain.CurrentDomain.BaseDirectory + filename;

            Random rnd = new Random();
            int students_count = rnd.Next(10, 101);

            NameGenerator nameGenerator = new NameGenerator();

            try
            {

                using (StreamWriter writer = new StreamWriter(full_filename))
                {
                    writer.WriteLine(students_count);
                    for (int i = 1; i <= students_count; i++)
                    {
                        string student_string = nameGenerator.GetRandomName() + " " + rnd.Next(1, 6) + " " + rnd.Next(1, 6) + " " + rnd.Next(1, 6);
                        writer.WriteLine(student_string);
                    }
                }

            }
            catch (Exception e)
            {
                My.ErrorSignal($"Ошибка записи файла {e.Message}");
                students_count = 0;
            }

            return students_count;
        }

        /// <summary>
        /// Загрузка данных студентов в массив
        /// </summary>
        /// <param name="students_filename">имя файла студентов</param>
        /// <returns>массив объектов класса Student</returns>
        static Student[] LoadStudentsToArray(string filename)
        {
            string full_filename = AppDomain.CurrentDomain.BaseDirectory + filename;

            Student[] result;

            if (!File.Exists(full_filename))
            {
                My.ErrorSignal($"Файл {full_filename} не найден");
                return new Student[] { };
            }

            try
            {
                using (StreamReader reader = new StreamReader(full_filename))
                {
                    if (reader.EndOfStream) throw new Exception("Ошибка формата файла: отсутствует число студентов");
                    string str_count_student = reader.ReadLine();
                    int array_size;
                    bool correct = int.TryParse(str_count_student, out array_size);
                    if (!correct) throw new Exception("Ошибка формата файла: ошибка преобразования числа студентов");
                    result = new Student[array_size];
                    for (int i = 0; i < array_size; i++)
                    {
                        if (reader.EndOfStream) throw new Exception("Ошибка формата файла: не достаточно данных студентов");
                        string student_info = reader.ReadLine();
                        string[] student_data = student_info.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (student_data.Length != 5) throw new Exception("Ошибка формата файла: некорректные данные студента");

                        //При наличии данных ошибок, считаем это предупреждением, файл грузим дальше
                        if (student_data[0].Length > 20) My.Error("Внимание: фамилия студента превышает 20 символов");
                        if (student_data[1].Length > 15) My.Error("Внимание: имя студента превышает 15 символов");
                        
                        bool g1_correct = int.TryParse(student_data[2], out int grade1);
                        bool g2_correct = int.TryParse(student_data[3], out int grade2);
                        bool g3_correct = int.TryParse(student_data[4], out int grade3);
                        if (!g1_correct || !g1_correct || !g1_correct) throw new Exception("Ошибка формата файла: ошибка преобразования оценок студента");
                        result[i] = new Student(student_data[0], student_data[1], grade1, grade2, grade2);
                    }
                }
            }
            catch (Exception e)
            {
                My.ErrorSignal($"Ошибка загрузки файла {e.Message}");
                return new Student[] { };
            }
            return result;
        }

        /// <summary>
        /// Метод выводит тройку худших студентов и также кандидатов с аналогичным средним баллом
        /// </summary>
        /// <param name="students">отсортированный массив студентов</param>
        static void PrintLowStudents(Student[] students)
        {
            My.Message();
            My.SlowMessage("Тройка худших студентов:", true);

            double min_average = 0;

            for (int i = 0; i < 3; i++)
            {
                if (students.Length > i) //проверка на наличие, может быть массив пустой, если была ошибка чтения файла
                {
                    My.Message(students[i].ToString());
                    min_average = students[i].AverageGrade; // минимальный средний балл из трех, будет у последнего
                }

            }

            My.Message();
            My.SlowMessage("Кандидаты в тройку худших: ", false); // делаем без переноса, если вдру кандидаты отсутствуют
            bool someoutput = false; //Хотябы один студент есть
            for (int i = 3; i < students.Length; i++)
            {
                if (students[i].AverageGrade > min_average) break; //не имеет смысла дальше проверять, т.к. массив отсортирован

                if (students[i].AverageGrade == min_average)
                {
                    if (!someoutput) My.Message(); //необходимый разовый перенос
                    someoutput = true;
                    My.Message(students[i].ToString());
                }
            }
            if (!someoutput) My.SlowMessage("Отсутствуют", true);

        }

        /// <summary>
        /// Задача ЕГЭ.
        /// На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
        /// В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
        /// <Фамилия> <Имя> <оценки>,
        /// где <Фамилия> — строка, состоящая не более чем из 20 символов,
        /// <Имя> — строка, состоящая не более чем из 15 символов,
        /// <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе.
        /// <Фамилия> и<Имя>, а также<Имя> и<оценки> разделены одним пробелом. Пример входной строки:
        /// Иванов Петр 4 5 3
        /// Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников.
        /// Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
        /// </summary>
        static void Task04()
        {
            My.NewTask("Задание 4. ЕГЭ. Работа со студентами");

            My.SlowMessage("Генерация файла исходных данных...", false);
            string students_filename = "students.txt";
            int student_count = GenerateFileOfStudens(students_filename);
            My.SlowMessage("Выполнено", true);
            My.SlowMessage($"Сгенерировано {student_count} записей в файле {students_filename}", true);

            My.SlowMessage("Загрузка данных студентов в массив...", false);
            Student[] students = LoadStudentsToArray(students_filename);
            My.SlowMessage("Выполнено", true);

            My.SlowMessage("Сортировка массива студентов по возврастанию среднего балла...", false);
            Array.Sort(students, new StudentComparer());
            My.SlowMessage("Выполнено", true);

            PrintLowStudents(students);

            PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000);
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
                    "Задание 1. Проверка корректности логинов",
                    "Задание 2. Демонстрация методов обработки текста",
                    "Задание 3. Определение перестановки строк",
                    "Задание 4. ЕГЭ. Работа со студентами"
                });

                switch (menu_number)
                {
                    case 1: Task01(); break;
                    case 2: Task02(); break;
                    case 3: Task03(); break;
                    case 4: Task04(); break;
                }

            } while (menu_number != 0);

        }
    }
}
