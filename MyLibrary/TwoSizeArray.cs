using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace MyLibrary
{
    /// <summary>
    /// Класс для работы с двумерным массивом
    /// </summary>
    public class TwoSizeArray
    {
        /// <summary>
        /// Массив для работы класса
        /// </summary>
        int[,] _arr;

        /// <summary>
        /// Свойство возвращаем минимальное значение массива
        /// </summary>
        public int min_value
        {
            get
            {
                return Min();
            }
        }

        /// <summary>
        /// Свойство возвращает мксимальное значение массива
        /// </summary>
        public int max_value
        {
            get
            {
                return Max();
            }
        }

        /// <summary>
        /// Конструктор создания класса, заполняет случайными значениямив диапазоне
        /// </summary>
        /// <param name="size1">первая размерность массива</param>
        /// <param name="size2">вторая размерность массива</param>
        /// <param name="min_value">минимальное значение заполнения (включительно)</param>
        /// <param name="max_value">максимальное значение заполнения (включительно)</param>
        public TwoSizeArray(int size1, int size2, int min_value, int max_value)
        {
            Random rnd = new Random();
            _arr = new int[size1, size2];
            for (int x = 0; x < size1; x++)
            {
                for (int y = 0; y < size2; y++)
                {
                    _arr[x, y] = rnd.Next(min_value, max_value + 1);
                }
            }
        }

        /// <summary>
        /// Конструктор класса по умолчанию
        /// Создаем пустой массива
        /// </summary>
        public TwoSizeArray()
        {
            _arr = new int[,] { };
        }

        /// <summary>
        /// Конструктор класса с автоматической загрузкой данных из файла
        /// </summary>
        /// <param name="filename">полное имя файла</param>
        public TwoSizeArray(string filename)
        {
            //все ошибки анализируются в методе load
            Load(filename);
        }

        /// <summary>
        /// Загрузка массива из файла
        /// В случае ошибки инициализирует пустой массив
        /// </summary>
        /// <param name="filename">полное имя файла</param>
        /// <returns>true - загрузка успешна</returns>
        public bool Load(string filename)
        {

            if (!File.Exists(filename))
            {
                My.ErrorSignal($"Файл {filename} не найден");
                _arr = new int[,] { };
                return false;
            }

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    bool convert; //результат конвертации в процессе чтения массива

                    if (reader.EndOfStream) throw new Exception("Ошибка формата файла. Отсутствуют размерность 1 массива");
                    convert = int.TryParse(reader.ReadLine(), out int size1);
                    if (!convert) throw new Exception("Ошибка преобразования размерности 1 массива");

                    if (reader.EndOfStream) throw new Exception("Ошибка формата файла Отсутствуют размерность 2 массива");
                    convert = int.TryParse(reader.ReadLine(), out int size2);
                    if (!convert) throw new Exception("Ошибка преобразования размерности 2 массива");

                    _arr = new int[size1, size2];
                    int current_int; // текущее значение при чтении массива
                    string current_str; // текущая строка прочитанная из файла
                    for (int x = 0; x < size1; x++)
                    {
                        for (int y = 0; y < size2; y++)
                        {
                            if (reader.EndOfStream) throw new Exception("Ошибка формата файла. Не хватает данных для загрузки");
                            current_str = reader.ReadLine();
                            convert = int.TryParse(current_str, out current_int);
                            if (!convert) throw new Exception($"Ошибка преобразования формата данных: {current_str}");
                            _arr[x, y] = current_int;
                        }
                    }

                }
            }
            catch (Exception e)
            {
                My.ErrorSignal($"Ошибка чтения файла: " + e.Message);
                _arr = new int[,] { };
                return false;
            }

            return true;
        }

        /// <summary>
        /// Сохрает массив в файл
        /// </summary>
        /// <param name="filename">полное имя файла</param>
        /// <returns>true - запись успешна</returns>
        public bool Save(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine(_arr.GetLength(0)); // записываем первую размерность массива
                    writer.WriteLine(_arr.GetLength(1)); // записываем вторую размерность массива

                    for (int x = 0; x < _arr.GetLength(0); x++)
                    {
                        for (int y = 0; y < _arr.GetLength(1); y++)
                        {
                            writer.WriteLine(_arr[x, y]);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                My.ErrorSignal($"Ошибка записи файла: " + e.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Метд возвращает сумму всех элементов массива
        /// </summary>
        /// <returns>сумма всех элементов</returns>
        public int ArraySum()
        {
            int sum = 0;
            for (int x = 0; x < _arr.GetLength(0); x++)
            {
                for (int y = 0; y < _arr.GetLength(1); y++)
                {
                    sum += _arr[x, y];
                }
            }

            return sum;
        }

        /// <summary>
        /// Метод возвращает сумму всех элементов массива больше заданного
        /// </summary>
        /// <param name="value">значение для сравнения</param>
        /// <returns>сумма выбранных элементов массива</returns>
        public int ArraySummOver(int value)
        {
            int sum = 0;
            for (int x = 0; x < _arr.GetLength(0); x++)
            {
                for (int y = 0; y < _arr.GetLength(1); y++)
                {
                    if (_arr[x, y] > value) sum += _arr[x, y];
                }
            }

            return sum;
        }

        /// <summary>
        /// Метод возвращает минимальное значение масссива
        /// </summary>
        /// <returns>минимальное значение массива (0 - если массив пустой)</returns>
        int Min()
        {
            if (_arr.GetLength(0) == 0 || _arr.GetLength(1) == 0)
            {
                return 0;
            }

            int min = _arr[0, 0];
            for (int x = 0; x < _arr.GetLength(0); x++)
            {
                for (int y = 0; y < _arr.GetLength(1); y++)
                {
                    if (_arr[x, y] < min) min = _arr[x, y];
                }
            }

            return min;
        }

        /// <summary>
        /// Метод возвращает максимальное значение массива
        /// </summary>
        /// <returns>максимальное значение массива (0 - если массив пустой)</returns>
        int Max()
        {
            if (_arr.GetLength(0) == 0 || _arr.GetLength(1) == 0)
            {
                return 0;
            }

            int max = _arr[0, 0];
            for (int x = 0; x < _arr.GetLength(0); x++)
            {
                for (int y = 0; y < _arr.GetLength(1); y++)
                {
                    if (_arr[x, y] > max) max = _arr[x, y];
                }
            }

            return max;
        }

        /// <summary>
        /// метод возвращает в параметрах индекс максимального значения и само максимальное значение
        /// </summary>
        /// <param name="x">индекс x максимального значения</param>
        /// <param name="y">индекс y максимального значения</param>
        /// <param name="value">максимальное значение</param>
        /// <returns>true - если элемент найден, false - если массив пустой</returns>
        public bool MaxIndexValue(out int x, out int y, out int value)
        {
            x = 0;
            y = 0;
            value = 0;

            if (_arr.GetLength(0) == 0 || _arr.GetLength(1) == 0)
            {
                return false;
            }

            value = _arr[0, 0];
            for (int ix = 0; ix < _arr.GetLength(0); ix++)
            {
                for (int iy = 0; iy < _arr.GetLength(1); iy++)
                {
                    if (_arr[ix, iy] > value)
                    {
                        value = _arr[ix, iy];
                        x = ix;
                        y = iy;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Метод выводит содержимое массива на экран
        /// </summary>
        public void Print()
        {
            //Шапка
            Console.Write("       |");
            for (int y = 0; y < _arr.GetLength(1); y++)
            {
                Console.Write($"{y}\t"); // номер колонки
            }
            Console.WriteLine();

            //Строка разделитель
            for (int y = 0; y <= _arr.GetLength(1); y++)
            {
                Console.Write("--------");
            }
            Console.WriteLine();

            for (int x = 0; x < _arr.GetLength(0); x++)
            {
                Console.Write(($"{x}        ").Substring(0, 7) + "|"); // номер строки
                for (int y = 0; y < _arr.GetLength(1); y++)
                {
                    Console.Write($"{_arr[x, y]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
