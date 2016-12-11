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

        public static void ReplaceBill(Bill bill)
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
            if (allArticles.Count == 0)
            {
                allArticles.Add(article);
                return;
            }

            var articleWithSameName = allArticles.Where(t => t.Name == article.Name).FirstOrDefault();
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

        internal static void SaveAllData()
        {
            SaveAllArticles();
            SaveAllBills();
        }

        public static List<Article> LoadArticles()
        {
            ArticlesAsList temp;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ArticlesAsList));
                using (var fs = new FileStream(@"articles.xml", FileMode.OpenOrCreate))
                {
                    temp = (ArticlesAsList)serializer.Deserialize(fs);
                }
                
                return temp.ArticleList;
            }
            catch
            {
                return new List<Article>();
            }
        }
        private static void SaveAllArticles()
        {
            ArticlesAsList artList = new ArticlesAsList(allArticles);

            var ser = new XmlSerializer(typeof(ArticlesAsList));

            using (FileStream fs = new FileStream(@"articles.xml", FileMode.OpenOrCreate))
            {
                ser.Serialize(fs, artList);
            }
        }

        private static void SaveAllBills()
        {
            BillsAsList billList = new BillsAsList(allBills);

            var ser = new XmlSerializer(typeof(BillsAsList));

            using (FileStream fs = new FileStream(@"bills.xml", FileMode.OpenOrCreate))
            {
                ser.Serialize(fs, billList);
            }
        }

        private static List<Bill> LoadBills()
        {
            BillsAsList temp;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BillsAsList));
                using (var fs = new FileStream(@"bills.xml", FileMode.OpenOrCreate))
                {
                    temp = (BillsAsList)serializer.Deserialize(fs);
                }
               
                return temp.BillsList;
            }
            catch
            {
                return new List<Bill>();
            }
        }
        internal static void DeleteArticle(Article article)
        {
            allArticles.Remove(article);
        }

        internal static void LoadData()
        {
            allBills = LoadBills();
            allArticles = LoadArticles();
        }

        /// <summary>
        /// Pomoćna klasa koja pomaže pri ispravnoj serijalizaciji
        /// </summary>
        public class ArticlesAsList
        {
            [XmlArray("ArticleList")]
            [XmlArrayItem("Article")]

            public List<Article> ArticleList { get; set; }
            public ArticlesAsList(List<Article> listOfAllArticles)
            {
                this.ArticleList = listOfAllArticles;
            }
            public ArticlesAsList()
            {
            }
        }

        /// <summary>
        /// Pomoćna klasa koja pomaže pri ispravnoj serijalizaciji
        /// </summary>
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
