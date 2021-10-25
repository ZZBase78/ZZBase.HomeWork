using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {

        struct Account
        {
            public string Login;
            public string Password;
        }
        //Методы, которые будут производить считывание данных из файла и проверку самого логина и пароля на валидность:

        static Account[] LoadAccountsFromFile(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
            //  Считываем количество элементов массива
            int n = int.Parse(streamReader.ReadLine());
            var accounts = new Account[n];
            //  Считываем массив
            for (int i = 0; i < n; i++)
            {
                var parts = streamReader.ReadLine().Split(new char[] { ' ' });
                accounts[i].Login = parts[0];
                accounts[i].Password = parts[1];
            }
            streamReader.Close();
            return accounts;
        }

        static bool Login(Account[] accounts, string login, string password)
        {
            for (int i = 0; i < accounts.Length - 1; i++)
            {
                if (accounts[i].Login == login && accounts[i].Password == password)
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
        }
    }
}
