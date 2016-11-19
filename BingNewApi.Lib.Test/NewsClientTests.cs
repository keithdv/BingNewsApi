using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using BingNewsApi.Lib.News;
using Autofac;
using System.Threading.Tasks;

namespace BingNewsApi.Lib.Test
{
    [TestClass]
    public class NewsClientTests
    {
        private static IContainer container;
        private ILifetimeScope scope;
        private INewsClient client;
        private INewsRequest request;

        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<AutoFacModule>();

            container = builder.Build();

        }

        [TestInitialize]
        public void TestInitialize()
        {
            scope = container.BeginLifetimeScope();
            client = scope.Resolve<INewsClient>();
            request = scope.Resolve<INewsRequest>();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            scope.Dispose();
        }

        [TestMethod]
        public void BasicContent()
        {



            request.AddQueryParameter("q", "deutsche bank");
            request.AddQueryParameter("count", "2");
           
            var result = client.Execute(request);

            Debug.Write(result.Content);

        }


        [TestMethod]
        public void NewsResponse()
        {

            request.AddQueryParameter("q", "deutsche bank");
            request.AddQueryParameter("count", "2");

            var result = client.Execute<RootObject>(request);

            Assert.IsNotNull(result.Data);
            
        }

        [TestMethod]
        public void NewsRequestSearchTest()
        {

            var search = scope.Resolve<INewsRequestSearch<RootObject>>();

            var result = search.Fetch("deutsche bank");

        }


        [TestMethod]
        public async Task NewsRequestSearchTestAsync()
        {

            var search = scope.Resolve<INewsRequestSearch<RootObject>>();

            var result = await search.FetchAsync("deutsche bank");

        }
    }
}
