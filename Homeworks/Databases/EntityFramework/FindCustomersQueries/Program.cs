namespace FindCustomersQueries
{
    using System;
    using System.Linq;
    using NorthwindDBContext;
    public class Program
    {
        public static void Main()
        {
            //Task 3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            Console.WriteLine("--- Task 3--\n");
            Console.WriteLine("All customers who have orders made in 1997 and shipped to Canada");
            FindAllCustomerOrderedToCanadaIn1997();

            //Task 4. Implement previous by using native SQL query and executing it through the DbContext.
            Console.WriteLine("\n--- Task 4--\n");
            Console.WriteLine("All customers who have orders made in 1997 and shipped to Canada");
            FindAllCustomerOrderedToCanadaIn1997UsingSQLQuery();

            //Task 5. Write a method that finds all the sales by specified region and period (start / end dates).
            Console.WriteLine("\n--- Task 5--\n");
            string region = "RJ";
            DateTime periodBegin = new DateTime(1996, 01, 01);           
            DateTime periodEnd = new DateTime(1999, 12, 31);

            Console.WriteLine("Sold Products in Region {0} from {1} to {2}",
                               region, 
                               periodBegin.ToShortDateString(), 
                               periodEnd.ToShortDateString());

            FindAllSalesByRegionAndPeriod(region, periodBegin, periodEnd);
        }

        private static void FindAllCustomerOrderedToCanadaIn1997()
        {
            using (var db = new NorthwindEntities())
            {
                var customers = db.Orders
                                  .Where(x => x.ShippedDate > new DateTime(1997, 1, 1))
                                  .Where(x => x.ShippedDate <= new DateTime(1997, 12, 31))
                                  .Where(x => x.ShipCountry == "Canada")
                                  .OrderBy(x => x.Customer.CompanyName)
                                  .Select(c =>  c.Customer.CompanyName)
                                  .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine("   --> {0}", customer);
                }
            }
        }

        private static void FindAllCustomerOrderedToCanadaIn1997UsingSQLQuery()
        {
            using (var db = new NorthwindEntities())
            {
                string query = @"SELECT c.CompanyName AS [Company] 
                                 FROM Orders o 
                                 JOIN Customers c
                                 ON o.CustomerID = c.CustomerID
                                 WHERE (OrderDate BETWEEN '1997.01.01' AND '1997.12.31') AND 
                                        ShipCountry = 'Canada'
                                 ORDER BY c.CompanyName";

                var customers = db.Database.SqlQuery<View>(query);

                foreach (var customer in customers)
                {
                    Console.WriteLine("   --> {0}", customer.Company);
                }
            }
        }

        private static void FindAllSalesByRegionAndPeriod(string region, DateTime periodBegin, DateTime periodEnd)
        {
            using (var db = new NorthwindEntities())
            {
                var sales = db.Order_Details
                              .Where(x => x.Order.ShipRegion == region)
                              .Where(x => x.Order.OrderDate >= periodBegin)
                              .Where(x => x.Order.OrderDate <= periodEnd)
                              .Select(x => x.Product.ProductName)
                              .OrderBy(x => x)
                              .ToList();

                foreach (var product in sales)
                {
                    Console.WriteLine("   --> {0}", product);
                }

            }

        }
    }
}
