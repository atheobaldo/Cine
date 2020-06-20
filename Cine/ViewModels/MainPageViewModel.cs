using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Cine.Views;
using DomainApiServiceTMDb.Core;
using DomainApiServiceTMDb.Interfaces;
using DomainApiServiceTMDb.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup.Contracts;
using Xamarin.Forms.Extended;

namespace Cine.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<Movie> _moviesItens;
        public  ObservableCollection<Movie> MoviesItens
        {
            get { return _moviesItens; }
            set { SetProperty(ref _moviesItens, value); }
        }


        public GenresResults _genres;
        public GenresResults Genres
        {
            get => _genres;
            set => _genres = value;
        }

        public InfiniteScrollCollection<Movie> _movies;
        public InfiniteScrollCollection<Movie> Movies
        {
            get => _movies;
            set => _movies = value;
        }

        private int pageCount = 1;

        private string _searchText = string.Empty;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        private readonly IMoviesApiService _moviesApiService;
        private readonly IGenresApiService _genresApiService;
        private readonly IPopupNavigation _popupNavigation;


        public ICommand MovieItemSelectedCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand TextChangedCommand { get; set; }

        public MainPageViewModel(
                INavigationService navigationService,
                IPageDialogService pageDialogService,
                IMoviesApiService moviesApiService,
                IGenresApiService genresApiService,
                IPopupNavigation popupNavigation
            ) : base(navigationService, pageDialogService)
        {
            _moviesApiService = moviesApiService;
            _genresApiService = genresApiService;
            _popupNavigation = popupNavigation;

            MovieItemSelectedCommand = new DelegateCommand<Movie>(ShowDetailedMovie);
            SearchCommand = new DelegateCommand(DoSearchCommandAsync);
            TextChangedCommand = new DelegateCommand(OnTextChanged);

            Title = "Cine";
            MoviesItens = new ObservableCollection<Movie>();

            LoadDataMovies();
            LoadDataGenres();
        }

        private void DoSearchCommandAsync()
        {
            Movies.Clear();
            pageCount = 0;
            Movies.LoadMoreAsync();
        }

        private void OnTextChanged()
        {
            if (SearchText == string.Empty)
                DoSearchCommandAsync();
        }

        private async void ShowDetailedMovie(Movie movie)
        {
            var genres = GetGenres(movie);
            await _popupNavigation.PushAsync(new MovieDetailsPopupPage(movie, genres));
        }

        private string GetGenres(Movie movie) 
        {
            var genres = "";
            foreach (var item in movie.Genres)
            {
                if (genres != string.Empty) genres += " / ";
                genres += Genres.genres.FirstOrDefault(a => a.Id == item).Name;
            }

            return genres;
        }

        private async Task LoadDataGenres()
        {
            Genres = await _genresApiService.GetMovieGenres();
        }

        private async Task LoadDataMovies()
        {
            Movies = new InfiniteScrollCollection<Movie>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;
                    pageCount += 1;
                    var items = await GetMovies();
                    IsBusy = false;
                    return items.results;
                }
            };

            await DownloadDataAsync();

        }

        private async Task DownloadDataAsync()
        { 
            var movies = await GetMovies();
            if (movies.results != null) Movies.AddRange(movies.results);
        }

        private async Task<MovieResults> GetMovies()
        {
            if(SearchText == string.Empty)
                return await _moviesApiService.GetUpcommingMovies(pageCount);

            return await _moviesApiService.SearchMovies(pageCount, SearchText);
        }

    }
}
