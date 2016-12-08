using System;

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

            while (!account.ValidOption(Console.ReadLine()))
            {
                Console.WriteLine("Nemate ovlasti ili ste unijeli nepostojeću naredbu");
            };

            FlushScreen();

            do
            {
                account.PerformAction();
            } while (account.ActionResult != null);
        }

        private static void FlushScreen()
        {
            for (int i=0;i<20;i++)
            {
                Console.WriteLine();
            }
        }
    }
}
