using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDbAPICaller.Domain
{
    public class Movie
    {
        //Dates
        public DateTime Released { get; set; } = DateTime.MinValue;

        //decimals
        public decimal Rate { get; set; } = 0m;
        public decimal imdbRating { get; set; } = 0m;
        public decimal imdbVotes { get; set; } = 0m;
        public decimal BoxOffice { get; set; } = 0m;
        public decimal Runtime { get; set; } = 0m;  //in minutes
        public decimal Year { get; set; } = 0m;

        // strings
        public string Title { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Plot { get; set; } = string.Empty;
        public string Awards { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
            
        //lists
        public List<string> Actors { get; set; } = new List<string>();
        public List<string> Directors { get; set; } = new List<string>();
        public List<string> Countries { get; set; } = new List<string>();
        public List<string> Genres { get; set; } = new List<string>();
        public List<string> Languages { get; set; } = new List<string>();
    }
}
