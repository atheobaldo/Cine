using DomainApiServiceTMDb.Services;
using NUnit.Framework;
using System;
namespace Tests
{
    [TestFixture()]
    public class TestDomainServiceMovie
    {
        [Test()]
        public async System.Threading.Tasks.Task TestGetMovieGenresAsync()
        {
            GenresApiService _genresApiService = new GenresApiService();
            var items = await _genresApiService.GetMovieGenres();
            Assert.IsTrue(items.genres.Count > 1);
        }

        [Test()]
        public async System.Threading.Tasks.Task TestGetUpcomingMoviesAsync()
        {
            MoviesApiService _moviesApiService = new MoviesApiService();
 
            var items = await _moviesApiService.GetUpcommingMovies(1);
            Assert.IsTrue(items.results.Count > 1);
        }
    }
}
