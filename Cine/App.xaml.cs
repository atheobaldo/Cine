using System;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
//using Cine.ViewModels;
//using Cine.Views;
using Xamarin.Forms;
using DomainApiServiceTMDb.Interfaces;
using DomainApiServiceTMDb.Services;
using Cine.Views;
using Cine.ViewModels;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;

namespace Cine
{
    public partial class App : PrismApplication
    {
        public App() : this(null)
        {

        }

        public App(IPlatformInitializer initializer) : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterSingleton<IMoviesApiService, MoviesApiService>();
            containerRegistry.RegisterSingleton<IGenresApiService, GenresApiService>();
            //containerRegistry.RegisterSingleton<MovieDetailsPopupPage, MovieDetailsPopupPageViewModel>();
            containerRegistry.RegisterInstance<IPopupNavigation>(PopupNavigation.Instance);
        }

    }
}
