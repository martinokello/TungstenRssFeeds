using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tungsten.Models.DomainModels
{
    public class RssFeed
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public RssFeedItem[] Items { get; set; }
    }

}
