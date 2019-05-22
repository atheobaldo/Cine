using System;
using System.Collections.Generic;
using DomainApiServiceTMDb.Models;
using Refit;

namespace DomainApiServiceTMDb.Core
{

    public class GenresResults : BaseResults<Genres>
    {
        [AliasAs("genres")]
        public List<Genres> genres { get; set; }

        public override IList<Genres> results { get; set; }

    }

}
