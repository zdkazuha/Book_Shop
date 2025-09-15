using Book_Shop.Data.Entities;

namespace Book_Shop.Interfaces
{
    public interface ICartService
    {
        int GetCartSize();

        void Add(int id);

        void Remove(int id);
        void Clear();

        List<Book> GetBooks();

        bool IsInCart(int id);
    }

}
