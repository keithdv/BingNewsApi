using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingNewsApi.Lib
{

    public interface INewsClient : IRestClient
    {

    }

    internal class NewsClient : RestSharp.RestClient, INewsClient
    {

        
        public NewsClient(string url) : base(url)
        {

         
        }




    }
}
