using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using XamarinUP2018.Models;
using XamarinUP2018.Services;
using XamarinUP2018.Views;

namespace XamarinUP2018.ViewModels
{
    public sealed class FeedViewModel : ViewModelBase
    {
        private readonly IHeroService unsplashService;
        public ICommand GoPicture { get; }
        private ObservableCollection<Hero> items = new ObservableCollection<Hero>();
        public ObservableCollection<Hero> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        private bool showNoData = false;
        public bool ShowNoData
        {
            get => showNoData;
            set => SetProperty(ref showNoData, value);
        }

        public FeedViewModel(INavigationService navigationService 
            , IHeroService unsplashService) 
            : base(navigationService)
        {
            this.unsplashService = unsplashService;
            this.GoPicture = new DelegateCommand<Hero>(async (picture) => await ExecuteGoPicture(picture));
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            await LoadFeedItems();
        }

        private async Task LoadFeedItems()
        {
            await ExecuteBusyAction(async () => 
            {
                UpdateItens(await unsplashService.GetHeros());
            });
        }

        private void UpdateItens(List<Hero> items)
        {
            Items.Clear();
            ShowNoData = items.Count == 0;

            foreach (var item in items)
                Items.Add(item);
        }

        private Task ExecuteGoPicture(Hero hero)
        {
            var param = new NavigationParameters();
            param.Add("hero", hero);

            return NavigationService.NavigateAsync($"{nameof(PicturePage)}", param);
        }

        public ICommand RefreshCommand
        {
            get => new Command(async () =>
                {
                    ShowNoData = false;
                    IsBusy = true;

                    UpdateItens(await unsplashService.GetHeros());

                    IsBusy = false;
                });
        }
    }
}
