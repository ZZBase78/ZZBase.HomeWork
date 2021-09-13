using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    /// <summary>
    /// Класс для решения задания №3
    /// </summary>
    public class OneSizeArray
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
        public OneSizeArray(int array_size, int start_value, int value_step)
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
        public OneSizeArray(int[] new_array)
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
            Array.Copy(_arr, new_array, _arr.Length); //Используем Copy для практики )
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
                }
                else if (_arr[i] == maxValue)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
