using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession06
{
    class Task01_updated
    {
        // Описываем делегат. В делегате описывается сигнатура методов, на
        // которые он сможет ссылаться в дальнейшем (хранить в себе)
        public delegate double Fun(double a, double x);

        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        // изменение параметров: передается параметра A чтобы быть использованым в делегате
        public static void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double a, double x)
        {
            return a * x * x; // замена формулы на a*x^2
        }

        public static void Task01_updated_Main()
        {
            My.NewTask("Задание 1 (доработка). Демонстрация программы с доработанными методами с новой сигнатурой делегата");

            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc:");

            double a = My.SlowReadDouble("Введите значение A:");

            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Table(new Fun(MyFunc), a, -2, 2);
            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
            // Упрощение(c C# 2.0).Делегат создается автоматически.            
            Table(MyFunc, a, -2, 2);
            Console.WriteLine("Таблица функции a*Sin(x):");
            Table(delegate (double k, double x) { return k * Math.Sin(x); }, a, -2, 2);      // Изменение: Использование виртуального метода
            Console.WriteLine("Таблица функции a*x^2:");
            // Упрощение(с C# 2.0). Использование анонимного метода
            Table(MyFunc, a, 0, 3);

            PressAnyKey.Run();
            FillScreen.Show(' ', My.pause1s / 12000);
        }

    }
}
