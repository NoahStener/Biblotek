namespace MinimalAPI.Models.DTOs
{
    public class BookCreateDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearOfRelease { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
    }
}
