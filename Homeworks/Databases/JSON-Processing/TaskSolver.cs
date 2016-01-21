namespace JSON_Processing
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class TaskSolver
    {
        public IEnumerable<Video> GetVideos(JObject json)
        {
            var videos = json["feed"]["entry"]
                .Select(entry => JsonConvert.DeserializeObject<Video>(entry.ToString()));

            return videos;
        }

        public string GetHtmlString(IEnumerable<Video> videos)
        {
            StringBuilder html = new StringBuilder();

            html.Append("<!DOCTYPE html>");
            html.Append("<html>");
            html.Append("   <head>");
            html.Append("       <title>JSON Processing</title>");
            html.Append("<style> div {float:left; width: 450px; height: 450px; padding:15px; margin:10px; background-color: #ccc; border-radius:15px;}</style>");
            html.Append("   </head><body>");

            foreach (var video in videos)
            {
                html.AppendFormat("<div>" +
                                  "<iframe width=\"400\" height=\"345\" " +
                                  "src=\"http://www.youtube.com/embed/{1}?autoplay=0\" " +
                                  "frameborder=\"0\" allowfullscreen></iframe>" +
                                  "<h3>{2}</h3><a href=\"{0}\">Go to YouTube</a></div>",
                                  video.Link.Href, video.Id, video.Title);
            }
            html.Append("</body></html>");

            return html.ToString();
        }

        public void DownloadRss(string url, string fileName)
        {
            WebClient myWebClient = new WebClient { Encoding = Encoding.UTF8 };
            myWebClient.DownloadFile(url, fileName);
        }

        public XmlDocument GetXml(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            return xmlDoc;
        }

        public JObject GetJsonObject(XmlDocument xmlDoc)
        {
            string json = JsonConvert.SerializeXmlNode(xmlDoc);
            var jsonObj = JObject.Parse(json);

            return jsonObj;
        }

        public IEnumerable<JToken> GetVideosTitles(JObject jsonObj)
        {
            return jsonObj["feed"]["entry"]
                .Select(entry => entry["title"]);
        }

        public void PrintTitles(IEnumerable<JToken> titles)
        {
            Console.WriteLine(string.Join(Environment.NewLine, titles));
        }

        public void SaveHtml(string html, string htmlName)
        {
            using (StreamWriter writer = new StreamWriter("../../" + htmlName, false, Encoding.UTF8))
            {
                writer.Write(html);
            }

            var currentDir = Directory.GetCurrentDirectory();
            var htmlDir = currentDir.Substring(0, currentDir.IndexOf("bin\\Debug")) + htmlName;

            Console.WriteLine("Html dir: {0}", htmlDir);
        }
    }
}
