using Newtonsoft.Json;
using OMDbAPICaller.Application;
using OMDbAPICaller.Domain;
using OMDbAPICaller.Infrastructure.DTOs;

namespace OMDbAPICaller.Infrastructure
{
    internal class MovieFetcher : IMovieDataProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "d982b40a";
        public MovieFetcher(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("title cannot be null or empty.");

            var response = await _httpClient.GetAsync($"http://www.omdbapi.com/?t={title}&apikey={_apiKey}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var omdbMovieDto = JsonConvert.DeserializeObject<OmdbMovieDTO>(json);
                if (omdbMovieDto == null)
                {
                    throw new Exception("Deserialization failed, movie data is null.");
                }
                else if(omdbMovieDto.Response == "False")
                {
                    throw new Exception(omdbMovieDto.Error);
                }
                var movieMapper = new MovieMapper();
                var movie = movieMapper.MapFromDTO(omdbMovieDto);
                return movie;
            }
            else
            {
                throw new Exception("Failed to retrieve movie data.");
            }
        }
    }
}
