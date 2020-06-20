using System;
using Refit;

namespace DomainApiServiceTMDb.Models
{
    public class Genres
    {
        [AliasAs("id")]
        public int Id { get; set; }

        [AliasAs("name")]
        public string Name { get; set; }
    }
}
