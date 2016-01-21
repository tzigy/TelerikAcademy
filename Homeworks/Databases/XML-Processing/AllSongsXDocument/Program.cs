namespace AllSongsXDocument
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class Program
    {
        static void Main()
        {            
            XDocument xDoc = XDocument.Load("../../../catalog.xml");            
            var albums = xDoc.Element("catalog").Elements("album");

            var titles = from title in albums.Descendants("title") select title.Value;

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
