using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Autofac;
using Caliburn.Micro.Autofac;

namespace BingNewsApi.App
{
    public class Bootstrapper : AutofacBootstrapper<MainWindowViewModel>
    {

        public Bootstrapper() : base()
        {
            base.Initialize();
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);

            builder.RegisterModule<Lib.AutoFacModule>();
            builder.RegisterType<ResultsViewModel>();
            builder.RegisterType<MainWindowViewModel>();

        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);

            DisplayRootViewFor<MainWindowViewModel>();

        }
    }
}