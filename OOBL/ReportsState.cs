using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOBL
{
    class ReportsState : IActionState
    {
        private Util.Actions reportForArticles;

        public ReportsState(Util.Actions reportForArticles)
        {
            this.reportForArticles = reportForArticles;
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public bool? PerformOperation()
        {
            string report;
            if (reportForArticles == Util.Actions.ReportForArticles)
            {
                report = GenerateReportForArticles();
            }

            //reportForArticles == Util.Actions.ReportForDay
            else
            {
                Console.WriteLine("Unesite datum:");

                var input = Console.ReadLine();
                DateTime result;
                while (!DateTime.TryParse(input, out result))
                {
                    Console.WriteLine("Unesite ispravan datum");
                }
                report = GenerateReportForDay(result);
            }

            Program.Display(report);
            return true;
        }

        private string GenerateReportForDay(DateTime dateTime)
        {
            StringBuilder sb = new StringBuilder();
            List<Bill> billsForDay = Persistence.allBills.Where(t => t.dateTime.Date == dateTime.Date).ToList();

            double totalItemValueForDay = 0;

            for (int i = 0; i < billsForDay.Count(); i++)
            {
                sb.AppendLine(billsForDay[i].dateTime + " , broj artikala = " + billsForDay[i].listOfArticles.Count + ", cijena= " + billsForDay[i].TotalAmount);
                totalItemValueForDay += billsForDay[i].TotalAmount;
            }
            sb.AppendLine("Ukupan zbroj svih računa: " + totalItemValueForDay);
            sb.AppendLine("Ukupan broj računa: " + billsForDay.Count);
            return sb.ToString();
        }

        private string GenerateReportForArticles()
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, int> soldQuantityPerArticle = new Dictionary<string, int>();
            var allBills = Persistence.allBills;
            try
            {
                foreach (var bill in allBills)
                {
                    foreach (var article in bill.listOfArticles)
                    {
                        if (soldQuantityPerArticle.ContainsKey(article.Name))
                        {
                            soldQuantityPerArticle[article.Name]++;
                        }
                        else
                        {
                            soldQuantityPerArticle.Add(article.Name, 1);
                        }
                    }
                }

                var myList = soldQuantityPerArticle.ToList();
                myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

                sb.AppendLine("Najprodavaniji artikli:");
                foreach (var entry in myList)
                {
                    sb.AppendLine(entry.Key + ",  broj prodanih jedinica: " + entry.Value);
                }
            }
            catch
            {
                return null;
            }
            return sb.ToString();
        }
    }
}
