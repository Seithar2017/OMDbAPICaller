using OMDbAPICaller.Domain;
using OMDbAPICaller.Infrastructure.DTOs;
using System;
using System.Globalization;
using System.Linq;

public class MovieMapper
{
    public Movie MapFromDTO(OmdbMovieDTO dto)
    {
        var movie = new Movie();

        // Mapping simple properties
        movie.Title = dto.Title;
        movie.Plot = dto.Plot;
        movie.Awards = dto.Awards;
        movie.Type = dto.Type;

        // DateTime mapping
        if (DateTime.TryParseExact(dto.Released, "dd MMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releasedDate))
        {
            movie.Released = releasedDate;
        }

        // String to Decimal mapping
        movie.imdbRating = TryParseDecimal(dto.imdbRating);
        movie.imdbVotes = TryParseDecimal(dto.imdbVotes);
        movie.BoxOffice = TryParseBoxOffice(dto.BoxOffice);
        movie.Runtime = TryParseRuntime(dto.Runtime);
        movie.Year = TryParseDecimal(dto.Year);

        //String to List mapping
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
