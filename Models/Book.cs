using System.ComponentModel.DataAnnotations;

namespace BookLibraryExam.Models
{
    public class Book
    {
        public class Book
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Title is required")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Author is required")]
            public string Author { get; set; }

            [Required(ErrorMessage = "ISBN is required")]
            [RegularExpression(@"^\d{10}(\d{3})?$", ErrorMessage = "Invalid ISBN format")]
            public string ISBN { get; set; }

            [Required(ErrorMessage = "Publication year is required")]
            [Range(1000, 9999, ErrorMessage = "Year must be between 1000 and 9999")]
            public int PublicationYear { get; set; }
        }
    }
