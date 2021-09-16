using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession05
{
    class NameGenerator
    {
        List<string> male_names;
        List<string> male_surnames;
        List<string> female_names;
        List<string> female_surnames;
        Random rnd;

        /// <summary>
        /// Осуществляет загрузку из файла в переданную коллекцию
        /// </summary>
        /// <param name="list">коллекция для загрузки</param>
        /// <param name="filename">полное имя файла</param>
        void LoadList(List<string> list, string filename)
        {
            list.Clear();

            if (!File.Exists(filename))
            {
                My.ErrorSignal($"Файл {filename} не найден");
                return;
            }

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        list.Add(reader.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {
                My.ErrorSignal($"Ошибка загрузки файла {e.Message}");
                list.Clear();
            }
        }

        /// <summary>
        /// Конструктор класса
        /// Загружает имена и фамилии
        /// Инициализирует генератор случайных чисел
        /// </summary>
        public NameGenerator()
        {
            male_names = new List<string>();
            male_surnames = new List<string>();
            female_names = new List<string>();
            female_surnames = new List<string>();
            rnd = new Random();
            LoadList(male_names, AppDomain.CurrentDomain.BaseDirectory + "Names\\male_names.txt");
            LoadList(male_surnames, AppDomain.CurrentDomain.BaseDirectory + "Names\\male_surnames.txt");
            LoadList(female_names, AppDomain.CurrentDomain.BaseDirectory + "Names\\female_names.txt");
            LoadList(female_surnames, AppDomain.CurrentDomain.BaseDirectory + "Names\\female_surnames.txt");
        }

        /// <summary>
        /// Возвращает случайный элемент из списка
        /// </summary>
        /// <param name="list">список</param>
        /// <returns>случайный элемент</returns>
        string GetRandomListElement(List<string> list)
        {
            int count = list.Count;
            int random_index = rnd.Next(0, count);
            return list[random_index];
        }

        /// <summary>
        /// Возвращает случайную фамилию и имя из списков
        /// </summary>
        /// <returns></returns>
        public string GetRandomName()
        {
            string result = "";
            int sex = rnd.Next(0, 2);
            switch (sex)
            {
                case 0: result = GetRandomListElement(male_surnames) + " " + GetRandomListElement(male_names); break;
                case 1: result = GetRandomListElement(female_surnames) + " " + GetRandomListElement(female_names); break;
            }

            return result;
        }
    }
}
