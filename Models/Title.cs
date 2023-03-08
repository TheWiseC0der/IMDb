namespace IMDb.Models
{
    public class Title
    {
        public string TitleID { get; set; }
        public string titleType { get; set; }
        public string primaryTitle { get; set; }
        public bool isAdult { get; set; }
        public int startYear { get; set; }
        public int runtimeMinutes { get; set; }

    }
}
