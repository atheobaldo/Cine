using DomainApiServiceTMDb.Models;
using Prism.Navigation;
using Prism.Services;

namespace Cine.ViewModels
{
    public class MovieDetailsPopupPageViewModel : ViewModelBase
    {
        public MovieDetailsPopupPageViewModel(
                INavigationService navigationService,
                IPageDialogService pageDialogService
            ) : base(navigationService, pageDialogService)
        {

        }

        private Movie _movie;
        public Movie Movies
        {
            get { return _movie; }
            set { SetProperty(ref _movie, value); }
        }

        private string _genres;
        public string Genres
        {
            get { return _genres; }
            set { SetProperty(ref _genres, value); }
        }

    }
}
