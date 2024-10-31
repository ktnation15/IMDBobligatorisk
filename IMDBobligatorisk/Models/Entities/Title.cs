using System.ComponentModel.DataAnnotations;

namespace IMDBobligatorisk.Models.Entities
{
    public class Title
    {
        [Key]
        public string? Tconst { get; set; }
        public string? TitleType { get; set; }
        public string? PrimaryTitle { get; set; }
        public string? OriginalTitle { get; set; }
        public bool? IsAdult { get; set; } // Assuming IsAdult is stored as a boolean
        public int? StartYear { get; set; } // Assuming years are integers
        public int? EndYear { get; set; } // Nullable for movies with no end year
        public int? RuntimeMinutes { get; set; } // Nullable if runtime is unknown
        public string? Genres { get; set; }
    }
}
