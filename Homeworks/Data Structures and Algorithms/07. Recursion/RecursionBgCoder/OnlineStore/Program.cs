namespace OnlineStore
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class Program
    {
        static StringBuilder output = new StringBuilder();

        static OrderedMultiDictionary<decimal, Product> priceDict =
               new OrderedMultiDictionary<decimal, Product>(true);

        static OrderedMultiDictionary<string, Product> nameDict =
           new OrderedMultiDictionary<string, Product>(true);

        static OrderedMultiDictionary<string, Product> prodDict =
           new OrderedMultiDictionary<string, Product>(true);

        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string currentCommand = Console.ReadLine();
                ExecuteCurrentCommand(currentCommand);
            }

            Console.WriteLine(output);
        }

        private static void ExecuteCurrentCommand(string currentCommand)
        {
            int index = currentCommand.IndexOf(" ");
            string commandAction = currentCommand.Substring(0, index);
            string token = currentCommand.Substring(index + 1);


            switch (commandAction)
            {
                case "AddProduct":
                    ExecuteAddCommand(token);
                    break;
                case "DeleteProducts":
                    ExecuteDeleteCommand(token);
                    break;
                case "FindProductsByName":
                    ExecuteFindProductsByNameCommand(token);
                    break;
                case "FindProductsByPriceRange":
                    ExecuteFindProductsByPriceRangeCommand(token);
                    break;
                case "FindProductsByProducer":
                    ExecuteFindProductsByProducerCommand(token);
                    break;
                default:
                    break;
            }
        }

        private static void ExecuteFindProductsByProducerCommand(string token)
        {

            if (prodDict.ContainsKey(token))
            {
                foreach (var item in prodDict.Values)
                {
                    if (item.Producer == token)
                    {
                        output.Append(item.ToString());
                        output.Append(Environment.NewLine);
                    }
                }
            }
            else
            {
                output.Append("No products found");
                output.Append(Environment.NewLine);
            }
        }

        private static void ExecuteFindProductsByPriceRangeCommand(string token)
        {
            string[] curent = token.Split(';');
            var fromPrice = Math.Round(decimal.Parse(curent[0], CultureInfo.InvariantCulture), 2);
            var toPrice = Math.Round(decimal.Parse(curent[1], CultureInfo.InvariantCulture), 2);

            var searchedValues = priceDict.Range(fromPrice, true, toPrice, true);

            foreach (var price in searchedValues)
            {
                foreach (var item in price.Value)
                {
                    output.Append(item.ToString());
                }
            }
            if (searchedValues.Count == 0)
            {
                output.Append("No products found");
            }
            output.Append(Environment.NewLine);
        }

        private static void ExecuteFindProductsByNameCommand(string token)
        {
            if (nameDict.ContainsKey(token))
            {
                foreach (var item in nameDict.Values)
                {
                    if (item.Name == token)
                    {
                        output.Append(item.ToString());
                    }
                }
            }
            else
            {
                output.Append("No products found");
            }
            output.Append(Environment.NewLine);
        }

        private static void ExecuteDeleteCommand(string token)
        {
            string[] curent = token.Split(';');
            var producer = string.Empty;
            var name = string.Empty;
            int counter = 0;

            if (curent.Length == 1)
            {
                producer = curent[0];
                if (prodDict.ContainsKey(producer))
                {
                    counter = prodDict[producer].Count;
                    prodDict.Remove(producer);
                }
            }
            else
            {
                name = curent[0];
                producer = curent[1];
                if (prodDict.ContainsKey(producer))
                {
                    foreach (var item in prodDict.Values)
                    {
                        if (item.Producer == producer && item.Name == name)
                        {
                            prodDict.Values.Remove(item);
                            counter++;
                        }
                    }
                }
            }

            output.Append(string.Format("{0} products deleted", counter));
            output.Append(Environment.NewLine);
        }

        private static void ExecuteAddCommand(string token)
        {
            string[] current = token.Split(';');
            var name = current[0];
            decimal price = Math.Round(decimal.Parse(current[1], CultureInfo.InvariantCulture), 2);
            var producer = current[2];
            var newProduct = new Product(name, price, producer);
            priceDict.Add(price, newProduct);
            nameDict.Add(name, newProduct);
            prodDict.Add(producer, newProduct);
            output.Append("Product added");
            output.Append(Environment.NewLine);
        }
    }
}