namespace CompanyArticles
{
    using System;
    using System.Text;

    public class Article : IComparable<Article>
    {
        public Article(string title, decimal price)
        {
            //this.Barcode = barcode;            
            this.Name = title;
            this.Price = price;
        }

        //public int Barcode { get; set; }        

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Article other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Product: {0}; Price: {1}", this.Name, this.Price);

            return output.ToString();
        }
    }
}
