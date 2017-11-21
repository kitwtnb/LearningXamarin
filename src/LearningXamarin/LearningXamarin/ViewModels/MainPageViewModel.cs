using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningXamarin.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) 
        public MainPageViewModel(INavigationService navigationService, Model model) 
            : base (navigationService)
        {
            Title = "Main Page";
        }
    }
}
