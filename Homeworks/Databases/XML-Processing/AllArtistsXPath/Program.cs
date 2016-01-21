namespace AllArtistsXPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.XPath;
    class Program
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../catalog.xml");
            XmlElement root = xmlDoc.DocumentElement;

            foreach (var pair in GetNumbersOfAlbumsForEachArtis(xmlDoc))
            {
                Console.WriteLine("{0} - {1} album(s)!", pair.Key, pair.Value);
            }
            
        }

        private static Dictionary<string, int> GetNumbersOfAlbumsForEachArtis(XmlDocument root)
        {
            Dictionary<string, int> artistsAndNumberOfAlbums = new Dictionary<string, int>();
            string xPathQuery = "/catalog/album/artist";
            var artists = root.SelectNodes(xPathQuery);

            foreach (XmlNode artist in artists)
            {
                string artistName = artist.InnerText;

                if (artistsAndNumberOfAlbums.ContainsKey(artistName))
                {
                    artistsAndNumberOfAlbums[artistName] += 1;
                }
                else
                {
                    artistsAndNumberOfAlbums.Add(artistName, 1);
                }
            }

            return artistsAndNumberOfAlbums;
        }
    }
}
