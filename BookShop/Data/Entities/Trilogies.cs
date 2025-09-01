using System.ComponentModel.DataAnnotations;

namespace Book_Shop.Data.Entities
{
    public class Trilogies
    {
        public Trilogies()
        {
            Books = new List<Book>();
        }

        public int Id { get; set; }

        [Required]
        public string NameTrilogie { get; set; }

        public ICollection<Book> Books { get; set; }
    }

}
