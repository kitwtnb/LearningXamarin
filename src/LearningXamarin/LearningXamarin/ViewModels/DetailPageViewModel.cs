using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningXamarin.ViewModels
{
	public class DetailPageViewModel : ViewModelBase
	{
        public static readonly string NavigateKey = "DetailPage";
        private static readonly string ParamKeyTitle = "title";
        private static readonly string ParamKeyUrl = "url";

        public ReactiveProperty<string> Url { get; } = new ReactiveProperty<string>();

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
            Url.Value = (string) parameters[ParamKeyUrl];
        }
    }
}
