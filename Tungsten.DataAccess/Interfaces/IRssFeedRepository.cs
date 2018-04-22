using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tungsten.Models.DomainModels;

namespace Tungsten.DataAccess.Interfaces
{
    public interface IRssFeedRepository
    {
        RssFeed GetRssFeeds(string url);
    }
}
