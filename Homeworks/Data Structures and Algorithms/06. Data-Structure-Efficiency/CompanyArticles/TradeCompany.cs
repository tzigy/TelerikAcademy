namespace CompanyArticles
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class TradeCompany
    {
        private OrderedMultiDictionary<decimal, Article> articles;

        public TradeCompany()
        {
            this.articles = new OrderedMultiDictionary<decimal, Article>(true);
        }

        public void AddArticle(Article article)
        {
            this.articles.Add(article.Price, article);
        }

        public ICollection<Article> SearchArticlesInPriceRange(decimal startPrice, decimal endPrice)
        {
            return this.articles.Range(startPrice, true, endPrice, true).Values;
        }
    }
}
