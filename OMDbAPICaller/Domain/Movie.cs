namespace OMDbAPICaller.Domain
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public DateTime? Released { get; set; }
        public double? Rate { get; set; }
        public string? Description { get; set; }
        public double? ImdbRating { get; set; }
        public double? ImdbVotes { get; set; }
        public double? BoxOffice { get; set; }
        public int? RuntimeMinutes { get; set; }
        public string? Language { get; set; }
        public string? Plot { get; set; }
        public string? Awards { get; set; }
        public string? Type { get; set; }
        public List<string> Actors { get; set; } = new List<string>();
        public List<string> Directors { get; set; } = new List<string>();
        public List<string> Countries { get; set; } = new List<string>();
        public List<string> Genres { get; set; } = new List<string>();
        public List<string> Languages { get; set; } = new List<string>();
    }
}
