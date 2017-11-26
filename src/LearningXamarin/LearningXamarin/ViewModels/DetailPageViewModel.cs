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
        private static readonly string ParamKeyTitle = "title";
        private static readonly string ParamKeyUrl = "url";

        private string _url;
        public string URL
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        public static NavigationParameters CreateParameter(string title, string url)
        {
            return new NavigationParameters()
            {
                { ParamKeyTitle, title },
                { ParamKeyUrl, url },
            };
        }

        public DetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = (string)parameters[ParamKeyTitle];
            URL = (string) parameters[ParamKeyUrl];
        }
    }
}
