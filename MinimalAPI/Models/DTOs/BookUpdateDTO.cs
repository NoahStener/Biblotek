using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Models.DTOs
{
    public class BookUpdateDTO
    {
        public int BookID { get; set; }
        
        public string Title { get; set; }
        
        public string Author { get; set; }
        public int YearOfRelease { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool IsAvaliable { get; set; }
    }
}
