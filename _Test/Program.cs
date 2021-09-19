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
            int result = new SelectedMenu().ChooseMenu(new string[] { 
                "Первое меню",
                "Второе меню",
                "Третье меню",
                "ВЫХОД"
            }, 25, SelectedMenu.ItemAlign.Left, "ГЛАВНОЕ МЕНЮ");

            Console.Write(result);

            Console.ReadLine();
        }
    }
}
