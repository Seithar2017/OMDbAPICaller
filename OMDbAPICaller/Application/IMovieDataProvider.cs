using OMDbAPICaller.Domain;
namespace OMDbAPICaller.Application
{
    internal interface IMovieDataProvider
    {
        Task<Movie> GetMovieByTitleAsync(string title);
    }
}