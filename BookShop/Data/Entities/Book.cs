
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Book_Shop.Data.Entities
{
    public class Book
    {
        public Book() {}

        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int NumberOfPages { get; set; }

        public int Year { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }

        public int? TrilogiesId { get; set; }

        // Navigation property

        public Trilogies? Trilogies { get; set; }
        public Author Author { get; set; }
    }
}

