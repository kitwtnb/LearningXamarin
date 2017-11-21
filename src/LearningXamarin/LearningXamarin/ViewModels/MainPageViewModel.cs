using LearningXamarin.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

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

        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get { return _searchCommand ?? new DelegateCommand(SearchExecute); }
        }

        public MainPageViewModel(INavigationService navigationService, Model model) 
            : base (navigationService)
        {
            Title = "Main Page";
            Text = model.Text;
        }

        private void SearchExecute()
        {
            Text = SearchText;
        }
    }
}
