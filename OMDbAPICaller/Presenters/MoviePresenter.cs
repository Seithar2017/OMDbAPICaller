using OMDbAPICaller.Domain;
using Spectre.Console;

namespace OMDbAPICaller.Presenters
{
    public static class MoviePresenter
    {
        public static void DisplayMovieDetails(Movie movie)
        {
            var table = new Table();

            //  Add Columns
            table.AddColumn("Attribute");
            table.AddColumn("Value");

            // Add Rows
            table.AddRow("Title", movie.Title);
            table.AddRow("Year", movie.Year.ToString());
            table.AddRow("Released", movie.Released.ToString("dd MMM yyyy"));
            table.AddRow("Runtime", $"{movie.Runtime} minutes");
            table.AddRow("IMDB Rating", $"{movie.imdbRating}/10 ({movie.imdbVotes} votes)");
            table.AddRow("Box Office", $"${movie.BoxOffice:N0}");
            table.AddRow("Language", movie.Language);
            table.AddRow("Genres", string.Join(", ", movie.Genres));
            table.AddRow("Directors", string.Join(", ", movie.Directors));
            table.AddRow("Actors", string.Join(", ", movie.Actors));
            table.AddRow("Countries", string.Join(", ", movie.Countries));
            table.AddRow("Languages", string.Join(", ", movie.Languages));
            table.AddRow("Awards", movie.Awards);

            
            AnsiConsole.Write(table);
        }
    }
}
