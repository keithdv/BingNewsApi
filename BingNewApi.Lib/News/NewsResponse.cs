﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BingNewsApi.Lib.News
{


    public class Thumbnail
    {
        public string contentUrl { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Image
    {
        public Thumbnail thumbnail { get; set; }
    }

    public class About
    {
        public string readLink { get; set; }
        public string name { get; set; }
    }

    public class Provider
    {
        public string _type { get; set; }
        public string name { get; set; }
    }

    public class About2
    {
        public string readLink { get; set; }
        public string name { get; set; }
    }

    public class Provider2
    {
        public string _type { get; set; }
        public string name { get; set; }
    }

    public class ClusteredArticle
    {
        public string name { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public List<About2> about { get; set; }
        public List<Provider2> provider { get; set; }
        public string datePublished { get; set; }
        public string category { get; set; }
    }

    public class Value : IValue
    {
        public string name { get; set; }
        public string url { get; set; }
        public Image image { get; set; }
        public string description { get; set; }
        public List<About> about { get; set; }
        public List<Provider> provider { get; set; }
        public string datePublished { get; set; }
        public string category { get; set; }
        public List<ClusteredArticle> clusteredArticles { get; set; }
    }

    public class RootObject
    {
        public string _type { get; set; }
        public string readLink { get; set; }
        public int totalEstimatedMatches { get; set; }
        public List<Value> value { get; set; }
    }

}
