using System.Collections.Generic;
using Newtonsoft.Json;

namespace DomainApiServiceTMDb.Core
{
    public abstract class BaseResults<T>
    {
        public abstract IList<T> results { get; set; }

        [JsonProperty("status_message")]
        public string statusMessage { get; set; }

        [JsonProperty("status_code")]
        public int statusCode { get; set; }
    }
}
