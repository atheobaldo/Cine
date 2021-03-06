﻿using System.Threading.Tasks;
using DomainApiServiceTMDb.Core;

namespace DomainApiServiceTMDb.Interfaces
{
    public interface IMoviesApiService
    {
        Task<MovieResults> GetUpcommingMovies(int page);
        Task<MovieResults> SearchMovies(int page, string query);
    }
}


