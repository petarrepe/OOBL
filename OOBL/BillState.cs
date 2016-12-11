using System;
using System.Collections.Generic;

namespace OOBL
{
    class BillState : IActionState
    {
        private Util.Actions billAction;
        private delegate void Delegate();
        private Bill bill = new Bill();
        private List<Article> allArticles = Persistence.allArticles;

        public BillState(Util.Actions action)
        {
            this.billAction = action;
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public bool? PerformOperation()
        {
            if (billAction == Util.Actions.NewBill)
            {
                CreateNewBill();
            }
            else if (billAction == Util.Actions.BillDeletion)
            {
                //administrator koji može editirati i brisati račune
                EditOrBill();
            }
            return true;
        }

        private void EditOrBill()
        {
            bill = new Bill();

        }

        private void CreateNewBill()
        {
            bill = new Bill();
            Delegate dl = new Delegate(BillDelegate);

            DisplayArticleInformation();

            string userInput;
            do
            {
                userInput = Console.ReadLine();
                AddArticleToBill(userInput);
            } while (userInput != "p");


            dl();
            Program.DisplayBill(bill);
            Persistence.SaveBill(bill);
        }

        private void AddArticleToBill(string userInput)
        {
            try
            {
                int code = int.Parse(userInput);
                bill.AddArticle(allArticles[code]);
                Console.WriteLine("Dodano: " + allArticles[code].Name);
            }
            catch
            {
                return;
            }

        }

        private void DisplayArticleInformation()
        {         
            Program.Display("Odaberite kôd artikla kojeg želite dodati na račun \nUnesite 'p' za ispis računa");
            for ( int i=0; i < allArticles.Count;i++)
            {
                Program.Display(string.Format("{0, -30}", allArticles[i].Name) + " " +i);
            }
        }

        public void BillDelegate()
        {
            bill.calculateBillInformation();
        }
    }
}
