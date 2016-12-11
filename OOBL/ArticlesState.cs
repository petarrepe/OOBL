using System;
using System.Collections.Generic;
using System.Text;

namespace OOBL
{
    class ArticlesState : IActionState
    {
        private Util.Actions articlesAction;
        private List<Article> allArticles = Persistence.allArticles;
        protected Dictionary<string, int> optionsWithCode = new Dictionary<string, int>()
        {
            {"Kreiraj novi artikl" , 1 },
            {"Izbriši artikl" , 2},
            {"Promijeni Artikl" , 3},
        };
        public ArticlesState(Util.Actions action)
        {
            this.articlesAction = action;
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public bool? PerformOperation()
        {
            if (articlesAction == Util.Actions.ArticlesEdit)
            {
                Program.Display(ShowOptions());
                int input=-1;
                do
                {
                    Console.WriteLine("Unesite kod iduce naredbe");
                    int.TryParse(Console.ReadLine(), out input);
                } while (input < 0 || input > optionsWithCode.Count);

                switch (input)
                {
                    case 1:
                        CreateNewArticle();
                        break;
                    case 2:
                        DeleteArticle();
                        break;
                    case 3:
                        EditArticle();
                        break;
                }
            }
            return true;
        }

        private void EditArticle()
        {
            DisplayAllArticles();

            int input;
            do
            {
                Console.WriteLine("Odaberite kod artikla kojeg želite promijeniti");
                int.TryParse(Console.ReadLine(), out input);
            } while (input < 0 || input > allArticles.Count);

            Article article = allArticles[input];

            Console.WriteLine("Unesite novi naziv artikla:");
            article.Name = Console.ReadLine();
            try
            {
                Console.WriteLine("Unesite novu cijenu:");
                article.Price = int.Parse(Console.ReadLine());

                Console.WriteLine("Unesite novi iznos PDV-a:");
                article.VatRate = int.Parse(Console.ReadLine());

                Console.WriteLine("Unesite 0 ako se proizvod prodaje na kilograme ili 1 ako se prodaje na komade:");
                article.unitOfSelling = (Console.ReadLine() == "0") ? Util.UnitOfSelling.Kilogram : Util.UnitOfSelling.Piece;
            }
            catch
            {
                Console.WriteLine("Pogrešan podatak: povratak na prijašnji meni...");
            }
        }

        private void DisplayAllArticles()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < allArticles.Count; i++)
            {
                sb.AppendLine(string.Format("{0, -30}", allArticles[i].Name) + " " + i);
            }
            Program.Display(sb.ToString());
        }

        private void DeleteArticle()
        {
            DisplayAllArticles();

            int input;
            do
            {
                Console.WriteLine("Odaberite kod artikla kojeg želite izbrisati");
                int.TryParse(Console.ReadLine(), out input);
            } while (input < 0 || input > allArticles.Count);

            Article article = allArticles[input];

            Persistence.DeleteArticle(article);
            Console.WriteLine("Izbrisano");
        }

        private void CreateNewArticle()
        {
            Article article = new OOBL.Article();
            Console.WriteLine("Unesite novi naziv artikla:");
            article.Name = Console.ReadLine();
            try
            {
                Console.WriteLine("Unesite novu cijenu:");
                article.Price = int.Parse(Console.ReadLine());

                Console.WriteLine("Unesite novi iznos PDV-a:");
                article.VatRate = int.Parse(Console.ReadLine());

                Console.WriteLine("Unesite 0 ako se proizvod prodaje na kilograme ili 1 ako se prodaje na komade:");
                article.unitOfSelling = (Console.ReadLine() == "0") ? Util.UnitOfSelling.Kilogram : Util.UnitOfSelling.Piece;

                Persistence.SaveArticle(article);
            }
            catch
            {
                Console.WriteLine("Pogrešan podatak: povratak na prijašnji meni...");
            }
        }

        internal string ShowOptions()
        {   //pripada li ovo ovoj klasi?
            StringBuilder sb = new StringBuilder();
            foreach (var entry in optionsWithCode)
            {
                sb.AppendLine(string.Format("{0, -30}", entry.Key) + " " + entry.Value);
            }

            return sb.ToString();
        }
    }
}
