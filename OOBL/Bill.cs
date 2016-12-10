using System;
using System.Collections.Generic;

namespace OOBL
{
    public class Bill
    {
        internal DateTime dateTime;
        internal List<Article> listOfArticles = new List<Article>();
        internal double VatAmount;
        internal double TotalAmount;

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
        public void DeleteArticle(Article article)
        {
            listOfArticles.Remove(article);
        }


        //TODO : u pozadini pozvati complete bill info
        internal void calculateBillInformation()
        {
            double totalAmount=0;
            double vatAmount=0;

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
