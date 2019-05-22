using System;
using System.Threading.Tasks;
using DomainApiServiceTMDb.Core;
using DomainApiServiceTMDb.Helpers;
using DomainApiServiceTMDb.Interfaces;

namespace DomainApiServiceTMDb.Services
{
    public class MoviesApiService : ConfigService<IMovieRoute>, IMoviesApiService
    {
        private IMovieRoute moviesRoutes;

        public async Task<MovieResults> GetUpcommingMovies(int page)
        {
            moviesRoutes = returnConfigurationService();

            try
            {
                var result = await moviesRoutes.GetUpcomingMovies(page, Constantes.Apikey);

                return result;

            }
            catch (Exception ex)
            {
                var result = new MovieResults();
                result.statusCode = 500;
                result.statusMessage = $"Aconteceu um erro com a sua solicitação: {ex.Message}";
                return result;
            }


        }

    }
}
