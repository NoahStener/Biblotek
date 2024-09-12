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
        [Required(ErrorMessage = "Year of Release is required")]
        public int YearOfRelease { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public bool IsAvaliable { get; set; } = true;
    }
}
