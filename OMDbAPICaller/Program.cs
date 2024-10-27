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
            string exitCommand = "!exit";

            string? title = string.Empty;
            do
            {
                if (!String.IsNullOrEmpty(title))
                {
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
                Console.WriteLine("Provide a movie's title:");
                title = Console.ReadLine();
            }
            while (title != exitCommand);
        }
    }
}
