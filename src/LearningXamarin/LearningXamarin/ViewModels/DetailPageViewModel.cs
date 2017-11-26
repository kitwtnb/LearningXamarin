using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningXamarin.ViewModels
{
	public class DetailPageViewModel : ViewModelBase
	{
        private string _url;
        public string URL
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        public DetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }
    }
}
