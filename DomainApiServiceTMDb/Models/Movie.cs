using System;
using System.Collections.Generic;
using DomainApiServiceTMDb.Helpers;
using Newtonsoft.Json;

namespace DomainApiServiceTMDb.Models
{
    public class Movie
    {
        public int Id { get; set; }

        private string _posterPath;

        [JsonProperty("Poster_Path")]
        public string PosterPath
        {
            get => String.Concat(Constantes.ImageUrlBase, _posterPath);
            set => _posterPath = value;
        }

        public Boolean Adult { get; set; }

        [JsonProperty("Vote_Average")]
        public string VoteAverage { get; set; }

        public string Overview { get; set; }

        [JsonProperty("Release_Date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        public string OriginalTitle { get; set; }

        public string Title { get; set; }

        [JsonProperty("genre_ids")]
        public IEnumerable<int> Genres { get; set; }
    }
}
