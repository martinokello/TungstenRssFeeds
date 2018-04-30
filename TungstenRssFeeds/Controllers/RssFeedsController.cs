using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Tungsten.Caching;
using Tungsten.Models.DomainModels;
using Tungsten.Services.Interfaces;
using TungstenRssFeeds.Models;

namespace TungstenRssFeeds.Controllers
{
    public class RssFeedsController : ApiController
    {
        private IRssService _rssService;
        public RssFeedsController()
        {

        }

        public RssFeedsController(IRssService rssService)
        {
            _rssService = rssService;
        }
        
        [Route("api/RssFeeds/PostRssFeeds")]
        public IHttpActionResult PostRssFeeds([FromBody] string rssFeedUrl)
        {
            try
            {
                var cacheStore = new Caching<RssFeed>();
                Func<RssFeed> getFromCache = () =>
                {
                    return _rssService.GetRssFeed(rssFeedUrl);
                };
                
                //Get From Cache if Available otherwise Call Service
                var result = cacheStore.GetFromCache(ConfigurationManager.AppSettings["CacheKey"],Int32.Parse(ConfigurationManager.AppSettings["CacheTimeSeconds"]), getFromCache);
                if (result == null)
                {
                    return NotFound();
                    //return Ok(new ResponseObject { RssFeed = new RssFeed(), ErrorMessage = "No results got", StatusCode = "200" });
                }

                return Ok(new ResponseObject { RssFeed = result, ErrorMessage = null, StatusCode = "200" });
            }
            catch (Exception ex)
            {
                //Log ex stack trace and ex Message then return bad request
                return BadRequest("The request could not be handled, contact system Admin");
            }
        }

        // GET: api/RssFeeds/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RssFeeds
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RssFeeds/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RssFeeds/5
        public void Delete(int id)
        {
        }
    }
}
