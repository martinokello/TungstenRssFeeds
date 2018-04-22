using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tungsten.Models.DomainModels;

namespace TungstenRssFeeds.Models
{
    public class ResponseObject
    {
        public string StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public RssFeed RssFeed {get;set;}
    }
}