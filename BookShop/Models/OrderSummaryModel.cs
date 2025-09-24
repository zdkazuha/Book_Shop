using Book_Shop.Data.Entities;

namespace Book_Shop.Models
{
    public class OrderSummaryModel
    {
        public string UserName { get; set; }
        public int OrderNumber { get; set; }
        public double TotalPrice { get; set; }
        public int ItemsCount { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
