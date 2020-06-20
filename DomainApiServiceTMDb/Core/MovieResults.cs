using System;
using System.Collections.Generic;
using DomainApiServiceTMDb.Models;
using Newtonsoft.Json;

namespace DomainApiServiceTMDb.Core
{

    public class MovieResults : BaseResults<Movie>
    {

        public override IList<Movie> results { get; set; }

        public int Page { get; set; }
        [JsonProperty("total_results")]

        public int TotalResults { get; set; }
        [JsonProperty("total_pages")]

        public int TotalPages { get; set; }

    }

}
