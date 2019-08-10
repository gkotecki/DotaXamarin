using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinUP2018.Models;
using XamarinUP2018.Services;

namespace XamarinUP2018.ViewModels
{
    class HeroViewModel : ViewModelBase
    {
        private readonly IFavoriteService favoriteService;
        public ICommand FavoritePicture { get; }

        Hero _heroObj;
        public Hero HeroObj
        {
            get { return _heroObj; }
            set { SetProperty(ref _heroObj, value); }
        }

        bool _wasFavorited;
        public bool WasFavorited
        {
            get { return _wasFavorited; }
            set { SetProperty(ref _wasFavorited, value); }
        }

        public HeroViewModel(
            INavigationService navigationService
            , IFavoriteService favoriteService) : base(navigationService)
        {
            this.favoriteService = favoriteService;
            this.WasFavorited = false;
            this.FavoritePicture = new DelegateCommand(async () => await FavoriteExecute())
                .ObservesCanExecute(() => IsNotBusy);
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            // TODO: CHECAR O QUE EH ISSO AQUI

            HeroObj = (Hero)parameters["hero"];

            //if (HeroObj.Description == null)
            //    HeroObj.Description = HeroObj.AltDescription;
            await LoadIsFavorited();
        }

        private async Task LoadIsFavorited()
        {
            await ExecuteBusyAction(async () =>
            {
                WasFavorited = await favoriteService.Exists(HeroObj);
            });
        }

        private async Task FavoriteExecute()
        {
            await ExecuteBusyAction(async () =>
            {
                // The button change WasFavorited's value first and so call this event
                if (WasFavorited)
                    await favoriteService.Add(HeroObj);
                else
                    await favoriteService.Delete(HeroObj);

                // Refeshing the button
                await LoadIsFavorited();
            });
        }
    }
}
