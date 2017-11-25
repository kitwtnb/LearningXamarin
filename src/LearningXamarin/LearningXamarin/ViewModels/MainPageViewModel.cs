﻿using LearningXamarin.Models;
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

namespace LearningXamarin.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        public ObservableCollection<QiitaContent> Contents { get; } = new ObservableCollection<QiitaContent>();

        private bool canExecuteSearch = true;
        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get { return _searchCommand ?? (_searchCommand = new DelegateCommand(SearchExecute, () => canExecuteSearch)); }
        }

        private ICommand _showDetailCommand;
        public ICommand ShowDetailCommand
        {
            get { return _showDetailCommand ?? (_showDetailCommand = new DelegateCommand<QiitaContent>(ShowDetailExecute)); }
        }

        private QiitaModel model;

        public MainPageViewModel(INavigationService navigationService, QiitaModel model) 
            : base (navigationService)
        {
            Title = "Main Page";
            this.model = model;
        }

        private void SearchExecute()
        {
            canExecuteSearch = false;
            Contents.Clear();
            model.FetchBy(SearchText)
                 .SubscribeOn(DefaultScheduler.Instance)
                 .ObserveOn(SynchronizationContext.Current)
                 .Finally(() => canExecuteSearch = true)
                 .Subscribe(content => Contents.Add(content));
        }

        private void ShowDetailExecute(QiitaContent content)
        {
        }
    }
}
