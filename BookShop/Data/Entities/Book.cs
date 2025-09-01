
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Book_Shop.Data.Entities
{
    public class Book
    {
        public Book() {}

        public int Id { get; set; }

        public string ImageUrl { get; set; }

        [Required, MinLength(3), MaxLength(50), RegularExpression("^[A-Z].*")]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public int NumberOfPages { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Price { get; set; }

        [Required, MinLength(10), MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public int? TrilogiesId { get; set; }

        // Navigation property

        public Trilogies? Trilogies { get; set; }
        public Author Author { get; set; }
    }
}

