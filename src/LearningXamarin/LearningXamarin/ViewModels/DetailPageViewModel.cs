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
        public DetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }
    }
}
