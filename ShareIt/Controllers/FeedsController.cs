using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mstum.utils;
using ShareIt.Models;

namespace ShareIt.Controllers
{
    public class FeedsController : ApiController
    {
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        // GET api/values
        public IEnumerable<Feed> GetAll()
        {
            return null;
            var repository = Repository.Get<Feed>();
            return repository.All().ToList();
        }

        // GET api/values/5
        public Feed Get(Guid id)
        {
            var feeds = Repository.Get<Feed>();
            var feed = feeds.Where(x => x.Id).Eq(id).FirstOrDefault();
            return feed;
        }
        
        // POST api/values
        public object Post(Feed feed)
        {
            feed.Id = Guid.NewGuid();
            var repository = Repository.Get<Feed>();
            repository.Save(feed);
            return new { id = feed.Id };
        }

        // PUT api/values/5
        public void Put(Guid id, FeedItem item)
        {
            var feeds = Repository.Get<Feed>();
            var feed = feeds.Where(x => x.Id).Eq(id).FirstOrDefault();
            if (feed != null)
            {
                item.PublishedDate = DateTime.Now;
                feed.Items.Add(item);
                feeds.Save(feed);
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}