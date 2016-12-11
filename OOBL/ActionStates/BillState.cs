using System;
using System.Collections.Generic;
using System.Text;

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

        public bool? PerformOperation()
        {
            if (billAction == Util.Actions.NewBill)
            {
                CreateNewBill();
            }
            else if (billAction == Util.Actions.BillDeletion)
            {
                //TODO : administrator koji može editirati i brisati račune
                EditBill();
            }
            return true;
        }

        private void EditBill()
        {
            bill = new Bill();

            throw new NotImplementedException();
        }

        private void CreateNewBill()
        {
            bill = new Bill();
            Delegate dl = new Delegate(BillDelegate);

            DisplayArticleInformation();

            string userInput;
            do
            {
                userInput = Program.GetUserInput();
                if (AddArticleToBill(userInput) )
                {
                    Program.Display("Dodano: " + allArticles[int.Parse(userInput)].Name);
                    Program.Display("Dodajte novi proizvod ili unesite 'p' za izdavanje racuna");
                }
                else
                {
                    Program.Display("Došlo je do pogreške! Molimo pokušajte opet");
                }
            } while (userInput != "p");


            dl();

            PrintBill();

            Persistence.SaveBill(bill);
        }

        private void PrintBill()
        {
            var printer = new ConsolePrinter();
            printer.Print(bill);
        }

        private bool AddArticleToBill(string userInput)
        {
            try
            {
                int code = int.Parse(userInput);
                bill.AddArticle(allArticles[code]);

                return true;
            }
            catch
            {
                return false;
            }

        }

        private void DisplayArticleInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Odaberite kôd artikla kojeg želite dodati na račun \nUnesite 'p' za ispis računa");
            for ( int i=0; i < allArticles.Count;i++)
            {
                sb.AppendLine(string.Format("{0, -30}", allArticles[i].Name) + " " +i);
            }

            Program.Display(sb.ToString());
        }

        public void BillDelegate()
        {
            bill.calculateBillInformation();
        }
    }
}
