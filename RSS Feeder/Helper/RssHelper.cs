using System.Net;
using System.Xml.XPath;
using RSS_Feeder.Models;
using RSS_Feeder.Settings;

namespace RSS_Feeder.Helper;

public class RssHelper
{
    public static List<Item> Read(string url)
    {
        List<Item> items = new List<Item>();

        try
        {
            var httpClientHandler = new HttpClientHandler();
            
            if (SettingsOptions.UseProxy)
            {
                var proxy = new WebProxy(SettingsOptions.ProxyAddress)
                {
                    Credentials = new NetworkCredential(
                        SettingsOptions.ProxyLogin, SettingsOptions.ProxyPassword)
                };
                
                httpClientHandler.UseProxy = true;
                httpClientHandler.Proxy = proxy;
            }

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                var response = httpClient.GetStringAsync(url).Result;
                
                using (var stringReader = new System.IO.StringReader(response))
                {
                    XPathDocument doc = new XPathDocument(stringReader);
                    XPathNavigator navigator = doc.CreateNavigator();
                    XPathNodeIterator nodes = navigator.Select("//item");
                    foreach (XPathNavigator node in nodes)
                    {
                        Item item = new Item
                        {
                            Description = node.SelectSingleNode("description")?.Value,
                            Link = node.SelectSingleNode("link")?.Value,
                            PubDate = node.SelectSingleNode("pubDate")?.Value,
                            Title = node.SelectSingleNode("title")?.Value
                        };
                        items.Add(item);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return items;
    }
}