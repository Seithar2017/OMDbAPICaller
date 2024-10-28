using Newtonsoft.Json.Linq;
using OMDbAPICaller.Domain;
using OMDbAPICaller.Infrastructure.DTOs;
using System.Globalization;
public class MovieMapper
{
    public Movie MapFromDTO(OmdbMovieDTO dto)
    {
        var movie = new Movie();
        movie.Title = dto.Title;
        movie.Plot = dto.Plot;
        movie.Awards = dto.Awards;
        movie.Type = dto.Type;
        if (DateTime.TryParseExact(dto.Released, "dd MMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releasedDate))
        {
            movie.Released = releasedDate;
        }
        movie.RuntimeMinutes = ParseStringToNullableInt(dto.Runtime);
        movie.Year = ParseStringToNonNullableInt(dto.Year);
        movie.ImdbRating = ParseStringToNullableDouble(dto.ImdbRating);
        movie.ImdbVotes = ParseStringToNullableDouble(dto.ImdbVotes);
        movie.BoxOffice = ParseStringToNullableDouble(dto.BoxOffice); 
        movie.Actors = dto.Actors.Split(", ").ToList();
        movie.Directors = dto.Director.Split(", ").ToList();
        movie.Countries = dto.Country.Split(", ").ToList();
        movie.Genres = dto.Genre.Split(", ").ToList();
        movie.Languages = dto.Language.Split(", ").ToList();
        return movie;
    }
    private decimal TryParseDecimal(string input)
    {
        return decimal.TryParse(input, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal result)
            ? result
            : 0;
    }
    private double? ParseStringToNullableDouble(string value)
    {
        return double.TryParse(value, out double parsedValue) ? (double?)parsedValue : null;
    }
    private int ParseStringToNonNullableInt(string value)
    {
        if (int.TryParse(value, out int parsedValue))
        {
            return parsedValue;
        }
        else
        {
            throw new ArgumentException("The provided value is not a valid integer.");
        }
    }
    private int? ParseStringToNullableInt(string value)
    {
        return int.TryParse(value, out int parsedValue) ? (int?)parsedValue : null;
    }
    private decimal TryParseBoxOffice(string boxOffice)
    {
        if (!string.IsNullOrEmpty(boxOffice) && boxOffice.StartsWith("$"))
        {
            // Usuwa symbol dolara i przecinki
            boxOffice = boxOffice.Replace("$", "").Replace(",", "");
            return TryParseDecimal(boxOffice);
        }
        return 0;
    }
    private decimal TryParseRuntime(string runtime)
    {
        if (!string.IsNullOrEmpty(runtime) && runtime.EndsWith(" min"))
        {
            runtime = runtime.Replace(" min", "");
            return TryParseDecimal(runtime);
        }
        return 0;
    }
}
