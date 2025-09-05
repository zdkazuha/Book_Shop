using System.ComponentModel.DataAnnotations;

namespace Book_Shop.Data.Entities
{
    public class Genre
    {
        public Genre()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }

        [Required]
        public string GenreName { get; set; }

        // Navigation property

        public ICollection<Book> Books { get; set; }
    }
}
