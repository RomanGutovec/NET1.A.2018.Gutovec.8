using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLib;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccountService service = new BankAccountService()
            {
                ClientsList = new List<Client>()
                {
                    new Client
                    {
                        FirstName = "Ivanov",
                        LastName = "Ivan",
                        Email = "ivanov@gmail.com",
                        PhoneNumber = "+37529115-35-35",
                        PassportNumber="MP222222",
                            Accounts = new List<Account>()
                            {
                                new Account { AccountValue = 100, AccountBehaviour=new Base() },
                                new Account { AccountValue = 200, AccountBehaviour=new Silver() },
                                new Account { AccountValue = 300, AccountBehaviour=new Gold() }
                            }
                    }
                }
            };

            service.ClientsList[0].Accounts[0].Withdraw(100);
            service.ClientsList[0].Accounts[1].Withdraw(200);
            service.ClientsList[0].Accounts[2].Withdraw(300);

            Console.WriteLine($"All account must have 0 value");
            Console.WriteLine($"The first account: {service.ClientsList[0].Accounts[0].ToString()}, " +
                $"\nthe second: {service.ClientsList[0].Accounts[1].ToString()}, " +
                $"\nthe third account: {service.ClientsList[0].Accounts[2].ToString()}");

            Console.WriteLine("\nPut on accounts 200, 300, 400");
            service.ClientsList[0].Accounts[0].Put(200);
            service.ClientsList[0].Accounts[1].Put(300);
            service.ClientsList[0].Accounts[2].Put(400);
            service.CloseAccount(null, service.ClientsList[0].Accounts[2].IdNumber);
            Console.WriteLine($"The first account: {service.ClientsList[0].Accounts[0].ToString()} " +
                $"\nthe second: {service.ClientsList[0].Accounts[1].ToString()}, " +
                $"\nthe third account: {service.ClientsList[0].Accounts[2].ToString()}");

            Console.WriteLine($"Add new account");
            Console.WriteLine("\nClient info: \n{0}", service.ClientsList[0].ToString());
            Console.ReadLine();
        }
    }
}
