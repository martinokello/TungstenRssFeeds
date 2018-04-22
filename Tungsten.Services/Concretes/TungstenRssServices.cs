using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tungsten.DataAccess.Interfaces;
using Tungsten.Models.DomainModels;
using Tungsten.Services.Interfaces;

namespace Tungsten.Services
{
    public class TungstenRssServices : IRssService
    {
        private IRssFeedRepository _rssService;
        public TungstenRssServices(IRssFeedRepository rssService)
        {
            _rssService = rssService;
        }
        public RssFeed GetRssFeed(string url)
        {
            return _rssService.GetRssFeeds(url);
        }
    }
}
