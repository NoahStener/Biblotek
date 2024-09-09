using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        public int YearOfRelease { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool IsAvaliable { get; set; } = true;
    }
}
