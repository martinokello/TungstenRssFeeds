using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tungsten.Models.DomainModels;

namespace XmlParser
{
    public class RssFeedsParser
    {
        public static RssFeed GetRssFeedModel(string xmlContent)
        {
            var rootElement = XElement.Parse(xmlContent);
            var rssItems = new List<RssFeedItem>();
            var channel = rootElement.Descendants("channel");

            var rssFeed = new RssFeed
            {
                Title = channel.Descendants("title").First().Value,
                Url = channel.Descendants("description").First().Value
            };

            var items = channel.Descendants("item").Select(p =>
                    new RssFeedItem { Title = p.Descendants("title").First().Value, Description = p.Descendants("description").First().Value }
                );


            rssItems.AddRange(items);
            rssFeed.Items = rssItems.ToArray();
            return rssFeed;
        }
    }
}
