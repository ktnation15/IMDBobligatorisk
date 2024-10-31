namespace IMDBobligatorisk.Models
{
    public class AddIMDBViewModel
    {
        public string Tconst { get; set; }
        public string TitleType { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; } // Ensure this is non-nullable
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public int? RuntimeMinutes { get; set; }
        public string Genres { get; set; }
    }
}
