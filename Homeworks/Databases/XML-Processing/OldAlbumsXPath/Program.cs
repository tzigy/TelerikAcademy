namespace NewAlbumsXPath
{
    using System;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../catalog.xml");
            string query = "/catalog/album[year<2000]/name";

            XmlNodeList albumNames = xmlDoc.SelectNodes(query);

            foreach (XmlNode name in albumNames)
            {
                Console.WriteLine(name.InnerText);
            }
        }
    }
}