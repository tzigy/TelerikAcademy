namespace ProductsCollection
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}", this.Name, this.Price);
        }
    }
}
