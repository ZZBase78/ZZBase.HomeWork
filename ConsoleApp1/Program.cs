using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static bool CorrectLength(string s) 
        {
            return (s.Length >= 2) && (s.Length <= 10);
        }

        static void Task1()
        {

            //Создать программу, которая будет проверять корректность ввода логина.
            //Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры,
            //при этом цифра не может быть первой:
            //а) без использования регулярных выражений;






            //Вводим логин
            Console.Write("Введите логин:");
            string login = Console.ReadLine();


            //проверка длины логина
            //Console.WriteLine($"Длина строки {login.Length}"); 

            if (CorrectLength(login))
            {
                Console.WriteLine("Длина строки корректная");
            }
            else
            {
                Console.WriteLine("Длина строки НЕ корректная");
            }




            //проверка символов латинские и цифры

            string letter = "abcdefghijklmnopqrstuvwxyz";
            string digital = "0123456789";

            string shablon = letter + letter.ToUpper() + digital;

            bool login_corrent = true;

            for (int i = 0; i < login.Length; i++)
            {
                if (shablon.Contains(login[i]) == false)
                {
                    login_corrent = false;
                }
            }

            if (login_corrent)
            {
                Console.WriteLine("Логин содержит корректные символы");

            }
            else
            {
                Console.WriteLine("Логин содержит не корректные символы");

            }



            //первая символ не цифра
            if (digital.Contains(login[0]) == false)
            {
                Console.WriteLine("Первый символ логина корректный");
            }
            else
            {
                Console.WriteLine("Первый символ логина НЕ корректный");
            }



            Console.ReadLine();

        }

        static void Main(string[] args)
        {

            Task1();
        }
    }
}
