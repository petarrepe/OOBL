using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOBL
{
    public static class Persistence
    {
        public static void SaveBill(Bill bill)
        {

        }

        public static void DeleteBill(Bill bill)
        {

        }
        public static void SaveArticle(Article article)
        {

        }
        public static List<Article> LoadArticles()
        {
            return new List<Article>();
        }

        internal static List<Bill> LoadBills()
        {
            throw new NotImplementedException();
        }
        internal static void DeleteArticle(Article article)
        {

        }
    }
}
