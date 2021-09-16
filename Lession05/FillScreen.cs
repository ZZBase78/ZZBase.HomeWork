using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession05
{
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
        /// Пауза с заданным количеством "пустых" циклов
        /// </summary>
        /// <param name="count">количество пустых циклов</param>
        static void Idle(int count)
        {
            DateTime st = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                //имитация тех же методов, которые использоались при расчете количества циклов
                DateTime dt = DateTime.Now;
                if (st > dt)
                {
                    continue;
                }
            }
        }

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
                    Idle(pause);

                    Console.SetCursorPosition(Console.WindowLeft + p.x, Console.WindowTop + p.y);
                    Console.Write(ch);
                }
                DeleteIndexInList(index); //убираем заполненную точку из коллекции
            }
            Console.CursorVisible = true;
        }

    }

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

}
