using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OOBL
{
    [Serializable]
    [XmlRoot("Bill")]
    public class Bill
    {
        [XmlElement("dateTime")]
        public DateTime dateTime;
        [XmlElement("listOfArticles")]
        public List<Article> listOfArticles = new List<Article>();
        [XmlElement("VatAmount")]
        public double VatAmount;
        [XmlElement("TotalAmount")]
        public double TotalAmount;

        public Bill()
        {

        }

        public void AddArticle(Article article)
        {
            if (!listOfArticles.Contains(article))
            {
                listOfArticles.Add(article);
            }
            else
            {
                return;
            }
        }
        
        internal void calculateBillInformation()
        {
            double totalAmount = 0;
            double vatAmount = 0;

            dateTime = DateTime.Now;

            foreach (var article in listOfArticles)
            {
                double vatRateTemp = 100 * article.VatRate / (100 + article.VatRate);
                vatAmount += article.Price * vatRateTemp / 100;

                totalAmount += article.Price;

            }
            TotalAmount = totalAmount;
            VatAmount = vatAmount;
        }
    }
}
