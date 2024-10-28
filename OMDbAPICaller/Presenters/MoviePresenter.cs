using OMDbAPICaller.Domain;
using OMDbAPICaller.Presenters.Validators;
using Spectre.Console;

namespace OMDbAPICaller.Presenters
{
    public static class MoviePresenter
    {
        public static void DisplayMovieDetails(Movie movie)
        {
            var table = new Table();
            table.AddColumn("Attribute");
            table.AddColumn("Value");
            movie.Title.CheckAndExecute(() => table.AddRow("Title", movie.Title));
            movie.Year.CheckAndExecute(() => table.AddRow("Year", movie.Year.ToString()));
            movie.Released.CheckAndExecute(() => table.AddRow("Released", movie.Released.Value.ToString("dd MMM yyyy")));
            movie.RuntimeMinutes.CheckAndExecute(() => table.AddRow("Runtime", $"{movie.RuntimeMinutes} minutes"));
            movie.ImdbRating.CheckAndExecute(() => table.AddRow("IMDB Rating", $"{movie.ImdbRating}/10 ({movie.ImdbVotes} votes)"));
            movie.BoxOffice.CheckAndExecute(() => table.AddRow("Box Office", $"${movie.BoxOffice:N0}"));
            movie.Language.CheckAndExecute(() => table.AddRow("Language", movie.Language));
            movie.Genres.CheckAndExecute(() => table.AddRow("Genres", string.Join(", ", movie.Genres)));
            movie.Directors.CheckAndExecute(() => table.AddRow("Directors", string.Join(", ", movie.Directors)));
            movie.Actors.CheckAndExecute(() => table.AddRow("Actors", string.Join(", ", movie.Actors)));
            movie.Countries.CheckAndExecute(() => table.AddRow("Countries", string.Join(", ", movie.Countries)));
            movie.Languages.CheckAndExecute(() => table.AddRow("Languages", string.Join(", ", movie.Languages)));
            movie.Awards.CheckAndExecute(() => table.AddRow("Awards", movie.Awards));
            AnsiConsole.Write(table);
        }
    }
}
