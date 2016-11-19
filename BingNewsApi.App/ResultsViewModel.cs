using BingNewsApi.Lib;
using BingNewsApi.Lib.News;
using Caliburn.Micro;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingNewsApi.App
{
    public class ResultsViewModel : Screen
    {

        INewsRequestSearch<RootObject> search;
        string query = string.Empty;

        public string Query
        {
            get { return query; }
        }

        public ResultsViewModel(INewsRequestSearch<RootObject> search)
        {
            this.search = search;
        }

        public ResultsViewModel(string query, INewsRequestSearch<RootObject> search) : this(search)
        {
            this.query = query;
        }

        protected override async void OnInitialize()
        {
            base.OnInitialize();

            this.RootObject = await search.FetchAsync(query);
            NotifyOfPropertyChange(nameof(Query));
        }


        public string MicrosoftUri
        {
            get { return $"http://www.bing.com/news/search?q={query}"; }
        }

        private RootObject _rootObject;

        public RootObject RootObject
        {
            get { return _rootObject; }
            set
            {
                _rootObject = value;
                NotifyOfPropertyChange(nameof(RootObject));
                NotifyOfPropertyChange(nameof(List));
            }
        }



        public IList<IValue> List
        {
            get
            {
                if(RootObject == null)
                {
                    return null;
                }


                return RootObject.value.Cast<IValue>().ToList();
                
            }
        }  


    }
}
