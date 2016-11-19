using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingNewsApi.Lib
{
    public class AutoFacModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(x =>
            {
                return new NewsClient("https://api.cognitive.microsoft.com/bing/v5.0");
            }).As<INewsClient>().InstancePerLifetimeScope();

            builder.Register(x =>
            {
                var request =  new NewsRequest("news/search");

                request.AddHeader("Ocp-Apim-Subscription-Key", "31adb52e8b3646db8a480823ad77c97b");

                return request;

            }).As<INewsRequest>();

            builder.RegisterGeneric(typeof(NewsRequestSearch<>)).As(typeof(INewsRequestSearch<>)).InstancePerLifetimeScope();

        }

    }
}
