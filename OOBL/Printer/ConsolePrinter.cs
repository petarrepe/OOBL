using System;

namespace OOBL
{
    class ConsolePrinter : IPrinter
    {
        public void Print(Bill bill)
        {
            Console.WriteLine();
            Console.WriteLine("Vrijeme računa: " + bill.dateTime);
            Console.WriteLine("Ukupan iznos: " + bill.TotalAmount);
            Console.WriteLine("Artikli na računu ");
            foreach (var item in bill.listOfArticles)
            {
                Console.WriteLine(string.Format("{0, -30}", item.Name) + " Price:" + item.Price + "        Unit:" + item.unitOfSelling);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
