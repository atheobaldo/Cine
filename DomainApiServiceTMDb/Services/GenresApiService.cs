using System;
using System.Threading.Tasks;
using DomainApiServiceTMDb.Core;
using DomainApiServiceTMDb.Helpers;
using DomainApiServiceTMDb.Interfaces;

namespace DomainApiServiceTMDb.Services
{
    public class GenresApiService : ConfigService<IGenresRoute>, IGenresApiService
    {
        IGenresRoute genresRoutes;


        public async Task<GenresResults> GetMovieGenres()
        {
            genresRoutes = returnConfigurationService();


            try
            {
                var result = await genresRoutes.GetMovieGenres(Constantes.Apikey);

                return result;

            }
            catch (Exception ex)
            {
                var result = new GenresResults();
                result.statusCode = 500;
                result.statusMessage = $"Aconteceu um erro com a sua solicitação: {ex.Message}";
                return result;
            }
        }

    }
}
