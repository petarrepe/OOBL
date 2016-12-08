using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOBL
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO : Load data
            Console.WriteLine("Prijavite se u sustav");

            while (!AccountManager.ValidLogin)
            {
                AccountManager.TryLogin(Console.ReadLine());
            }

            Account account = AccountFactory.GetAccount(AccountManager.typeOfAccount);

            Console.WriteLine("Prijavljeni ste kao: "+ account.typeOfAccount );

            Console.WriteLine("Popis opcija - unesite kod za iduću naredbu");
            Console.Write(account.ShowOptions());

            Console.ReadLine();
        }

        private void FlushScreen()
        {
            for (int i=0;i<20;i++)
            {
                Console.WriteLine();
            }
        }
    }
}
