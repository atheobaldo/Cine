using System.Threading.Tasks;
using DomainApiServiceTMDb.Core;
using Refit;

namespace DomainApiServiceTMDb.Interfaces
{
    public interface IMovieRoute
    {
        [Get("/movie/upcoming")]
        Task<MovieResults> GetUpcomingMovies(int page, [AliasAs("api_key")] string apiKey);
    }
}
