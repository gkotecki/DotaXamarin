using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;
using XamarinUP2018.Repositories;
using XamarinUP2018.Services;
using XamarinUP2018.ViewModels;
using XamarinUP2018.Views;

namespace XamarinUP2018
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(OnBoardingPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILocalDataBaseRepository, LocalDataBaseRepository>();
            containerRegistry.Register<IHeroService, HeroService>();
            containerRegistry.Register<IFavoriteService, FavoriteService>();

            containerRegistry.RegisterForNavigation<NavigationPage>(nameof(NavigationPage));
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>(nameof(HomePage));
            containerRegistry.RegisterForNavigation<OnBoardingPage, OnBoardingViewModel>(nameof(OnBoardingPage));
            containerRegistry.RegisterForNavigation<FeedPage, FeedViewModel>(nameof(FeedPage));
            containerRegistry.RegisterForNavigation<PicturePage, HeroViewModel>(nameof(PicturePage));
            containerRegistry.RegisterForNavigation<FavoritePage, FavoriteViewModel>(nameof(FavoritePage));
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
