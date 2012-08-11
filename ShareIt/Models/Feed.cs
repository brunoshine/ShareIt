using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareIt.Models
{
    public class Feed
    {
        public string Name { get; set; }
        public bool Private { get; set; }

        public User Owner { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<FeedItem> Items { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class FeedItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}