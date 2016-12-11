using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace OOBL
{
    public static class Persistence
    {
        internal static List<Bill> allBills { get; private set; } = LoadBills();
        internal static List<Article> allArticles { get; private set; } = LoadArticles();

        public static void SaveBill(Bill bill)
        {
            allBills.Add(bill);
        }

        public static void DeleteBill(Bill bill)
        {
            var billWithSameDT = allBills.Where(t => t.dateTime == bill.dateTime).First();
            if (billWithSameDT == null)
            {
                allBills.Add(bill);
            }
            else
            {
                allBills.Remove(billWithSameDT);
                allBills.Add(bill);
            }
        }
        public static void SaveArticle(Article article)
        {
            var articleWithSameName = allArticles.Where(t => t.Name == article.Name).First();
            if (articleWithSameName == null)
            {
                allArticles.Add(article);
            }
            else
            {
                allArticles.Remove(articleWithSameName);
                allArticles.Add(article);
            }
        }
        public static List<Article> LoadArticles()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ArticlesAsList));
            var fs = new FileStream(@"c:\bills.xml", FileMode.OpenOrCreate);

            var temp = (ArticlesAsList)serializer.Deserialize(fs);
            //serializer.Serialize(Console.Out, personen);
            return temp.ArticleList;
        }
        private static void SaveArticles()
        {
            ArticlesAsList artList = new ArticlesAsList(allArticles);

            var ser = new XmlSerializer(typeof(Article));

            using (FileStream fs = new FileStream(@"c:\articles.xml", FileMode.OpenOrCreate))
            {
                ser.Serialize(fs, artList);
            }
        }

        private static void SaveBills()
        {
            BillsAsList billList = new BillsAsList(allBills);

            var ser = new XmlSerializer(typeof(Article));

            using (FileStream fs = new FileStream(@"c:\bills.xml", FileMode.OpenOrCreate))
            {
                ser.Serialize(fs, billList);
            }
        }

        private static List<Bill> LoadBills()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BillsAsList));
            var fs = new FileStream(@"c:\bills.xml", FileMode.OpenOrCreate);

            var temp = (BillsAsList)serializer.Deserialize(fs);
            //serializer.Serialize(Console.Out, personen);
            return temp.BillsList;
        }
        internal static void DeleteArticle(Article article)
        {
            allArticles.Remove(article);
        }

        public class ArticlesAsList
        {
            [XmlArray("ArticleList"), XmlArrayItem(typeof(Article), ElementName = "Article")]
            public List<Article> ArticleList { get; set; }
            public ArticlesAsList(List<Article> listOfAllArticles)
            {
                this.ArticleList = listOfAllArticles;
            }
            public ArticlesAsList()
            {
            }
        }


        public class BillsAsList
        {
            [XmlArray("BillList"), XmlArrayItem(typeof(Bill), ElementName = "Bill")]
            public List<Bill> BillsList { get; set; }
            public BillsAsList(List<Bill> listOfAllBills)
            {
                this.BillsList = listOfAllBills;
            }
            public BillsAsList()
            {
            }
        }

    }
}
