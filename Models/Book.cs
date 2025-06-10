using System.ComponentModel.DataAnnotations;

namespace BookLibraryExam.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(50, ErrorMessage = "Author can't be longer than 50 characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [RegularExpression(@"\d{13}", ErrorMessage = "ISBN must be exactly 13 digits")]
        public string ISBN { get; set; }

        [Range(1500, 2100, ErrorMessage = "Publication year must be between 1500 and 2100")]
        public int PublicationYear { get; set; }
    }
}
