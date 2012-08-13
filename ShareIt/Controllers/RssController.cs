using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using ShareIt.Models;

namespace ShareIt.Controllers
{
    [HandleError]
    public class RssController : Controller
    {
        public ActionResult Index(Guid id)
        {
            var feeds = Repository.Get<Feed>();
            var feed = feeds.Where(x => x.Id).Eq(id).FirstOrDefault();
            var items = feed.Items.OrderBy(p => p.PublishedDate).Take(15)
                .Select(p => new SyndicationItem(p.Title, p.Description, new Uri(p.Url)));

            var rss = new SyndicationFeed(feed.Name, string.Empty, new Uri(string.Format("http://shareit.apphb.com/#/feed/{0}", id)), items)
            {
                //Copyright = blog.Copyright,
                Language = "en-US"
            };

            return new FeedResult(new Rss20FeedFormatter(rss));
        }

    }

    public class FeedResult : ActionResult
    {
        public Encoding ContentEncoding { get; set; }
        public string ContentType { get; set; }

        private readonly SyndicationFeedFormatter feed;
        public SyndicationFeedFormatter Feed
        {
            get { return feed; }
        }

        public FeedResult(SyndicationFeedFormatter feed)
        {
            this.feed = feed;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/rss+xml";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            if (feed != null)
                using (var xmlWriter = new XmlTextWriter(response.Output))
                {
                    xmlWriter.Formatting = Formatting.Indented;
                    feed.WriteTo(xmlWriter);
                }
        }
    }
}
