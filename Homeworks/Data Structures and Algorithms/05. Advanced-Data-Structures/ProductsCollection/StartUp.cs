namespace ProductsCollection
{
    using System;
    using System.IO;
    using Wintellect.PowerCollections;
    using System.Linq;

    public class StartUp
    {
        static readonly OrderedBag<Product> products = new OrderedBag<Product>();
        static readonly Random random = new Random();

        public static void Main()
        {
            AddProductsToBag(50000);
            Console.WriteLine("Writing....");
            WriteProductsInRangeToFile("../../result.txt", 1000);
        }

        private static void WriteProductsInRangeToFile(string filePath, int numberOfSearches)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < numberOfSearches; i++)
                {
                    writer.WriteLine("Search number: {0}", i);

                    Product fromProduct = new Product("From", 1);
                    Product toProduct = new Product("From", 3);
                    var result = products.Range(fromProduct, true, toProduct, true).Take(20);

                    foreach (var product in result)
                    {
                        writer.WriteLine(product);
                    }
                }
            }
        }

        private static void AddProductsToBag(int numberOfProducts)
        {
            for (int i = 0; i < numberOfProducts; i++)
            {
                products.Add(new Product("Product", Math.Round((decimal)random.NextDouble() * 100, 2)));
            }
        }
    }
}
