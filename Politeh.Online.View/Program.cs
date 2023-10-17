using Politeh.BLL;
using Politeh.BLL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Politeh.BLL.Enums;

namespace Politeh.Online.View
{
    internal class Program
    {
        static string path = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;

        static void Main(string[] args)
        {
            int cur = (int)Currency.kzt;
            string strCur = Currency.kzt.ToString();

            AccountDTO acc1 = new AccountDTO() { Balance = 5, Currency=Currency.kzt};
            
            AccountDTO acc2 = new AccountDTO() { Balance = 5, Currency = Currency.kzt};

            var result = acc1 + acc2;

            FirstMenu();


            Counter counter = new Counter() { Seconds = 666 };

            CounterDTO counterDTO = (CounterDTO)counter;
            //CounterDTO counterDTO = new CounterDTO();
            //counterDTO.Seconds = counter.Seconds;
        }

        public static void FirstMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Авторизация");
            Console.WriteLine("2) Регистрация");
            Console.WriteLine("3) Выход");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Authorization();
                    break;
                case 2:
                    Registration();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void Authorization()
        {
            ClientDTO client = new ClientDTO();
            Console.Write("Введите логин: ");
            client.Email = Console.ReadLine();
            Console.Write("Введите пароль: ");
            client.Password = Console.ReadLine();

            ServiceClient serviceClient = new ServiceClient(path);
            client = serviceClient.AuthorizationClient(client);
            if (client != null)
            {
                Console.WriteLine("Приветствую тебя, " + client.FullName);
            }
            else
            {
                Console.WriteLine("Такой пользователь не зарегистрирован");
                Thread.Sleep(2000);
                FirstMenu();
            }
        }
        public static void Registration()
        {
            ClientDTO client = new ClientDTO();
            Console.Write("Введите email: ");

            client.Sex = Sex.Male;

            client.Email = Console.ReadLine();
            Console.Write("Введите пароль: ");
            client.Password = Console.ReadLine();

            Console.Write("Введите имя: ");
            client.FName = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            client.SName = Console.ReadLine();

            Console.Write("Введите отчество: ");
            client.LName = Console.ReadLine();

            ServiceClient serviceClient = new ServiceClient(path);
            var result = serviceClient.RegisterClient(client);
            if (result.isError)
            {
                Console.Write(result.message);
            }
            else
            {

                Console.WriteLine("Все прошло успешно");
                Thread.Sleep(2000);
                FirstMenu();
            }

        }
    }

    public class Counter
    {
        public int Seconds { get; set; }
        public static implicit operator CounterDTO(Counter counter)
        {
            return new CounterDTO() { Seconds = counter.Seconds };
        }

        public static explicit operator int(Counter counter)
        {
            return counter.Seconds;
        }
    }

    public class CounterDTO
    {
        public int Seconds { get; set; }
    }
}

