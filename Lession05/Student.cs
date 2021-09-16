using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession05
{
    /// <summary>
    /// Класс для хранения и работы со студентом
    /// </summary>
    class Student
    {
        //Данные ученика

        public string surname;
        public string name;
        public int grade1;
        public int grade2;
        public int grade3;

        /// <summary>
        /// Свойство возвращает среднюю оценту ученик
        /// </summary>
        public double AverageGrade
        {
            get
            {
                return GetAverageGrade();
            }
        }

        /// <summary>
        /// Метод возвращает среднюю оценку ученика
        /// </summary>
        /// <returns>средняя оценка</returns>
        double GetAverageGrade()
        {
            return ((double)grade1 + grade2 + grade3) / 3;
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="surname">фамилия</param>
        /// <param name="name">имя</param>
        /// <param name="grade1">1 оценка</param>
        /// <param name="grade2">2 оценка</param>
        /// <param name="grade3">3 оценка</param>
        public Student(string surname, string name, int grade1, int grade2, int grade3)
        {
            this.surname = surname;
            this.name = name;
            this.grade1 = grade1;
            this.grade2 = grade2;
            this.grade3 = grade3;
        }

        /// <summary>
        /// Перезапись метода для вывод данных студента
        /// </summary>
        /// <returns>представлеие данных студента</returns>
        public override string ToString()
        {
            return $"{surname} {name} (Оценки: {grade1}, {grade2}, {grade3}; Средний балл: {AverageGrade:F2})";
        }
    }

    /// <summary>
    /// Класс для сортировки студентов по возврастанию их среднего балла
    /// </summary>
    class StudentComparer : IComparer<Student>
    {
        public int Compare(Student s1, Student s2)
        {
            double a1 = s1.AverageGrade;
            double a2 = s2.AverageGrade;

            if (a1 > a2)
                return 1;
            else if (a1 < a2)
                return -1;
            else
                return 0;
        }
    }
}
