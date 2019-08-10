using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamarinUP2018.ViewModels
{
    public sealed class HomeViewModel : ViewModelBase
    {

        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
