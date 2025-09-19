namespace Book_Shop.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice{ get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
