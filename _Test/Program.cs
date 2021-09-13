using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            Console.Write("Введите пароль:");
            ConsoleKeyInfo c;
            do
            {
                c = Console.ReadKey(true);
                if (c.Key != ConsoleKey.Enter)
                {
                    s += c.KeyChar;
                    Console.Write("*");
                }

            } while (c.Key != ConsoleKey.Enter);
            Console.WriteLine();
            Console.WriteLine($"Пароль: {s}");

            Console.ReadLine();

            
        }
    }
}
