using Cine.ViewModels;
using DomainApiServiceTMDb.Models;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace Cine.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailsPopupPage : PopupPage
    {
        public MovieDetailsPopupPageViewModel ViewModel
        {
            get
            {
                return (MovieDetailsPopupPageViewModel)BindingContext;
            }
        }

        public MovieDetailsPopupPage(Movie movie, string genres)
        {
            InitializeComponent();
            ViewModel.Movies = movie;
            ViewModel.Genres = genres;
        }

        private async void OnClosePopupPage(object sender, System.EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}
