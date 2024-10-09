using OMDbAPICaller.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDbAPICaller.Application
{
    internal interface IMovieDataProvider
    {
        Task<Movie> GetMovieByTitleAsync(string title);
    }
}
