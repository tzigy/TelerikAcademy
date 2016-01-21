namespace CompanyArticles
{
    using System;

    public class Program
        {
        static Random rng = new Random();
        

        public static void Main()
        {
            TradeCompany myCompany = new TradeCompany();


            for (int i = 0; i < 100; i++)
            {
                
                string articleName = "name-" + i;
                decimal articlePrice = (decimal)rng.Next(0, 10000)/100;
                Article newArticle = new Article(articleName, articlePrice);
                myCompany.AddArticle(newArticle);
            }

            foreach (var article in myCompany.SearchArticlesInPriceRange(10, 200))
            {
                Console.WriteLine(article.ToString());
            }
        }        
    }
}
