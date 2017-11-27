using LearningXamarin.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Collections.ObjectModel;
using Reactive.Bindings;

namespace LearningXamarin.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ReactiveProperty<string> SearchText { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<bool> IsRefreshing { get; } = new ReactiveProperty<bool>();

        public ObservableCollection<QiitaContent> Contents { get; } = new ObservableCollection<QiitaContent>();

        public ReactiveCommand SearchCommand { get; }
        public ReactiveCommand<QiitaContent> ShowDetailCommand { get; }

        private QiitaModel model;

        public MainPageViewModel(INavigationService navigationService, QiitaModel model) 
            : base (navigationService)
        {
            Title = "Main Page";
            this.model = model;

            SearchCommand = IsRefreshing.Select(b => b == false).ToReactiveCommand();
            SearchCommand.Subscribe(SearchExecute);

            ShowDetailCommand = new ReactiveCommand<QiitaContent>();
            ShowDetailCommand.Subscribe(ShowDetailExecute);
        }

        private void SearchExecute()
        {
            IsRefreshing.Value = true;
            Contents.Clear();
            model.FetchBy(SearchText.Value)
                 .SubscribeOn(DefaultScheduler.Instance)
                 .ObserveOn(SynchronizationContext.Current)
                 .Finally(() => {
                     IsRefreshing.Value = false;
                 })
                 .Subscribe(content => Contents.Add(content));
        }

        private void ShowDetailExecute(QiitaContent content)
        {
            var parameter = DetailPageViewModel.CreateParameter(content.Title, content.URL);
            NavigationService.NavigateAsync(DetailPageViewModel.NavigateKey, parameter);
        }
    }
}
