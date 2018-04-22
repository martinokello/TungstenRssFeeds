using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Tungsten.DataAccess.Interfaces;
using Tungsten.Models.DomainModels;
using Tungsten.HttpRequests.Interfaces;
using XmlParser;

namespace Tungsten.DataAccess.Concretes
{
    public class TungstenRssFeedsRepository : IRssFeedRepository
    {
        ITungstenHttpRequest _tungstenHttpRequest;
        public TungstenRssFeedsRepository(ITungstenHttpRequest tungstenHttpRequest)
        {
            _tungstenHttpRequest = tungstenHttpRequest;
        }
        public RssFeed GetRssFeeds(string url)
        {
           var result = _tungstenHttpRequest.Request(url, Method.Get);

            if (!string.IsNullOrEmpty(result))
            {
                return RssFeedsParser.GetRssFeedModel(result);
            }
            return null;
        }
    }
}
