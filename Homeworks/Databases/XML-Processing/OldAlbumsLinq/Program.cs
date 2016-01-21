
namespace NewAlbumsLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class Program
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("../../../catalog.xml");

            var albumNames = from album in doc.Descendants("album")
                             where int.Parse(album.Element("year").Value) < 2000
                             select album.Element("name").Value;

            Console.WriteLine(string.Join(Environment.NewLine, albumNames));
        }
    }
}