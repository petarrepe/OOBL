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
            return null;
        }

        private string GenerateReportForDay(DateTime dateTime)
        {
            StringBuilder sb = new StringBuilder();
            List<Bill> billsForDay = Persistence.LoadBills().Where(t=>t.dateTime.Date==dateTime.Date).ToList();

            double totalItemValueForDay=0;

            for(int i = 0; i < billsForDay.Count(); i++)
            {
                sb.AppendLine(billsForDay[i].dateTime + " " + billsForDay[i].listOfArticles.Count + " "+ billsForDay[i].TotalAmount);
                totalItemValueForDay += billsForDay[i].TotalAmount;
            }
            sb.AppendLine("Ukupan zbroj svih računa: " + totalItemValueForDay);
            sb.AppendLine("Ukupan broj računa: " + billsForDay.Count);
            return sb.ToString();
        }

        private string GenerateReportForArticles()
        {
            StringBuilder sb = new StringBuilder();
            //TODO : ovdje prepisati kod
            return sb.ToString();
        }
    }
}
