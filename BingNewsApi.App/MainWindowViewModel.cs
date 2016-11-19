using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingNewsApi.App
{
    public class MainWindowViewModel : Conductor<IScreen>.Collection.OneActive
    {


        public MainWindowViewModel(Func<string, ResultsViewModel> createResultsViewModel)
        {
            this.createResultsViewModel = createResultsViewModel;
            base.DisplayName = "Bing News Search";
        }

        Func<string, ResultsViewModel> createResultsViewModel;

        protected override void OnActivate()
        {
            base.OnActivate();
        }
        protected override void OnInitialize()
        {
            base.OnInitialize();

        }

        public void DeutscheBank()
        {
            this.ActivateItem(createResultsViewModel("Deutsche Bank"));
        }

        public void SwissRe()
        {
            this.ActivateItem(createResultsViewModel("Swiss Re"));
        }
    }
}
