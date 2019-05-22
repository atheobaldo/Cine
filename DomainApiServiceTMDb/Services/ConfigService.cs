using DomainApiServiceTMDb.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace DomainApiServiceTMDb.Services
{

    public class ConfigService<T>
    {
        protected T returnConfigurationService()
        {
            return RestService.For<T>(Constantes.UrlBase,
                new RefitSettings
                {
                    ContentSerializer = new JsonContentSerializer(
                        new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }
                    )
                }
            );
        }
    }
}


