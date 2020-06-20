using System.Threading.Tasks;
using DomainApiServiceTMDb.Core;

namespace DomainApiServiceTMDb.Interfaces
{
    public interface IGenresApiService
    {
        Task<GenresResults> GetMovieGenres();
    }
}
