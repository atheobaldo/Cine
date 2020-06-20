using System.Threading.Tasks;
using DomainApiServiceTMDb.Core;
using Refit;

namespace DomainApiServiceTMDb.Interfaces
{
    public interface IGenresRoute
    {
        [Get("/genre/movie/list")]
        Task<GenresResults> GetMovieGenres([AliasAs("api_key")] string apiKey);
    }

}

