using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession06
{

    class Task03_updated
    {
        //Сделал класс вложенным, чтоюы классы из разных заданий не конфликтовали между собой

        class Student
        {
            public string lastName;
            public string firstName;
            public string university;
            public string faculty;
            public int course;
            public string department;
            public int group;
            public string city;
            public int age;
            // Создаем конструктор
            public Student(string firstName, string lastName, string university, string faculty, string department, int course, int age, int group, string city)
            {
                this.lastName = lastName;
                this.firstName = firstName;
                this.university = university;
                this.faculty = faculty;
                this.department = department;
                this.course = course;
                this.age = age;
                this.group = group;
                this.city = city;
            }
        }

        static int MyDelegat(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {

            return String.Compare(st1.firstName, st2.firstName);          // Сравниваем две строки
        }

        /// <summary>
        /// Задание 3(в)
        /// Метод для сортировки студентов по возрасту
        /// </summary>
        /// <param name="st1">первый студент для сравнения</param>
        /// <param name="st2">второй студент для сравнения</param>
        /// <returns>результат сравнения (-1, 0, 1)</returns>
        static int SortByAge(Student st1, Student st2)
        {
            if (st1.age > st2.age)
            {
                return 1;
            } else if (st1.age < st2.age)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Задание 3(г)
        /// Метод для сортировки студентов по курсу и возрасту
        /// </summary>
        /// <param name="st1">первый студент для сравнения</param>
        /// <param name="st2">второй студент для сравнения</param>
        /// <returns>результат сравнения (-1, 0, 1)</returns>
        static int SortByCourseAndAge(Student st1, Student st2)
        {
            if (st1.course > st2.course)
            {
                return 1;
            }
            else if (st1.course < st2.course)
            {
                return -1;
            }
            else if (st1.age > st2.age)
            {
                return 1;
            }else if (st1.age < st2.age)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// Переделать программу Пример использования коллекций для решения следующих задач:
        /// а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
        /// б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
        /// в) отсортировать список по возрасту студента;
        /// г) *отсортировать список по курсу и возрасту студента;
        /// </summary>
        public static void Task03_updated_Main()
        {

            My.NewTask("Задание 3 (доработка). Доработанный пример работы со списком студентов");

            int bakalavr = 0;
            int magistr = 0;
            List<Student> list = new List<Student>();                             // Создаем список студентов
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students.csv");

            int students56 = 0; // Задание 3(а). счетчик студентов на 5 и 6 курсах

            Dictionary<int, int> d_count = new Dictionary<int, int>(); // Задание 3(б). создаем частотный массив (словарь) для подсчета количество студентов на курсах

            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    //Изменен порядок параметров, т.к. в тестовом файле сначала идет возвраст а потом курс
                    Student st = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[6]), int.Parse(s[5]), int.Parse(s[7]), s[8]);
                    list.Add(st);
                    // Одновременно подсчитываем количество бакалавров и магистров
                    // Номер курса под 6м индесом
                    if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;

                    // Задание 3(а). Увеличиваем счетчик студентов на 5 и 6 курсах
                    if (My.isInInterval(st.course, 5, 6)) students56++;

                    //Заполним словарь если вдруг, не будет текущего курса в словаре
                    //Чтобы в итоге словарь содержал все курсы потока в правильном порядке
                    while (d_count.Count < st.course) d_count[d_count.Count + 1] = 0;

                    if (My.isInInterval(st.age, 18, 20)) // Задание 3(б). Считаем только студентов от 18 до 20 лет
                        d_count[st.course]++; // ключ в словаре уже должен быть
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(MyDelegat));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.WriteLine(DateTime.Now - dt);
            
            My.Message();

            //Задание 3(а). выводим количество студентов на 5 и 6 курсаз
            My.SlowMessage($"Количество студентов учащихся на 5 и 6 курсах равно {students56}");
            My.Message();

            //Задание 3(а). выаедем словарь
            My.SlowMessage($"Список студентов от 18 до 20 лет, учащиеся на различных курсах:");
            foreach (KeyValuePair<int, int> kv in d_count)
                My.Message($"Курс {kv.Key}: студентов {kv.Value}");
            My.Message();

            //Задание 3(в). Сортировка студентов по возврасту
            list.Sort(new Comparison<Student>(SortByAge));
            //Выведем отсортированный список студентов
            My.SlowMessage($"Список студентов (сортировка по возрасту):");
            for (int i = 0; i < list.Count; i++)
                My.Message($"{i+1}. {list[i].lastName} {list[i].firstName}, возраст {list[i].age}");
            My.Message();

            //Задание 3(г). Сортировка студентов по курсу и возврасту
            list.Sort(new Comparison<Student>(SortByCourseAndAge));
            //Выведем отсортированный список студентов
            My.SlowMessage($"Список студентов (сортировка по курсу и возрасту):");
            for (int i = 0; i < list.Count; i++)
                My.Message($"{i + 1}. {list[i].lastName} {list[i].firstName}, курс {list[i].course},  возраст {list[i].age}");
            My.Message();

            PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000);
        }
    }

}
