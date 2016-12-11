using System;

namespace OOBL
{
    class Program
    {
        /// <summary>
        /// Od funkcionalnosti jedino nije moguće raditi izmjene na postojećim / izdanim računima.
        /// Znam da predano rješenje nije potpuno u skladu sa objektnom paradigmom, nažalost rok za predaju
        /// je došao prebrzo.
        /// </summary>
        static void Main(string[] args)
        {
            Persistence.LoadData();

            Console.WriteLine("Prijavite se u sustav (* administrator = 0000 , obicni korisnik = 1234)");

            while (!AccountManager.ValidLogin)
            {
                AccountManager.TryLogin(Console.ReadLine());
            }

            Account account = AccountFactory.GetAccount(AccountManager.typeOfAccount);

            Console.WriteLine("Prijavljeni ste kao: "+ account.typeOfAccount );

            while (true)
            {
                Console.WriteLine("Popis opcija - unesite kod za iduću naredbu");
                Console.WriteLine();
                Console.Write(account.ShowOptions());

                while (!account.ValidOption(Console.ReadLine()))
                {
                    Console.WriteLine("Nemate ovlasti ili ste unijeli nepostojeću naredbu");
                };

                FlushScreen();
                while (true)
                {
                    do
                    {
                        account.PerformAction();
                    } while (account.ActionRequiresSavingData == false);

                    FlushScreen();

                    Persistence.SaveAllData();

                    break;
                }
            }
        }

        private static void FlushScreen()
        {
            for (int i=0;i<15;i++)
            {
                Console.WriteLine();
            }
        }
        public static void Display(string message)
        {
                Console.WriteLine(message);
        }

        public static string GetUserInput()
        {
            var input = Console.ReadLine();
            return input;
        }
    }
}
