namespace DeleteAlbumsDomParser
{
    using System;
    using System.Xml;
    class Program
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../catalog.xml");
            XmlElement root = xmlDoc.DocumentElement;

            DeleteAlbumsWithPriceBiggerThan(root, 20.0);
            xmlDoc.Save("../../updatedCatalogue.xml");
           
        }

        private static void DeleteAlbumsWithPriceBiggerThan(XmlElement root, double maxPrice)
        {
            XmlNodeList childNodes = root.ChildNodes;            

            for (int i = 0; i < childNodes.Count; i++)
            {
                XmlNode album = childNodes[i];

                string xmlPrice = album["price"].InnerText;
                double price = double.Parse(xmlPrice);

                if (maxPrice < price)
                {
                    root.RemoveChild(album);
                }
            }
        }
    }
}
