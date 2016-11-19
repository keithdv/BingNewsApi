using BingNewsApi.Lib.News;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingNewsApi.Lib
{

    public interface INewsRequest : IRestRequest { }

    public interface INewsRequestSearch<T> where T : class, new()
    {
        IRestResponse<T> FetchResponse(string query);
        Task<T> FetchAsync(string query);
        T Fetch(string query);
    }

    public class NewsRequestSearch<T> : INewsRequestSearch<T>
        where T : class, new()
    {

        Lazy<INewsClient> client;
        Func<INewsRequest> request;

        public NewsRequestSearch(Lazy<INewsClient> client, Func<INewsRequest> request)
        {
            this.client = client;
            this.request = request;
        }


        public IRestResponse<T> FetchResponse(string query)
        {
            var r = request();

            r.AddQueryParameter("q", query);

            return client.Value.Execute<T>(r);
        }


        public async Task<T> FetchAsync(string query)
        {
            var r = request();

            r.AddQueryParameter("q", query);

            return await client.Value.GetTaskAsync<T>(r);

        }

        public T Fetch(string query)
        {

            var r = request();

            r.AddQueryParameter("q", query);

            return client.Value.Execute<T>(r).Data;
        }

    }

    internal class NewsRequest : RestRequest, INewsRequest
    {

        public NewsRequest(string resource) : base(resource) { }

    }
}
