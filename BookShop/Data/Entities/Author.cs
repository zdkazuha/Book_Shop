using System.ComponentModel.DataAnnotations;

namespace Book_Shop.Data.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        // Navigation property

        public ICollection<Book> Books { get; set; }
    }
}
