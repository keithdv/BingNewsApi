using System.Collections.Generic;

namespace BingNewsApi.Lib.News
{
    public interface IValue
    {
        List<About> about { get; set; }
        string category { get; set; }
        List<ClusteredArticle> clusteredArticles { get; set; }
        string datePublished { get; set; }
        string description { get; set; }
        Image image { get; set; }
        string name { get; set; }
        List<Provider> provider { get; set; }
        string url { get; set; }
    }
}