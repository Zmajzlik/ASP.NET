﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using AboutMe.Models;

namespace AboutMe.Controllers
{
    public class RSSController : Controller
    {
        // GET: RSS
        public ActionResult About() 
        {
            var url = "https://feed.rssunify.com/5c7d5a6091910/rss.xml";

            var rss = XElement.Load(url);

            var items = rss.Descendants("item").Select(item =>
            new RssItem
            {
                Title = item.Element("title").Value,
                PubDate = item.Element("pubDate").Value,
                Description = item.Element("description").Value
            });
            return View(items);
        }
    }
}