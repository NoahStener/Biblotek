using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace MinimalAPI.Models.DTOs
{
    public class BookDTO
    {
        public int BookID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }
        public int YearOfRelease { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool IsAvaliable { get; set; } = true;
    }
}
