using System;

namespace OOBL
{
    class Program
    {
        static void Main(string[] args)
        {
            Persistence.LoadData();

            Console.WriteLine("Prijavite se u sustav");

            while (!AccountManager.ValidLogin)
            {
                AccountManager.TryLogin(Console.ReadLine());
            }

            Account account = AccountFactory.GetAccount(AccountManager.typeOfAccount);

            Console.WriteLine("Prijavljeni ste kao: "+ account.typeOfAccount );

            while (true)
            {
                Console.WriteLine("Popis opcija - unesite kod za iduću naredbu");
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
                    } while (account.ActionResult == false);
                    FlushScreen();

                    Persistence.SaveAllData();

                    break;
                }
            }
        }

        private static void FlushScreen()
        {
            for (int i=0;i<20;i++)
            {
                Console.WriteLine();
            }
        }
        public static void Display(string message)
        {
                Console.WriteLine(message);
        }

        internal static void DisplayBill(Bill bill)
        {
            Console.WriteLine();
            Console.WriteLine("Vrijeme računa:"+ bill.dateTime);
            Console.WriteLine("Ukupan iznos: " + bill.TotalAmount);
            Console.WriteLine("Artikli na računu");
            foreach(var item in bill.listOfArticles)
            {
                Console.WriteLine(string.Format("{0, -30}", item.Name) + " Price:" + item.Price +"        Unit:"+item.unitOfSelling);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
