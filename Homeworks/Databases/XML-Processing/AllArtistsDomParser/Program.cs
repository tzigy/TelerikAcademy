namespace AllArtistsDomParser
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    public class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            XmlElement root = doc.DocumentElement;

            foreach (var pair in GetNumberOfAlbumsFromCatalog(root))
            {
                Console.WriteLine("{0} - {1} album(s)!", pair.Key, pair.Value);
            }
        }

        private static Dictionary<string, int> GetNumberOfAlbumsFromCatalog(XmlElement root)
        {
            Dictionary<string, int> artistsAndNumberOfAlbums = new Dictionary<string, int>();
            XmlNodeList artists = root.GetElementsByTagName("artist");

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
