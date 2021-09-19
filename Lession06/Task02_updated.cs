using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession06
{
    class Task02_updated
    {
        //описание делегата, который будет использоваться при передаче
        public delegate double Function(double x);

        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }
        public static void SaveFunc(string fileName, Function funct, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(funct(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        
        /// <summary>
        /// Доработанный метод
        /// Возвращает массив прочитанных значений
        /// И минимум через out-параметр
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <param name="min">значение минимум прочитанных данных</param>
        /// <returns>массив прочитанных данных</returns>
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double d;
            List<double> result_list = new List<double>(); // делаем список, т.к. не знаем сколько данным мы прочитаем
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
                result_list.Add(d);
            }
            bw.Close();
            fs.Close();

            double[] result = new double[result_list.Count];
            result_list.CopyTo(result);
            return result;
        }

        /// <summary>
        /// Возвращаем массив делегатов в виде словаря
        /// где ключ - название(описание) функции
        /// а значение - делагат данной функции
        /// </summary>
        /// <returns></returns>
        static Dictionary<string, Function> GetFunctionDictionary()
        {
            Dictionary<string, Function> result = new Dictionary<string, Function>();

            result["y = sin(x)"] = delegate (double x) { return Math.Sin(x); };
            result["y = cos(x)"] = delegate (double x) { return Math.Cos(x); };
            result["y = x^2 - 50x + 10"] = F;
            result["y = 2x + 1"] = delegate (double x) { return 2 * x + 1; };
            result["y = x^2 - 100"] = delegate (double x) { return x * x + 1; };

            return result;
        }

        /// <summary>
        /// выбирает номер из элеметодв dictionary
        /// </summary>
        /// <param name="d">переданный словарь</param>
        /// <returns></returns>
        static int ChooseFunction(Dictionary<string, Function> d)
        {
            My.SlowMessage("Выберите функцию для анализа:", true);

            int i = 1;
            foreach (KeyValuePair<string, Function> keyValuePair in d)
            {
                My.SlowMessage($"{i}. {keyValuePair.Key}", true);
                i++;
            }

            return My.SlowReadInt($"Введите номер функции (0 - ВЫХОД):", 0, d.Count);
        }

        /// <summary>
        /// Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
        /// а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.
        /// Использовать массив(или список) делегатов, в котором хранятся различные функции.
        /// б) *Переделать функцию Load, чтобы она возвращала массив считанных значений.Пусть она возвращает минимум через параметр (с использованием модификатора out).
        /// </summary>
        public static void Task02_updated_Main()
        {
            My.NewTask("Задание 2 (доработка). Нахождение минимума функции с использованием делегатов");

            Dictionary<string, Function> d = GetFunctionDictionary();


            int result;

            do
            {
                result = ChooseFunction(d);

                if (result != 0)
                {
                    double start_x = My.SlowReadDouble("Введите начальное значение интервала:");
                    double end_x = My.SlowReadDouble("Введите конечное значение интервала:");
                    double step_x = My.SlowReadDouble("Введите шаг:");

                    SaveFunc("data.bin", d.ElementAt(result - 1).Value, start_x, end_x, step_x);

                    double[] read_values = Load("data.bin", out double min);
                    My.SlowMessage($"Количество прочитанных значений {read_values.Length}", true);
                    My.SlowMessage($"Минимум функции на выбранном интервале равен {min}", true);
                    My.Message();
                }
                

            } while (result != 0);
            
            //PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000);
        }
    }
}
