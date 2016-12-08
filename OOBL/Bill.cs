using System;
using System.Collections.Generic;

namespace OOBL
{
    internal class Bill
    {
        private DateTime dateTime;
        private List<Article> listOfArticles = new List<Article>();
        private double VatAmount;
        private double TotalAmount;

        public void AddArticle(Article article)
        {
            listOfArticles.Add(article);
        }
        public void DeleteArticle(Article article)
        {
            listOfArticles.Remove(article);
        }

        //TODO : u pozadini pozvati complete bill info
        internal void calculateBillInformation()
        {
            double totalAmount=0;
            double vatAmount=0;

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
