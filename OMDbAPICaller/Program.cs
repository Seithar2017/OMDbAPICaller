using OMDbAPICaller.Infrastructure;
using OMDbAPICaller.Presenters;

namespace OMDbAPICaller
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var movieFetcher = new MovieFetcher(httpClient);

            // Pobieramy film po tytule
            Console.WriteLine("Podaj tytuł filmu:");
            string ?title = Console.ReadLine();

            try
            {
                var movie = await movieFetcher.GetMovieByTitleAsync(title);
                MoviePresenter.DisplayMovieDetails(movie);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
